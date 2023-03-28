CREATE PROCEDURE spDeleteFromDB
(
	@FirstName VARCHAR(30)
)
AS BEGIN
	
	DELETE FROM AddressBook_Table WHERE FirstName = @FirstName
END
