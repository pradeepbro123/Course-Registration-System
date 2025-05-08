using RepositoryLayer.Model;

namespace RepositoryLayer.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsAlreadyEnrolled(int userId, int courseId)
        {
            return _context.Enrollments.Any(e => e.UserId == userId && e.CourseId == courseId);
        }

        public bool CourseExists(int courseId)
        {
            return _context.Courses.Any(c => c.Id == courseId);
        }

        public void Enroll(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }
    }
}

