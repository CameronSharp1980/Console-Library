using System;

namespace Console_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            string Selection;
            bool quit = false;
            Book HeadFirst = new Book("HeadFirst with C#", "Some Guy");
            Book Mastering = new Book("Mastering the Console App", "Some Guy");
            Book SeeSharpGame = new Book("C# Game Programming: For Serious Game Creation", "Some Guy");
            Book Pro = new Book("Pro C# 5.0 and the .NET 4.5 Framework", "Some Guy");

            Library MyLibrary = new Library("My Library", "Boise, ID");

            MyLibrary.AddBook(HeadFirst);
            MyLibrary.AddBook(Mastering);
            MyLibrary.AddBook(SeeSharpGame);
            MyLibrary.AddBook(Pro);


            while (!quit)
            {
                MyLibrary.PrintBooks();
                Selection = Console.ReadLine();
                if (Selection.ToLower() == "quit" || Selection.ToLower() == "q")
                {
                    quit = true;
                    continue;
                }
                else
                {
                    MyLibrary.SelectBook(Selection);
                }
            }




        }
    }
}
