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
            public string SubscriberName { get { return subscriberName; } set { subscriberName = value; } }
            public int SubscriberId { get { return subscriberId; } set { subscriberId = value; } }
            public int BooksOnLoan { get { return booksOnLoan; } set { booksOnLoan = value; } }
        }
        class Library
        {
            private const int maxLength = 5; // Перезаписать на 25!!

            private Book[] books = new Book[maxLength];
            private int bookCount = 0; // tracks the number of books

            Subscriber[] subscribers = new Subscriber[maxLength];
            private int subCount = 0; // tracks the number of subscribers
            public Library() { } // default constructor
            public bool LookOnTheShelf(Book newBook)
            {
                for (int i = 0; i < bookCount; i++)
                {
                    if ((books[i] == newBook))
                    {
                        return true; // in case: book found
                    }
                }
                return false; // in case: book not found
            }
            public bool CheckTheList(Subscriber newSub)
            {
                for (int i = 0; i < subCount; i++)
                {
                    if ((subscribers[i].SubscriberId == newSub.SubscriberId))
                    {
                        return true; // in case: subscriber found
                    }
                }
                return false; // in case: subscriber not found
            }
            public void AddBook(Book newBook)
            {
                if (LookOnTheShelf(newBook))
                {
                    Console.WriteLine("This book already exists in the library.");
                }
                else
                {
                    if (bookCount >= maxLength)
                    {
                        Console.WriteLine("Sorry, the library is full.");
                    }
                    else
                    {
                        books[bookCount] = newBook;
                        bookCount++;
                        Console.WriteLine("Success! New book was added to the library.");
                    }
                }
            }
            public void AddSubscruber(Subscriber newSub)
            {
                if (CheckTheList(newSub))
                {
                    Console.WriteLine("Subscriber exists in the system.");
                }
                else
                {
                    if (subCount >= maxLength)
                    {
                        Console.WriteLine("Sorry, our system is full.\nWe can't receive another subscriber.");
                    }
                    else
                    {
                        subscribers[subCount] = newSub;
                        subCount++;
                        Console.WriteLine("Success! New subscriber were added to the system.");
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Library library = new Library();

            Console.WriteLine("Hello and welcome to our Library.");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nWhat would you like to do?\n\n" +
                    "Here is our menu:");
                Console.WriteLine
                    ("1 - Add a new book.\n" +
                    "2 - Add a new subcriber press.\n" +
                    "3 - Borrow a book.\n" +
                    "4 - Return a book.\n" +
                    "5 - Display all books.\n" +
                    "6 - Display books by genre.\n" +
                    "7 - Exit.");
                Console.WriteLine("Enter your choice (1-7):");

                int choice = -1;
                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Error, the value needs to be a whole number from 1 to 7.\n" +
                            "Try again.");
                    }
                    if (choice >= 1 && choice <= 7)
                    {
                        Console.WriteLine($"You've entered {choice}.\nLet's proceed.\n");
                        break;
                    }
                    else { Console.WriteLine("Error, the number needs to be from 1 to 7.\nTry again."); }
                }
                switch (choice)
                {
                    case 1: Console.WriteLine("\n\n - Adding a book. - \n\n");
                        // Here will be a code
                        break;
                    case 2:
                        Console.WriteLine("\n\n - Adding a subscriber. - \n\n");
                        // Here will be a code
                        break;
                    case 3:
                        Console.WriteLine("\n\n - Borrowing a book. - \n\n");
                        // Here will be a code
                        break;
                    case 4:
                        Console.WriteLine("\n\n - Returning a book. - \n\n");
                        // Here will be a code
                        break;
                    case 5:
                        Console.WriteLine("\n\n - Displaying all books. - \n\n");
                        // Here will be a code
                        break;
                    case 6:
                        Console.WriteLine("\n\n - Displaying books by genre. - \n\n");
                        // Here will be a code
                        break;
                    case 7:
                        Console.WriteLine("\n\n - Exiting the system. - \n\n");
                        Console.WriteLine("Goodbye :)");
                        exit = true;
                        break;
                }
                Console.WriteLine("Press 'Enter' to continue.");
                Console.ReadLine();
            }
        }
    }
}
