using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Library
    {
        Dictionary<int, Book> Bookshelf = new Dictionary<int, Book>(); // Stores all books
        Dictionary<int, Subscriber> Subscribers = new Dictionary<int, Subscriber>(); // Stores all subscribers
        HashSet<string> Genres = new HashSet<string>(); // Stores all genres
        public Library() { } // Empty constructor for initializing default values

        // Input validation: ID
        public int InputID()
        {
            int id = -1;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0 || id > 99999)
            {
                Console.WriteLine("Invalid input. Please enter a number up to 5 digits.");
            } // input validation
            return id;
        }

        // Input validation: Yes/No
        public bool InputYN()
        {
            bool answer;
            while (true)
            {
                string answerStr = Console.ReadLine().ToLower();
                if (answerStr == "y")
                {
                    answer = true;
                    break;
                }
                else if (answerStr == "n")
                {
                    answer = false;
                    break;
                }
                else
                {
                    Console.Write("Invalid input. Please enter 'Y' or 'N': ");
                }
            }// input validation
            return answer;
        }
        // Input validation: 1/2
        public int Input12()
        {
            int choice;
            while (true)
            {
                if ((int.TryParse(Console.ReadLine(), out choice)) && ((choice == 1) || (choice == 2)))
                {
                    break;
                }
                else { Console.WriteLine("Invalid input, please enter 1 or 2."); }
            } // input validation
            return choice;
        }

        // Adds a book to the library
        public void AddBook()
        {
            Console.Write("\nPlease enter Book id: ");
            int bookID = InputID();
            if (Bookshelf.ContainsKey(bookID))
            {
                Console.WriteLine("\nThis book already exists in the library.\n Would you like to add another one? -  Y/N? ");
                bool answer = InputYN();
                if (answer) { AddBook(); }
            } // If book already exist
            else
            {
                Console.Write("\nPlease enter a title of the book: ");
                string title = Console.ReadLine().ToLower().Trim();

                Console.Write("Please enter the author's name: ");
                string author = Console.ReadLine().ToLower().Trim();

                Console.WriteLine("Is it a fiction or reference book?\n" +
                "'fiction'  -  press 1\n'reference'  -  press 2");
                int choice = Input12();
                switch (choice)
                {
                    case 1:
                        Console.Write("What is the genre of this book? ");
                        string genre = Console.ReadLine().ToLower().Trim();

                        Bookshelf.Add(bookID, new FictionBook(bookID, title, author, genre));
                        Console.WriteLine("\nSuccess! New book was added to the library.");

                        Genres.Add(genre); // Adds the genre to the list of available genres

                        break; // If fiction
                    case 2:
                        Bookshelf.Add(bookID, new ReferenceBook(bookID, title, author));

                        Console.Write("Is it available for loan? - Y/N? ");

                        bool availability = InputYN();

                        if (Bookshelf[bookID] is ReferenceBook referenceBook) // checks if the cast was successful
                        {
                            if (availability)
                            {
                                referenceBook.AvailableForLoan = true;
                            }
                        }

                        Bookshelf[bookID].CopiesNum++;
                        Console.WriteLine("\nBook successfully added to the library.");
                        break; // If reference
                }

                Console.Write("How many copies of that book would you like to add? ");
                int numOfCopies = -1;
                while (true)
                {
                    if ((int.TryParse(Console.ReadLine(), out numOfCopies) && (numOfCopies > 0)))
                    {
                        Bookshelf[bookID].CopiesNum = numOfCopies;
                        Console.WriteLine($"You've entered {numOfCopies}.\nYour copies were added.\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error, the value needs to be a whole positive number.\n" +
                            "Try again.");
                    }
                } // input validation
                Console.Write("Would you like to add another book? - Y/N? ");
                bool answer = InputYN(); ;
                if (answer) { AddBook(); }
            } // input validation and adding the copies
        }

        // Adds a subscriber to the library
        public void AddSubscriber()
        {
            Console.Write("\nPlease enter Subscriber id: ");
            int id = InputID();
            if (Subscribers.ContainsKey(id))
            {
                Console.WriteLine("This subscriber already exists in our system.");
            }
            else
            {
                Console.Write("Please enter a name: ");
                string name = Console.ReadLine();
                Subscribers.Add(id, new Subscriber(name, id));
                Console.WriteLine("\nSuccess! New subscriber has been added to the system.");
            }
            Console.Write("Would you like to add another one? - Y/N? ");
            bool answer = InputYN();
            if (answer) { AddSubscriber(); }
        }

        // Loans a book to a subscriber
        public void LoanBook()
        {
            Console.Write("\nPlease enter Subscriber id: ");
            int idB = InputID();
            int bookIDB;

            if (!Subscribers.ContainsKey(idB))
            {
                Console.Write("\nSorry, this subscriber does not exist.\nWould you like to add one? - Y/N? ");
                bool answer = InputYN();
                if (answer) { AddSubscriber(); }
            }// Check if subscriber exists
            else if (Subscribers[idB].BooksLoaned >= 3)
            {
                Console.WriteLine("\nThis subscriber has maximum number of allowed books on loan.");
            }// Check if subscriber can loan
            else
            {
                Console.WriteLine("\nWhat information do you have about the book?\n" +
                    "'ID'  -  press 1\n'Name'  -  press 2");
                int choice = Input12();
                switch (choice)
                {
                    case 1:
                        Console.Write("\nPlease enter Book id: ");
                        bookIDB = InputID();
                        if (!Bookshelf.ContainsKey(bookIDB))
                        {
                            Console.WriteLine("\nSorry, this book does not exist in the library.");
                        }// Check if the book exists
                        else if (!(Bookshelf[bookIDB].CopiesNum > 0) ||
                        ((Bookshelf[bookIDB] is ReferenceBook referenceBook2) && (!referenceBook2.AvailableForLoan)))
                        {
                            Console.WriteLine("\nSorry, book is unavailable for loan.");
                        }// Check if available
                        else
                        {
                            Subscribers[idB].Books.Add(Bookshelf[bookIDB]);
                            Bookshelf[bookIDB].CopiesNum--;
                            Subscribers[idB].BooksLoaned++;
                            Console.WriteLine("\nSuccess! Enjoy your book.");
                        }// If success
                        break;// Loan using ID
                    case 2:
                        bookIDB = -1;
                        Console.Write("Please enter the book's Name: ");
                        string nameB = Console.ReadLine().ToLower().Trim();

                        Dictionary<int, Book> BooksUnderName = new Dictionary<int, Book>();
                        foreach (var book in Bookshelf)
                        {
                            if (book.Value.Title == nameB)
                            {
                                BooksUnderName.Add(book.Key, book.Value);
                            }
                        }// Looks for books with that name and Adds to the dictionary
                        if (BooksUnderName.Count == 0)
                        {
                            Console.WriteLine("\nSorry, this book does not exist in the library.");
                        }// If there are no books
                        else
                        {
                            if (BooksUnderName.Count > 1)
                            {
                                Console.WriteLine($"\nWe've found {BooksUnderName.Count} books under that name.\n" +
                                    $"Here is the list: ");

                                foreach (var book in BooksUnderName)
                                {
                                    Console.WriteLine($"ID: {book.Key} - {book.Value.ToString()}");
                                } // Display the list of books under that name

                                Console.WriteLine("\nWhat one of those do you choose to loan?\nEnter the id: ");
                                while (true)
                                {
                                    if ((int.TryParse(Console.ReadLine(), out bookIDB)) && (bookIDB >= 0 && bookIDB <= 99999))
                                    {
                                        if (!BooksUnderName.ContainsKey(bookIDB))
                                        {
                                            Console.WriteLine("Error, wrong ID. Try again.");
                                        }// Checks if the Id is in the new list
                                        else
                                        {
                                            Console.WriteLine($"You entered {bookIDB}");
                                            break;
                                        }// If success
                                    }
                                    else { Console.WriteLine("Error, the number needs to be up to 5 digits.\nTry again."); }
                                } // input validation
                            }// If there are more than one book under that name
                            if (bookIDB == -1)
                            {
                                bookIDB = BooksUnderName.First().Key;
                            } // If there is only one book under that name
                            if (!(Bookshelf[bookIDB].CopiesNum > 0) ||
                            ((Bookshelf[bookIDB] is ReferenceBook referenceBook) && (!referenceBook.AvailableForLoan)))
                            {
                                Console.WriteLine("\nSorry, book is unavailable for loan.");
                            } // If unavailable for loan
                            else
                            {
                                Subscribers[idB].Books.Add(Bookshelf[bookIDB]);
                                Bookshelf[bookIDB].CopiesNum--;
                                Subscribers[idB].BooksLoaned++;
                                Console.WriteLine("\nSuccess! Enjoy your book.");
                            } // If success
                        }
                        break;// Loan using Name
                }
            }
        }

        // Returns a book from a subscriber
        public void ReturnBook()
        {
            Console.Write("\nPlease enter Subscriber id: ");
            int idR = InputID();
            if (!Subscribers.ContainsKey(idR))
            {
                Console.WriteLine("\nSorry, this subscriber does not exist.\nWould you like to add one? - Y/N? ");
                bool answer = InputYN();
                if (answer) { AddSubscriber(); }
            } // If subscriber doesn't exist
            else if (Subscribers[idR].BooksLoaned == 0)
            {
                Console.Write("\nYou don't have any books yet. Would you like to loan one? - Y/N? ");
                bool answer = InputYN();
                if (answer) { LoanBook(); }
            } // If subscriber doesn't have any books
            else
            {
                Console.Write("\nPlease enter Book id: ");
                int bookIDR = InputID();
                if (!Bookshelf.ContainsKey(bookIDR))
                {
                    Console.WriteLine("\nSorry, this book does not exist in the library.");
                } // If book doesn't exist in the library
                else if ((Bookshelf[bookIDR] is ReferenceBook referenceBook) && (!referenceBook.AvailableForLoan))
                {
                    Console.WriteLine("\nError, you're trying to return a book that is unavailable for loan.");
                } // If book is unavailable for loan
                else if (!Subscribers[idR].Books.Contains(Bookshelf[bookIDR]))
                {
                    Console.WriteLine("\nThis book is not in your borrowed list. Please check and try again.");
                } // If book isn't under subscriber's name
                else
                {
                    Subscribers[idR].Books.Remove(Bookshelf[bookIDR]);
                    Bookshelf[bookIDR].CopiesNum++;
                    Subscribers[idR].BooksLoaned--;
                    Console.WriteLine("\nSuccess! Thank thee for returning it.");
                } // If success
            } // If subscriber exists and has books
        }

        // Displays all books in the library
        public void DisplayAllBooks()
        {
            if (Bookshelf.Count > 0)
            {
                Console.WriteLine("\nHere are all the books we have: ");
                foreach (KeyValuePair<int, Book> book in Bookshelf)
                {
                    Console.WriteLine("   " + book.Value.ToString());
                }
            }
            else
            {
                Console.Write("\nOur library doesn't have any books yet. Would you like to add one? - Y/N? ");
                bool answer = InputYN();
                if (answer) { AddBook(); }
            }
        }

        // Displays books by a specific genre
        public void DisplayByGenre()
        {
            if (Bookshelf.Count > 0)
            {
                Console.WriteLine("Here are all the genres we have: ");
                foreach (string item in Genres)
                {
                    Console.WriteLine($"{item}");
                } // Display a list of genres for user to choose from

                Console.Write("Please enter books of which genre would you like to display: ");
                string genre = Console.ReadLine().ToLower();

                if (Genres.Contains(genre))
                {
                    Console.WriteLine($"\nHere are the books of that genre:");
                    foreach (var book in Bookshelf)
                    {
                        if ((book.Value is FictionBook fictionbook) && (fictionbook.Genre == genre))
                        {
                            Console.WriteLine($"ID: {book.Key} - {book.Value.ToString()}");
                        }
                    }
                } // If there are books of that genre
                else
                {
                    Console.Write("\nSorry, our library doesn't have any books of that genre.\nWould you like to check another genre? - Y/N? ");
                    bool answer = InputYN();
                    if (answer) { DisplayByGenre(); }
                } // If there are no books of that genre
            }// If there are books in the library
            else
            {
                Console.Write("\nOur library doesn't have any books yet. Would you like to add one? - Y/N? ");
                bool answer = InputYN();
                if (answer) { AddBook(); }
            } // If there are no books in the library
        }

        // Display books associated with the subscriber
        public void DisplaySubBooks()
        {
            Console.Write("\nPlease enter Subscriber id: ");
            int id = InputID();
            if (!Subscribers.ContainsKey(id))
            {
                Console.WriteLine("\nSorry, this subscriber does not exist.\nWould you like to add one? - Y/N? ");
                bool answer = InputYN();
                if (answer) { AddSubscriber(); }
            }// Check if subscriber exists 
            else
            {
                if (Subscribers[id].Books.Count > 0)
                {
                    Console.WriteLine("\nHere are all the books you have: ");
                    foreach (var book in Subscribers[id].Books)
                    {
                        Console.WriteLine("   " + book.Title + " by " + book.Author);
                    }
                } // If subscriber has books 
                else
                {
                    Console.Write("\nYou don't have any books yet. Would you like to loan one? - Y/N? ");
                    bool answer = InputYN();
                    if (answer) { LoanBook(); }
                } // If subscriber doesn't have any books
            }
        }
    }
}
