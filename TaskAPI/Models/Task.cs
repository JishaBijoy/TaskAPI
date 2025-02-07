namespace TaskAPI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public string Color { get; set; }
        public string AssignedTo { get; set; }
        public Status Status { get; set; }

    }

    public enum Status
    {
        Pending,
        Hold,
        Completed,
        InProgress
    }
}
