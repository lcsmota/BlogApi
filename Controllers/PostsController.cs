using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public PostsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult> GetPostsAsync()
    {
        try
        {
            var posts = await _unitOfWork.PostsRepository.GetAllAsync();

            if (!posts.Any())
                return NotFound("Posts not found.");

            return Ok(posts);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetPostById")]
    public async Task<ActionResult> GetPostAsync(int id)
    {
        try
        {
            var post = await _unitOfWork.PostsRepository.GetByIdAsync(e => e.PostId == id);

            if (post is null) return NotFound("Post not found.");

            return Ok(post);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertPostAsync(Post post)
    {
        try
        {
            if (post is null) return BadRequest("Check the field(s) and try again.");

            await _unitOfWork.PostsRepository.InsertAsync(post);

            await _unitOfWork.CommitAsync();

            return CreatedAtRoute("GetPostById", new { id = post.PostId }, post);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdatePostAsync(int id, Post post)
    {
        try
        {
            if (post.PostId != id) return BadRequest("Check the field(s) and try again.");

            var dbPost = await _unitOfWork.PostsRepository.GetByIdAsync(e => e.PostId == id);
            if (dbPost is null) return NotFound("Post not found.");

            _unitOfWork.PostsRepository.Update(post);

            await _unitOfWork.CommitAsync();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeletePostAsync(int id)
    {
        try
        {
            var dbPost = await _unitOfWork.PostsRepository.GetByIdAsync(e => e.PostId == id);
            if (dbPost is null) return NotFound("Post not found.");

            _unitOfWork.PostsRepository.Delete(dbPost);

            await _unitOfWork.CommitAsync();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
