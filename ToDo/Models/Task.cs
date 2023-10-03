using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskText { get; set; }
        [ForeignKey("Users")]
        public int UserId {  get; set; }
        public virtual User Users { get; set; }
    }
}
