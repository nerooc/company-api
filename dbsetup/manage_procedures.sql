use cmapiDB
go  

CREATE TABLE Employee (
        id int NOT NULL UNIQUE,
		level hierarchyid NOT NULL UNIQUE,
		firstName nvarchar(30) NOT NULL,
        lastName nvarchar(30) NOT NULL,
		position nvarchar(30) NOT NULL,
		salary int NOT NULL
	);

CREATE PROCEDURE AddEmployee 
@level as varchar(1000), @firstName as varchar(1000), @lastName as varchar(1000), @position as varchar(1000), @salary as Int
AS BEGIN
    INSERT Employee VALUES ( hierarchyid::Parse(@level), @firstName, @lastName, @position, @salary );
END
go