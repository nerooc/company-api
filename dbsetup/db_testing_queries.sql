EXEC AddEmployee @level='/', @firstName='Test', @lastName='Testowy', @position='CEO', @salary=2500

SELECT * FROM Employee

DBCC CHECKIDENT('Employee', RESEED, 0)
