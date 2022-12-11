using MemeIT.Helpers.Exceptions;

namespace MemeIT.IServices
{
    public interface ILoginService
    {
        /// <summary>
        /// Check if provided credentials are valid and returns auth token if so
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Jwt auth token</returns>
        /// <exception cref="Helpers.Exceptions.InvalidDataException">Trow if credentials are wrong</exception>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<string> Login(string username, string password);
    }
}
