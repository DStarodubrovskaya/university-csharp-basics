using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class FictionBook : Book
    {
        protected string genre = "Unknown";
        public FictionBook() { } // Empty constructor for initializing default values
        public FictionBook(int id, string title, string author, string genre) : base(id, title, author)
        {
            this.genre = genre;
        }
        public string Genre { get { return genre; } set { genre = value; } }
        public override string ToString()
        {
            string info = base.ToString() + " Fiction book." + " Genre: " + genre + ".";
            if (copiesNum == 0) { info += " Status: All copies are loaned."; } else { info += " Status: Available."; }
            return info;
        }// Overriding ToString to display fiction book information
    }
}
