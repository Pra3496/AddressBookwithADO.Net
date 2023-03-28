CREATE PROCEDURE spUpdateData
(
@FirstName VARCHAR(30),
@LastName VARCHAR(30)
)
AS BEGIN
UPDATE AddressBook_Table SET FirstName = @FirstName WHERE LastName = @LastName
END