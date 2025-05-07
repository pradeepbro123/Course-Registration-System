using System.ComponentModel.DataAnnotations;

namespace RepositoryLayer.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

    }
}