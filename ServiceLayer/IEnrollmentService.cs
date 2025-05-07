using ServiceLayer.Dto;

namespace ServiceLayer
{
    public interface IEnrollmentService
    {
        public void Enroll(int userId, EnrollRequestDto request);
    }
}
