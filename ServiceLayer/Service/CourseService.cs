using RepositoryLayer;
using RepositoryLayer.Dto;
using RepositoryLayer.Models;
using ServiceLayer.Dto;

namespace ServiceLayer
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public List<CourseDto> GetCourses(string? search, int page, int pageSize)
        {
            var courses = _repository.GetAllCourses(search, page, pageSize);

            return courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title
            }).ToList();
        }
        public CourseDto GetById(int id)
        {
            var course = _repository.GetById(id) ?? throw new Exception("Course not found");
            return new CourseDto { Id = course.Id, Title = course.Title };
        }

        public void Create(CourseCreateDto dto)
        {
            var course = new Course { Title = dto.Title };
            _repository.Add(course);
        }

        public void Update(int id, CourseUpdateDto dto)
        {
            var course = _repository.GetById(id) ?? throw new Exception("Course not found");
            course.Title = dto.Title;
            _repository.Update(course);
        }

        public void Delete(int id)
        {
            var course = _repository.GetById(id) ?? throw new Exception("Course not found");
            _repository.Delete(course);
        }
    }
}
