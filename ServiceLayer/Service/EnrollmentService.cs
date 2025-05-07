using RepositoryLayer;
using RepositoryLayer.Model;
using ServiceLayer.Dto;

namespace ServiceLayer
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _repository;

        public EnrollmentService(IEnrollmentRepository repository)
        {
            _repository = repository;
        }

        public void Enroll(int userId, EnrollRequestDto dto)
        {
            if (!_repository.CourseExists(dto.CourseId))
                throw new Exception("Course does not exist.");

            if (_repository.IsAlreadyEnrolled(userId, dto.CourseId))
                throw new Exception("User is already enrolled in this course.");

            var enrollment = new Enrollment
            {
                UserId = userId,
                CourseId = dto.CourseId
            };

            _repository.Enroll(enrollment);
        }
    }
}
