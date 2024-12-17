using Microsoft.VisualBasic;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace C___lec7_exercises
{
    internal class Program
    {
        static int SortAges(Person person1, Person person2)
        {
            if (person1.Age < person2.Age)
            {
                return -1;
            } else if (person1.Age > person2.Age)
            {
                return 1;
            }
            else return 0;
        }
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
        class Pet
        {
            protected double weight = 0; // Default is 0.0; explicit for clarity.
            public Pet() { } // / Default constructor, no need to reinitialize weight
            public Pet(double weight) { this.weight = weight; }
            public override string ToString()
            {
                return $"This is a pet. Weight: {weight} kg.";
            }
            public virtual double Eat()
            {
                weight += 0.2;
                Console.WriteLine("The pet is eating.\nNow the weight is " + Math.Round(weight, 2) + " kg.");
                return weight;
            }
            public virtual void ShowJoy()
            {
                Console.WriteLine("The pet is happy.");
            }
            public double Weight { set { weight = value; } get { return weight; } }
            public double GetWeight() { return Math.Round(weight, 2); } // leaved that option, because it's different from the default
        }
        class Dog : Pet
        {
            protected string dogRace = "Unknown";
            public Dog() { }
            public Dog(double weight, string dogRace) : base(weight) // Calls Pet's constructor
            {
                this.dogRace = dogRace;
            }
            public override string ToString()
            {
                return $"This is a dog. Weight: {weight} kg. It's race is {dogRace}.";
            }
            public override double Eat()
            {
                weight += 0.32;
                Console.WriteLine("The dog is eating meat.\nNow the weight is " + Math.Round(weight, 2) + " kg.");
                return weight;
            }
            public override void ShowJoy()
            {
                Console.WriteLine("The dog is barking happily.");
            }
            public void HideBone()
            {
                Console.WriteLine("The dog is hiding a bone under the tree.");
            }
            public string DogRace { set { dogRace = value; } get { return dogRace; } }
        }
        class Cat : Pet
        {
            protected string catRace = "Unknown";
            public Cat() { }
            public Cat(double weight, string catRace) : base(weight) // Calls Pet's constructor
            {
                this.catRace = catRace;
            }
            public override string ToString()
            {
                return $"This is a cat. Weight: {weight} kg. It's race is {catRace}.";
            }
            public override double Eat()
            {
                weight += 0.15;
                Console.WriteLine("The cat is licking milk.\nNow the weight is " + Math.Round(weight, 2) + " kg.");
                return weight;
            }
            public override void ShowJoy()
            {
                Console.WriteLine("The cat is purring.");
            }
            public void Scratch()
            {
                Console.WriteLine("The cat is scratching a sofa");
            }
            public string CatRace { set { catRace = value; } get { return catRace; } }
        }
        class Fish : Pet
        {
            protected double fishLength = 0; // Default is 0.0; explicit for clarity.
            protected string fishColor = "Unknown";
            public Fish() { }
            public Fish(double weight, double fishLength, string fishColor) : base(weight) // Calls Pet's constructor
            {
                this.fishLength = fishLength;
                this.fishColor = fishColor;
            }
            public override string ToString()
            {
                return $"This is a fish. Weight: {weight} kg. Length: {fishLength}. It's color is {fishColor}.";
            }
            public override double Eat()
            {
                weight += 0.05;
                Console.WriteLine("The fish is eating seaweed.\nNow the weight is " + Math.Round(weight, 2) + " kg.");
                return weight;
            }
            public override void ShowJoy()
            {
                Console.WriteLine("The fish is remaining silent.");
            }
            public void MakeBubbles()
            {
                Console.WriteLine("The fish is making bubbles in the water.");
            }
            public double FishLength { set { fishLength = value; } get { return fishLength; } }
            public string FishColor { set { fishColor = value; } get { return fishColor; } }
        }
        class WebSites
        {
            Stack<string> webSites = new Stack<string>();
            public WebSites() { }
            public void EnterSite(string url) 
            { 
                webSites.Push(url);
            }
            public void BackButton()
            {
                if (webSites.Count != 0)
                {
                    Console.WriteLine("Last visited site: " + webSites.Pop());
                }
                else
                {
                    Console.WriteLine("No previous history.");
                }
                
            }
        }
        static void Main(string[] args)
        {
            // Ex.1
            // Create a queue of strings.
            // Insert several strings to the queue
            // Iterate over the queue and print all values.

            Console.WriteLine("\n\n - Ex.1 - \n\n");

            Queue<string>rainbow = new Queue<string>();
            rainbow.Enqueue("red");
            rainbow.Enqueue("orange");
            rainbow.Enqueue("yellow");
            rainbow.Enqueue("green");
            rainbow.Enqueue("blue");
            rainbow.Enqueue("indigo");
            rainbow.Enqueue("violet");
            
            foreach (string color in rainbow)
            {
                Console.WriteLine($"{color}");
            }// iterating over the queue without losing values

            // Ex.2
            // Create a queue of people waiting for the doctor.
            // Each object in the queue will be of class Person.
            // Insert several people waiting for the doctor.
            // Remove people from the queue and choose
            // which doctor they should go to according to
            // age-under 18 to pediatrician, 18 and over to general physician.
            // Print the details of each person along with the doctor they should go to.
                        
            Console.WriteLine("\n\n - Ex.2 - \n\n");
            Queue<Person> lineToDoctor = new Queue<Person>();
            lineToDoctor.Enqueue(new Person("Dasha", "Star", 24, 169));
            lineToDoctor.Enqueue(new Person("Vitalik", "Svetov", 13, 155));
            lineToDoctor.Enqueue(new Person("Alex", "Johnson", 56, 173.7));

            while (lineToDoctor.Count > 0)
            {
                Person person = lineToDoctor.Dequeue();
                if (person.Age < 18)
                {
                    Console.WriteLine(person.ToString() + "\nPlease, proceed to pediatricion.\n");
                }
                else
                {
                    Console.WriteLine(person.ToString() + "\nPlease, proceed to general physician.\n");
                }
            }

            // Ex.3
            // Create a stack of Pets.
            // Insert several pets to the stack
            // Iterate over the stack and print all values
            // Insert several pets of a specific type - Dog, Mammal..
            // Print specific information relevant to them.

            Console.WriteLine("\n\n - Ex.3 - \n\n");
            Stack<Pet> zoo = new Stack<Pet>();
            zoo.Push(new Dog(3.5, "Saint Bernard"));
            zoo.Push(new Cat(2.7, "Maine Coon"));
            zoo.Push(new Fish(0.5, 100, "white-orange"));
            zoo.Push(new Pet());

            foreach (Pet p in zoo)
            {
                Console.WriteLine(p.ToString() + "\n");
            }

            foreach (Pet p in zoo)
            {
                if (p is Dog pDog)
                {
                    pDog.HideBone();
                    pDog.ShowJoy();
                    Console.WriteLine("");
                }
                else if (p is Fish pFish)
                {
                    pFish.MakeBubbles();
                    pFish.ShowJoy();
                    Console.WriteLine("");
                }
                else if (p is Cat pCat)
                {
                    pCat.Scratch();
                    pCat.ShowJoy();
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("This is just a pet.");
                    p.ShowJoy();
                    Console.WriteLine("");
                }
            }

            // Ex.4
            // Implement the web site stack storage.
            // E.g – ‘http://www.cnn.com’
            // Insert several web sites urls.
            // Implement the back button as a function.
            // It will get the website last visited and displays it.

            Console.WriteLine("\n\n - Ex.4 - \n\n");
            WebSites webSites = new WebSites();
            webSites.EnterSite("https://en.wikipedia.org/wiki/Wiki");
            webSites.EnterSite("http://www.cnn.com");
            webSites.EnterSite("https://www.bbc.com");
            webSites.EnterSite("https://www.netflix.com/il/");

            for (int i = 0; i < 5; i++)
            {
                webSites.BackButton();
            }

            // Ex.5
            // Create a list of strings.
            // Insert several strings to the list
            // Iterate over the list and print all values.

            Console.WriteLine("\n\n - Ex.5 - \n\n");
            List<string> week = new List<string>() { "Monday", "Tuesday", "Wednesday" };
            week.Add("Thursday");
            week.Add("Friday");
            string[] weekend = new string[2] { "Saturday", "Sunday" };
            week.AddRange(weekend);

            foreach (string day in week)
            {
                Console.Write(day + " ");
            }

            // Ex.6
            // Create a list of People.
            // Each object in the list will be of class Person.
            // Insert several people to the list.
            // Sort the list based on age of the people

            // In order to sort based on age, create a method
            // which gets two person objects and returns -1
            // if first person is younger than second person, 1
            // if first person is older than second person and 0
            // if they are the same age.
            
            Console.WriteLine("\n\n - Ex.6 - \n\n");

            List<Person> people = new List<Person>();
            people.Add(new Person("Emily", "Thompson", 17, 165.5));
            people.Add(new Person("Lucas", "Bennett", 27, 180));
            people.Add(new Person("Sophie", "Martinez", 24, 170));
            
            Console.WriteLine("\nBefore Sort:\n");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
            people.Sort(SortAges);

            Console.WriteLine("\nAfter Sort:\n");
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
