using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Subscriber
    {
        private string subscriberName = "Unknown";
        private int subscriberId = 0;
        private int booksLoaned = 0; // Number of books currently loaned
        private List<Book> books = new List<Book>();
        public Subscriber(string name, int id)
        {
            this.subscriberName = name;
            this.SubscriberId = id;
        }
        public string SubscriberName { get { return subscriberName; } set { subscriberName = value; } }
        public int SubscriberId { get { return subscriberId; } set { subscriberId = value; } }
        public int BooksLoaned { get { return booksLoaned; } set { booksLoaned = value; } }
        public List<Book> Books { get { return books; } }
    }
}
