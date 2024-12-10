namespace C___lec6_exercises
{
    internal class Program
    {
        class Person
        {
            private string first_name = "Unknown";
            private string last_name = "Unknown";
            private int age = 0;
            private double height = 0; 
            public Person() { }
            public Person(string first_name, string last_name, int age, double height)
            {
                this.first_name = first_name;
                this.last_name = last_name;
                this.age = age;
                this.height = height;
            }
            // Overrides ToString() to provide a meaningful string representation
            public override string ToString()
            {
                return $"{first_name} {last_name}, Age: {age}, Height: {height} cm";
            }
            public string FirstName { get { return first_name; } set { this.first_name = value; } }
            public string LastName { get { return last_name; } set { this.last_name = value; } }
            public int Age { get { return age; } set { this.age = value; } }
            public double Height { get { return height; } set { this.height = value; } }
        }
        static void Main(string[] args)
        {

            //Ex.1
            // Create a dictionary of countries and their cities
            Console.WriteLine("\n\n - Ex.1 - \n\n");

            // Initialize the dictionary with country names as keys and city names as values (separated by commas)
            Dictionary<string,string> Countries = new Dictionary<string,string>();
            Countries.Add("Israel", "Tel Aviv");
            Countries.Add("Russia", "Moscow");
            Countries.Add("Ireland", "Dublin");
            Countries["Canada"] = "Toronto";

            // Iterate over the dictionary and print the keys and values
            Console.WriteLine("The first way of iteration:");
            foreach (KeyValuePair<string, string> country in Countries) {
                Console.WriteLine("{1} is in {0}", country.Key, country.Value);
            } // the first way

            Console.WriteLine("\nThe second way of iteration:");
            foreach (var country in Countries) { 
                Console.Write(country.Value + " is in ");
                Console.WriteLine(country.Key);
            } // the second way

            //Ex.2
            // Create a dictionary of people with an identifier as the key and a Person object as the value
            Console.WriteLine("\n\n - Ex.2 - \n\n");

            // Initialize the dictionary with IDs as keys and Person objects as values
            Dictionary<int, Person> People = new Dictionary<int, Person>()
            {
                {1, new Person("Masha", "Sokolova", 13, 164.5) },
                {2, new Person("Sveta", "Volkov", 52, 163) },
            };
            // Add more entries to the dictionary
            Person newPerson = new Person(); 
            People.Add(3, newPerson); // Using Add() method
            People[4] = new Person("Pavel", "Seleznev", 33, 182); // Using indexer

            // Iterate over the dictionary and print the IDs and person information
            foreach (var person in People)
            {
                Console.WriteLine("ID: " + person.Key + ".\nMain info: " + (person.Value).ToString());
            }

            // Ex.3
            // Create a dictionary with Person objects as keys and strings as values
            Console.WriteLine("\n\n - Ex.3 - \n\n");

            // Initialize the dictionary with Person objects as keys and place names as values
            Dictionary<Person, string> Places = new Dictionary<Person, string>();

            // Add entries to the dictionary
            Places[new Person("Katya", "Starshov", 25, 172)] = "The First Place";
            Places[new Person("Luntic", "none", 1000, 100.5)] = "The Second Place";
            Places[new Person()] = "The Third Place";
            // Use the Keys property to get all keys in a dictionary
            Dictionary<Person, string>.KeyCollection keys = Places.Keys;

            // Iterate over the keys and print the key-value pairs
            foreach (Person key in keys)
            {
                Console.WriteLine($"Key: {key}, Value: {Places[key]}");
            }
        }
    }
}
