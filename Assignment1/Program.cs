namespace Assignment1
{
    internal class Program
    {
        class Book
        {
            protected string title = "Unknown";
            protected string author = "Unknown";
            protected bool isOnLoan = false;
            public Book() { } // default constructor
            public Book(string title, string author, bool isOnLoan)
            {
                this.title = title;
                this.author = author;
                this.isOnLoan = isOnLoan;
            }
            public string Title { get { return title; } set { title = value; } }
            public string Author { get { return author; } set { author = value; } }
            public bool IsOnLoan { get { return isOnLoan; } set { isOnLoan = value; } }
            public static bool operator == (Book book1, Book book2)
            {
                return ((book1.title == book2.title) && (book1.author == book2.author));
            }
            public static bool operator != (Book book1, Book book2)
            {
                return !(book1 == book2); // negates the result of the == operator
            }
        }
        class FictionBook : Book
        {
            protected string genre = "Unknown";
            public FictionBook() { } // default constructor
            public FictionBook(string title, string author, bool isOnLoan, string genre) : base(title, author, isOnLoan)
            {
                this.genre = genre;
            }
            public string Genre { get { return genre; } set { genre = value; } }
            /*public static bool operator == (FictionBook book1, FictionBook book2)
            {
                bool result = (Book)book1 == (Book)book2 && book1.genre == book2.genre;
                return result;
            } // checks through upcasting
            public static bool operator != (FictionBook book1, FictionBook book2)
            {
                return !(book1 == book2); // negates the result of the == operator
            }*/  // Может лишнее. Уточнить!
        }
        
        class ReferenceBook : Book
        {
            protected bool canBeLend = false;
            public ReferenceBook() { } // default constructor
            public ReferenceBook(string title, string author, bool isOnLoan, bool canBeLend) : base(title, author, isOnLoan)
            {
                this.canBeLend = canBeLend;
            }
            public bool CanBeLend { get { return canBeLend; } set { canBeLend = value; } }
        }
        class Subscriber
        {
            private string subscriberName = "Unknown";
            private int subscriberId = 0;
            private int booksOnLoan = 0;
            public Subscriber() { } // default constructor
        }
        class Library
        {
            const int shelfLength = 5; // Перезаписать на 25!!
            Book[] books = new Book[shelfLength];
            Subscriber[] subscribers = new Subscriber[shelfLength];
            public Library() { } // default constructor
            public bool LookOnTheShelf(Book newBook)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] != null) 
                    {
                        break; // stops searching if we hit an empty slot
                    }
                    if (books[i] == newBook)
                    {
                        return true; // in case: book found
                    }
                }
                return false; // in case: book not found
            }
        }


            static void Main(string[] args)
        {

        }
    }
}
