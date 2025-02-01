using System.Globalization;
using System.IO;
using CsvHelper;
using System.Text.RegularExpressions;
using System;

namespace Assingment3
{
    internal class Program
    {
        // Tracks the execution time of a given method.
        public static TimeSpan Track_Time(Action method)
        {
            DateTimeOffset valBefore = (DateTimeOffset)DateTime.UtcNow; // Start time
            method();
            DateTimeOffset valAfter = (DateTimeOffset)DateTime.UtcNow; // End time
            TimeSpan val = valAfter - valBefore;  // Calculates elapsed time
            return val;
        }
        // Enum for user menu options.
        public enum ChooseMethod
        {
            InsertAll = 1,
            SearchByID,
            SearchByRgx,
            PrintAll,
            Delete,
            Exit
        }
        // Represents a book with ID, title, and author.
        public class Book
        {
            public Book(int id, string title, string author) 
            {
                ID = id;
                Title = title;
                Author = author;
            }
            public int ID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public override string ToString()
            {
                string info = "id: " + ID + " - " + Title + " by " + Author + ".";
                return info;
            }// Overriding ToString to display book information
        }
        // Prints a message when a search operation fails.
        private static void PrintNotFound()
        {
            Console.WriteLine($"Didn't find any book.");
        }
        // Reads data from the CSV file and inserts all records into a dictionary.
        public static void Dict_Insert_All(Dictionary<int, Book> My_dict)
        {
            Console.WriteLine("\n\nInserting Data to the Dictionary ...");
            // Reading csv file (insert all)
            try
            {
                // Creates an object that reads files
                using (StreamReader reader = new StreamReader("books.csv"))
                {
                    // Creates an object that use StrReader to read csv files
                    var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        int id = csv.GetField<int>("Id");
                        string title = csv.GetField<string>("Title");
                        string author = csv.GetField<string>("Author");

                        // Avoides duplicate IDs
                        if (!My_dict.ContainsKey(id))
                        {
                            My_dict.Add(id, new Book(id, title, author)); // Add book if ID is unique
                        }
                        else // Error message
                        {
                            Console.WriteLine($"Duplicate ID {id} found. Skipping entry.");
                        }
                    }
                    Console.WriteLine($"Number of objects added to the dictionary: {My_dict.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        // Reads data from the CSV file and inserts all records into a list.
        public static void List_Insert_All(List<Book> My_list)
        {
            Console.WriteLine("\n\nInserting Data to the List ...");
            // Reading csv file (insert all)
            try
            {
                // Creates an object that reads files
                using (StreamReader reader = new StreamReader("books.csv"))
                {
                    // Creates an object that use StrReader to read csv files
                    var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        int id = csv.GetField<int>("Id");
                        string title = csv.GetField<string>("Title");
                        string author = csv.GetField<string>("Author");

                        My_list.Add(new Book(id, title, author));
                    }
                    Console.WriteLine($"Number of objects added to the dictionary: {My_list.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        // Reads data from the CSV file and inserts all records into a hash set.
        public static void Set_Insert_All(HashSet<Book> My_set)
        {
            Console.WriteLine("\n\nInserting Data to the Set ...");
            // Reading csv file (insert all)
            try
            {
                // Creates an object that reads files
                using (StreamReader reader = new StreamReader("books.csv"))
                {
                    // Creates an object that use StrReader to read csv files
                    var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        int id = csv.GetField<int>("Id");
                        string title = csv.GetField<string>("Title");
                        string author = csv.GetField<string>("Author");

                        My_set.Add(new Book(id, title, author));
                    }
                    Console.WriteLine($"Number of objects added to the dictionary: {My_set.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        // Searches for a book in the dictionary by its ID and prints the book details.
        public static void Dict_Search_ID(int id, Dictionary<int, Book> My_dict)
        {
            Console.WriteLine($"\n\nSearching for ID {id} in the Dictionary ...");
            if (My_dict.ContainsKey(id)) 
            {
                Console.WriteLine(My_dict[id].ToString()); 
            }
            else 
            {
                PrintNotFound();
            } // In case didn't find
        }
        // Searches for a book in the list by its ID and prints the book details.
        public static void List_Search_ID(int id, List<Book> My_list)
        {
            Console.WriteLine($"\n\nSearching for ID {id} in the List ...");
            bool find = false;
            foreach (Book book in My_list)
            {
                if (book.ID == id) 
                { 
                    Console.WriteLine(book.ToString());
                    find = true;
                    break; 
                }
            }
            if (!find) 
            {
                PrintNotFound();
            } // In case didn't find
        }
        // Searches for a book in the hash set by its ID and prints the book details.
        public static void Set_Search_ID(int id, HashSet<Book> My_set)
        {
            Console.WriteLine($"\n\nSearching for ID {id} in the Set ...");
            bool find = false;
            foreach (Book book in My_set)
            {
                if (book.ID == id)
                {
                    Console.WriteLine(book.ToString());
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                PrintNotFound();
            } // In case didn't find
        }
        // Searches for books in the dictionary with titles matching a regular expression pattern.
        public static void Dict_Search_Rgx(Regex rgx, Dictionary<int, Book> My_dict)
        {
            Console.WriteLine($"\n\nSearching in the Dictionary for titles matching the pattern: \"{rgx}\" ...");
            int matchCount = 0;
            foreach (var book in My_dict)
            {
                if (rgx.IsMatch(book.Value.Title))
                {
                    Console.WriteLine(book.Value.ToString());
                    matchCount++;
                }
            }
            if (matchCount == 0)
            {
                PrintNotFound();
            } // In case didn't find
            else
            {
                Console.WriteLine($"\n{matchCount} matches found.");
            }
        }
        // Searches for books in the list with titles matching a regular expression pattern.
        public static void List_Search_Rgx(Regex rgx, List<Book> My_list)
        {
            Console.WriteLine($"\n\nSearching in the List for titles matching the pattern: \"{rgx}\" ...");
            int matchCount = 0;
            foreach (var book in My_list)
            {
                if (rgx.IsMatch(book.Title))
                {
                    Console.WriteLine(book.ToString());
                    matchCount++;
                }
            }
            if (matchCount == 0)
            {
                PrintNotFound();
            } // In case didn't find
            else
            {
                Console.WriteLine($"\n{matchCount} matches found.");
            }
        }
        // Searches for books in the hash set with titles matching a regular expression pattern.
        public static void Set_Search_Rgx(Regex rgx, HashSet<Book> My_set)
        {
            Console.WriteLine($"\n\nSearching in the Set for titles matching the pattern: \"{rgx}\" ...");
            int matchCount = 0;
            foreach (var book in My_set)
            {
                if (rgx.IsMatch(book.Title))
                {
                    Console.WriteLine(book.ToString());
                    matchCount++;
                }
            }
            if (matchCount == 0)
            {
                PrintNotFound();
            } // In case didn't find
            else
            {
                Console.WriteLine($"\n{matchCount} matches found.");
            }
        }
        // Prints all book records stored in the dictionary.
        public static void Dict_Print_All(Dictionary<int, Book> My_dict)
        {
            Console.WriteLine($"\n\nPrinting all records from the Dictionary ...");
            
            foreach (var book in My_dict)
            {
                Console.WriteLine(book.Value.ToString()); 
            }
        }
        // Prints all book records stored in the list.
        public static void List_Print_All(List<Book> My_list)
        {
            Console.WriteLine($"\n\nPrinting all records from the List ...");

            foreach (var book in My_list)
            {
                Console.WriteLine(book.ToString());
            }
        }
        // Prints all book records stored in the hash set.
        public static void Set_Print_All(HashSet<Book> My_set)
        {
            Console.WriteLine($"\n\nPrinting all records from the Set ...");

            foreach (var book in My_set)
            {
                Console.WriteLine(book.ToString());
            }
        }
        // Deletes a book from the dictionary by its ID.
        public static void Dict_Delete(int id, Dictionary<int, Book> My_dict)
        {
            Console.WriteLine($"\n\nDeleting the ID {id} from the Dictionary ...");
            if (My_dict.ContainsKey(id))
            {
                My_dict.Remove(id);
                Console.WriteLine("The book was deleted.");
            }
            else
            {
                PrintNotFound();
            } // In case didn't find
        }
        // Deletes a book from the list by its ID.
        public static void List_Delete(int id, List<Book> My_list)
        {
            Console.WriteLine($"\n\nDeleting the ID {id} from the List ...");
            bool find = false;
            foreach (Book book in My_list)
            {
                if (book.ID == id)
                {
                    My_list.Remove(book);
                    Console.WriteLine("The book was deleted.");
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                PrintNotFound();
            } // In case didn't find
        }
        // Deletes a book from the hash set by its ID.
        public static void Set_Delete(int id, HashSet<Book> My_set)
        {
            Console.WriteLine($"\n\nDeleting the ID {id} from the Set ...");
            bool find = false;
            foreach (Book book in My_set)
            {
                if (book.ID == id)
                {
                    My_set.Remove(book);
                    Console.WriteLine("The book was deleted.");
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                PrintNotFound();
            } // In case didn't find
        }
        static void Main(string[] args)
        {
            // Initialize data structures
            Dictionary<int, Book> My_dict = new Dictionary<int, Book>();
            List<Book> My_list = new List<Book>();
            HashSet<Book> My_set = new HashSet<Book>();

            Console.Write("Hello and welcome to Time Tracking Exercise.\n" +
                "Today we will track time for different methods\nusing 3 data structures: dictionary, list and hashset.\n");
            try
            {
                bool exit = false;
                Console.WriteLine("Which method time do you want to track?");
                while (!exit)
                {
                    // Display menu
                    foreach (var method in Enum.GetValues(typeof(ChooseMethod)))
                    {
                        Console.WriteLine($"{(int)method} - {method}");
                    }
                    Console.Write("\nMake your choice (1-6): ");

                    ChooseMethod choice;
                    while (!Enum.TryParse(Console.ReadLine(), out choice) || !Enum.IsDefined(typeof(ChooseMethod), choice))
                    {
                        Console.WriteLine("Invalid choice. Enter a number corresponding to method from the menu.");
                    } // Input validation

                    // Switch case for user choice
                    switch (choice)
                    {
                        case ChooseMethod.InsertAll:
                            Console.WriteLine($"\n ... Time Tracking for 'Insert All' Method ... \n");
                            TimeSpan dTime1 = Track_Time(() => Dict_Insert_All(My_dict));
                            TimeSpan lTime1 = Track_Time(() => List_Insert_All(My_list));
                            TimeSpan sTime1 = Track_Time(() => Set_Insert_All(My_set));
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"This method took {dTime1} seconds for the Dictionary");
                            Console.WriteLine($"This method took {lTime1} seconds for the List");
                            Console.WriteLine($"This method took {sTime1} seconds for the Set");
                            break;
                        case ChooseMethod.SearchByID:
                            Console.WriteLine($"\n ... Time Tracking for 'Search by ID' Method  ... \n");
                            int id;
                            while (true)
                            {
                                Console.Write("Please enter book ID: ");
                                if ((!int.TryParse(Console.ReadLine(), out id)) || (id <= 0))
                                {
                                    Console.WriteLine("Error: input needs to be a positive number");
                                }
                                else { break; }
                            }// Gets ID from User (with validation)
                            TimeSpan dTime2 = Track_Time(() => Dict_Search_ID(id, My_dict));
                            TimeSpan lTime2 = Track_Time(() => List_Search_ID(id, My_list));
                            TimeSpan sTime2 = Track_Time(() => Set_Search_ID(id, My_set));
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"This method took {dTime2} seconds for the Dictionary");
                            Console.WriteLine($"This method took {lTime2} seconds for the List");
                            Console.WriteLine($"This method took {sTime2} seconds for the Set");
                            break;
                        case ChooseMethod.SearchByRgx:
                            Console.WriteLine($"\n ... Time Tracking for 'Search by Rgx' Method ... \n");
                            string title_pattern = @"^\d+:\s*\d+$";
                            Regex rgx = new Regex(title_pattern);
                            TimeSpan dTime3 = Track_Time(() => Dict_Search_Rgx(rgx, My_dict));
                            TimeSpan lTime3 = Track_Time(() => List_Search_Rgx(rgx, My_list));
                            TimeSpan sTime3 = Track_Time(() => Set_Search_Rgx(rgx, My_set));
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"This method took {dTime3} seconds for the Dictionary");
                            Console.WriteLine($"This method took {lTime3} seconds for the List");
                            Console.WriteLine($"This method took {sTime3} seconds for the Set");
                            break;
                        case ChooseMethod.PrintAll:
                            Console.WriteLine($"\n ... Time Tracking for 'Print All' Method ... \n");
                            TimeSpan dTime4 = Track_Time(() => Dict_Print_All(My_dict));
                            TimeSpan lTime4 = Track_Time(() => List_Print_All(My_list));
                            TimeSpan sTime4 = Track_Time(() => Set_Print_All(My_set));
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"This method took {dTime4} seconds for the Dictionary");
                            Console.WriteLine($"This method took {lTime4} seconds for the List");
                            Console.WriteLine($"This method took {sTime4} seconds for the Set");
                            break;
                        case ChooseMethod.Delete:
                            Console.WriteLine($"\n ... Time Tracking for 'Delete' Method ... \n");
                            int delete_id;
                            while (true)
                            {
                                Console.Write("Please enter book ID: ");
                                if ((!int.TryParse(Console.ReadLine(), out delete_id)) || (delete_id <= 0))
                                {
                                    Console.WriteLine("Error: input needs to be a positive number");
                                }
                                else { break; }
                            }// Gets ID from User (with validation)
                            TimeSpan dTime5 = Track_Time(() => Dict_Delete(delete_id, My_dict));
                            TimeSpan lTime5 = Track_Time(() => List_Delete(delete_id, My_list));
                            TimeSpan sTime5 = Track_Time(() => Set_Delete(delete_id, My_set));
                            Console.WriteLine("\n\n");
                            Console.WriteLine($"This method took {dTime5} seconds for the Dictionary");
                            Console.WriteLine($"This method took {lTime5} seconds for the List");
                            Console.WriteLine($"This method took {sTime5} seconds for the Set");
                            break;
                        case ChooseMethod.Exit:
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
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
