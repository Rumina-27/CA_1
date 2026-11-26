
import socket
import json
import psycopg2
import re

# Database connection
def connect_database():
    return psycopg2.connect(
        dbname="library_db",
        user="rumina",
        host="localhost",
        port="5432"
    )


# Validate registration details
def validate_details(data):
    required_fields = [
        "full_name", "address", "phone",
        "email", "membership_duration"
    ]

    for field in required_fields:
        if field not in data or not str(data[field]).strip():
            return False, f"{field} is required."

    if not re.fullmatch(r"[^@\s]+@[^@\s]+\.[^@\s]+", data["email"]):
        return False, "Invalid email address."

    if data["membership_duration"] not in [6, 12]:
        return False, "Membership must be 6 or 12 months."

    return True, "Valid details."


# Save registration in PostgreSQL
def save_registration(data):
    connection = connect_database()
    cursor = connection.cursor()

    try:
        query = """
            INSERT INTO registrations
            (full_name, address, phone, email, membership_duration)
            VALUES (%s, %s, %s, %s, %s)
            RETURNING registration_id;
        """

        cursor.execute(query, (
            data["full_name"],
            data["address"],
            data["phone"],
            data["email"],
            data["membership_duration"]
        ))

        registration_id = cursor.fetchone()[0]
        connection.commit()

        return registration_id

    finally:
        cursor.close()
        connection.close()


# Start TCP server
def start_server():
    host = "127.0.0.1"
    port = 5000

    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server.bind((host, port))
    server.listen(5)

    print(f"Library server listening on {host}:{port}")

    while True:
        client_socket, client_address = server.accept()

        with client_socket:
            print("Connected by:", client_address)

            try:
                received_data = client_socket.recv(4096).decode("utf-8")
                data = json.loads(received_data)

                valid, message = validate_details(data)

                if not valid:
                    response = {"success": False, "message": message}
                else:
                    registration_id = save_registration(data)

                    response = {
                        "success": True,
                        "message": "Registration successful!",
                        "registration_id": registration_id
                    }

            except psycopg2.errors.UniqueViolation:
                response = {
                    "success": False,
                    "message": "This email is already registered."
                }

            except Exception as error:
                response = {
                    "success": False,
                    "message": str(error)
                }

            client_socket.sendall(
                json.dumps(response).encode("utf-8")
            )

            print("Response sent:", response)


if __name__ == "__main__":
    start_server()
