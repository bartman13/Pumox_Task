# Pumox_Task

Respository created for interviev execrise for Pumox GmbH Company.

Used components:
-Ms Sql Server
-Asp Net Core Api 3.1
-Linq
-EntityFramework Core
-AutoMapper
-JsonSerialization

Credentials set in appsettings.json

username : "user"
password: "password"

Examples of Endpoints:

/company/create:
{
	{
        "Name": "Moja Testowa Firma",
        "EstablishmentYear": 1998,
        "Employees": [
             {
                 "FirstName": "Bart",
                 "LastName": "Luszt",
                 "DateOfBirth": "1990-01-27",
                "JobTitle": "Architect"
            },
             {
                 "FirstName": "Roman",
                 "LastName": "Luszt",
                 "DateOfBirth": "1972-01-27",
                 "JobTitle": "Manager"
            }
        ]
	}
}

/company/search:
{
    
        {
        "Keyword": "a",
        "EmployeeDateOfBirthFrom": "1998-01-27",
        "EmployeeDateOfBirthTo": "1998-01-30" ,
        "EmployeeJobTitles": ["Manager","Architect"]
	}
}

/company/update/8
{
	{
        "Name": "Moja zmieniona firma",
        "EstablishmentYear": 1998,
        "Employees": [
             {
                 "FirstName": "Bart",
                 "LastName": "Luszt",
                 "DateOfBirth": "1990-01-27",
                "JobTitle": "Architect"
            },
             {
                 "FirstName": "Roman",
                 "LastName": "Luszt",
                 "DateOfBirth": "1972-01-27",
                 "JobTitle": "Manager"
            }
        ]
	}
}

/company/delete/
{}
