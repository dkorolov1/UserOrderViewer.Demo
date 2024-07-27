namespace DemoApp.Server.Models;

public class Order : Entity
{
        public decimal Amount { get; set; }        
        public DateTime Date { get; set; }         
        public string Status { get; set; } = null!;
        public int UserId { get; set; }
}