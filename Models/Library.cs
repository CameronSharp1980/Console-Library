using System;
using System.Collections.Generic;

namespace Console_Library
{
    public class Library
    {
        public string Name;
        public string Location;
        private List<Book> _books = new List<Book>();
        private Book CheckedOutBook;
        private bool SomethingcheckedOut = false;

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void PrintBooks()
        {
            Console.WriteLine("Please select a book to check out:\n");
            Console.WriteLine("Type \"quit\" to leave the library\n");

            for (int i = 0; i < _books.Count; i++)
            {
                Book currentBook = _books[i];
                Console.WriteLine($"{i + 1}. {currentBook.Title}\n");
            }
            if (SomethingcheckedOut)
            {
                Console.WriteLine($"Book currently checked out: {CheckedOutBook.Title}");
                Console.WriteLine($"If you wish to return your book, type \"Return\"\n");
            }
        }

        public void SelectBook(string Selection)
        {
            bool valid;
            int SelectionInt;
            valid = int.TryParse(Selection, out SelectionInt);
            if (valid && SelectionInt <= _books.Count)
            {
                CheckOut(SelectionInt);
            }
            else if (Selection.ToLower() == "return" || Selection.ToLower() == "r")
            {
                ReturnBook();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection. Please select only from the book numbers provided");
            }
        }

        private void CheckOut(int selectedBook)
        {
            Book bookToCheckout;
            if (SomethingcheckedOut)
            {
                Console.Clear();
                Console.WriteLine("You must return your book before you can check out another...\n");
            }
            else
            {
                Console.Clear();
                bookToCheckout = _books[selectedBook - 1];
                _books.Remove(_books[selectedBook - 1]);
                CheckedOutBook = bookToCheckout;
                SomethingcheckedOut = true;
            }

        }

        private void ReturnBook()
        {
            if (CheckedOutBook != null)
            {
                Console.Clear();
                Console.WriteLine("Book returned to shelf...");
                AddBook(CheckedOutBook);
                SomethingcheckedOut = false;
                CheckedOutBook = null;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You do not currently have a book to return...");
            }

        }





        public Library(string name, string location)
        {
            Name = name;
            Location = location;
        }

    }

}
