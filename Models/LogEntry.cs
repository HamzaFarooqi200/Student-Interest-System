using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ActivityType { get; set; }
        public LogEntry()
        {

        }
    }
}
