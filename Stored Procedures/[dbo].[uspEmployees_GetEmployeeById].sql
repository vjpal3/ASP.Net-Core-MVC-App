SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspEmployees_GetEmployeeById]
					@Id int
as
begin
	set nocount on;
	SELECT * FROM dbo.Employees where Id = @Id
end
GO

