using System.ComponentModel.DataAnnotations;

namespace TodoRecords.Domain.Models
{
    public class TodoModel
    {
        [Key]
        public int IdTodo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool IsDeleted { get; set; } = false;

    }

}
