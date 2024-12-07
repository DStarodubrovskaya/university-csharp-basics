using System.Drawing;

namespace C___lec5_ex_interfaces
{
    internal class Program
    {   
        // pets
        interface IPet
        {
            public double Weight { get; set; }
            double Eat();
            void ShowJoy();
        }
        class Dog : IPet
        {
            protected string dogRace = "Unknown";
            public double Weight { get; set; } // has to be repeated from interface
            public Dog() { Weight = 0; } // default coinstructor with initialization
            public Dog(double weight, string dogRace)
            {
                this.Weight = weight;
                this.dogRace = dogRace;
            }
            public string DogRace { set { dogRace = value; } get { return dogRace; } }
            public double Eat()
            {
                Weight += 0.32;
                Console.WriteLine("The dog is eating meat.\nNow the weight is " + Math.Round(Weight, 2) + " kg.");
                return Weight;
            } // no need to override
            public void ShowJoy()
            {
                Console.WriteLine("The dog is barking happily.");
            } // no need to override
            public void HideBone()
            {
                Console.WriteLine("The dog is hiding a bone under the tree.");
            }
        }
        class Cat : IPet
        {
            protected string catRace = "Unknown";
            public double Weight { get; set; } // has to be repeated from interface
            public Cat() { Weight = 0; } // default coinstructor with initialization
            public Cat(double weight, string catRace)
            {   
                this.Weight = weight;
                this.catRace = catRace;
            }
            public double Eat()
            {
                Weight += 0.15;
                Console.WriteLine("The cat is licking milk.\nNow the weight is " + Math.Round(Weight, 2) + " kg.");
                return Weight;
            } // no need to override
            public void ShowJoy()
            {
                Console.WriteLine("The cat is purring.");
            } // no need to override
            public void Scratch()
            {
                Console.WriteLine("The cat is scratching a sofa");
            }
            public string CatRace { set { catRace = value; } get { return catRace; } }
        }
        class Fish : IPet
        {
            protected double fishLength = 0; // Default is 0.0; explicit for clarity.
            protected string fishColor = "Unknown";
            public double Weight { get; set; } // has to be repeated from interface
            public Fish() { Weight = 0; }
            public Fish(double weight, double fishLength, string fishColor) 
            {   
                this.Weight = weight;
                this.fishLength = fishLength;
                this.fishColor = fishColor;
            }
            public double Eat()
            {
                Weight += 0.05;
                Console.WriteLine("The fish is eating seaweed.\nNow the weight is " + Math.Round(Weight, 2) + " kg.");
                return Weight;
            } // no need to override
            public void ShowJoy()
            {
                Console.WriteLine("The fish is remaining silent.");
            } // no need to override
            public void MakeBubbles()
            {
                Console.WriteLine("The fish is making bubbles in the water.");
            }
            public double FishLength { set { fishLength = value; } get { return fishLength; } }
            public string FishColor { set { fishColor = value; } get { return fishColor; } }
        }

        // shapes
        interface ITwoDimShape 
        {
            public string Color { get; set; }
            double CalculateArea();
            double CalculatePerimeter();
            void DisplayDetails();
        }

        class Rectangle : ITwoDimShape
        {
            public Rectangle() { Width = 0; Height = 0; Color = "Blank"; }
            public Rectangle(double width = 0, double height = 0, string color = "Blank" )
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }
            public static Rectangle CreateFromUserInput()
            {
                Console.WriteLine("Ok, let's make a rectangle.\n" +
                "Please enter its width: ");
                double width;
                while (true)
                {
                    while (!double.TryParse(Console.ReadLine(), out width))
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                    break;
                }
                Console.WriteLine("Great! Now its height: ");
                double height;
                while (true)
                {
                    while (!double.TryParse(Console.ReadLine(), out height))
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                    break;
                }
                Console.WriteLine("Perfect! Last but not least, what color it will be?");
                string color = Console.ReadLine();

                return new Rectangle(width, height, color);
            }
            public string Color { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }

