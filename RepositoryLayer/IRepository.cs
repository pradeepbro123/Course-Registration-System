using RepositoryLayer.Model;
using RepositoryLayer.Models;

namespace RepositoryLayer
{
    public interface IRepository 
    {
        public void RegistrationRepo(User dto);
        public User GetEmail(string email);
    }
}
