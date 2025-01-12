using System;
using System.IO; // very important when working with files!
using System.Globalization;
using CsvHelper;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class Program
{
    class Details
    {
        public Details(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }

    static void Main(string[] args)
    {
        /*
        // -- Ex.1 FILES --

        // READS CSV
        // new object which can read files
        StreamReader reader = new StreamReader(@"C:\Users\dstpo\OneDrive\Dasha\My Studies\בר אילן\לימודי מידע\שנה 2\תכנות מתקדם\lesson9\תרגול-20250106\csv_file.csv");
        // new object which uses StreamReader to read csv files
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        List<Details> detailsList = new List<Details>();
        csv.Read();
        csv.ReadHeader();
        
        while (csv.Read())
        {
            int id = csv.GetField<int>("Id");
            string name = csv.GetField<string>("Name");
            Details details = new Details(id, name); // creates new object with new details
            detailsList.Add(details); // Add to the list
        }
        reader.Close(); // Close the reader after reading
        // Display the results
        foreach (var detail in detailsList)
        {
            Console.WriteLine($"Id: {detail.ID}, Name: {detail.Name}");
        }

        Console.WriteLine("\n\n\n");

        // WRITES CSV TO A NEW FILE

        /* StreamWriter writer = new StreamWriter(@"C:\Users\dstpo\OneDrive\Dasha\My Studies\בר אילן\לימודי מידע\שנה 2\תכנות מתקדם\lesson9\תרגול-20250106\csv_file_writer.csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(detailsList);
        writer.Flush();
        writer.Close();

        // ADDS NEW RECORDS AND WRITES CSV TO A NEW FILE

        detailsList.Add(new Details (22, "Dana"));
        detailsList.Add(new Details(100, "Gila"));
        StreamWriter writer = new StreamWriter(@"C:\Users\dstpo\OneDrive\Dasha\My Studies\בר אילן\לימודי מידע\שנה 2\תכנות מתקדם\lesson9\תרגול-20250106\csv_file_writer.csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(detailsList);
        writer.Flush();
        writer.Close();
        */

        // -- Ex.2 REGULAR EXPRESSIONS --

        string str = "This is my test string. It is for regular expressions, end of string";
        Console.WriteLine("The string: \"" + str + "\"");

        // 1. how many words are in the string
        
        Regex rg1 = new Regex(@"\b\w+\b");
        MatchCollection mc1 = rg1.Matches(str);
        Console.WriteLine($"\nThere are {mc1.Count} words.\n");

        // 2. how many 'is' are in the string

        Regex rg2 = new Regex(@"is");
        MatchCollection mc2 = rg2.Matches(str);
        Console.WriteLine($"There are {mc2.Count} \"is\".\n");

        // 3. how many “in” are in the string

        Regex rg3 = new Regex(@"in");
        MatchCollection mc3 = rg3.Matches(str);
        Console.WriteLine($"There are {mc3.Count} \"in\".\n");

        // 4. how many lines begin with t

        Regex rg4 = new Regex(@"^\s*[Tt].*$");
        MatchCollection mc4 = rg4.Matches(str);
        Console.WriteLine($"{mc4.Count} line begins with \"t\".\n");

        // 5. how many lines end with a “.”

        Regex rg5 = new Regex(@"\.\s*$");
        MatchCollection mc5 = rg5.Matches(str);
        Console.WriteLine($"{mc5.Count} lines end with \".\".\n");

        // 6. how many words begin with "is"

        Regex rg6 = new Regex(@"\bis\w*");
        MatchCollection mc6 = rg6.Matches(str);
        Console.WriteLine($"{mc6.Count} words begin with \"is\".\n");

        // 7. how many words contain "is" but do not start with "is"

        // Regex rg7 = new Regex(@"\b[^(is)]\w+is\w*"); // - my way
        Regex rg7 = new Regex(@"\Bis\w*"); // - better way
        MatchCollection mc7 = rg7.Matches(str);
        Console.WriteLine($"{mc7.Count} words contain \"is\" but do not start with \"is\".\n");

        // 8. how many words start with "i"

        Regex rg8 = new Regex(@"\bi\w*"); 
        MatchCollection mc8 = rg8.Matches(str);
        Console.WriteLine($"{mc8.Count} words start with \"i\".\n");

        // 9. how many words contain at least one "e"

        Regex rg9 = new Regex(@"\b\w*e\w*\b");
        MatchCollection mc9 = rg9.Matches(str);
        Console.WriteLine($"{mc9.Count} contain at least one \"e\".\n");

        // 10. how many words contain at least one "e"
        //     followed by an "s" but not immediately after the "e"

        Regex rg10 = new Regex(@"\b\w*e\w+s\w*\b");
        MatchCollection mc10 = rg10.Matches(str);
        Console.WriteLine($"{mc10.Count} contain at least one \"e\"" +
            $" followed by an \"s\" but not immediately after the \"e." +
            $"\nAnd it is: {mc10[0].Value}\n");

        // 11. how many expressions have "e" followed by "s" or "x"

        Regex rg11 = new Regex(@"\b\w*e[sx]\w*\b");
        MatchCollection mc11 = rg11.Matches(str);
        Console.WriteLine($"{mc11.Count} have \"e\" followed by \"s\" or \"x\".\nAnd they are:");
        for ( int i = 0; i < mc11.Count; i++)
        {
            Console.Write(mc11[i].Value + "\n");
        }

        // 12. how many have "e" followed by "s" but not "ss"

        Regex rg12 = new Regex(@"\b\w*es(?!s)\w*\b");
        MatchCollection mc12 = rg12.Matches(str);
        Console.WriteLine($"\n{mc12.Count} have \"e\" followed by \"s\" but not \"ss\".\nAnd it is:");
        for (int i = 0; i < mc12.Count; i++)
        {
            Console.Write(mc12[i].Value + "\n");
        }

        // 13. how many have "u" or "x" or "g" - note that regular will be counted multiple times.

        Regex rg13 = new Regex(@"\b\w*[uxg]\w*\b");
        MatchCollection mc13 = rg13.Matches(str);
        Console.WriteLine($"\n{mc13.Count} have \"u\" or \"x\" or \"g\".\nAnd they are:");
        for (int i = 0; i < mc13.Count; i++)
        {
            Console.Write(mc13[i].Value + "\n");
        }

        // 14. how many words start with vowel.

        Regex rg14 = new Regex(@"\b[aeiou]\w*\b");
        MatchCollection mc14 = rg14.Matches(str);
        Console.WriteLine($"\n{mc14.Count} start with vowel.\nAnd they are:");
        for (int i = 0; i < mc14.Count; i++)
        {
            Console.Write(mc14[i].Value + "\n");
        }

        // 15. how many words start with vowel, and have "s" twice (consecutive).

        Regex rg15 = new Regex(@"\b[aeiou]\w*s{2}\w*\b");
        MatchCollection mc15 = rg15.Matches(str);
        Console.WriteLine($"\n{mc15.Count} start with vowel, and have \"s\" twice.\nAnd they are:");
        for (int i = 0; i < mc15.Count; i++)
        {
            Console.Write(mc15[i].Value + "\n");
        }

        // 16. how many words do not start with “s” or “r”

        Regex rg16 = new Regex(@"\s\b[^srSR]\w+");
        MatchCollection mc16 = rg16.Matches(str);
        Console.WriteLine($"\n{mc16.Count} do not start with “s” or “r”.\nAnd they are:");
        for (int i = 0; i < mc16.Count; i++)
        {
            Console.Write(mc16[i].Value + "\n");
        }

        // 17. how many words are in the string – another way (with SPLIT)

        Regex rg17 = new Regex(@"\W+");
        string[] words = rg17.Split(str);
        Console.WriteLine($"\nThere are {words.Length} words.");

        // 18. how many words contain one of the letters (d,e,f,g,h) not as the first or last letter

        Regex rg18 = new Regex(@"\b[^d-h]\w*[d-h]\w*[^d-h]\b", RegexOptions.IgnoreCase);
        MatchCollection mc18 = rg18.Matches(str);
        Console.WriteLine($"\n{mc18.Count} contain one of the letters (d,e,f,g,h) not as the first or last letter.\nAnd they are:");
        for (int i = 0; i < mc18.Count; i++)
        {
            Console.Write(mc18[i].Value + "\n");
        }

        // 19. find all the occurrences of is and it

        Regex rg19 = new Regex(@"\b(is|it)\b", RegexOptions.IgnoreCase);
        MatchCollection mc19 = rg19.Matches(str);
        Console.WriteLine($"\nThere are {mc19.Count} occurrences of is and it.\n");

        // 20. find valid emails in the list.

        string[] emails = {"luke@gmail.com", "andy@yahoocom", "34234sdfa#2345", "f344@gmail.com"};
        Regex rg20 = new Regex(@"[a-z0-9._-]+@[a-z0-9-]+\.[a-z]{2,18}", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        foreach (string email in emails)
        {
            if (rg20.IsMatch(email))
            {
                Console.WriteLine(email + " matches");
            }
            else { Console.WriteLine(email + " doesn't match"); }
        }

    }
}