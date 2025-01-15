using backoffice_api.Dtos;
using backoffice_api.Exceptions;
using backoffice_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace backoffice_api.Controllers;

[ApiController]
[Route("users")]
public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
{
    
    private readonly IUserService _userService = userService;
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet]
    public Task<IActionResult> GetAll()
    {
        return Task.FromResult<IActionResult>(Ok(_userService.GetUsers()));
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetById(int id)
    {
        UserOutDto user;

        try
        {
            user = _userService.GetUserById(id);
        }
        catch (UserNotFoundException exception)
        {
            _logger.LogError(exception.Message);
            return Task.FromResult<IActionResult>(NotFound(exception.Message));
        }
        
        return Task.FromResult<IActionResult>(Ok(user));
    }

    [HttpPost]
    public Task<IActionResult> Create(UserInDto user)
    {
        
        UserOutDto newUser;

        try
        {
            newUser = _userService.Create(user);
        }
        catch (AlreadyExistingUserException exception)
        {
            _logger.LogError(exception.Message);
            return Task.FromResult<IActionResult>(Conflict(exception.Message));
        }
        
        return Task.FromResult<IActionResult>(Ok(newUser));
    }

    [HttpPut("{id}")]
    public Task<IActionResult> Update(int id, UserInDto user)
    {
        
        UserOutDto updatedUser;

        try
        {
            updatedUser = _userService.Update(id, user);
        }
        catch (UserNotFoundException exception)
        {
            return Task.FromResult<IActionResult>(NotFound(exception.Message));
        }
        
        return Task.FromResult<IActionResult>(Ok(updatedUser));
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> Delete(int id)
    {
        
        _userService.Delete(id);
        return Task.FromResult<IActionResult>(NoContent());
    }

    [HttpGet("email/{email}")]
    public Task<IActionResult> GetByEmail(string email)
    {
        
        UserOutDto user;

        try
        {
            user = _userService.GetUserByEmail(email);
        }
        catch (UserNotFoundException exception)
        {
            _logger.LogError(exception.Message);
            return Task.FromResult<IActionResult>(NotFound(exception.Message));
        }

        return Task.FromResult<IActionResult>(Ok(user));
    }

    [HttpGet("username/{username}")]
    public Task<IActionResult> GetByUsername(string username)
    {
        UserOutDto user;

        try
        {
            user = _userService.GetUserByUsername(username);
        }
        catch (UserNotFoundException exception)
        {
            _logger.LogError(exception.Message);
            return Task.FromResult<IActionResult>(NotFound(exception.Message));
        }
        
        return Task.FromResult<IActionResult>(Ok(user));
    }

    [HttpGet("group/{groupName}")]
    public Task<IActionResult> GetByGroupName(string groupName)
    {
        
        List<UserOutDto> users;

        try
        {
            users = _userService.GetUsersByGroup(groupName);
        }
        catch (UserNotFoundException exception)
        {
            _logger.LogError(exception.Message);
            return Task.FromResult<IActionResult>(NotFound(exception.Message));
        }

        return Task.FromResult<IActionResult>(Ok(users));
    }
}