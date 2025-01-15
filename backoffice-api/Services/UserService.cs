using backoffice_api.Data;
using backoffice_api.Dtos;
using backoffice_api.Exceptions;
using backoffice_api.Models;

namespace backoffice_api.Services;

public class UserService(AppDbContext appDbContext, ILogger<UserService> logger) : IUserService
{

    private readonly AppDbContext _context = appDbContext;
    private readonly ILogger<UserService> _logger = logger;

    public List<UserOutDto> GetUsers()
    {
        
        List<User> users = _context.Users.ToList();
        _logger.LogDebug($"users found: {users}");

        //output list
        List<UserOutDto> usersOutDto = users.Select(user => UserOutDto.Build(user)).ToList();
        
        return usersOutDto;
    }

    public UserOutDto GetUserById(int id)
    {
        
        User user = _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new UserNotFoundException("user not found");
        _logger.LogDebug($"user found: {user}");
        
        return UserOutDto.Build(user);
    }

    public UserOutDto Create(UserInDto user)
    {
        
        //check if email and username are already present in DB
        if (_context.Users.FirstOrDefault(u => u.Email == user.Email) == null && _context.Users.FirstOrDefault(u => u.Username == user.UserName) != null)
        {
            throw new AlreadyExistingUserException("user already exists");
        }
        
        //creating new User
        User newUser = new User();
        newUser.Email = user.Email;
        newUser.Username = user.UserName;
        newUser.Password = user.Password;
        newUser.FirstName = user.FirstName;
        newUser.LastName = user.LastName;
        newUser.Group = user.Group;
        newUser.Role = Role.User;
        newUser.Status = (Status)Enum.Parse(typeof(Status), user.Status);
        
        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        _logger.LogDebug($"new user: {newUser}");

        return UserOutDto.Build(newUser);
    }

    public UserOutDto Update(int id, UserInDto user)
    {
        
        //getting user by id
        User userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new UserNotFoundException("user not found");
        
        //updating user
        userToUpdate.Email = user.Email;
        userToUpdate.Username = user.UserName;
        userToUpdate.Password = user.Password;
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Group = user.Group;
        userToUpdate.Role = Role.User;
        userToUpdate.Status = (Status)Enum.Parse(typeof(Status), user.Status);
        
        _context.SaveChanges();
        
        _logger.LogDebug($"User with Id: [{userToUpdate.Id}] updated");
        
        return UserOutDto.Build(userToUpdate);
    }

    public void Delete(int id)
    {
        
        User user = _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new UserNotFoundException("user not found");
        
        _context.Users.Remove(user);
        _context.SaveChanges();
        
        _logger.LogDebug($"User with Id: [{id}] deleted");
    }

    public UserOutDto GetUserByEmail(string email)
    {
        
        User user = _context.Users.FirstOrDefault(u => u.Email == email) ?? throw new UserNotFoundException("user not found");
        _logger.LogDebug($"user found: {user}");
        
        return UserOutDto.Build(user);
    }

    public UserOutDto GetUserByUsername(string username)
    {
        
        User user = _context.Users.FirstOrDefault(u => u.Username == username) ?? throw new UserNotFoundException("user not found");
        _logger.LogDebug($"user found: {user}");
        
        return UserOutDto.Build(user);
    }

    public List<UserOutDto> GetUsersByGroup(string groupName)
    {
        
        List<User> users = _context.Users.Where(u => u.Group == groupName).ToList();
        _logger.LogDebug($"users found: {users}");
        
        //building output
        List<UserOutDto> usersOutDto = users.Select(user => UserOutDto.Build(user)).ToList();
        return usersOutDto;
    }
}