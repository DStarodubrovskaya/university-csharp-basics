﻿namespace C___lec4_exercises
{
    internal class Program
    {
        class Book
        {
            protected int current_page = 0, total_pages = 0;
            protected string title = "Unknown";
            public Book() { }
            public Book(int currentpage, int total_pages, string title)
            {
                this.current_page = currentpage;
                this.total_pages = total_pages;
                this.title = title;
            }
            public int GetCurrentPage() { return current_page; }
            public void SetCurrentPage(int currentpage) { this.current_page = currentpage; }
            public int GetTotalPages() { return total_pages; }
            public void SetTotalPages(int total_pages) { this.total_pages = total_pages; }
            public string GetTitle() { return title; }
            public void SetTitle(string title) { this.title = title; }
            public override string ToString()
            {
                return $"The book title is -{title}- and it has {total_pages} pages.\n" +
                    $"You're on the {current_page} page. Enjoy :)";
            }
            public virtual int TurnPage(int number)
            {
                current_page += number;
                Console.WriteLine("You are reading and turning pages.\nNow you're on the " +  current_page + " page.");
                return current_page;
            }
        }
        class PaperBook : Book
        {
            bool softCover = false;
            public PaperBook() { }
            public PaperBook(bool softCover, int currentpage, int total_pages, string title) : base(currentpage, total_pages, title)
            {
                this.softCover = softCover; 
            }
            public bool GetSoftCover() {  return softCover; }
            public void SetSoftCover(bool softCover) { this.softCover = softCover; }
            public override string ToString()
            {   
                return $"{base.ToString()}\nIs the book cover Soft? Answer: {softCover}.";
            }
            public override int TurnPage(int number)
            {
                current_page += number;
                Console.WriteLine("\nThe pages of the book rustle quietly under your fingers.\n" +
                    "Now you're on the " + current_page + " page.");
                return current_page;
            }
        }
        class DigitalBook : Book
        {
            protected double file_size;
            public DigitalBook() { }
            public DigitalBook(double file_size, int currentpage, int total_pages, string title) : base(currentpage, total_pages, title)
            {
                this.file_size = file_size;
            }
            public double GetFileSize() { return file_size; }
            public void SetFileSize(double file_size) { this.file_size = file_size; }
            public override string ToString()
            {
                return $"{base.ToString()}\nOh, and the file_size is: {file_size}.";
            }
            public override int TurnPage(int number)
            {
                current_page += number;
                Console.WriteLine("\nTime flies while you read and you are already on the " + current_page + " page.");
                return current_page;
            }
        }
        class Pet
        {
            protected double weight = 0; // Default is 0.0; explicit for clarity.
            public Pet() { } // / Default constructor, no need to reinitialize weight
            public Pet(double weight) { this.weight = weight; }
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
            public void SetWeight(double weight) { this.weight = weight; }
            public double GetWeight() { return Math.Round(weight, 2); }
        }
        class Dog : Pet
        {
            protected string dogRace = "Unknown";
            public Dog() { }
            public Dog(double weight, string dogRace) : base(weight) // Calls Pet's constructor
            {
                this.dogRace = dogRace;
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
            public void SetDogRace(string dogRace) { this.dogRace = dogRace; }
            public string GetDogRace() { return this.dogRace; }
        }
        class Cat : Pet
        {
            protected string catRace = "Unknown";
            public Cat() { }
            public Cat(double weight, string catRace) : base(weight) // Calls Pet's constructor
            {
                this.catRace = catRace;
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
            public void SetCatRace(string catRace) { this.catRace = catRace; }
            public string GetCatRace() { return this.catRace; }
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
            public void SetFishLength(double fishLength) { this.fishLength = fishLength; }
            public double GetFishLength() { return this.fishLength; }
            public void SetFishColor(string fishColor) { this.fishColor = fishColor; }
            public string GetFishColor() { return this.fishColor; }
        }

        static void Main(string[] args)
        {

            /* Ex.1: In method Main, Create objects of Pet, Dog and Fish
             * and call the method Eat() on each one.
             * Print the weight of each animal before and after calling Eat(). */
            Console.WriteLine("\n\n  - Ex.1 -\n\n");

            Pet[] zoo = new Pet[5];
            zoo[0] = new Pet();
            zoo[1] = new Dog();
            zoo[2] = new Cat();
            zoo[3] = new Fish();
            zoo[4] = new Pet(0.001);

            Console.WriteLine("Welcome to the Zoo!");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\n  The {i + 1} pet info:");
                Console.WriteLine("The current weight is " + zoo[i].GetWeight() + " kg");
                zoo[i].Eat();
                zoo[i].ShowJoy();
            }

            /* Ex.2: Define a Pet object and create a new Dog object.
             * Use different methods on the new object.
             * Cast the object to Dog using AS or IS and then use the different methods.
             * Define a Fish object and create a new Pet object.
             * Use different methods on the new object.*/
            Console.WriteLine("\n\n  - Ex.2 -\n\n");

            Pet newYearGift = new Dog(2.5, "Corgi");
            Console.WriteLine("The current weight is " + newYearGift.GetWeight() + " kg");
            newYearGift.ShowJoy();
            newYearGift.Eat();

            Console.WriteLine("\n .. Wait! Downcasting is happening. .. \n");

            if (newYearGift is Dog)     // downcasting
            {
                Dog Sharik = (Dog)newYearGift;
                Console.WriteLine("The current weight is " + Sharik.GetWeight() + " kg");
                Sharik.ShowJoy();
                Sharik.Eat();
                Sharik.HideBone();
            }
            else
            {
                Console.WriteLine("The pet isn't a dog.");
            }

            Console.WriteLine(" ");
            Fish Nemo = new Fish(0.01, 150, "orange");
            Nemo.MakeBubbles();
            Console.WriteLine("The fish has a beautiful " + Nemo.GetFishColor() + " color.");
            Console.WriteLine("The current weight is " + Nemo.GetWeight() + " kg");
            Nemo.Eat();
            Nemo.ShowJoy();

            Console.WriteLine("\n .. Wait! Upcasting is happening. .. \n");

            Pet nemoThePet = Nemo;     // upcasting
            Console.WriteLine("The current weight is " + nemoThePet.GetWeight() + " kg");
            nemoThePet.Eat();
            nemoThePet.ShowJoy();

            /* Ex.3: For the Book, DigitalBook, PaperBook classes you created:
             * In each of the classes override the method ToString(),
             * so that it returns a string containing the attributes names and values.
             * Change the turn_page methods in class Book to virtual.
             * In some of the derived classes, override the method with a different
             * implementation which is specific to the derived class.
             * Call the method on the different objects you created
             * and print the current page.*/
            Console.WriteLine("\n\n  - Ex.3 -\n\n");

            Book book = new Book(100, 450, "Harry Potter");
            PaperBook bookPaper = new PaperBook(true, 10, 600, "Dark Tower");
            DigitalBook bookDigitalBook = new DigitalBook(124.5, 33, 370, "Gone with the wind");
            Console.WriteLine(book.ToString());
            Console.WriteLine($"\n{bookPaper.ToString()}");
            Console.WriteLine($"\n{bookDigitalBook.ToString()}");

            Console.WriteLine("\n.. Let's read ..\n");
            book.TurnPage(15);
            bookPaper.TurnPage(11);
            bookDigitalBook.TurnPage(30);
        }
    }
}
