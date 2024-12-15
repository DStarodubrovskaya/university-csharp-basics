namespace Assignment1
{
    internal class Program
    {
        class Book
        {
            protected string title = "Unknown";
            protected string author = "Unknown";
            protected bool isLoaned = false;
            public Book() { } // default constructor
            public Book(string title, string author, bool isLoaned)
            {
                this.title = title;
                this.author = author;
                this.isLoaned = isLoaned;
            }
            public string Title { get { return title; } set { title = value; } }
            public string Author { get { return author; } set { author = value; } }
            public bool IsLoaned { get { return isLoaned; } set { isLoaned = value; } }
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
            public FictionBook(string title, string author, bool isLoaned, string genre) : base(title, author, isLoaned)
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
            protected bool availableForLoan = false;
            public ReferenceBook() { } // default constructor
            public ReferenceBook(string title, string author, bool isLoaned) : base(title, author, isLoaned) {}
            public bool AvailableForLoan { get { return availableForLoan; } set { availableForLoan = value; } }
        }
        class Subscriber
        {
            private string subscriberName = "Unknown";
            private int subscriberId = 0;
            private int booksLoaned = 0;
            public Subscriber(string name, int id) 
            {
                this.subscriberName = name;
                this.SubscriberId = id;
            } 
            public string SubscriberName { get { return subscriberName; } set { subscriberName = value; } }
            public int SubscriberId { get { return subscriberId; } set { subscriberId = value; } }
            public int BooksLoaned { get { return booksLoaned; } set { booksLoaned = value; } }
        }
        class Library
        {
            private const int maxLength = 4; // Перезаписать на 25!!

            private Book[] books = new Book[maxLength];
            private int bookCount = 0; // tracks the number of books

            Subscriber[] subscribers = new Subscriber[maxLength];
            private int subCount = 0; // tracks the number of subscribers
            public Library() { } // default constructor
            public int LookOnTheShelf(string title, string author)
            {
                for (int i = 0; i < bookCount; i++)
                {  
                    if ((books[i].Title.ToLower() == title.ToLower()) && (books[i].Author.ToLower() == author.ToLower()))
                    {
                        return i; // in case: book found
                    }
                }
                return -1; // in case: book not found
            }
            public int CheckTheList(int id)
            {
                for (int i = 0; i < subCount; i++)
                {
                    if ((subscribers[i].SubscriberId == id))
                    {
                        return i; // in case: subscriber found
                    }
                }
                return -1; // in case: subscriber not found
            }
            public string WhatKind()
            {
                Console.Write("Is it a fiction or reference book? ");

                while (true)
                {
                    string kind = Console.ReadLine();
                    if (kind.ToLower() != "reference" && kind.ToLower() != "fiction")
                    {
                        Console.WriteLine("Wrong input. Please enter 'fiction' or 'reference'");
                    }
                    else
                    {
                        return kind;
                    }
                }
            }
            public void AddBook(string title, string author)
            {
                if (LookOnTheShelf(title, author) != -1)
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
                        string kind = WhatKind();

                        if (kind.ToLower() == "fiction")
                        {
                            Console.WriteLine("What is the genre of this book?");
                            string genre = Console.ReadLine();
                            books[bookCount] = new FictionBook(title, author, false, genre);
                            bookCount++;
                            Console.WriteLine("Success! New book was added to the library.");
                        }
                        else if (kind.ToLower() == "reference")
                        {
                            books[bookCount] = new ReferenceBook(title, author, false);
                            Console.WriteLine("Is it available for loan? - Y/N?");
                            string availability = Console.ReadLine();

                            if (books[bookCount] is ReferenceBook referenceBook) // Checks if the cast was successful
                            {
                                if (availability.ToLower() == "y")
                                {
                                    referenceBook.AvailableForLoan = true;
                                }
                            }

                            bookCount++;
                            Console.WriteLine("Success! New book was added to the library.");
                        }
                    }
                }
            }
            public void AddSubscriber(Subscriber newSub)
            {
                if (CheckTheList(newSub.SubscriberId) != -1)
                {
                    Console.WriteLine("Subscriber with this ID already exists in the system.");
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
            public void LoanBook(int id, string title, string author)
            {
                int subPlace = CheckTheList(id);
                int bookPlace = LookOnTheShelf(title, author);
                if (subPlace == -1)
                {
                    Console.WriteLine("Sorry, this subscriber does not exist.\nWould you like to create an account?");
                }
                else if (bookPlace == -1)
                {
                    Console.WriteLine("Sorry, this book does not exist in the library.");
                }
                else if ((books[bookPlace].IsLoaned) ||
                    ((books[bookPlace] is ReferenceBook referenceBook) && (!referenceBook.AvailableForLoan)))
                {
                    Console.WriteLine("Sorry, book is unavailable for loan.");
                }
                else if (subscribers[subPlace].BooksLoaned >= 3)
                {
                    Console.WriteLine("This subscriber has maximum number of allowed books on loan.");
                }
                else
                {
                    Console.WriteLine("Success! Enjoy your book.");
                    books[bookPlace].IsLoaned = true;
                    subscribers[subPlace].BooksLoaned++;
                }     
            }
            public void ReturnBook(int id, string title, string author)
            {
                int subPlace = CheckTheList(id);
                int bookPlace = LookOnTheShelf(title, author);
                if (subPlace == -1)
                {
                    Console.WriteLine("Sorry, this subscriber does not exist.\nWould you like to create an account?");
                }
                else if (bookPlace == -1)
                {
                    Console.WriteLine("Sorry, this book does not exist in the library.");
                }
                else if ((books[bookPlace] is ReferenceBook referenceBook) && (!referenceBook.AvailableForLoan))
                {
                    Console.WriteLine("Error, you're trying to return a book that is unavailable for loan.");
                }
                else if (!books[bookPlace].IsLoaned)
                {
                    Console.WriteLine("This book is not currently on loan.");
                }
                else
                {
                    Console.WriteLine("Success! Thank thee for returning it.");
                    books[bookPlace].IsLoaned = false;
                    subscribers[subPlace].BooksLoaned--;
                }
            }
        }

        static void Main(string[] args)
        {
            // Set console encoding to UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Library library = new Library();

            Console.WriteLine("Hail and well met! Welcome to our Library.");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nWhat would you like to do?\n\n" +
                    "Here is our menu:");
                Console.WriteLine
                    ("1 - Add a new book.\n" +
                    "2 - Add a new subscriber.\n" +
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
                        Console.Write("Please enter a title of the book: ");
                        string title = Console.ReadLine();
                        Console.Write("Please enter the author's name: ");
                        string author = Console.ReadLine();
                        
                        library.AddBook(title, author);

                        break;
                    case 2:
                        Console.WriteLine("\n\n - Adding a subscriber. - \n\n");
                        Console.Write("Please enter a name: ");
                        string name = Console.ReadLine();
                        Console.Write("Please enter an id: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Please enter a number value");
                        }

                        Subscriber newSub = new Subscriber(name, id);
                        library.AddSubscriber(newSub);
                        break;
                    case 3:
                        Console.WriteLine("\n\n - Borrowing a book. - \n\n");
                        Console.Write("Please enter a title of the book: ");
                        string titleB = Console.ReadLine();
                        Console.Write("Please enter the author's name: ");
                        string authorB = Console.ReadLine();
                        Console.Write("Please enter an id: ");
                        int idB;
                        while (!int.TryParse(Console.ReadLine(), out idB))
                        {
                            Console.WriteLine("Please enter a number value");
                        }
                        library.LoanBook(idB, titleB, authorB);
                        break;
                    case 4:
                        Console.WriteLine("\n\n - Returning a book. - \n\n");
                        Console.Write("Please enter a title of the book: ");
                        string titleR = Console.ReadLine();
                        Console.Write("Please enter the author's name: ");
                        string authorR = Console.ReadLine();
                        Console.Write("Please enter an id: ");
                        int idR;
                        while (!int.TryParse(Console.ReadLine(), out idR))
                        {
                            Console.WriteLine("Please enter a number value");
                        }
                        library.ReturnBook(idR, titleR, authorR);
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
