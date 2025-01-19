// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using CSE422_NguyenThanhDuy_Lab3.BookManegement;

// Program.cs
using System;
using System.Collections.Generic;
using System.Data;


namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----------------------");

            // Create an instance of AdvancedNotificationService
            AdvancedNotificationService advancedNotificationService = new AdvancedNotificationService();
            advancedNotificationService.SendNotification("Welcome to the advanced library service!");
            Console.WriteLine("----------------------");
           
            // Create a library instance
            Library library = new Library("City Library");
            // Predefined list of books
            library.Books = new List<Book>
            {
                    new Book("11-11-11", "Learning Python", "Mark Lutz", 2013, 8),
                    new Book("22-22-22", "Effective Java", "Joshua Bloch", 2018, 4),
                    new Book("33-33-33", "You Don't Know JS", "Kyle Simpson", 2015, 6),
                    new Book("44-44-44", "Improving the Design of Code", "Martin Fowler", 2018, 3),
                    new Book("55-55-55", "Artificial Intelligence", "David L. Poole", 2017, 5),
                    new Book("66-66-66", "The Clean Coder", "Robert C. Martin", 2011, 7)
            };
           
            // Predefined list of members
            library.Members = new List<Member>
            {
                new Member ( "M001", "Nguyen Van A", "nguyenvana@example.com" ),
                new Member( "M002",  "Tran Thi B",  "tranthib@example.com" ),
                new Member (  "M004", "Pham Minh D",  "phamminhd@example.com" ),
                new PremiumMember ( "M005", "Do Thi E",  "dothie@example.com",  DateTime.Now.AddYears(1),  5 ),
                new PremiumMember ( "M003",  "Le Van C",  "levanc@example.com", DateTime.Now.AddYears(1), 10 ),
            };

            // Display all books
            Console.WriteLine("Available Books:");
            foreach (var book in library.Books)
            {
                book.PrintDetails();
            }
            Console.WriteLine("----------------------");
            // Display all members
            Console.WriteLine("\nMembers:");
            foreach (var member in library.Members)
            {
                member.PrintDetails();
            }
            Console.WriteLine("----------------------");
            // Simulate borrowing books
            //Console.WriteLine("\n--- Borrowing Books ---");
            //var borrowTransaction1 = new BorrowTransaction(
            //         "T001",
            //         DateTime.Now,
            //         library.Members[0],
            //         library.Books[0]
            //     );
            //borrowTransaction1.Execute();
            //library.Books[0].CopiesAvailable--; // Update the available copies
            //Console.WriteLine("\nUpdated Library Status:");
            //foreach (var book in library.Books)
            //{
            //    book.PrintDetails();
            //}

            //Console.WriteLine();

            //var borrowTransaction2 = new BorrowTransaction(
            //    "T002",
            //    DateTime.Now,
            //    library.Members[1],
            //    library.Books[1] // "Introduction to Algorithms"
            //);
            //borrowTransaction2.Execute();
            //library.Books[1].CopiesAvailable--; // Update the available copies
            //Console.WriteLine("\nUpdated Library Status:");
            //foreach (var book in library.Books)
            //{
            //    book.PrintDetails();
            //}

            //Console.WriteLine("----------------------");

            //// Simulate returning books
            //Console.WriteLine("\n--- Returning Books ---");
            //var returnTransaction1 = new ReturnTransaction
            //(
            //    "T003",
            //     DateTime.Now,
            //    library.Members[0],
            //     library.Books[0]
            //);
            //returnTransaction1.Execute();
            //library.Books[0].CopiesAvailable++; // Update the available copies
            //Console.WriteLine("\nUpdated Library Status After Return:");
            //foreach (var book in library.Books)
            //{
            //    book.PrintDetails();
            //}

            Console.WriteLine("----------------------");
            // Creating objects of BookClass and BookRecord
            BookClass bookClass1 = new BookClass("12345", "The Great Gatsby", "F. Scott Fitzgerald");
            BookClass bookClass2 = new BookClass("12345", "The Great Gatsby", "F. Scott Fitzgerald");

            BookRecord bookRecord1 = new BookRecord("12345", "The Great Gatsby", "F. Scott Fitzgerald");
            BookRecord bookRecord2 = new BookRecord("12345", "The Great Gatsby", "F. Scott Fitzgerald");

            
            Console.WriteLine($"BookClass objects are equal: {bookClass1 == bookClass2}");
            //BookClass so sánh theo tham chiếu(reference)
           
            Console.WriteLine($"BookRecord objects are equal: {bookRecord1 == bookRecord2}");
            //BookRecord so sánh theo giá trị(value).
            
           // Update Value = with 
            BookRecord bookRecord3 = bookRecord1 with { Title = "The Great Gatsby - Version2" };

            Console.WriteLine($"Original Title: {bookRecord1.Title}");
            Console.WriteLine($"Updated Title: {bookRecord3.Title}");



            Console.WriteLine("---------------");   
            // Create some books and members
            Book book20 = new Book("77-77-77", "C# Programming", "John Smith", 2020, 5);
            Book book21 = new Book("88-88-88", "Learn C#", "Jane Doe", 2021, 3);
            Member member1 = new Member("M008", "Alice Johnson", "alice.johnson@email.com");
            Member member2 = new Member("M009", "Bob Brown", "bob.brown@email.com");

            // Add books and members to the library
            library.Books.Add(book20);
            library.Books.Add(book21);
            library.Members.Add(member1);
            library.Members.Add(member2);
            Console.WriteLine("----Add More Book----");
            Console.WriteLine("\nUpdated Library Status:");
            foreach (var book in library.Books)
            {
                book.PrintDetails();
            }
            Console.WriteLine("----Add More Member----");
            Console.WriteLine("\nUpdated Library Status:");
            foreach (var mem in library.Members)
            {
                mem.PrintDetails();
            }  
            library.OnBookBorrowed += (book, member) =>
            {
                Console.WriteLine($"{member.Name} borrowed the book '{book.Title}'.");
            };
            // Borrow a book and execute the transaction
           
            library.OnBookBorrowed += (bookClass1, member1) =>
            {
                bookClass1.CopiesAvailable--;
            };
            Console.WriteLine("-------------");
            library.BorrowBook(book21, member1);
            Console.WriteLine("-------------");
            library.BorrowBook(book20, member2);
            Console.WriteLine("-------------");


            // Display final library status
            Console.WriteLine("\nFinal Library Status:");
            foreach (var book in library.Books)
            {
                book.PrintDetails();
            }
            Console.WriteLine("\nFinal Library Members:");
            foreach (var member in library.Members)
            {
                member.PrintDetails();
            }
            Console.Read();
        }
    }
}