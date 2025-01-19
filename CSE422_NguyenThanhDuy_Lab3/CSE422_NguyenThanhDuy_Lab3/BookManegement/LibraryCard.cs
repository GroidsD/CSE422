using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSE422_NguyenThanhDuy_Lab3.Interfaces;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class LibraryCard
    {
        public string CardNumber { get; private set; }
        public Member Owner { get; set; }
        public DateTime IssueDate { get; private set; }

        

        // Method to renew the card, updating the IssueDate
        public void RenewCard()
        {
            IssueDate = DateTime.Now; // Update the IssueDate to the current date
            Console.WriteLine($"Library card {CardNumber} renewed. New Issue Date: {IssueDate}");
        }
        // Constructor
        public LibraryCard(string cardNumber, Member owner)
        {
            CardNumber = cardNumber;
            Owner = owner;
            IssueDate = DateTime.Now;
        }

        // Method to display card information
        public void DisplayCardInfo()
        {
            Console.WriteLine($"Card Number: {CardNumber}, Card Holder: {Owner.Name}, Issue Date: {IssueDate}");
        }
    }
}
