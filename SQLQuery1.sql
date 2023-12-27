Create database School01Db
Use School01Db

CREATE TABLE Subject (
    SubjectID INT PRIMARY KEY NOT NULL,
    SubjectName NVARCHAR(50)
)

CREATE TABLE Class (
    ClassID INT PRIMARY KEY NOT NULL,
    ClassName NVARCHAR(50),
    ClassTeacher NVARCHAR(100),
    SubjectID INT FOREIGN KEY REFERENCES Subject(SubjectID)
)


CREATE TABLE Student (
    StudentID INT PRIMARY KEY NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    ClassID INT FOREIGN KEY REFERENCES Class(ClassID)
)


select * from Student
select * from Subject
select * from Class