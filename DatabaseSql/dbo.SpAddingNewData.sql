CREATE PROCEDURE SpAddingNewData(
@FirstName VARCHAR(30),
@LastName VARCHAR(30),
@Address VARCHAR(50),
@City VARCHAR(20),
@State VARCHAR(30),
@Zip INT,
@PhoneNumber  BIGINT,
@Email VARCHAR(30)
)
AS BEGIN
INSERT INTO AddressBook_Table(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email)
VALUES
(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email)
END

