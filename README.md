## Data Visualization Api
This .NET Core web API application is designed to replicate data from MS SQL to MongoDB for analytics and visualization purposes. By leveraging the scalability and performance of MongoDB, the application can provide fast and reliable data access for web and mobile applications.

The application includes a data migration component that retrieves data from MS SQL and maps it to a MongoDB database, using a predefined schema. This migration process can be scheduled or triggered on demand, depending on the specific use case.

Once the data is migrated to MongoDB, the web API component allows for easy sharing of data with different applications. The API can be used to query the data, filter and sort the results, and expose the data in a format that is easy to consume by other applications.

The web API can be accessed by different applications, such as web and mobile applications, using standard HTTP requests. The API supports common HTTP methods, such as GET, POST, PUT, and DELETE, to perform CRUD (Create, Read, Update, Delete) operations on the data.

## Tools and Technology 
+ Microsoft SQL Server
+ MongoDB
+ Microsoft Visual Studio Enterprise 2022
+ MS .Net Core Web Api (.NET 7.0)
+ Entity Framework Core
+ Linq
+ Stored Procedure

## Project Architecture 
![Architecture](/DataVisualization.Api/images/ProjectView.PNG)
