namespace auth_api.Clients;

public class BackOfficeClient (HttpClient httpClient)
{

    private readonly HttpClient _httpClient = httpClient;
    
    public async Task<UserDto?> GetUserByIdAsync(int userId)
    {
        return await _httpClient.GetFromJsonAsync<UserDto>($"users/{userId}");
    }

}

public class UserDto
{
    public int Id { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Username { get; set; } = string.Empty;
    
    public string Role { get; set; } = string.Empty;
    
    public string Group { get; set; } = string.Empty;
}