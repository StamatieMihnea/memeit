using MemeIT.Entities;
using MemeIT.Helpers.Exceptions;
using MemeIT.IServices;
using Microsoft.AspNetCore.Authorization;
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
            try
            {
                List<Meme> memes = await _memeService.GetMemes();
                return Ok(memes);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeme(int id)
        {
            try
            {
                Meme meme = await _memeService.GetMeme(id);
                return Ok(meme);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMeme(Meme meme)
        {
            try
            {
                Meme addedMeme = await _memeService.AddMeme(meme);
                return Ok(addedMeme);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> ChangeMemeDescription(Meme meme)
        {
            try
            {
                Meme modifiedMeme = await _memeService.ChangeDescription(meme);
                return Ok(modifiedMeme);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMeme(int id)
        {
            try
            {
                await _memeService.DeleteMeme(id);
                return Ok($"Meme with id = {id} successfully deleted");
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(e.Message);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}