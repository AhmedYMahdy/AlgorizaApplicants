Introduction:  
  This application is a simple system to run CRUD opertations on Applicants table.
  In This application i used technologies like(.Net Core MVC and Entity Framework Core).
  The system has 2 interfaces Swagger interface for developers, and the Views for the users.
  You can access swagger interface using this like:https://localhost:7228/swagger/index.html.
  And you can access the views using this like: https://localhost:7228/api/ApplicantsFV/applicants.
  Both interface you can access after running the application, by default it opens with the Views interface.
  In the system I applied some validations on the inputs on both sides (client-side and Server-side), one of those validation
  is on Country which I used an external api, I integrated with this api "https://restcountries.com/v3.1/name/"to Validate the country.

Installation
    This App doesn't need an installation, just we need to run command "update-database" to apply the migrations into the DB.
    
Postman Collection:
  https://www.getpostman.com/collections/5aea1a005eb4fc5debbc.
    

    
