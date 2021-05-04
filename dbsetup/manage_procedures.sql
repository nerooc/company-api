USE cmapiDB
GO  

-- Główna tabela Employee zawierająca pracowników
CREATE TABLE Employee (
        id int NOT NULL UNIQUE,
		level hierarchyid NOT NULL UNIQUE,
		firstName nvarchar(30) NOT NULL,
        lastName nvarchar(30) NOT NULL,
		position nvarchar(30) NOT NULL,
		salary int NOT NULL
	);

-- Procedura dodająca nowego pracownika
CREATE PROCEDURE AddEmployee 
@level as varchar(1000), @firstName as varchar(1000), @lastName as varchar(1000), @position as varchar(1000), @salary as Int
AS BEGIN
    INSERT Employee VALUES ( hierarchyid::Parse(@level), @firstName, @lastName, @position, @salary );
END

GO 

-- Procedura usuwająca pracownika po ID
CREATE PROCEDURE RemoveEmployeeById 
@id as Int
AS BEGIN
    DELETE FROM Employee 
    WHERE id=@id
END

GO 

-- Procedura usuwająca pracownika po imieniu
CREATE PROCEDURE RemoveEmployeeByFirstName
@firstName as varchar(1000)
AS BEGIN
    DELETE FROM Employee 
    WHERE firstName=@firstName
END

GO 

-- Procedura usuwająca pracownika po nazwisku
CREATE PROCEDURE RemoveEmployeeByLastName
@lastName as varchar(1000)
AS BEGIN
    DELETE FROM Employee 
    WHERE lastName=@lastName
END

GO 

-- Procedura usuwająca pracownika po poziomie (hierarchyid)
CREATE PROCEDURE RemoveEmployeeByLevel
@level hierarchyid
AS BEGIN
    DELETE FROM Employee
    WHERE level=@level 
END

GO