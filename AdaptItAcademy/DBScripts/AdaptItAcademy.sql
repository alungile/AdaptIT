USE [AdaptItAcademy]

-- Create Course table
CREATE TABLE dbo.Course
	(
	ID int NOT NULL IDENTITY (1, 1),
	CourseName varchar(20) NOT NULL,
	CourseCode varchar(10) NOT NULL,
	CourseDescr nvarchar(200) NOT NULL,
	IsCoursePaidFor bit NOT NULL,
	IsCourseActive bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Course ADD CONSTRAINT
	PK_Course PRIMARY KEY CLUSTERED
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

-- Create Training table
CREATE TABLE dbo.Training
	(
	ID int NOT NULL IDENTITY (1, 1),
	Venue varchar(20) NOT NULL,
	CourseID int NOT NULL,
	NumberOfSits int NOT NULL,
	StartDate DATETIME NOT NULL,
	EndDate DATETIME NOT NULL,
	TrainingCost decimal(6,2) NULL,
	RegClosingDate DATETIME NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Training ADD CONSTRAINT
	PK_Training PRIMARY KEY CLUSTERED
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.Training ADD CONSTRAINT
	FK_Training_Course FOREIGN KEY
	(
	CourseID
	) REFERENCES dbo.Course
	(
	ID
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION
GO

-- Create Dietary Requirements table
CREATE TABLE dbo.DietaryRequirements
	(
	ID int NOT NULL IDENTITY (1, 1),
	Diet varchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DietaryRequirements ADD CONSTRAINT
	PK_DietaryRequirements PRIMARY KEY CLUSTERED
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- Create Delegate table
CREATE TABLE dbo.Delegates
	(
	ID int NOT NULL IDENTITY (1, 1),
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	Telephone varchar(20) NOT NULL,
	Email varchar(50) NOT NULL,
	DietaryID int NOT NULL,
	CompanyName varchar(100) NOT NULL,
	PostalAddress1 varchar(50) NULL,
	PostalAddress2 varchar(50) NULL,
	PostalAddress3 varchar(50) NOT NULL,
	PostalCity varchar(20) NOT NULL,
	PostalCode nchar(10) NOT NULL,
	PhysicalAddress1 varchar(50) NULL,
	PhysicalAddress2 varchar(50) NULL,
	PhysicalAddress3 varchar(50) NOT NULL,
	PhysicalCity varchar(20) NOT NULL,
	PhysicalCode nchar(10) NOT NULL,
	CourseID int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Delegates ADD CONSTRAINT
	PK_Delegates PRIMARY KEY CLUSTERED
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE dbo.Delegates ADD CONSTRAINT
	FK_Delegates_Course FOREIGN KEY
	(
	CourseID
	) REFERENCES dbo.Course
	(
	ID
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION
GO

ALTER TABLE dbo.Delegates ADD CONSTRAINT
	FK_Delegates_DietaryRequirements FOREIGN KEY
	(
	DietaryID
	) REFERENCES dbo.DietaryRequirements
	(
	ID
	) ON UPDATE  NO ACTION
	 ON DELETE  NO ACTION
GO
