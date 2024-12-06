using System.Text.Json;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

public class JsonStringLocalizer : IStringLocalizer
{
    private readonly  Newtonsoft.Json.JsonSerializer _serializer = new();
    public LocalizedString this[string name] {
        get{
            var result = GetString(name);
            return new LocalizedString(name, result); // this will return an object
        }
    }

    public LocalizedString this[string name, params object[] arguments] {
        get {
            var valueObject = this[name];
            if (!valueObject.ResourceNotFound ) 
                return new LocalizedString(name, string.Concat(valueObject.Value, arguments));
            return valueObject;
        }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        throw new NotImplementedException();
    }
    public string GetString(string key) {
        var path = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
        var filePath = Path.GetFullPath(path);
        if (File.Exists(filePath)){
            var result = GetValueFromJson(key, filePath);
            return result;
        }
        return string.Empty;
        
    }   
    public string GetValueFromJson(string propertyName, string filePath) {
        if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(filePath)) 
            return string.Empty;
        using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        using StreamReader streamReader = new(stream);
        using JsonTextReader reader = new(streamReader);
        while (reader.Read()) {
            if (reader.TokenType == JsonToken.PropertyName && reader.Value as string == propertyName) {
                reader.Read();
                var resultValue = _serializer.Deserialize<string>(reader);
                return resultValue;
            }
        }
        return string.Empty;
    }
}