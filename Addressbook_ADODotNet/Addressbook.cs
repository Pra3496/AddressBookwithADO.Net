using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace Addressbook_ADODotNet
{
    public class Addressbook
    {
        public static string connectionString = @"data source=.;initial catalog=AddressBook_Service;trusted_connection=True;TrustServerCertificate=True";
       
        public void AddingNewValue(AddressbookModel addressbookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpAddingNewData", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", addressbookModel.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressbookModel.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressbookModel.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressbookModel.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressbookModel.State);
                    sqlCommand.Parameters.AddWithValue("@Zip", addressbookModel.Zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", addressbookModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", addressbookModel.Email);

                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if(result >=1)
                    {
                        Console.WriteLine("\n\tNew Contact added Succesfuly\n");
                    }
                    else { Console.WriteLine("\n\tNot Added...!\n"); }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Not Ready");
            }

            
        }

        public void GetAllDataFromDataBase()
        {
            int iCnt = 0;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<AddressbookModel> addressBookList = new List<AddressbookModel>();

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("SpGetAllDataFromDB", sqlConnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            AddressbookModel addressBookModel = new AddressbookModel();

                            addressBookModel.FirstName = sqlReader.GetString(1);
                            addressBookModel.LastName = sqlReader.GetString(2);
                            addressBookModel.Address = sqlReader.GetString(3);
                            addressBookModel.City = sqlReader.GetString(4);
                            addressBookModel.State = sqlReader.GetString(5);
                            addressBookModel.Zip = sqlReader.GetInt32(6);
                            addressBookModel.PhoneNumber = sqlReader.GetInt64(7);
                            addressBookModel.Email = sqlReader.GetString(8);

                            addressBookList.Add(addressBookModel);
                        }

                        foreach (AddressbookModel item in addressBookList)
                        {
                            Console.WriteLine("+++++++++++[ {0} ]+++++++++++", ++iCnt);

                            Console.WriteLine("FirstName    : " + item.FirstName);
                            Console.WriteLine("LastName     : " + item.LastName);
                            Console.WriteLine("Address      : " + item.Address);
                            Console.WriteLine("City         : " + item.City);
                            Console.WriteLine("State        : " + item.State);
                            Console.WriteLine("Zip          : " + item.Zip);
                            Console.WriteLine("Phone Number : " + item.PhoneNumber);
                            Console.WriteLine("Email        : " + item.Email);

                            Console.WriteLine("\n+++++++++++*+*+*+*++++++++++++\n");
                        }
                    }
                    else
                        Console.WriteLine("no data found in table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

       

        public void UpdateDatafromDatabase(string FirstName, string LastName)
        {
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            AddressbookModel addressbookModel = null;
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spUpdateData", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName",FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName",LastName);
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result >= 1)
                    {
                        Console.WriteLine("\n\tNew Contact Updated Succesfuly\n");
                    }
                    else { Console.WriteLine("\n\tNot Updated...!\n"); }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Not Ready");
            }


        }


        public void GetSelectedDataFromDataBase(string Name)
        {
            int iCnt = 0;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<AddressbookModel> addressBookList = new List<AddressbookModel>();

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spSelcteDataDisplay", sqlConnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName",Name);

                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            AddressbookModel addressBookModel = new AddressbookModel();

                            addressBookModel.FirstName = sqlReader.GetString(1);
                            addressBookModel.LastName = sqlReader.GetString(2);
                            addressBookModel.Address = sqlReader.GetString(3);
                            addressBookModel.City = sqlReader.GetString(4);
                            addressBookModel.State = sqlReader.GetString(5);
                            addressBookModel.Zip = sqlReader.GetInt32(6);
                            addressBookModel.PhoneNumber = sqlReader.GetInt64(7);
                            addressBookModel.Email = sqlReader.GetString(8);

                            addressBookList.Add(addressBookModel);
                        }
                        foreach (AddressbookModel item in addressBookList)
                        {
                            Console.WriteLine("+++++++++++[ {0} ]+++++++++++",++iCnt);

                            Console.WriteLine("FirstName    : " + item.FirstName);
                            Console.WriteLine("LastName     : " + item.LastName);
                            Console.WriteLine("Address      : " + item.Address);
                            Console.WriteLine("City         : " + item.City);
                            Console.WriteLine("State        : " + item.State);
                            Console.WriteLine("Zip          : " + item.Zip);
                            Console.WriteLine("Phone Number : " + item.PhoneNumber);
                            Console.WriteLine("Email        : " + item.Email);

                            Console.WriteLine("\n+++++++++++*+*+*+*++++++++++++\n");
                        }

                    }
                    else
                        Console.WriteLine("no data found in table");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public void DeleteDatafromDatabase(string FirstName)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            AddressbookModel addressbookModel = null;
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("spDeleteFromDB", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@FirstName", FirstName);
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result >= 1)
                    {
                        Console.WriteLine("\n\t{0} is Deleted Succesfuly\n",FirstName);
                    }
                    else { Console.WriteLine("\n\tNot Deleted...!\n"); }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Not Ready");
            }


        }







    }
}
