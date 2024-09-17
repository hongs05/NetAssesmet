

using Assesments.Data;
using Assesments.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assesments.Api;

[Authorize(AuthenticationSchemes = "ApiKey")]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserServices _userServices;

    public UsersController(UserServices userServices)
    {
        _userServices = userServices;
    }

    // Get all users
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userServices.GetAllUsersAsync();
        return Ok(users);
    }

    // Get user by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userServices.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // Create a new user
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDto user)
    {
        if (user == null)
            return BadRequest();
        try
        {
            await _userServices.AddUserAsync(new User
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                LastName = user.LastName,

            });

            return CreatedAtAction(nameof(AddUser), user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
            throw ex;

        }


    }
    // Delete a user
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _userServices.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();

        //await _userServices.DeleteUserAsync(id);
        return NoContent();
    }
    // // Update an existing user
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    // {
    //     if (id != user.Id || user == null)
    //         return BadRequest();

    //     var existingUser = await _userRepository.GetUserByIdAsync(id);
    //     if (existingUser == null)
    //         return NotFound();

    //     _userRepository.(user);
    //     return NoContent();
    // }

}
