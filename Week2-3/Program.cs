namespace test2
{   
    class Book
    {
        protected int _current_page, _pages;
        protected string _title;

        public Book ()
        {
            _current_page = 0;
            _pages = 0;
            _title = "Not known";
        }
        public Book(int current_page, int pages, string title)
        {
            _current_page= current_page;
            _pages = pages;
            _title = title;
        }
        public int getCurrentPage()
        {
            return _current_page;
        }
        public int getPages()
        {
            return _pages;
        }
        public string getTitle()
        {
            return _title;
        }
        public void setCurrentPage(int current_page)
        {
            _current_page = current_page;
        }
        public void setPages(int pages)
        {
            _pages = pages;
        }
        public void setTitle(string title)
        {
            _title = title;
        }
    }
    class PaperBook : Book
    {
        protected bool _softCover;

        public PaperBook() : base() // refers to default Book constructor
        {
            _softCover = false;
        }
        public PaperBook(int current_page, int pages, string title, bool sofCover) : base(current_page, pages, title)
        {
            _softCover = sofCover;
        }

        public bool isSoftCover()
        {
            return _softCover;
        }

        public void setSoftCover(bool softCover)
        {
            _softCover = softCover;
        }
    }
    class DigitalBook : Book
    {

        protected double _file_size;

        public DigitalBook() : base () // refers to default Book constructor
        {
            _file_size = 0;
        }
        public DigitalBook(int current_page, int pages, string title, double file_size) : base(current_page, pages, title)
        {
            _file_size = file_size;
        }
        
        public double getFileSize()
        {
            return _file_size;
        }
       
        public void setFileSize(double fileSize)
        {
            _file_size = fileSize;
        }
    }
    class Pet
    {
        protected double _weight;
        public Pet()
        {
            _weight = 0;
        }
        public Pet(double weight)
        {
            _weight = weight;
        }
        public double getWeight()
        {
            return _weight;
        }
        public void setWeight(double weight)
        {
            _weight = weight;
        }
        public double Eat()
        {
            Console.WriteLine("Pet is eating...and gaining weight :)");
            _weight += 0.2;
            return _weight;
        }
        public void ShowJoy()
        {
            Console.WriteLine("Pet is showing joy to the human.");
        }
    }
    class Dog : Pet
    {
        private string _dRace;
        public Dog () : base()
        {
            _dRace = "Unknown";
        }
        public Dog (string dRace, double weight) : base(weight)
        {
            _dRace = dRace;
        }
        public string getDogRace()
        {
            return _dRace;
        }
        public void setDogRace(string dRace)
        {
            _dRace = dRace;
        }
    }
    class Cat : Pet
    {
        private string _cRace;

        public Cat() : base()
        {
            _cRace = "Unknown";
        }
        public Cat(string cRace, double weight) : base(weight)
        {
            _cRace = cRace;
        }
        public string getCatRace()
        {
            return _cRace;
        }
        public void setCatRace(string cRace)
        {
            _cRace = cRace;
        }
    }
    class Fish : Pet
    {
        protected string _fColor;
        protected double _fLength;
        public Fish() : base()
        {
            _fColor = "Unknown";
            _fLength = 0;
        }
        public Fish(double weight, string fColor, double fLength) : base(weight)
        {
            _fColor = fColor;
            _fLength = fLength;
        }

        public string getFishColor()
        {
            return _fColor;
        }
        public void setFishColor(string color)
        {
            _fColor = color;
        }
        public double getFishLength()
        {
            return _fLength;
        }
        public void setFishLength(double length)
        {
            _fLength = length;
        }
    }
    class Person
    {
        private string _name;
        private int _age;
        private double _height;

        public Person()
        {
            _name = "Not known";
            _age = 0;
            _height = 0;
        }
        public Person (string name, int age, double height)
        {
            _name = name;
            _age = age;
            _height = height;
        }

        public void printInfo()
        {
            Console.WriteLine($"Name: {_name}\nAge: {_name}\nHeight: {_age}");
        }
        public void setName (string name)
        {
            _name = name;
        }
        public void setAge (int age)
        {
            _age = age;
        }
        public void setHeight(double height)
        {
            _height = height;
        }
        public string getName()
        {
            return _name;
        }
        public int getAge()
        {
            return _age;
        }
        public double getHeight()
        {
            return _height;
        }
    }
    internal class Program
    {
        static void myMethod()
        {
            Console.WriteLine("hi");
        }
        static void Main(string[] args)
        {
           /* Person person1 = new Person();
            Person person2 = new Person("Dasha", 24, 169.9);

            person1.setName("Boris");
            person1.setAge(18);
            person1.setHeight(185);
            Console.WriteLine($"{person1.getName()} is {person1.getAge()} year's old and {person1.getHeight()} Cm's tall.");
            Console.WriteLine($"{person2.getName()} is {person2.getAge()} year's old and {person2.getHeight()} Cm's tall.");
            */
            Book book1 = new Book();
            PaperBook book2 = new PaperBook();
            DigitalBook book3 = new DigitalBook();

            Console.WriteLine("Please enter 3 book titles.");
            book1.setTitle(Console.ReadLine());
            book2.setTitle(Console.ReadLine());
            book3.setTitle(Console.ReadLine());

            Console.WriteLine($"The titles you've entered:\n{book1.getTitle()}\n{book2.getTitle()}\n{book3.getTitle()}");
        }
    }
}
