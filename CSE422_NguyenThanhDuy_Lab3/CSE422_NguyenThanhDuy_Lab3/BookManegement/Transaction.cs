using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public abstract class Transaction
    {
        public string TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public Member Member { get; set; }

        public abstract void Execute();
        public Transaction(string transactionID, DateTime transactionDate, Member member)
        {
            TransactionID = transactionID;
            TransactionDate = transactionDate;
            Member = member;
        }

    }
}
