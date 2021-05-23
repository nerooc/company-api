USE cmapiDB
GO  

-- Główna tabela Employee zawierająca dane pracowników
CREATE TABLE Employee (
        id int NOT NULL UNIQUE IDENTITY,
		level hierarchyid NOT NULL UNIQUE,
		firstName nvarchar(30) NOT NULL,
        lastName nvarchar(30) NOT NULL,
		position nvarchar(30) NOT NULL,
		salary int NOT NULL
	);