            public double CalculateArea()
            {
                double area = Width * Height;
                return area;
            }
            public double CalculatePerimeter()
            {
                double perimeter = 2 * (Width + Height);
                return perimeter;
            }
            public void DisplayDetails()
            {
                Console.WriteLine($"This is a rectangle.\nWidth = {Width}.\nHeight = {Height}.\nColor = {Color}.\n" +
                    $"Area = {Math.Round(CalculateArea(), 2)}.\nPerimeter = {Math.Round(CalculatePerimeter(), 2)}");
            }

        // here I want to compair their Perimeters and Areas. How to do that for all shapes?
    }


    class Circle : ITwoDimShape
    {
        public Circle() { Radius = 0; Color = "Blank"; }
        public Circle(double radius = 0, string color = "Blank" )
    {
        this.Radius = radius;
        this.Color = color;
    }
        public static Circle CreateFromUserInput()
            {
                Console.WriteLine("Let's make a circle.\nPlease enter its radius: ");
                double radius;
                while (true)
                {
                    while (!double.TryParse(Console.ReadLine(), out radius))
                    {
                        Console.WriteLine("Please enter a number.");
                    }
                    break;
                }
                Console.WriteLine("Ok, and what color it will be?");
                string color = Console.ReadLine();

                return new Circle(radius, color);
            }
        public string Color { get; set; }
        public double Radius { get; set; }

            public double CalculateArea()
            {
                double area = 3.14 * Radius * Radius;
                return area;
            }
            public double CalculatePerimeter()
            {
                double perimeter = 2 * 3.14 * Radius;
                return perimeter;
            }
            public void DisplayDetails()
            {
                Console.WriteLine($"This is a circle.\nRadius = {Radius}.\nColor = {Color}.\n" +
                    $"Area = {Math.Round(CalculateArea(), 2)}.\nPerimeter = {Math.Round(CalculatePerimeter(), 2)}");
            }
        }

static void Main(string[] args)
        {
            /*Ex.1: Create several objects of pets in class Main. 
            Console.WriteLine("\n\n  - Ex.1 -\n\n");

            Console.WriteLine("Welcome to the Zoo!\n" +
                "Let's take a look at our animals.");
            Dog pet1 = new Dog();
            Cat pet2 = new Cat();
            Fish pet3 = new Fish();

            int x;
            while (true) 
            {
                Console.WriteLine("Please enter a number: 1, 2 or 3");
                while (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine("Please enter a number.");
                }
                if ((x == 1 )|| (x == 2) || (x == 3)) { break; }
                else { Console.WriteLine("Your number is out of the range."); }
            }

            switch (x)
            {
                case 1:
                    {
                        Console.WriteLine($"\n  The first pet's info:");
                        Console.WriteLine("The current weight is " + pet1.Weight + " kg");
                        pet1.Eat();
                        pet1.ShowJoy();
                        pet1.HideBone();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"\n  The second pet's info:");
                        Console.WriteLine("The current weight is " + pet2.Weight + " kg");
                        pet2.Eat();
                        pet2.ShowJoy();
                        pet2.Scratch();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"\n  The third pet's info:");
                        Console.WriteLine("The current weight is " + pet3.Weight + " kg");
                        pet3.Eat();
                        pet3.ShowJoy();
                        pet3.MakeBubbles();
                        break;
                    }
            }

            /*Ex.2: Create an Interface ITwoDimShape and class Rectangle.
             * Declare a method. Implement a class Rectangle
             * which inherits from it and implement the method. */
            Console.WriteLine("\n\n  - Ex.2 -\n\n");

            Console.WriteLine("Greetings! Welcome to the Two_Dimensional_World.\n" +
                "Let's create some shapes.");
           
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("What shape would you like to create?\n" +
                    "If rectangle press 1, if circle press 2.");
                int x;
                while (!int.TryParse(Console.ReadLine(), out x))
                {
                    Console.WriteLine($"Ops, you've made a mistake.\n" +
                        $"Please enter a number." +
                        "If rectangle press 1, if circle press 2.");
                }
                switch (x)
                {
                    case 1: Console.WriteLine("Rectangle. Nice choice!");
                        Rectangle rectangle = Rectangle.CreateFromUserInput();
                        rectangle.DisplayDetails();
                        break;
                    case 2: Console.WriteLine("Circle. Nice choice!");
                        Circle circle = Circle.CreateFromUserInput();
                        circle.DisplayDetails();
                        break;
                }

            }   

        }
    }
}
