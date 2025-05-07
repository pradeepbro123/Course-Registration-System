using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RepositoryLayer.Models;

namespace RepositoryLayer.Model
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}


