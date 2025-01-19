using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class ReturnTransaction : Transaction
    {
        public Book BookReturned { get; set; }

        public ReturnTransaction(string transactionID, DateTime transactionDate, Member member, Book bookReturned)
           : base(transactionID, transactionDate, member) // Call the base class constructor
        {
            BookReturned = bookReturned;
        }
        public override void Execute()
        {
            // Logic for returning a book
            Console.WriteLine($"{Member.Name} returned {BookReturned.Title} on {TransactionDate}");
        }
    }
}
