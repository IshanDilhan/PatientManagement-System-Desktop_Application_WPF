create database named hospitalDB
connect database and add this 2 tables

// create Admin table


CREATE TABLE [dbo].[Admin_Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Admin_Name] VARCHAR(50) NULL, 
    [Admin_Email] VARCHAR(50) NOT NULL, 
    [Admin_Username] VARCHAR(50) NOT NULL, 
    [Admin_Password] VARCHAR(50) NOT NULL
)



// creat patient table

CREATE TABLE [dbo].[Pation_Table] (
    [Pation_Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Pation_Name]   VARCHAR (50) NOT NULL,
    [Pation_Age]    VARCHAR (50) NOT NULL,
    [Pation_gender] VARCHAR (50) NOT NULL,
    [Guardian_TP]   VARCHAR (50) NOT NULL,
    [Reason]        VARCHAR (50) NOT NULL,
    [Ward]          VARCHAR (50) NOT NULL,
    [other]         VARCHAR (50) NULL,
    [Admin_Regi_nu] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Pation_Id] ASC)
);
