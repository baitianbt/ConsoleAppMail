namespace ConfigServices;

public interface IConfigService
{
    public string? GetValue(string key);
}