# Entity-CodeFirst
It's API using EntityFrameWork for database managment.

Data Structure
----
![image](https://github.com/KaluxikS/Entity-CodeFirst/assets/128908183/cdec114c-bf2e-47ac-91f9-1a11dd96b79b)

Project structure
----
Project is devided for files like:
- Config (Configuration classes for each entity.)
- Controllers (Ccontrollers that handle HTTP requests coming to the API. Each controller contains actions (methods) responsible for handling specific requests. Controllers communicate with the service layer, fetch or process data, and return HTTP responses to the client.)
- DTOs (Data Transfer Object, which are used to transfer data between the client and the server, simplified versions of entities)
- Entities (Classes representing the data structure in the database)
- Migrations (Database migration files. Migrations are used to create, modify, and update the database structure based on entity definitions and configurations.)
- Service (Service classes that contain the business logic of the application.)

Endpoints
----
Doctors:
- GET /api/hospital/doctors - Retrieves a list of all doctors.
- POST /api/hospital/doctors - Creates a new doctor based on the provided data in the request body.
- PUT /api/hospital/doctors/{id} - Updates the doctor with the specified ID using the data provided in the request body.
- DELETE /api/hospital/doctors/{id} - Deletes the doctor with the specified ID.

Prescriptions:
- GET /api/hospital/prescriptions/{id} - Retrieves the prescription with the specified ID, including the personal data of the patient, doctor, and the list of medications.
