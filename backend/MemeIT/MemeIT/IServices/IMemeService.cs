using MemeIT.Entities;
using MemeIT.Helpers.CustomExceptions;
using MemeIT.Models;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="userId">User that tries the operation</param>
        /// <returns>The modified meme</returns>
        /// <exception cref="NotFoundException">Trow if no meme with desired id exists</exception>
        /// <exception cref="NoPermissionException"></exception>    
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<Meme> ChangeDescription(MemeModel meme, int userId);

        /// <summary>
        /// Add a new meme
        /// </summary>
        /// <param name="meme">Meme to be added</param>
        /// <param name="userId">User that tries the operation</param>
        /// <returns>The added meme</returns>
        /// <exception cref="InternalProblemException">Trow if an internal error occurs</exception>
        Task<Meme> AddMeme(ImageMemeModel meme, int userId);

        /// <summary>
        /// Deletes a meme based on id
        /// </summary>
        /// <param name="memeId">Meme Id to be deleted</param>
        /// <param name="userId">User that tries the operation</param>
        /// <returns></returns>
        /// <exception cref="InternalProblemException"></exception>
        /// <exception cref="NoPermissionException"></exception> 
        /// <exception cref="NotFoundException">Trow if no meme with desired id exists</exception>
        Task DeleteMeme(int memeId, int userId);
        
        /// <summary>
        /// Retrieve meme image based on id
        /// </summary>
        /// <param name="memeId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public FileStream GetMemeImage(int memeId);
    }
}