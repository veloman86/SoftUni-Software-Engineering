USE [SoftUni]
GO
/****** Object:  UserDefinedFunction [dbo].[udf_ProjectDurationWeeks]    Script Date: 10.10.2019 г. 22:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[udf_ProjectDurationWeeks]
(@StartDate DATETIME, 
 @EndDate   DATETIME
)
RETURNS INT
AS
     BEGIN
         DECLARE @projectWeeks INT;
         IF(@EndDate IS NULL)
             BEGIN
                 SET @EndDate = GETDATE();
             END
         SET @projectWeeks = DATEDIFF(WEEK, @StartDate, @EndDate);
         RETURN @projectWeeks;
     END