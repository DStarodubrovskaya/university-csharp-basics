using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace Assignment1
{
    internal class Program
    {
        // Defines the set of actions available in the library system
        enum LibraryActions
        {
            AddBook = 1,
            AddSubscriber,
            LoanBook,
            ReturnBook,
            DisplayAllBooks,
            DisplayBooksByGenre,
            DisplaySubscriberBooks,
            Exit
        }
        static void Main(string[] args)
        {
            // Set console encoding to UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Library library = new Library();

            Console.WriteLine("Hail and well met! Welcome to our Library.");

            bool exit = false;
            try
            {

                while (!exit)
                {
                    Console.WriteLine("\nWhat would you like to do?\n\n" +
                        "Here is our menu:");
                    foreach (var action in Enum.GetValues(typeof(LibraryActions)))
                    {
                        Console.WriteLine($"{(int)action} - {action}");
                    }

                    Console.Write("\nEnter your choice (1-8): ");

                    LibraryActions choice;
                    while (!Enum.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(LibraryActions), choice))
                    {
                        Console.WriteLine("Invalid choice. Enter a number corresponding to an action from the menu.");
                    } // input validation

                    switch (choice)
                    {
                        case LibraryActions.AddBook:
                            Console.WriteLine("\n\n - Adding a book. - \n\n");
                            library.AddBook();// calls the method
                            break;// Add a book
                        case LibraryActions.AddSubscriber:
                            Console.WriteLine("\n\n - Adding a subscriber. - \n\n");
                            library.AddSubscriber();
                            break;// Add a subcriber                  
                        case LibraryActions.LoanBook:
                            Console.WriteLine("\n\n - Borrowing a book. - \n\n");
                            library.LoanBook();// calls the method

                            break;// Borrow a book
                        case LibraryActions.ReturnBook:
                            Console.WriteLine("\n\n - Returning a book. - \n\n");
                            library.ReturnBook();// calls the method
                            break;// Return a book
                        case LibraryActions.DisplayAllBooks:
                            Console.WriteLine("\n\n - Displaying all books. - \n\n");

                            library.DisplayAllBooks();
                            break;// Display all
                        case LibraryActions.DisplayBooksByGenre:
                            Console.WriteLine("\n\n - Displaying books by genre. - \n\n");
                            library.DisplayByGenre();
                            break;// Display by genre
                        case LibraryActions.DisplaySubscriberBooks:
                            Console.WriteLine("\n\n - Displaying subscriber's books. - \n\n");
                            library.DisplaySubBooks();
                            break;// Display subscriber's books
                        case LibraryActions.Exit:
                            Console.WriteLine("\n\n - Exiting the system. - \n\n");
                            Console.WriteLine("Goodbye :)");
                            exit = true;
                            break;// Exit
                    }
                    if (!exit)
                    {
                        Console.WriteLine("\nPress 'Enter' to continue.");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
