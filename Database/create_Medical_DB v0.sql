
USE master
GO

CREATE DATABASE Medical_DB
GO


USE Medical_DB
GO

CREATE TABLE Doctors(
	[doctor_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[first_name] nvarchar(max) NOT NULL,
	[last_name] nvarchar(max) NOT NULL,
	[phone_number] nvarchar(12) NOT NULL,
	[brith_date]	datetime2 NULL	
)
GO

CREATE TABLE Clients(
	[client_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[first_name] nvarchar(max) NOT NULL,
	[last_name] nvarchar(max) NOT NULL,
	[phone_number] nvarchar(12) NOT NULL,
	[brith_date]	datetime2 NULL	
)
GO

CREATE TABLE Chats(
	[chat_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[doctor_id] uniqueidentifier NOT NULL,
	[client_id] uniqueidentifier NOT NULL,
	[date_creating]	datetime2 NOT NULL,
	[date_closing]	datetime2 NULL
)
GO  
ALTER TABLE [Chats] 
add constraint Chats_to_Doctor FOREIGN KEY ( [doctor_id] ) references Doctors([doctor_id])
GO
ALTER TABLE [Chats] 
add constraint Chats_to_Client FOREIGN KEY ( [client_id] ) references Clients([client_id])
GO



CREATE TABLE Message_History(
	[message_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[chat_id] uniqueidentifier NOT NULL,
	[message] ntext  NOT NULL,
	[date_send]	datetime2 NOT NULL,
	[date_receive]	datetime2 NULL
)
GO
ALTER TABLE Message_History 
add constraint MessageHistory_to_Chats FOREIGN KEY ( [chat_id] ) references Chats([chat_id])
GO

CREATE TABLE Specialists(
	[specialist_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[name] nvarchar(max) NOT NULL,
	[description] ntext  NOT NULL
)
GO   

CREATE TABLE Specialists_to_Doctor(
	[doctor_id] uniqueidentifier NOT NULL,
	[specialist_id] uniqueidentifier NOT NULL	 
)
GO  
ALTER TABLE Specialists_to_Doctor 
add constraint SpecialistsToDoctor_to_Doctor FOREIGN KEY ( [doctor_id] ) references Doctors([doctor_id])
GO
ALTER TABLE Specialists_to_Doctor 
add constraint SpecialistsToDoctor_to_Specialist FOREIGN KEY ( [specialist_id] ) references Specialists([specialist_id])
GO


CREATE TABLE Banned_Users(
	[banned_id] int IDENTITY PRIMARY KEY NOT NULL,
	[doctor_id] uniqueidentifier NOT NULL,
	[client_id] uniqueidentifier NOT NULL,
	[date_banned] datetime2 NOT NULL
)
GO
ALTER TABLE Banned_Users 
add constraint BannedUsers_to_Doctor FOREIGN KEY ( [doctor_id] ) references Doctors([doctor_id])
GO
ALTER TABLE Banned_Users 
add constraint BannedUsers_to_Client FOREIGN KEY ( [client_id] ) references Clients([client_id])
GO

CREATE TABLE Medical_Assessments(
	[assesment_id] int IDENTITY PRIMARY KEY NOT NULL,
	[doctor_id] uniqueidentifier NOT NULL,
	[sum_raitings] int NOT NULL,
	[count_of_votes] int NOT NULL,
	[rating] AS [sum_raitings]/[count_of_votes],
)
GO
ALTER TABLE Medical_Assessments 
add constraint MedicalAssessments_to_Doctor FOREIGN KEY ( [doctor_id] ) references Doctors([doctor_id])
GO 


CREATE TABLE Photo(
	[photo_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[message_id] uniqueidentifier NOT NULL,
	[image_data] varbinary(max) NOT NULL
)
GO
ALTER TABLE Photo 
add constraint Photo_to_MessageHistory FOREIGN KEY ( [message_id] ) references Message_History([message_id])
GO


CREATE TABLE Video(
	[video_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[message_id] uniqueidentifier NOT NULL,
	[video_data] varbinary(max) NOT NULL
)
GO
ALTER TABLE Video 
add constraint Video_to_MessageHistory FOREIGN KEY ( [message_id] ) references Message_History([message_id])
GO



CREATE TABLE Voice(
	[voice_id] uniqueidentifier PRIMARY KEY NOT NULL,
	[message_id] uniqueidentifier NOT NULL,
	[voice_data] varbinary(max) NOT NULL
)
GO
ALTER TABLE Voice
add constraint Voice_to_MessageHistory FOREIGN KEY ( [message_id] ) references Message_History([message_id])
GO