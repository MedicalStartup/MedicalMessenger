
USE master
GO
 
CREATE DATABASE StatusMedicalService_DB
GO


USE StatusMedicalService_DB
GO

CREATE TABLE OnlineUsers(
	[phone_number] nvarchar(12) NOT NULL,
	[connection_date] datetime2 NOT NULL	
)
GO