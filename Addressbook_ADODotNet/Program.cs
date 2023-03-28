using System.Transactions;

namespace Addressbook_ADODotNet
{
    public class Program
    {

        
        static void Main(string[] args)
        {
            AddressbookModel addressbookModel = new AddressbookModel()
            {
                FirstName = "Pranav",
                LastName = "Waghmare",
                Address = "acs street",
                City = "Wardha",
                State = "Maha",
                Zip = 78964,
                PhoneNumber = 978213,
                Email = "qwert@rtyui"

            };


            Addressbook addressbook = new Addressbook();
            bool flag = true;
            string name = null;

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("\n\tWell-Come to AddressBook with MS-SQL\n");
                Console.WriteLine("\t\t-:OPTIONS:-\n");
                Console.WriteLine("1 : ADDING Data to AddressBook");
                Console.WriteLine("2 : DISPLAY Data From AddressBook");
                Console.WriteLine("3 : UPDATE Data From AddressBook");
                Console.WriteLine("4 : DISPLAY SELECTED Data From AddressBook");
                Console.WriteLine("5 : DELETE SELECTED Data From AddressBook");
                Console.WriteLine("0 : EXIT\n");
                Console.Write("Enter option : ");
                int opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("---------{ ADDING Data to AddressBook }---------");
                        addressbook.AddingNewValue(addressbookModel);
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("---------{ DISPLAY Data From AddressBook }---------");
                        addressbook.GetAllDataFromDataBase();
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("---------{ UPDATE Data From AddressBook }---------");
                        addressbook.UpdateDatafromDatabase("Nishant","Waghmare");
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("---------{ DISPLAY SELECTED Data From AddressBook }---------");
                        Console.Write("\nEnter the Name : ");
                        name = Convert.ToString(Console.ReadLine());
                        addressbook.GetSelectedDataFromDataBase(name);
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("---------{ DELETE Data From AddressBook }---------");
                        Console.Write("\nEnter the Name : ");
                        name = Convert.ToString(Console.ReadLine());
                        addressbook.DeleteDatafromDatabase(name);
                        Console.Write("Press any key...");
                        Console.ReadKey();
                        break;

                    case 0:
                        flag = false;
                        break;
                }
            }





        }
    }
}