using MemeIT.Entities;
using MemeIT.Helpers.Exceptions;

namespace MemeIT.IServices
{
    public interface IRegisterService
    {
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns></returns>
        /// <exception cref="Helpers.Exceptions.InvalidDataException">Trow if the provided username or email already exists</exception>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task RegisterUser(User user);
    }
}
