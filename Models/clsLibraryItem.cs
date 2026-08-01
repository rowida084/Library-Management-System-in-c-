using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    abstract class clsLibraryItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
      
        public DateTime AddedDate { get; set; }
        public bool IsAvailable { get; set; } 

        public clsLibraryItem(int ID, string Title, DateTime addedDate)
        {
            this.ID = ID;
            this.Title = Title;
           this. AddedDate = addedDate;
            IsAvailable = true;
        }

        public clsLibraryItem()
        { }//default constructor
        public abstract string GetInfo();


    }
}
