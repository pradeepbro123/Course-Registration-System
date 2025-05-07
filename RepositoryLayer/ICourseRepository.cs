using RepositoryLayer.Model;
using RepositoryLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetAllCourses(string? search, int page, int pageSize);
        public Course GetById(int id);
        public void Add(Course course);
        public void Update(Course course);
        public void Delete(Course course);
    }
}