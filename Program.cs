using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        enum enMainManuOption
        {
            AddBook = 1,
            RegisterMember = 2,
            BorrowBook = 3,
            ReturnBook = 4,
            SearchCatalog = 5,
            ViewAvailableBooks = 6,
            MemberBorrowingHistory = 7,
            LateReturnReport = 8,
            Exit = 0
        }
        static void Main(string[] args)
        {
            clslibrary library = new clslibrary();
            library.SeedData();
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("===== Library Management System =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Register Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. View Available Books");
                Console.WriteLine("7. Member Borrowing History");
                Console.WriteLine("8. Late Return Report");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Please Enter Your Choice");
                choice=int.Parse(Console.ReadLine());
                Console.WriteLine();
            
                switch ((enMainManuOption)choice)
                {
                    case enMainManuOption.AddBook:
                        {
                          
                            library.AddBook();
                            break;
                        }

                        case enMainManuOption.RegisterMember:
                        {
                            
                            library.RegisterMember();
                            break;
                        }

                    case enMainManuOption.BorrowBook:
                        {
                           
                            library.BorrowBook();
                            break;
                        }

                    case enMainManuOption.ReturnBook:
                        {
                          
                            library.ReturnBook();
                            break;
                        }

                    case enMainManuOption.SearchCatalog:
                        {
                          
                            library.Search();
                            break;
                        }

                    case enMainManuOption.ViewAvailableBooks:
                        {
                            
                            library.ViewAvailableBooks();
                            break;
                        }

                    case enMainManuOption.MemberBorrowingHistory:
                        {
                           
                            library.MemberBorrowingHistory();
                            break;
                        }

                    case enMainManuOption.LateReturnReport:
                        {
                           
                            library.LateReturnReport();
                            break;
                        }

                    case enMainManuOption.Exit:
                        {
                            return;
                        }
                }
               
            }
            while(choice != 0);
        }
    }
}
