using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSE422_NguyenThanhDuy_Lab3.Interfaces;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class Book:IPrintable
    {
        private string _isbn;
        private string _title;
        private string _author;
        private int _year;
        private int _copiesAvailable;


        public Book(string isbn, string title, string author, int year, int copiesAvailable)
        {
            _isbn = isbn;
            Title = title;
            Author = author;
            Year = year;
            CopiesAvailable = copiesAvailable;
          
        }

        public string ISBN
        {
            get => _isbn;
            set => _isbn = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Year cannot be less than 0.");
                _year = value;
            }
        }

        public int CopiesAvailable
        {
            get => _copiesAvailable;
            set
            {
                if (value < 0)
                    throw new ArgumentException("CopiesAvailable cannot be less than 0.");
                _copiesAvailable = value;
            }
        }
        public void PrintDetails()
        {
            DisplayInfo();
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Year: {Year}, Copies Available: {CopiesAvailable}");
        }
    }

}
