using MemeIT.DbContext;
using MemeIT.IServices;
using MemeIT.Models;
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

        public async Task<List<Meme>?> GetMemes()
        {
            try
            {
                return await _dbContext.Set<Meme>().ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Meme?> GetMeme(int id)
        {
            try
            {
                return await _dbContext.Set<Meme>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Meme?> ChangeDescription(Meme meme)
        {
            var initialMeme = await GetMeme(meme.MemeId);
            if (initialMeme == null) return initialMeme;
            initialMeme.Description = meme.Description;
            try
            {
                _dbContext.Update(initialMeme);
                await _dbContext.SaveChangesAsync();
                return initialMeme;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Meme?> AddMeme(Meme meme)
        {
            try
            {
                Meme addedMeme = (await _dbContext.AddAsync(meme)).Entity;
                await _dbContext.SaveChangesAsync();
                return addedMeme;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteMeme(int id)
        {
            var meme = await GetMeme(id);
            if (meme == null) return false;
            try
            {
                _dbContext.Remove(meme);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}