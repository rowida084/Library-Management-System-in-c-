using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class clsBorrowRecord
    {
        public int ID { get; set;}
        public clsBook Book { get; set;}
        public clsMember Member { get; set;}
        public DateTime BorrowDate { get; set;}
        public DateTime? ReturnDate { get; set;}
        public clsBorrowRecord(int iD, clsBook book, clsMember member, DateTime borrowDate)
        {
          this. ID = iD;
            this.Book = book;
            this.Member = member;
            this.BorrowDate = borrowDate;
            this.ReturnDate = null;
        }

      public  bool isLate()
        {
            return ((DateTime.Now - BorrowDate).TotalDays > Member.LoanDays);
        }

        public string PrintBorrowCardInfo()
        {
            return $"Loan ID     : {ID}\n" +
           $"Book        : {Book.Title}\n" +
           $"Member      : {Member.Name}\n" +
           $"Borrow Date : {BorrowDate:dd/MM/yyyy}\n" +
           $"Return status : {(ReturnDate.HasValue ? ReturnDate.Value.ToString("dd/MM/yyyy") : "Not Returned Yet")}";
        }
    
    }
}
