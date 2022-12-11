using MemeIT.DbContext;
using MemeIT.Entities;
using MemeIT.Helpers.Exceptions;
using MemeIT.IServices;
using Microsoft.EntityFrameworkCore;

namespace MemeIT.Services
{
    public class MemeService : IMemeService
    {
        private readonly DbCon _dbContext;

        public MemeService(DbCon dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />>
        public async Task<List<Meme>> GetMemes()
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
        public async Task<Meme> GetMeme(int id)
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
        public async Task<Meme> ChangeDescription(Meme meme)
        {
            Meme? initialMeme = await GetMeme(meme.MemeId);
            if (initialMeme == null)
            {
                throw new NotFoundException($"Meme with id = {meme.MemeId} not found!");
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
        public async Task<Meme> AddMeme(Meme meme)
        {
            try
            {
                Meme addedMeme = (await _dbContext.AddAsync(meme)).Entity;
                await _dbContext.SaveChangesAsync();
                return addedMeme;
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
        }

        /// <inheritdoc />>
        public async Task DeleteMeme(int id)
        {
            Meme meme = await GetMeme(id);
            try
            {
                _dbContext.Remove(meme);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InternalProblemException("An internal error occurred!");
            }
        }
    }
}