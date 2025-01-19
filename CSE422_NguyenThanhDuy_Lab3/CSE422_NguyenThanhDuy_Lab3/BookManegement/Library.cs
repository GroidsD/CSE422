using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class Library
    {
        public string LibraryName { get; set; }
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public event Action<Book, Member> OnBookBorrowed;
        // Constructor
        public Library(string libraryName)
        {
            LibraryName = libraryName;
            Books = new List<Book>();
            Members = new List<Member>();
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }

        // Method to add a new member
        public void AddMember(Member member)
        {
            Members.Add(member);
            Console.WriteLine($"Member '{member.Name}' added to the library.");
        }

        // Method to display library information
        public void DisplayLibraryInfo()
        {
            Console.WriteLine($"Library Name: {LibraryName}");
            Console.WriteLine($"Total Books: {Books.Count}");
            Console.WriteLine($"Total Members: {Members.Count}");
        }

        // Method to borrow a book
        public void BorrowBook(Member member, Book book)
        {
            if (book.CopiesAvailable > 0)
            {
                member.BorrowBook(book);
                book.CopiesAvailable--;
            }
            else
            {
                Console.WriteLine($"Sorry, {book.Title} is not available.");
            }
        }

        // Method to return a book
        public void ReturnBook(Member member, Book book)
        {
            member.ReturnBook(book);
            book.CopiesAvailable++;
        }

        public void BorrowBook(Book book, Member member)
        {
            // Create a new BorrowTransaction
            var borrowTransaction = new BorrowTransaction(
                transactionID: Guid.NewGuid().ToString(),
                transactionDate: DateTime.Now,
                member: member,
                bookBorrowed: book
            );

            // Execute the borrow transaction (this will check availability and update the book count)
            borrowTransaction.Execute();

            // Trigger the event after a successful borrow
            OnBookBorrowed?.Invoke(book, member);
        }
        // Method to add a new book
      
    }
}
