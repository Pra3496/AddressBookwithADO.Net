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
            

            while(flag)
            {
                Console.Clear();
                Console.WriteLine("\n\tWell-Come to AddressBook with MS-SQL\n");
                Console.WriteLine("\t\t-:OPTIONS:-\n");
                Console.WriteLine("1 : ADDING Data to AddressBook");
                Console.WriteLine("2 : DISPLAY Data From AddressBook");
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
                    case 0:
                        flag = false;
                        break;
                }
            }





        }
    }
}