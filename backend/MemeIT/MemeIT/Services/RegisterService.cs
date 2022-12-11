using MemeIT.DbContext;
using MemeIT.Entities;
using MemeIT.Helpers.Exceptions;
using MemeIT.IServices;
using Microsoft.EntityFrameworkCore;
using InvalidDataException = MemeIT.Helpers.Exceptions.InvalidDataException;

namespace MemeIT.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly DbCon _dbContext;

        public RegisterService(DbCon dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />>
        public async Task RegisterUser(User user)
        {
            int passwordLength = user.Password.Length;
            if (passwordLength is < User.MinPasswordLimit or > User.MaxPasswordLimit)
            {
                throw new InvalidDataException($"Password must be between {User.MinPasswordLimit} and {User.MaxPasswordLimit}");
            }
            bool usernameAlreadyExist = await _dbContext.Set<User>().AnyAsync(u => u.Username == user.Username);
            bool emailAlreadyExist = await _dbContext.Set<User>().AnyAsync(u => u.Email == user.Email);
            if (usernameAlreadyExist)
            {
                throw new InvalidDataException("Username already exists");
            }
            if (emailAlreadyExist)
            {
                throw new InvalidDataException("Email already registered");
            }
            String hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            try
            {
                await _dbContext.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
        }
    }
}
