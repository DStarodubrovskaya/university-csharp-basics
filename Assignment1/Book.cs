using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Book
    {
        protected int id = -1;
        protected string title = "Unknown";
        protected string author = "Unknown";
        protected int copiesNum = 0;
        public Book() { } // Empty constructor for initializing default values
        public Book(int id, string title, string author)
        {
            this.title = title;
            this.author = author;
            this.id = id;
            this.copiesNum++;
        }
        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public int CopiesNum { get { return copiesNum; } set { copiesNum = value; } }
        public override string ToString()
        {
            string info = title + " by " + author + "." + "\nNumber of copies: " + copiesNum;
            return info;
        }// Overriding ToString to display book information
        public static bool operator ==(Book book1, Book book2)
        {
            return (book1.id == book2.id);
        }
        public static bool operator !=(Book book1, Book book2)
        {
            return !(book1 == book2); // Negates the result of the == operator
        }// Overloading the == and != operators to compare books
    }
}
