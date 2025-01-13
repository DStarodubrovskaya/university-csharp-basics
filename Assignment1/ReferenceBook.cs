using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class ReferenceBook : Book
    {
        protected bool availableForLoan = false;
        public ReferenceBook() { } // Empty constructor for initializing default values
        public ReferenceBook(int id, string title, string author) : base(id, title, author) { }
        public bool AvailableForLoan { get { return availableForLoan; } set { availableForLoan = value; } }
        public override string ToString()
        {
            string info = base.ToString() + " Reference book.";
            if ((availableForLoan) && (copiesNum != 0))
            {
                info += " Status: Available.";
            }
            else if ((availableForLoan) && (copiesNum == 0))
            {
                info += " Status: All copies are loaned.";
            }
            else
            {
                info += " Status: Unavailable.";
            }
            return info;
        }// Overriding ToString to display reference book information
    }
}
