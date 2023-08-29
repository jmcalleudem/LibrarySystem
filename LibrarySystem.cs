
namespace LibrarySystem
{
    using System;
    using System.Collections.Generic;

    public class LibrarySystem
    {
        private Dictionary<string, Book> catalog = new Dictionary<string, Book>();
        private Dictionary<string, List<Book>> checkedOutBooks = new Dictionary<string, List<Book>>();

        public void AddBook(string title, string author, string ISBN)
        {
            catalog[ISBN] = new Book(title, author, ISBN);
        }

        public void CheckOutBook(string ISBN, string borrower)
        {
            if (!catalog.ContainsKey(ISBN))
            {
                throw new ArgumentException("Book not found in catalog.");
            }

            Book book = catalog[ISBN];

            if (!checkedOutBooks.ContainsKey(borrower))
            {
                checkedOutBooks[borrower] = new List<Book>();
            }

            checkedOutBooks[borrower].Add(book);
            catalog.Remove(ISBN);
        }

        public void ReturnBook(string ISBN, string borrower)
        {
            if (!checkedOutBooks.ContainsKey(borrower))
            {
                throw new ArgumentException("Borrower not found.");
            }

            Book book = checkedOutBooks[borrower].Find(b => b.ISBN == ISBN);
            if (book == null)
            {
                throw new ArgumentException("Book not borrowed by this borrower.");
            }

            checkedOutBooks[borrower].Remove(book);
            catalog[ISBN] = book;
        }

        public int GetAvailableBooksCount()
        {
            return catalog.Count;
        }

        public int GetBorrowedBooksCount(string borrower)
        {
            if (checkedOutBooks.ContainsKey(borrower))
            {
                return checkedOutBooks[borrower].Count;
            }
            return 0;
        }
    }

    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; }

        public Book(string title, string author, string ISBN)
        {
            Title = title;
            Author = author;
            this.ISBN = ISBN;
        }
    }

}
