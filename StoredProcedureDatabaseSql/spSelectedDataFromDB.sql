CREATE PROCEDURE spSelcteDataDisplay
(
	@FirstName VARCHAR(30)
)
AS BEGIN
SELECT * FROM AddressBook_Table WHERE FirstName = @FirstName
END
