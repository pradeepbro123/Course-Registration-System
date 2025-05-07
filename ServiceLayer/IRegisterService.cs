using RepositoryLayer;
using RepositoryLayer.Model;

namespace ServiceLayer
{
    public interface IRegisterService
    {
        public void Register(User user);
        string Login(string email, string password);
    }
}
