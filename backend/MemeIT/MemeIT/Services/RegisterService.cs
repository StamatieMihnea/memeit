using AutoMapper;
using MemeIT.DbContext;
using MemeIT.Entities;
using MemeIT.Helpers.CustomExceptions;
using MemeIT.IServices;
using MemeIT.Models;
using Microsoft.EntityFrameworkCore;
using InvalidDataException = MemeIT.Helpers.CustomExceptions.InvalidDataException;

namespace MemeIT.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly DbCon _dbContext;
        private readonly IMapper _mapper;

        public RegisterService(DbCon dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />>
        public async Task RegisterUser(UserModel user)
        {
            bool usernameAlreadyExist;
            bool emailAlreadyExist;
            try
            {
                usernameAlreadyExist = await _dbContext.Set<User>().AnyAsync(u => u.Username == user.Username);
                emailAlreadyExist = await _dbContext.Set<User>().AnyAsync(u => u.Email == user.Email);
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
            
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
                await _dbContext.AddAsync(_mapper.Map<User>(user));
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
        }
    }
}