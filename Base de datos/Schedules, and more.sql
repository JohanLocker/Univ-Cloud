/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Code_Schedule]
      ,[Hour]
      ,[Day]
      ,[Subject]
      ,[Classroom]
  FROM [Cloud].[dbo].[Schedule]

  select * from ControlPanel;
  SELECT * FROM Employee;
  SELECT * FROM Position;
  SELECT * FROM Subject;
  SELECT * FROM Schedule;
  select * from Professor_Subject;
  SELECT * FROM Schedule_Professor;
  SELECT * FROM Professor_Subjects_Assigned;
  SELECT * FROM Schedules_Assigned WHERE Classroom_Assigned =  '1 A';-- 1ro A