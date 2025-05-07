using RepositoryLayer.Model;

namespace RepositoryLayer
{
    public interface IEnrollmentRepository
    {
        public bool IsAlreadyEnrolled(int userId, int courseId);
        public bool CourseExists(int courseId);
        public void Enroll(Enrollment enrollment);
    }
}