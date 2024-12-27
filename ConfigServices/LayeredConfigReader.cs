namespace ConfigServices;

public class LayeredConfigReader: IConfigReader
{
    private readonly IEnumerable<IConfigReader> services;

    public LayeredConfigReader(IEnumerable<IConfigReader> services)
    {
        this.services = services;
    }

    public string GetValue(string key)
    {
        string value = null;
        foreach (var configReader in services)
        {
            string newValue = configReader.GetValue(key);
            if (newValue != null)
            {
                value = newValue;
            }
        }
        return value;
    }
}