using MemeIT.Helpers.CustomExceptions;
using MemeIT.Models;

namespace MemeIT.IServices
{
    public interface IRegisterService
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns></returns>
        /// <exception cref="Helpers.CustomExceptions.InvalidDataException">Trow if the provided username or email already exists</exception>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task RegisterUser(UserModel user);
    }
}
