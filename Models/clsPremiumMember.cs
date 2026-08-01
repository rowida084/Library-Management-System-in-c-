using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class clsPremiumMember: clsMember
    {
        public override int LoanDays { get; } = 30;
        public override int BorrowLimit => 10;

        public clsPremiumMember(int ID, string Name, string Email, DateTime JoinDate) 
            :base( ID, Name, Email, JoinDate)
        {

        }

        public override string GetInfo()
        {
               return  $"\nMember Type: Premium" +
                   $"\nMax Borrow Limit: {BorrowedBooks.Length}" + base.GetInfo();
        }
    }
}
