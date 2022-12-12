using MemeIT.DbContext;
using MemeIT.Entities;
using MemeIT.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MemeIT.Helpers.CustomExceptions;
using InvalidDataException = MemeIT.Helpers.CustomExceptions.InvalidDataException;

namespace MemeIT.Services
{
    public class LoginService : ILoginService
    {
        private const int TokenDuration = 120;

        private readonly DbCon _dbCon;
        private readonly IConfiguration _config;

        public LoginService(DbCon dbCon, IConfiguration config)
        {
            _dbCon = dbCon;
            _config = config;
        }

        /// <summary>
        /// Generate JWT token based on user data
        /// </summary>
        /// <param name="user">The user to whom the token should be provided</param>
        /// <returns>JWT token</returns>
        private string GenerateJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim("username", user.Username),
                new Claim("email",user.Email),
                new Claim("id", user.UserId.ToString())
            };

            var token = new JwtSecurityToken("", "",
                claims,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <inheritdoc />>
        public async Task<string> Login(string username, string password)
        {
            User? user;
            try
            {
               user = await _dbCon.Set<User>().FirstOrDefaultAsync(u => u.Username == username);

            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");

            }
            if (user == null)
            {
                throw new InvalidDataException("Wrong username or password");
            }
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (passwordMatch)
            {
                return GenerateJwt(user);
            }
            throw new InvalidDataException("Wrong username or password");
        }
    }
}
