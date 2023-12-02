using Attendance.Server.Authorization;
using Attendance.Server.Models;
using Attendance.Shared.DTOs.Requests;
using Attendance.Shared.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Attendance.Server.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _users;
    private readonly AppSettings _settings;

    public UserController(IUserRepository users, IOptions<AppSettings> settings)
    {
        _users = users;
        _settings = settings.Value;
    }

    // [AllowAnonymouse]
    // [HttpPost("authenticate")]
    // public


    /// <summary>
    ///  Returns a list of paginated users with a default page size of 5.
    /// </summary>
    [HttpGet]
    [AllowAnonymouse]
    [Route("GetAllPaged")]
    [ProducesResponseType(200)]
    public IActionResult GetUsers([FromQuery] string? name, int page)
    {
        return Ok(_users.GetUsers(name, page));
    }

    /// <summary>
    ///  Returns a list of users.
    /// </summary>
    [HttpGet]
    [AllowAnonymouse]
    [Route("GetAll")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _users.GetAllAsync());
    }

    /// <summary>
    /// Get a specific user by id.
    /// </summary>
    [HttpGet("{id}")]
    [AllowAnonymouse]
    [Route("Get")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(await _users.GetUser(id));
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateUser(UserRequestDto user)
    {
        // TODO add mappings
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpPut]
    [Route("Update")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdateUser(UserRequestDto user)
    {
        // TODO add mappings
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    [HttpDelete]
    [Route("Delete")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> DeleteUser(int id)
    {
        // TODO add mappings
        throw new NotImplementedException();
    }
}