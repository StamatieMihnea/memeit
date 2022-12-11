using MemeIT.IServices;
using MemeIT.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemeIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IMemeService _memeService;

        public MemesController(IMemeService memeService)
        {
            _memeService = memeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMemes()
        {
            List<Meme>? memes = await _memeService.GetMemes();
            if (memes != null)
            {
                return Ok(memes);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeme(int id)
        {
            Meme? meme = await _memeService.GetMeme(id);
            if (meme != null)
            {
                return Ok(meme);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeme(Meme meme)
        {
            Meme? addedMeme = await _memeService.AddMeme(meme);
            if (addedMeme != null)
            {
                return Ok(addedMeme);
            }

            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeMemeDescription(Meme meme)
        {
            Meme? modifiedMeme = await _memeService.ChangeDescription(meme);
            if (modifiedMeme != null)
            {
                return Ok(modifiedMeme);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMeme(int id)
        {
            bool deleted = await _memeService.DeleteMeme(id);
            if (deleted)
            {
                return Ok($"Meme with id = {id} successfully deleted");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}