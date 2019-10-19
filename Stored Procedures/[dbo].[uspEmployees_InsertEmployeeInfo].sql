SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspEmployees_InsertEmployeeInfo]
					@FirstName nvarchar(50), @LastName nvarchar(50), 
					@Email nvarchar(50), @DateOfBirth datetime2
AS
SET NOCOUNT ON
Insert into dbo.Employees
			(FirstName, LastName, Email, DateOfBirth)
		values
			(@FirstName, @LastName, @Email, @DateOfBirth)
GO

