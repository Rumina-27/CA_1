
import requests
from bs4 import BeautifulSoup
import json
import csv
import re

# Wikipedia page
url = "https://en.wikipedia.org/wiki/List_of_Dublin_postal_districts"

# Step 1: Download the webpage
response = requests.get(
    url,
    headers={"User-Agent": "DublinPostalDistrictStudentProject/1.0"},
    timeout=20
)
response.raise_for_status()

soup = BeautifulSoup(response.text, "html.parser")

# Step 2: Extract postal district information
districts = []

for heading in soup.find_all(["h2", "h3"]):
    heading_text = heading.get_text(" ", strip=True)

    match = re.match(r"^Dublin\s+(\d+|6\s+West)\s*(?:\((D\d+W?)\))?$",
                     heading_text)

    if not match:
        continue

    district_number = match.group(1)
    district_name = "Dublin " + district_number
    district_code = match.group(2)

    if not district_code:
        district_code = "D6W" if district_number == "6 West" else "D" + district_number

    areas = ""

    # Find the paragraph describing the district
    for element in heading.find_all_next():
        if element.name in ["h2", "h3"]:
            break

        if element.name == "p":
            paragraph = element.get_text(" ", strip=True)

            if "includes" in paragraph.lower():
                area_match = re.search(
                    r"\bincludes?\s+(.*?)(?:\.|$)",
                    paragraph,
                    re.IGNORECASE
                )

                if area_match:
                    areas = area_match.group(1).strip()
                    break

    if areas:
        districts.append({
            "postal_district": district_name,
            "district_code": district_code,
            "areas": areas
        })

# Step 3: Save information into JSON
with open("dublin_postal_districts.json", "w", encoding="utf-8") as file:
    json.dump(districts, file, indent=4, ensure_ascii=False)

print("Data successfully saved to JSON file.")

# Step 4: Read JSON data
with open("dublin_postal_districts.json", "r", encoding="utf-8") as file:
    data = json.load(file)

# Step 5: Save JSON data into CSV
with open("dublin_postal_districts.csv", "w", newline="", encoding="utf-8") as file:
    fieldnames = ["postal_district", "district_code", "areas"]

    writer = csv.DictWriter(file, fieldnames=fieldnames)
    writer.writeheader()
    writer.writerows(data)

print("Data successfully converted into CSV file.")

# Step 6: Read and display CSV data
print("\n===== DUBLIN POSTAL DISTRICTS =====")

with open("dublin_postal_districts.csv", "r", encoding="utf-8") as file:
    reader = csv.DictReader(file)

    for row in reader:
        print("\nPostal District:", row["postal_district"])
        print("District Code:", row["district_code"])
        print("Areas:", row["areas"])

print("\nTotal districts extracted:", len(data))
