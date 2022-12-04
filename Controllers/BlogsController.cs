using BlogApi.Interfaces;
using BlogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BlogsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public BlogsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult> GetBlogsAsync()
    {
        try
        {
            var blogs = await _unitOfWork.BlogsRepository.GetAllAsync();

            if (!blogs.Any())
                return NotFound("Blogs not found.");

            return Ok(blogs);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetBlogById")]
    public async Task<ActionResult> GetBlogAsync(int id)
    {
        try
        {
            var blog = await _unitOfWork.BlogsRepository.GetByIdAsync(e => e.BlogId == id);

            if (blog is null)
                return NotFound("Blog not found.");

            return Ok(blog);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertBlogAsync(Blog blog)
    {
        try
        {
            if (blog is null)
                return BadRequest("Check the field(s) and try again");

            await _unitOfWork.BlogsRepository.InsertAsync(blog);

            await _unitOfWork.CommitAsync();

            return CreatedAtRoute("GetBlogById", new { id = blog.BlogId }, blog);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateBlogAsync(int id, Blog blog)
    {
        try
        {
            if (blog.BlogId != id)
                return BadRequest("Check the field(s) and try again");

            var dbBlog = await _unitOfWork.BlogsRepository.GetByIdAsync(e => e.BlogId == id);
            if (dbBlog is null) return NotFound("Blog not found.");

            _unitOfWork.BlogsRepository.Update(blog);

            await _unitOfWork.CommitAsync();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteBlogAsync(int id)
    {
        try
        {
            var dbBlog = await _unitOfWork.BlogsRepository.GetByIdAsync(e => e.BlogId == id);
            if (dbBlog is null) return NotFound("Blog not found.");

            _unitOfWork.BlogsRepository.Delete(dbBlog);

            await _unitOfWork.CommitAsync();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
