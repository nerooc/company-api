USE cmapiDB
GO  

-- Główna tabela Employee zawierająca pracowników
CREATE TABLE Employee (
        id int NOT NULL UNIQUE IDENTITY,
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

-- Procedura usuwająca wszystkich pracowników
CREATE PROCEDURE RemoveAllEmployees
AS BEGIN
    DELETE FROM Employee
END

GO

-- Procedura zwracająca pracownika po ID
CREATE PROCEDURE GetEmployeeById
@id as Int
AS BEGIN
    SELECT id as [id], level, firstName, lastName, position, salary FROM Employee
    WHERE id=@id
END

GO

-- Procedura zwracająca pracownika po poziomie (hierarchyid)
CREATE PROCEDURE GetEmployeeByLevel
@level as hierarchyid
AS BEGIN
    SELECT level as [level], firstName, lastName, position, salary FROM Employee
    WHERE level=@level
END

GO

-- Procedura zwracająca pracownika po imieniu
CREATE PROCEDURE GetEmployeeByFirstName
@firstName as varchar(1000)
AS BEGIN
    SELECT level, firstName as [firstName], lastName, position, salary FROM Employee
    WHERE firstName=@firstName
END

GO

-- Procedura zwracająca pracownika po nazwisku
CREATE PROCEDURE GetEmployeeByLastName
@lastName as varchar(1000)
AS BEGIN
    SELECT level, firstName, lastName as [lastName], position, salary FROM Employee
    WHERE lastName=@lastName
END

GO

-- Procedura zwracająca pracownika wraz z podwładnymi
CREATE PROCEDURE GetEmployeeWithSubordinates
@level as hierarchyid
AS BEGIN
    SELECT level as [level], firstName, lastName, position, salary FROM Employee
    WHERE level.IsDescendantOf(@level) = 1
END

GO

-- Procedura zwracająca wszystkich pracowników
CREATE PROCEDURE GetAllEmployees
AS BEGIN
    SELECT level as [level], firstName, lastName, position, salary FROM Employee
END

GO

-- Procedura największą wypłatę
CREATE PROCEDURE GetMaxSalary
AS BEGIN
    SELECT MAX(salary) as salary 
    FROM GetAllEmployees
END

GO

-- Procedura największą wypłatę
CREATE PROCEDURE GetAverageSalary
AS BEGIN
    SELECT AVG(salary) as salary 
    FROM GetAllEmployees
END

GO
