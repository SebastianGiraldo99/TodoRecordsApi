namespace TodoRecords.Domain.DTOs
{
    public class UpdateTodoDTO
    {
        public int idTodo { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }

    }
}
