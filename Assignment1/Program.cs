namespace Assignment1
{
    internal class Program
    {
        class Book
        {
            protected string title = "Unknown";
            protected string author = "Unknown";
            protected bool isLoaned = false;
            public Book() { } // Default constructor
            public Book(string title, string author, bool isLoaned)
            {
                this.title = title;
                this.author = author;
                this.isLoaned = isLoaned;
            }
            public string Title { get { return title; } set { title = value; } }
            public string Author { get { return author; } set { author = value; } }
            public bool IsLoaned { get { return isLoaned; } set { isLoaned = value; } }
            public override string ToString()
            {
                string info = title + " by " + author + ".";
                return info;
            }// Overriding ToString to display book information
            public static bool operator == (Book book1, Book book2)
            {
                return ((book1.title == book2.title) && (book1.author == book2.author));
            } 
            public static bool operator != (Book book1, Book book2)
            {
                return !(book1 == book2); // negates the result of the == operator
            }// Overloading the == and != operators to compare books
        }
        class FictionBook : Book
        {
            protected string genre = "Unknown";
            public FictionBook() { } // Default constructor
            public FictionBook(string title, string author, bool isLoaned, string genre) : base(title, author, isLoaned)
            {
                this.genre = genre;
            }
            public string Genre { get { return genre; } set { genre = value; } }
            public override string ToString()
            {
                string info = base.ToString() + " Fiction book."+ " Genre: " + genre + ".";
                if (isLoaned) { info += " Status: loaned."; } else { info += " Status: available."; }
                return info;
            }// Overriding ToString to display fiction book information
        }
        class ReferenceBook : Book
        {
            protected bool availableForLoan = false;
            public ReferenceBook() { } // Default constructor
            public ReferenceBook(string title, string author, bool isLoaned) : base(title, author, isLoaned) {}
            public bool AvailableForLoan { get { return availableForLoan; } set { availableForLoan = value; } }
            public override string ToString()
            {
                string info = base.ToString() + " Reference book.";
                if ((availableForLoan) && (!isLoaned))
                {
                    info += " Status: available.";
                }
                else if ((availableForLoan) && (isLoaned))
                { 
                    info += " Status: loaned.";
                }
                else 
                {
                    info += " Status: unavailable.";
                }
                return info;
            }// Overriding ToString to display reference book information
        }
        class Subscriber
        {
            private string subscriberName = "Unknown";
            private int subscriberId = 0;
            private int booksLoaned = 0; // Number of books currently loaned
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
            private const int maxLength = 25; // Maximum capacity of books and subscribers

            private Book[] books = new Book[maxLength];
            private int bookCount = 0; // Tracks the number of books

            Subscriber[] subscribers = new Subscriber[maxLength];
            private int subCount = 0; // Tracks the number of subscribers
            public Library() { } // Default constructor

            // Methods:
            // Find a book by title and author, returning its index
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
            // Find a subscriber by ID, returning their index
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
            // Checks if the library is full
            public bool IsLibraryFull()
            {
                if (bookCount >= maxLength)
                {
                    Console.WriteLine("\nThe library is full.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Checks if the subscriber list is full
            public bool IsListFull()
            {
                if (subCount >= maxLength)
                {
                    Console.WriteLine("\nSorry, our system is full.\nWe can't receive another subscriber.");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Determines the type of book: Fiction or Reference
            public string WhatKind()
            {
                Console.Write("Is it a fiction or reference book? ");

                while (true)
                {
                    string kind = Console.ReadLine().ToLower();
                    if (kind != "reference" && kind != "fiction")
                    {
                        Console.WriteLine("Wrong input. Please enter 'fiction' or 'reference'");
                    }
                    else
                    {
                        return kind;
                    }
                }// input validation
            }
            // Adds a book to the library
            public void AddBook(string title, string author)
            {
                if (LookOnTheShelf(title, author) != -1)
                {
                    Console.WriteLine("\nThis book already exists in the library.");
                }
                else
                { 
                    string kind = WhatKind();

                    if (kind.ToLower() == "fiction")
                    {
                        Console.Write("What is the genre of this book?");
                        string genre = Console.ReadLine().ToLower();
                        books[bookCount] = new FictionBook(title, author, false, genre);
                        bookCount++;
                        Console.WriteLine("\nSuccess! New book was added to the library.");
                    }
                    else if (kind.ToLower() == "reference")
                    {
                        books[bookCount] = new ReferenceBook(title, author, false);
                        Console.Write("Is it available for loan? - Y/N? ");

                        string availability;
                        while (true)
                        {
                            availability = Console.ReadLine().ToLower();
                            if ((availability != "y") && (availability != "n"))
                            {
                                Console.WriteLine("Wrong input.\nIs it available for loan? - Y/N? ");
                            }
                            else { break; }
                        }// input validation

                        if (books[bookCount] is ReferenceBook referenceBook) // checks if the cast was successful
                        {
                            if (availability == "y")
                            {
                                referenceBook.AvailableForLoan = true;
                            }
                        }

                        bookCount++;
                        Console.WriteLine("\nSuccess! New book was added to the library.");
                    }
                }
            }
            // Adds a subscriber to the library
            public void AddSubscriber(Subscriber newSub)
            {
                if (CheckTheList(newSub.SubscriberId) != -1)
                {
                    Console.WriteLine("\nSubscriber with this ID already exists in the system.");
                }
                else
                {
                    subscribers[subCount] = newSub;
                    subCount++;
                    Console.WriteLine("\nSuccess! New subscriber were added to the system.");   
                }
            }
            // Loans a book to a subscriber
            public void LoanBook(int id, string title, string author)
            {
                int subPlace = CheckTheList(id);
                int bookPlace = LookOnTheShelf(title, author);
                if (subPlace == -1)
                {
                    Console.WriteLine("\nSorry, this subscriber does not exist.");
                }
                else if (bookPlace == -1)
                {
                    Console.WriteLine("\nSorry, this book does not exist in the library.");
                }
                else if ((books[bookPlace].IsLoaned) ||
                    ((books[bookPlace] is ReferenceBook referenceBook) && (!referenceBook.AvailableForLoan)))
                {
                    Console.WriteLine("\nSorry, book is unavailable for loan.");
                }
                else if (subscribers[subPlace].BooksLoaned >= 3)
                {
                    Console.WriteLine("\nThis subscriber has maximum number of allowed books on loan.");
                }
                else
                {
                    Console.WriteLine("\nSuccess! Enjoy your book.");
                    books[bookPlace].IsLoaned = true;
                    subscribers[subPlace].BooksLoaned++;
                }     
            }
            // Returns a book from a subscriber
            public void ReturnBook(int id, string title, string author)
            {
                int subPlace = CheckTheList(id);
                int bookPlace = LookOnTheShelf(title, author);
                if (subPlace == -1)
                {
                    Console.WriteLine("\nSorry, this subscriber does not exist.");
                }
                else if (bookPlace == -1)
                {
                    Console.WriteLine("\nSorry, this book does not exist in the library.");
                }
                else if ((books[bookPlace] is ReferenceBook referenceBook) && (!referenceBook.AvailableForLoan))
                {
                    Console.WriteLine("\nError, you're trying to return a book that is unavailable for loan.");
                }
                else if (!books[bookPlace].IsLoaned)
                {
                    Console.WriteLine("\nThis book is not currently on loan.");
                }
                else
                {
                    Console.WriteLine("\nSuccess! Thank thee for returning it.");
                    books[bookPlace].IsLoaned = false;
                    subscribers[subPlace].BooksLoaned--;
                }
            }
            // Displays all books in the library
            public void DisplayAllBooks()
            {
                if (bookCount != 0)
                {
                    Console.WriteLine("\nHere are all the books we have: ");
                    for (int i = 0; i < bookCount; i++)
                    {
                        Console.WriteLine("   " + books[i].ToString());
                    }
                } else
                {
                    Console.WriteLine("\nOur library don't have any book yet. Would you like to add one?");
                }
        }
            // Displays books by a specific genre
            public void DisplayByGenre()
            {
                if (bookCount != 0)
                {
                    Console.Write("Please enter a genre: ");
                    string genre = Console.ReadLine().ToLower();
                    Console.WriteLine($"\nHere are the books of genre: {genre}");
                    for (int i = 0; i < bookCount; i++)
                    {
                        if ((books[i] is FictionBook fictionbook) && (fictionbook.Genre == genre))
                        Console.WriteLine("   " + books[i].ToString());
                    }
                }
                else
                {
                    Console.WriteLine("\nOur library don't have any book yet. Would you like to add one?");
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
                    Console.Write("\nEnter your choice (1-7): ");

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
                    } // input validation
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n\n - Adding a book. - \n\n");
                            
                            while (true)
                            {
                                if (library.IsLibraryFull())
                                {
                                    break;
                                }
                                Console.Write("\nPlease enter a title of the book: ");
                                string title = Console.ReadLine();
                                Console.Write("Please enter the author's name: ");
                                string author = Console.ReadLine();

                                library.AddBook(title, author);// calls the method

                                string input1;
                                Console.Write("\nWould you like to add another book? - Y/N? ");
                                while (true)
                                {
                                    input1 = Console.ReadLine().ToLower();
                                    if ((input1 != "y") && (input1 != "n"))
                                    {
                                        Console.WriteLine("Wrong input.\nWould you like to add another book? - Y/N?");
                                    }
                                    else 
                                    { 
                                        break;
                                    }
                                }// input validation
                                if (input1 == "n")
                                {
                                    break;
                                } // back to Main Menu
                            }
                            
                            break;// Add a book
                        case 2:
                            Console.WriteLine("\n\n - Adding a subscriber. - \n\n");

                            while (true)
                            {
                                if (library.IsListFull())
                                {
                                    break;
                                }
                                Console.Write("Please enter a name: ");
                                string name = Console.ReadLine();
                                Console.Write("Please enter an id: ");
                                int id;
                                while (!int.TryParse(Console.ReadLine(), out id))
                                {
                                    Console.WriteLine("Please enter a number value");
                                }// input validation

                                Subscriber newSub = new Subscriber(name, id);// calls the method
                                library.AddSubscriber(newSub);

                                string input2;
                                Console.Write("\nWould you like to add another subscriber? - Y/N? ");
                                while (true)
                                {
                                    input2 = Console.ReadLine().ToLower();
                                    if ((input2 != "y") && (input2 != "n"))
                                    {
                                        Console.WriteLine("Wrong input.\nWould you like to add another subscriber? - Y/N?");
                                    }
                                    else { break; }
                                } // input validation
                                if (input2 == "n")
                                {
                                    break;
                                }// back to Main Menu
                            }
                            break;// Add a subcriber
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
                            }// input validation

                            library.LoanBook(idB, titleB, authorB);// calls the method
                            break;// Borrow a book
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
                            }// input validation

                            library.ReturnBook(idR, titleR, authorR);// calls the method
                            break;// Return a book
                        case 5:
                            Console.WriteLine("\n\n - Displaying all books. - \n\n");

                            library.DisplayAllBooks();
                            break;// Display all
                        case 6:
                            Console.WriteLine("\n\n - Displaying books by genre. - \n\n");
                            library.DisplayByGenre();
                            break;// Display by genre
                        case 7:
                            Console.WriteLine("\n\n - Exiting the system. - \n\n");
                            Console.WriteLine("Goodbye :)");
                            exit = true;
                            break;// Exit
                    }
                    Console.WriteLine("\nPress 'Enter' to continue.");
                    Console.ReadLine();
                }
            }
        }
    }
}
