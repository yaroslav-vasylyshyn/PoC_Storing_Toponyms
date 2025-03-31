Overview:
PoCStoringToponyms is a proof-of-concept (PoC) project demonstrating how to store Toponym data in MongoDB. It features a repository pattern to abstract data access, and includes a simple example of converting a list of Toponyms into JSON and saving them both in the database and as a .json file.

Prerequisites:
.NET 7 SDK (or later)
MongoDB
Option 1: Install MongoDB locally.
Option 2: Use Docker and run the MongoDB container:
MongoDB.Driver NuGet Package
Newtonsoft.Json NuGet Package

Setup:
Clone the Repository, if you haven’t already done so:
git clone <repo-url>
cd PoCStoringToponyms
Restore Dependencies:
Make sure you’re in the project’s root directory, then run:
dotnet restore
Verify MongoDB is Installed and Running:
Local Installation: Ensure the MongoDB service is started.
Docker:
docker pull mongo:latest
docker run -d --name mongodb -p 27017:27017 mongo:latest
Check if the container is running with:
docker ps
You should see the mongodb container running.
Build & Run the Project:
dotnet build
dotnet run

As a result it will:
Connect to the MongoDB instance at mongodb://localhost:27017.
Insert sample Toponym data into the ToponymsDb database.
Save a JSON file (toponyms.json) with the same sample data.

Considerations for a Real-World Project:
Configuration & Environment Separation
    appsettings.json: Move the MongoDB connection string and database name out of hard-coded strings into configuration. For instance, store them in appsettings.Development.json or environment variables
Dependency Injection (DI)
    Register the MongoDB client and your repository in the DI container in Program.cs. 