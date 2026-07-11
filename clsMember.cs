using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class clsMember :clsIsSearched
    {
        public string Name { get; set; }
        public int ID {  get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
       public clsBook[] BorrowedBooks {  get; set; }
        public virtual int LoanDays { get; } = 14;
       public virtual int BorrowLimit => 3;
        public short BorrowCount { get; set; } = 0;

        public clsMember(int ID,string Name,string Email,DateTime JoinDate)
        {
            this.ID = ID;
            this.Name= Name;
            this.Email= Email;
            this.JoinDate = JoinDate;
            BorrowedBooks = new clsBook[BorrowLimit];
            
        }
       public bool MatchesQuery(string query)
        {
            return Name.ToLower() == query.ToLower();
        }

        public virtual string GetInfo()
        {
            string info = $"ID: {ID}\n" +
                          $"Name: {Name}\n" +
                          $"Email: {Email}\n" +
                          $"Join Date: {JoinDate:dd/MM/yyyy}\n" +
                          $"Loan Days: {LoanDays}\n" +
                          $"Borrowed Books:\n";

            foreach (clsBook book in BorrowedBooks)
            {
                if (book != null)
                    info += $"- {book.Title}\n";
            }

            return info;
        }

    }
}
