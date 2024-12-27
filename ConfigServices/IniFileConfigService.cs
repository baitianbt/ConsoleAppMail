namespace ConfigServices;

public class IniFileConfigService : IConfigService
{
    public string FilePath { get; set; }

    public string? GetValue(string name)
    {
        var kv = File.ReadAllLines(FilePath).Select(s => new { Name = s.Split('=')[0], Value = s.Split('=')[1] })
            .SingleOrDefault(kv => kv.Name == name);

        if (kv is not null)
        {
            return kv.Value;
        }
        else
        {
            return null;
        }
    }
}