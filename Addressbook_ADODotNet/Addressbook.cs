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
       
        public void AddingNewValue( AddressbookModel addressbookModel)
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
       








    }
}
