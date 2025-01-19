using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE422_NguyenThanhDuy_Lab3.BookManegement
{
    public class NotificationService
    {
        public virtual void SendNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
        // Overloaded method to send a notification to a specific recipient
        public void SendNotification(string message, string recipient)
        {
            Console.WriteLine($"Notification to {recipient}: {message}");
        }

        // Overloaded method to send a notification to multiple recipients
        public void SendNotification(string message, List<string> recipients)
        {
            foreach (var recipient in recipients)
            {
                Console.WriteLine($"Notification  {recipient}: {message}");
            }
        }
        public void NotifyBookBorrowed(Book book, Member member)
        {
            Console.WriteLine($"Notification: {member.Name} borrowed '{book.Title}' by {book.Author}.");
        }
    }
}
