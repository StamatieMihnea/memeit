using MemeIT.Entities;
using MemeIT.Helpers.CustomExceptions;
using MemeIT.IServices;
using MemeIT.Models;
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
                List<Meme> memes = await _memeService.GetAll();
                return Ok(memes);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = e.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeme(int id)
        {
            try
            {
                Meme meme = await _memeService.Get(id);
                return Ok(meme);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = e.Message });
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMeme([FromForm] ImageMemeModel meme)
        {
            int userId = Convert.ToInt32(User.Claims.First(c => c.Type == "id").Value);
            try
            {
                Meme addedMeme = await _memeService.Add(meme, userId);
                return Ok(addedMeme);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new { error = e.Message });
            }
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> ChangeMemeDescription(MemeModel meme)
        {
            int userId = Convert.ToInt32(User.Claims.First(c => c.Type == "id").Value);
            try
            {
                Meme modifiedMeme = await _memeService.ChangeDescription(meme, userId);
                return Ok(modifiedMeme);
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = e.Message });
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(new { error = e.Message });
            }
            catch (Exception e) when (e is NoPermissionException)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { error = e.Message });
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteMeme(int memeId)
        {
            int userId = Convert.ToInt32(User.Claims.First(c => c.Type == "id").Value);
            try
            {
                await _memeService.Delete(memeId, userId);
                return Ok($"Meme with id = {memeId} successfully deleted");
            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(new { error = e.Message });
            }
            catch (Exception e) when (e is InternalProblemException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = e.Message });
            }
            catch (Exception e) when (e is NoPermissionException)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { error = e.Message });
            }
        }

        [HttpGet]
        [Route("image/{memeId}")]
        public IActionResult GetMemeImage(int memeId)
        {
            try
            {
                return File(_memeService.GetImage(memeId), "image/png");

            }
            catch (Exception e) when (e is NotFoundException)
            {
                return NotFound(new { error = e.Message });
            }
        }
    }
}