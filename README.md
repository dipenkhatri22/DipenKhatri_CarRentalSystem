# Car Rental System - Windows Forms Application

## Overview
The **Car Rental System** is a Windows Forms (WinForms) application developed in **C#** using **.NET Framework** and **SQL Server**. It provides a user-friendly interface to manage car rentals, customers, and rental transactions efficiently.

## Features
- **User Authentication**: Simple login system for admin users.
- **Car Registration**: Add, update, and delete car details.
- **Customer Management**: Manage customer records.
- **Rental Transactions**: Rent cars to customers and track due dates.
- **Return Management**: Record returned cars and calculate fines if applicable.
- **Database Integration**: Uses **SQL Server** for data storage.

## Technologies Used
- **C# (WinForms .NET Framework)**
- **SQL Server**
- **System.Data.SqlClient** (for database connectivity)
- **Visual Studio 2022**
- **SQL Server Management Studio (SSMS)**

## Database Setup
1. Open **SQL Server Management Studio (SSMS)**.
2. Create a new database:
   ```sql
   CREATE DATABASE carrental;
   ```
3. Use the database:
   ```sql
   USE carrental;
   ```
4. Create necessary tables:
   ```sql
   CREATE TABLE carreg (
       regno NVARCHAR(50) PRIMARY KEY,
       make NVARCHAR(100),
       model NVARCHAR(100),
       available NVARCHAR(10)
   );

   CREATE TABLE customer (
       custid NVARCHAR(50) PRIMARY KEY,
       custname NVARCHAR(100),
       phone NVARCHAR(20)
   );

   CREATE TABLE rental (
       rentalid INT IDENTITY PRIMARY KEY,
       car_id NVARCHAR(50),
       cust_id NVARCHAR(50),
       date DATE,
       due DATE,
       FOREIGN KEY (car_id) REFERENCES carreg(regno),
       FOREIGN KEY (cust_id) REFERENCES customer(custid)
   );

   CREATE TABLE returncar (
       returnid INT IDENTITY PRIMARY KEY,
       car_id NVARCHAR(50),
       cust_id NVARCHAR(50),
       returndate DATE,
       fine INT,
       FOREIGN KEY (car_id) REFERENCES carreg(regno),
       FOREIGN KEY (cust_id) REFERENCES customer(custid)
   );
   ```

## Installation & Setup
### 1. Clone the Repository
```sh
git clone https://github.com/DipenKhatri_Dot_Net_Assignment/CarRentalSystem.git
```
### 2. Open in Visual Studio
- Open **Visual Studio 2022**.
- Load the `CarRentalSystem.sln` solution file.

### 3. Configure Database Connection
- Open `DBConnection.cs`.
- Update the connection string:
  ```csharp
  public static SqlConnection GetConnection()
  {
      return new SqlConnection("Data Source=YOUR_SERVER; Initial Catalog=carrental; User ID=YOUR_USER; Password=YOUR_PASSWORD;");
  }
  ```

### 4. Run the Application
- Press **F5** or click **Start** in Visual Studio.
- Login using the default credentials:
  - **Username**: `testadmin`
  - **Password**: `123`

![image](https://github.com/user-attachments/assets/fef3d3d6-af11-48ac-a10b-380b91712d1f)
![image](https://github.com/user-attachments/assets/98084245-2845-46cd-8a5f-95d8401b9133)


## Future Enhancements
- Implement **role-based authentication**.
- Enhance **UI/UX** with a modern design.
- Add **reporting features** for rentals and returns.

## Author
**Dipen Khatri**

## License
This project is licensed under the MIT License.
