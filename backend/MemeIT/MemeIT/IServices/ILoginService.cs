using MemeIT.Helpers.CustomExceptions;
using MemeIT.Models;

namespace MemeIT.IServices
{
    public interface ILoginService
    {
        /// <summary>
        /// Check if provided credentials are valid and returns auth token if so
        /// </summary>
        /// <param name="loginModel">Model containing username and password</param>
        /// <returns>Jwt auth token</returns>
        /// <exception cref="Helpers.CustomExceptions.InvalidDataException">Trow if credentials are wrong</exception>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<string> Login(LoginModel loginModel);
    }
}