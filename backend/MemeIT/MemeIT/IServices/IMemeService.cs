using MemeIT.Entities;
using MemeIT.Helpers.Exceptions;

namespace MemeIT.IServices
{
    public interface IMemeService
    {
        /// <summary>
        /// Get all memes
        /// </summary>
        /// <returns>A list with all memes</returns>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<List<Meme>> GetMemes();


        /// <summary>
        /// Get a single meme based on provided id
        /// </summary>
        /// <param name="id">The desired meme id</param>
        /// <returns>Found meme object</returns>
        /// <exception cref="NotFoundException">Trow if no meme with desired id exists</exception>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<Meme> GetMeme(int id);

        /// <summary>
        /// Changes a meme description 
        /// </summary>
        /// <param name="meme">The meme with the desired modifications made</param>
        /// <returns>The modified meme</returns>
        /// <exception cref="NotFoundException">Trow if no meme with desired id exists</exception>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<Meme> ChangeDescription(Meme meme);

        /// <summary>
        /// Add a new meme
        /// </summary>
        /// <param name="meme">Meme to be added</param>
        /// <returns>The added meme</returns>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<Meme> AddMeme(Meme meme);

        /// <summary>
        /// Deletes a meme based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InternalProblemException"></exception>
        /// <exception cref="NotFoundException">Trow if no meme with desired id exists</exception>
        Task DeleteMeme(int id);
    }
}
