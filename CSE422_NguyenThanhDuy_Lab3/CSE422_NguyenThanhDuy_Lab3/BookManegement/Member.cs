using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSE422_NguyenThanhDuy_Lab3.Interfaces;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class Member : IPrintable, IMemberActions
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(string memberID, string name, string email)
        {
            MemberID = memberID;
            Name = name;
            Email = email;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Member ID: {MemberID}, Name: {Name}, Email: {Email}");
        }

        public void PrintDetails()
        {
            DisplayInfo();
        }

        public void BorrowBook(Book book)
        {
            Console.WriteLine($"{Name} borrowed {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            Console.WriteLine($"{Name} returned {book.Title}");
        }
    }

   
   

}
