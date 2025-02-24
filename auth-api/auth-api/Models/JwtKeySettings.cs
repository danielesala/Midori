namespace auth_api.Models;

public class JwtKeySettings
{
    public string PrivateKey { get; set; } = string.Empty;
    public string PublicKey { get; set; } = string.Empty;
}