using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSE422_NguyenThanhDuy_Lab3.BookManegement;

namespace CSE422_NguyenThanhDuy_Lab3.Interfaces
{
    public interface IMemberActions
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }

}
