using MemeIT.Models;

namespace MemeIT.IServices
{
    public interface IMemeService
    {
        Task<List<Meme>?> GetMemes();

        Task<Meme?> GetMeme(int id);

        Task<Meme?> ChangeDescription(Meme meme);

        Task<Meme?> AddMeme(Meme meme);

        Task<bool> DeleteMeme(int id);
    }
}
