-- Create a new database
CREATE DATABASE EmployeeDB;
GO
-- Use the newly created database
USE EmployeeDB;
GO

-- Create a new table named Employees
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(200) NOT NULL,
    Mobile NVARCHAR(20) NOT NULL,
    DOB DATE NOT NULL
);
GO

-- Insert sample data into the Employees table
INSERT INTO Employees (Name, Address, Mobile, DOB)
VALUES
('Vaibhav Chavan', 'Miraj, Sangli', '9134455620', '1998-06-15'),
('Ashish Mane', 'Karad Satara', '7382923546', '1990-12-05');
GO