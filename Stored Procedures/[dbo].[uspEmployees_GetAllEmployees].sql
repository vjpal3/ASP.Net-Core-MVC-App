SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[uspEmployees_GetAllEmployees] 
as
begin
	set nocount on;
	SELECT * FROM dbo.Employees
end

GO

