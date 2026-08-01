using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class clslibrary
    {
        private clsBook[] Books;
        private clsMember[] Members;
        private clsBorrowRecord[] BorrowRecords;

        private short BookCount = 0;
        private short BorrowCount = 0;
        private short MemberCount = 0;

        public clslibrary()
        {
            Books = new clsBook[10];
            Members = new clsMember[10];
            BorrowRecords = new clsBorrowRecord[10];
        }
        private void _addBook(clsBook book)
        {
            Books[BookCount] = book;
            BookCount++;
        }

        public void AddBook( )
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Copies: ");
            int copies = int.Parse(Console.ReadLine());

           clsBook book = new clsBook(BookCount+1,title,DateTime.Now,author,category,copies);
            _addBook(book);
        }

        private void _registerMember(clsMember member)
        {
            member.JoinDate = DateTime.Now;
            Members[MemberCount] = member;
            MemberCount++;
        }

        public void RegisterMember()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("1. Regular Member");
            Console.WriteLine("2. Premium Member");
            int type = int.Parse(Console.ReadLine());
            bool added=false;
           if(type == 1)
            {
                clsMember member=new clsMember(MemberCount+1,name,email,DateTime.Now);
                _registerMember(member);
                added=true;
            }
           else if(type == 2)
            {
                clsMember member= new clsPremiumMember(MemberCount+1,name,email,DateTime.Now);
                _registerMember(member);
                added=true;
            }
            else
            {
                Console.WriteLine("This Option Not Available");
            }
           if(added)
            {
                Console.WriteLine("Member is registered successfully.");
            }
        }

        private clsBook GetBookByID(int BookID)
        {

            foreach (clsBook book in Books)
            {
                if (book.ID == BookID)

                    return book;
            }
            Console.WriteLine("Book Not Found");
            return null;
        }

        private clsMember GetMemberByID(int MemberID)
        {
            foreach (clsMember member in Members)
            {
                if (member.ID == MemberID)
                    return member;
            }
            Console.WriteLine("Member Not Found");
            return null;
        }

        private void _borrowBook(int BookID, int MemberID)
        {
            clsBook book = GetBookByID(BookID);
            clsMember member = GetMemberByID(MemberID);
            if (book == null || member == null)
                return;
            if (book.IsAvailable == false)
            {
                Console.WriteLine("Book Is Not Available");
                return;
            }

            if (member.BorrowCount < member.BorrowLimit)
            {
                clsBorrowRecord borrowRecord = new clsBorrowRecord(BorrowCount + 1, book, member, DateTime.Now);
                BorrowRecords[BorrowCount] = borrowRecord;
                BorrowCount++;
                book.IsAvailable = false;
                member.BorrowedBooks[member.BorrowCount] = book;
                member.BorrowCount++;
                Console.WriteLine("Book Borrowed Successfully");
            }
            else
            {
                Console.WriteLine("Member Cannot Borrow Any Books Now");
            }
        }

        public void BorrowBook()
        {
            int BookID, MemberID;
            do
            {
                Console.WriteLine("Enter Book ID: ");
                BookID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Member ID");
                MemberID = int.Parse(Console.ReadLine());
            }
            while (GetBookByID(BookID) == null || GetMemberByID(MemberID) == null);
            _borrowBook(BookID, MemberID);
        }
        private void _returnBook(int BookID, int MemberID)
        {
            bool found = false;
            foreach (var borrowRecord in BorrowRecords)
            {
                if (borrowRecord != null)
                {
                    if (borrowRecord.Book.ID == BookID && borrowRecord.Member.ID == MemberID
                        && borrowRecord.ReturnDate == null)
                    {
                        found = true;
                        borrowRecord.Book.IsAvailable = true;
                        borrowRecord.ReturnDate = DateTime.Now;
                        break;
                    }
                }
            }
            if (found)
            {
                clsMember member = GetMemberByID(MemberID);
                int BookIndex = -1;

                for (int i = 0; i < member.BorrowCount; i++)
                {
                    if (member.BorrowedBooks[i].ID == BookID)
                    {
                        BookIndex = i;
                        break;
                    }
                }


                for (int i = BookIndex; i < member.BorrowCount - 1; i++)
                {
                    member.BorrowedBooks[i] = member.BorrowedBooks[i + 1];

                }
                member.BorrowCount--;
            }
            else
            {
                Console.WriteLine("This Borrow Card Not Found");
            }
        }


        public void ReturnBook()
        {
            Console.WriteLine("Enter Book ID: ");
            int BookID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Member ID");
            int MemberID = int.Parse(Console.ReadLine());
            _returnBook(BookID, MemberID);
        }

        private void _searchCategory(string query)
        {
            bool found = false;
            for (int i = 0; i < BookCount; i++)
            {
                if (Books[i].MatchesQuery(query))
                {
                    Console.WriteLine("Book Information:");
                    Console.WriteLine(Books[i].GetInfo());
                    found = true;
                }
            }

            for (int i = 0; i < MemberCount; i++)
            {
                if (Members[i].MatchesQuery(query))
                {
                    Console.WriteLine("Member Information:");
                    Console.WriteLine(Members[i].GetInfo());
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Result!");
            }
        }

        public void Search()
        {
            Console.WriteLine("Enter The Text");
            string query=Console.ReadLine();
            _searchCategory(query);
        }
        public void ViewAvailableBooks()
        {
            int availableCount = 0;
            for (int i = 0; i < BookCount; i++)
            {
                if (Books[i].IsAvailable)
                {
                    availableCount++;
                    Console.WriteLine(Books[i].GetInfo());
                    Console.WriteLine("========================================");
                }
            }
            if (availableCount == 0)
            {
                Console.WriteLine("No Available Books");
            }
        }

        private void _memberBorrowingHistory(int memberID)
        {
            bool found = false;

            for (int i = 0; i < BorrowCount; i++)
            {
                if (BorrowRecords[i].Member.ID == memberID)
                {
                    Console.WriteLine(BorrowRecords[i].PrintBorrowCardInfo());
                    Console.WriteLine("====================================");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("This member has no borrowing history.");
            }
        }

        public void MemberBorrowingHistory()
        {
            Console.WriteLine("Enter Member ID: ");
            int memberID = int.Parse(Console.ReadLine());
            _memberBorrowingHistory(memberID);
        }
        public void LateReturnReport()
        {
            bool found =false;
            for(int i=0;i<BorrowCount;i++)
            {
                if (BorrowRecords[i].isLate())
                {
                    int overdueDays= (int)(DateTime.Now - BorrowRecords[i].BorrowDate).TotalDays
                - BorrowRecords[i].Member.LoanDays;

                    Console.WriteLine(BorrowRecords[i].PrintBorrowCardInfo());
                    Console.WriteLine($"Overdue Days : {overdueDays}");
                    found = true;
                }
            }
            if(!found)
            {
                Console.WriteLine("No Late Borrow Records");
            }
        }

        public void SeedData()
        {
            Books[BookCount++] = new clsBook(
                1,
                "Clean Code",
                DateTime.Now,
                "Robert C. Martin",
                "1",
                3);

            Books[BookCount++] = new clsBook(
                2,
                "C# in Depth",
                DateTime.Now,
                "Jon Skeet",
                "2",
                2);

            Members[MemberCount++] = new clsMember(
                1,
                "Ahmed",
                "ahmed@gmail.com",
                DateTime.Now);

            Members[MemberCount++] = new clsPremiumMember(
                2,
                "Sara",
                "sara@gmail.com",
                DateTime.Now);
        }
    }
}
