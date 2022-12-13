using AutoMapper;
using MemeIT.DbContext;
using MemeIT.Entities;
using MemeIT.Helpers.CustomExceptions;
using MemeIT.IServices;
using MemeIT.Models;
using Microsoft.EntityFrameworkCore;

namespace MemeIT.Services
{
    public class MemeService : IMemeService
    {
        private readonly DbCon _dbContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;


        public MemeService(DbCon dbContext, IMapper mapper, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _environment = environment;
        }

        /// <inheritdoc />>
        public async Task<List<Meme>> GetAll()
        {
            try
            {
                return await _dbContext.Set<Meme>().ToListAsync();
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
        }

        /// <inheritdoc />>
        public async Task<Meme> Get(int id)
        {
            Meme? meme;
            try
            {
                meme = await _dbContext.Set<Meme>().FindAsync(id);
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }

            if (meme == null)
            {
                throw new NotFoundException($"Meme with id = {id} not found!");
            }

            return meme;
        }

        /// <inheritdoc />>
        public async Task<Meme> ChangeDescription(MemeModel meme, int userId)
        {
            Meme? initialMeme = await Get(meme.MemeId);
            if (initialMeme == null)
            {
                throw new NotFoundException($"Meme with id = {meme.MemeId} not found!");
            }

            if (initialMeme.UserId != userId)
            {
                throw new NoPermissionException("You can only modify your memes");
            }

            initialMeme.Description = meme.Description;
            try
            {
                _dbContext.Update(initialMeme);
                await _dbContext.SaveChangesAsync();
                return initialMeme;
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
        }

        /// <inheritdoc />>
        public async Task<Meme> Add(ImageMemeModel meme, int userId)
        {
            Meme addedMeme;
            try
            {
                Meme memeToAdd = _mapper.Map<Meme>(meme);
                memeToAdd.UserId = userId;
                addedMeme = (await _dbContext.AddAsync(memeToAdd)).Entity;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }

            await SaveMemeImage(meme.Image, addedMeme.MemeId, userId);
            return addedMeme;
        }

        /// <summary>
        /// Save meme image into filesystem based on meme id
        /// </summary>
        /// <param name="image">Image to be saved</param>
        /// <param name="memeId">Corresponding meme</param>
        /// <param name="userId">User trying to perform the action</param>
        /// <returns></returns>
        /// <exception cref="InternalProblemException"></exception>
        private async Task SaveMemeImage(IFormFile image, int memeId, int userId)
        {
            try
            {
                string path = Path.Combine(_environment.WebRootPath, "Images/",
                    $"{memeId}{Path.GetExtension(image.FileName)}");
                await using FileStream stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
                stream.Close();
            }
            catch (Exception)
            {
                //If image save fails the entry is remove from database in order to ensure that all memes have images
                await Delete(memeId, userId);
                throw new InternalProblemException("An internal error occurred while trying to save the image");
            }
        }

        /// <summary>
        /// Remove meme image from filesystem based in meme id
        /// </summary>
        /// <param name="memeId">Corresponding meme</param>
        /// <exception cref="InternalProblemException"></exception>
        private void RemoveMemeImage(int memeId)
        {
            try
            {
                string path = Path.Combine(_environment.WebRootPath, "Images/");
                string filesToDelete = $"{memeId}.*"; //Delete meme image of any extension
                string[] fileList = Directory.GetFiles(path, filesToDelete);
                foreach (string file in fileList)
                {
                    File.Delete(file);
                }
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred while trying to delete the image");
            }
        }

        /// <inheritdoc />>
        public async Task Delete(int memeId, int userId)
        {
            Meme meme = await Get(memeId);
            if (meme.UserId != userId)
            {
                throw new NoPermissionException("You can only modify your memes");
            }

            try
            {
                _dbContext.Remove(meme);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }

            RemoveMemeImage(memeId);
        }

        /// <inheritdoc />>
        public FileStream GetImage(int memeId)
        {
            try
            {
                string path = Path.Combine(_environment.WebRootPath, "Images/", $"{memeId}.png");
                var image = File.OpenRead(path);
                return image;
            }
            catch (Exception)
            {
                throw new NotFoundException("Meme image not found");
            }
           
        }
    }
}