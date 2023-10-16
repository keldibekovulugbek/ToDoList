using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entities
{
    public class UploadImageDTO
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
