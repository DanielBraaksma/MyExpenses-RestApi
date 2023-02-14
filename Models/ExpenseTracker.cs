namespace ExpenseTracker.Models
{
    public class ExpenseTracker
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Amount { get; set; }

        public string? Date { get; set; }

        public string? Category { get; set; }
    }
}
