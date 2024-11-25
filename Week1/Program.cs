using System.Security.Cryptography.X509Certificates;

namespace test
{
    internal class Program
    {
        static void addTen()
        {
            Console.WriteLine("Please enter an integer:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(number + 10);
        }
        static void printAverage()
        {
            Console.WriteLine("Enter your first value");
            double value1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your second value");
            double value2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine((value1 + value2) / 2);

        }

        static void functionNum3()
        {
            /*a function that gets from the user names, ages (as int), genders (as string: female, male), 
             * heights (as float), of two people and computes the differences in their ages and
             * heights and also calculates their years of birth; and thenprints their names, 
             * their genders, the computed differences, differences in heights and birth years to the console screen.
             */

            // the solution is written without checking the input, assuming that the user wouldn't make a mistake
            int age1, age2;
            string name1, name2, gender1, gender2;
            float height1, height2;
            Console.WriteLine("Hello and welcome to our system!\nPlease enter next information.\n\n");
            
            Console.WriteLine("User 1, your name:");
            name1 = Console.ReadLine();

            Console.WriteLine("Your age:");
            age1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Your gender:");
            gender1 = Console.ReadLine();

            Console.WriteLine("Your height:");
            height1 = float.Parse(Console.ReadLine());

            Console.WriteLine("User 2, your name:");
            name2 = Console.ReadLine();

            Console.WriteLine("Your age:");
            age2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Your gender:");
            gender2 = Console.ReadLine();

            Console.WriteLine("Your height:");
            height2 = float.Parse(Console.ReadLine());


            Console.WriteLine("Thank you for entering that infomation.\n" +
                $"So, the first user is {name1}, {gender1}, {age1} year's old and {height1} Cm's tall.\n" +
                $"{name1} was born in {2024 - age1}.\n\n" +
                $"The second user is {name2}, {gender2}, {age2} year's old and {height2} Cm's tall.\n" +
                $"{name2} was born in {2024 - age2}.\n\n" +
                $"Your age difference is {Math.Abs(age1-age2)} years and your height difference is {Math.Abs(height1-height2)} Cm");


        }
        static void functionNum4()
        {
            Console.WriteLine("Please enter your three integers:");
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            // calculating the difference
            int difference = 0;
            if (num1 > num2)
            {
                if (num3 > num1) { difference = num3 - num2; }
                else if (num2 > num3) { difference = num1 - num3; }
                else { difference = num1 - num2; }

            }
            else if (num1 < num2)
            {
                if (num3 > num2) { difference = num3 - num1; }
                else if (num1 > num3) { difference = num2 - num3; }
                else { difference = num2 - num1; }
            }
            else if (num3 > num1) { difference = num3 - num1; }
            else if (num1 > num3) { difference = num1 - num3; }
            else { difference = 0; }
            Console.WriteLine($"The difference is: {difference} and the new values are:\n{num1 + difference}\n{num2 + difference}\n{num3 + difference}");
        }
        static void functionNum5()
        {
            Console.WriteLine("Please enter a year:");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Please enter an integer.");
            }
            if ((year % 4 != 0) || ((year % 100 == 0) && (year % 400 != 0)))
            {
                Console.WriteLine($"{year} isn't a leap year.");
            }
            else
            {
                Console.WriteLine($"Yes! {year} is a leap year!");
            }
        }

        static void functionNum6()
        {
            Console.WriteLine("Please enter your age:");
            int age;

            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("No, please enter an integer.\n Your age:");
            }

            if (age <= 12) { Console.WriteLine("You're a child."); }
            else if (age <= 19) { Console.WriteLine("You're an teenager."); }
            else if (age <= 39) { Console.WriteLine("You're an adult."); }
            else { Console.WriteLine("You're a senior."); }
        }

        static void functionNum7()
        {
            Random random = new Random();
            int secretNum = random.Next(1, 101);
            int userGuess = 0;

            Console.WriteLine("Please enter your guess");
            while (userGuess != secretNum)
            {
                userGuess = int.Parse(Console.ReadLine());
                if (userGuess > secretNum) { Console.WriteLine("Your number is bigger"); }
                else if (userGuess < secretNum) { Console.WriteLine("Your number is lower"); }
                else { Console.WriteLine("Congratulations! You guessed right :)"); }
            }

        }

        static void functionNum8()
        {
            Console.WriteLine("Please enter a number of elementes.");
            int num;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Please enter an integer");
                }

                if (num > 0) { break; }
            }

            // creating an array
            int[] array_of_ints = new int[num];

            Console.WriteLine("Thank you.\n Now let's create an array.");
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter the {i+1} number:");

                while (!int.TryParse(Console.ReadLine(), out array_of_ints[i]))
                {
                    Console.WriteLine("Please enter an integer");
                }                
            }

            // calculating the sum

            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum += array_of_ints[i];
            }
            Console.WriteLine("Thank you for providing us that info.\nWe've calculated a sum of all the numbers in an array for you." +
                $"\nThe sum is {sum}.");
        }

        static void functionNum9()
        {
            Console.WriteLine("Hello! This program counts the frequency of each character in a given string.\n" +
                "Let's begin :)");
            Console.WriteLine("Please enter a string:");
            string input_string = Console.ReadLine();

            // creating of an array (string.length)

            char[] uniqueCharacters = new char[input_string.Length];
            int index = 0;

            for (int i = 0; i < input_string.Length; i++)
            {
                char currentChar = input_string[i];
                bool test = true;

                for (int j = 0; j < uniqueCharacters.Length; j++)
                {
                    if (uniqueCharacters[j] == currentChar)
                    {
                        test = false;
                    }
                }
                if (test)
                {
                    int frequency = 0;
                    for (int j = 0; (j < input_string.Length); j++)
                    {
                        if (currentChar == input_string[j]) { frequency++; }
                    }
                    Console.WriteLine($"The character {currentChar} appears {frequency}");
                    uniqueCharacters[index] = currentChar;
                    index++;
                }
            }
        }

        static void Main(string[] args)
        {
            //addTen();
            //printAverage();
            functionNum9();
        }
    }
}
