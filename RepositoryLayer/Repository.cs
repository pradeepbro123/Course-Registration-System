using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Model;

namespace RepositoryLayer
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegistrationRepo(User dto)
        {
            try
            {
                _context.Users.Add(dto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Database save failed: " + ex.InnerException?.Message ?? ex.Message);
            }
        }

        public User GetEmail(string email)
        {
            var res = _context.Users.Include(u => u.Roles).FirstOrDefault(x => x.Email == email);
            
            return res;
        }
    }
}
