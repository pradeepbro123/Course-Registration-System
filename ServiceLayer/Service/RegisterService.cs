using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using RepositoryLayer.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public RegisterService(IRepository repository, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public void Register(User user)
        {
            var existingUser = _repository.GetEmail(user.Email);
            if (existingUser != null)
                throw new Exception("User already exists");

            user.Password = _passwordHasher.HashPassword(user, user.Password);
            var user1 = new User
            {
                Email = user.Email,
                RoleId = user.RoleId,
                Name = user.Name,
                Password = user.Password
            };
            _repository.RegistrationRepo(user1);
        }

        public string Login(string email, string password)
        {
            var user = _repository.GetEmail(email);
            if (user == null)
                throw new Exception("Invalid email or password");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid email or password");


            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Roles.RoleName)  
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

