namespace GreenThumb.Model;

public record User
{
    public User()
    {
        Plants = new List<Plant>();
    }
    public int UserId { get; set; }
    public ICollection<Plant> Plants { get; set; }

    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }

    public static bool strongPassword(string password)
    {
        if (password.Length < 6 || password.Length > 12)
            return false;

        if (!password.Any(c => char.IsDigit(c)))
            return false;

        if (!password.Any(c => char.IsUpper(c)))
            return false;

        if (!password.Any(c => char.IsLower(c)))
            return false;

        if (!password.Any(c => char.IsSymbol(c)))
            return false;

        else
        return true;
    }

}