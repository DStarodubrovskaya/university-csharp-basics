namespace C___lec6_exercises_exceptions
{
    internal class Program
    {
        class Book
        { 
            public string Author { get; set; }
        }
        public static int Divide(int value1, int value2) { return value1/value2; }
        static void Main(string[] args)
        {
            // Ex.1 - IndexOutOfRangeException
            int[] ints = new int[5];
            try
            {
                ints[5] = 1;
            }
            catch
            {
                Console.WriteLine("The index is out of range.");
            }

            // Ex.2 - DivideByZeroException
            try
            {
                Console.WriteLine(Divide(2, 0));
            }
            catch 
            {
                Console.WriteLine("You can't devide by zero.");
            }

            // Ex.3 - FormatException
            Console.WriteLine("Please enter an integer.");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine(num + " - This is a number.");
            }
            else { Console.WriteLine("This is not a number."); }

            // Ex.4 - NullReferenceException      ????
            Book newBook = null;
            if (newBook == null) { newBook = new Book(); }
            newBook.Author = "J.Rowling";

        }
    }
}
