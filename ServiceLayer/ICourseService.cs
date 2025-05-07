using RepositoryLayer.Dto;
using ServiceLayer.Dto;

namespace ServiceLayer
{
    public interface ICourseService
    {
        List<CourseDto> GetCourses(string? search, int page, int pageSize);
        CourseDto GetById(int id);
        void Create(CourseCreateDto dto);
        void Update(int id, CourseUpdateDto dto);
        void Delete(int id);
    }
}
