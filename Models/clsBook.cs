using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class clsBook : clsLibraryItem,clsIsSearched
    {
        public string Author {  get; set; }
        public string  Category { get; set;}
        public int Copies {  get; set; }
       
        public clsBook() { }

        public clsBook(int ID,string Title,DateTime AddedDate,string Author, string  Category, int Copies)
            : base(ID, Title, AddedDate)
        {
           this. Author = Author;
          this.  Category = Category;
           this. Copies = Copies;
        }

       public bool MatchesQuery(string query)
        {
            return Title.ToLower() == query.ToLower();
        }

        public override string GetInfo()
        {
           return $"ID: {ID}\n" +
           $"Title: {Title}\n" +
           $"Author: {Author}\n" +
           $"Category: {Category}\n" +
           $"Copies: {Copies}\n" +
           $"Added Date: {AddedDate:dd/MM/yyyy}";
        }
    }
}
