
import socket
import json


def register_member():
    print("\n===== LIBRARY MEMBERSHIP REGISTRATION =====")

    full_name = input("Enter full name: ")
    address = input("Enter address: ")
    phone = input("Enter phone number: ")
    email = input("Enter email address: ")

    while True:
        try:
            membership_duration = int(
                input("Enter membership duration (6 or 12 months): ")
            )

            if membership_duration in [6, 12]:
                break

            print("Please enter either 6 or 12.")

        except ValueError:
            print("Please enter a valid number.")

    registration_data = {
        "full_name": full_name,
        "address": address,
        "phone": phone,
        "email": email,
        "membership_duration": membership_duration
    }

    try:
        client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        client.connect(("127.0.0.1", 5000))

        client.sendall(json.dumps(registration_data).encode("utf-8"))

        response = client.recv(4096).decode("utf-8")
        result = json.loads(response)

        print("\n===== SERVER RESPONSE =====")
        print(result["message"])

        if result["success"]:
            print("Registration Number:", result["registration_id"])

        client.close()

    except ConnectionRefusedError:
        print("Could not connect to the library server.")

    except Exception as error:
        print("Error:", error)


if __name__ == "__main__":
    register_member()