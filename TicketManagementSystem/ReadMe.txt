SAAB 2nd stage - Interview Test 

Mr. Ehi Izevbaye
12 Bunkers Hill Road
Hull, Hu46bd

07796130091

ehi.baye@gmail.com 

Things I have done.


1. MAJOR CODE REFACTOR
Using Cloud service architecture to separate the code into microservices.

1.1. Separated the code into different services: Solution root
	├── Domain Tier
	├── Presentation Tier
	├── Services
	├── Tests
	└── ReadMe.txt

	1.2. Domain Tier
	├── Entities
		├── Classes
		└── Error Handling
		├── Enums
		└── Exceptions
		├── Repositories
		└── UnitOfWork
	1.3. Presentation Tier
		├── Program.cs 
		└── Entry Point
		User Interface or Presntation Logic
	1.4. Services
		├── Business Logic
		└── Data Access
	1.5. Tests
		├── Unit Tests


2. SEPERATION OF CONCERNS - I have seperated the application into three main layers: Presentation Layer, Business Logic Layer, and Data Access Layer.
	2.1. Presentation Layer: User Logic
	2.2. Business Logic Layer: Contains all the core functionality and business rules of the application.
	2.3. Data Access Layer: I did not touch this, as it was not part of the requirement.
	2.4. Service Layer - Facilitates communication between the Presentation Layer and Business Logic Layer.
	2.5. Unit Test: again I did not touch this, as it was not part of the requirement.

Each layer has its own responsibility, making the codebase more modular and easier to maintain.

3. GENERAL CODE REFACTOR - 

Readability, Restructing, Improved code quality and structure
Based on Clean Code principles. e.g. martin fowler's principles 

	2.1. Using SOLID principles to enhance code maintainability and scalability.
	2.2. Added comprehensive error handling and logging mechanisms.
	2.3. Improved naming conventions for better readability.




THINGS I COULD HAVE IMPROVED UPON

mOST Important: The Stored Procedure is called directly and hard coded, which is not a good practice. Ideally, I would have abstracted the data access layer further to avoid direct calls to stored procedures.

I would have implemented an ORM Mapper (e.g. EF or anonymous Functions, e.g. in the new .net ASPIRE and blazor models) and used a generiC db class to called the stored procedure.

1. Implemented Dependency Injection to further decouple components and enhance testability.
2. Added more unit tests to cover edge cases and ensure robustness.
3. Used design patterns like Repository Pattern and Unit of Work for better data management.
4. Improved documentation within the code for better understanding of complex logic.
5. Implemented caching mechanisms to improve performance for frequently accessed data.
6. Used asynchronous programming to improve responsiveness and scalability.
7. Implemented configuration management for better handling of environment-specific settings.
