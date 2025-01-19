using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class BorrowTransaction : Transaction
    {
        public Book BookBorrowed { get; set; }

        public BorrowTransaction(string transactionID, DateTime transactionDate, Member member, Book bookBorrowed) : base(transactionID, transactionDate, member)
        {
            BookBorrowed = bookBorrowed;
        }
        public override void Execute()
        {
            // Logic for borrowing a book
            Console.WriteLine($"{Member.Name} borrowed {BookBorrowed.Title} on {TransactionDate}");
        }
    }
}
