# Animal Shelter API

#### By Molly Donegan

#### _An API that allows users to create, read, update and delete posts about various animals at the shelter._

## Technologies Used

* _C#/.NET_
* _SQL Workbench_
* _MVC_
* _Entity Framework_
* _Identity_
* _Swagger_

## Description

An API that allows users to create, read, update and delete posts about various animals at the shelter.

There are custom endpoints for some of these user stories.

* A user can GET and POST information about adoptable animals.

* A user can PUT and DELETE animals.

* A user can access the API endpoint with a query parameter that specifies the page that should be returned.

## Setup/Installation Requirements
_Requires console application such as Git Bash, Terminal, or PowerShell_

1. Open Git Bash or PowerShell if on Windows and Terminal if on Mac
2. Run the command

    ``git clone https://github.com/mdonegan91/ShelterApi.Solution``

3. Run the command

    ``cd ShelterApi``

* You should now have a folder `ShelterApi` with the following structure.
    <pre>ShelterApi
    ├── .gitignore 
    ├── ... 
    └── ShelterApi
        ├── Controllers
        ├── Models
        ├── ...
        ├── README.md</pre>

4. Add a file named appsettings.json in the following location, inside ShelterApi folder 

    <pre>ShelterApi
    ├── .gitignore 
    ├── ... 
    └── ShelterApi
        ├── Controllers
        ├── Models
        ├── ...
        └── <strong>appsettings.json</strong></pre>
      
5. Copy and paste below JSON text in appsettings.json.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=shelter_api;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}

```

7. Replace [YOUR-USERNAME-HERE] with your MySQL user name.

8. Replace [YOUR-PASSWORD-HERE] with your MySQL password.

9. Run the command

    ```dotnet ef database update```


<strong>To Run</strong>

Navigate to the following directory in the console
    <pre>ShelterApi
    └── <strong>ShelterApi</strong></pre>

Run the following command in the console

  ``dotnet build``

Then run the following command in the console

  ``dotnet run``

This program was built using _`Microsoft .NET SDK 6.0`_, and may not be compatible with other versions. Cross-version performance is neither implied nor guaranteed, your actual mileage may vary.

## API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.

###  Swagger Documentation 
To view the Swagger documentation for the ShelterApi, launch the project using `dotnet run` using Terminal or Powershell, then input the following URL into your browser: `https://localhost:5001/swagger/index.html`

### Animals

Get information about different global animals.

#### HTTP Request Structure
```
GET https://localhost:5001/api/Animals/
GET https://localhost:5001/api/Animals/{id}
POST https://localhost:5001/api/Animals/
PUT https://localhost:5001/api/Animals/{id}
DELETE https://localhost:5001/api/Animals/{id}
GET https://localhost:5001/api/Animals/page/{page}
```
* To utilize the POST request and create a new instance of a animal, the following information is required.
```
{
    "animalId": "int",
    "name": "string",
    "species": "string",
    "breed": "string",
    "age": "int",
}
```

#### Example Query
```
https://localhost:5001/api/Animals/1
```
#### Sample JSON Response
```
{
    "animalId": 1,
    "name": "Salmon",
    "species": "Cat",
    "breed": "Scottish Fold",
    "age": 7,
}
```

## Known Bugs

* _No known issues_

* _Reach out with any questions or concerns to [mollyrdonegan@gmail.com](mollyrdonegan@gmail.com)_

## License

[MIT](/LICENSE)

Copyright Molly Donegan