using DynamicFormGenerator.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicFormGenerator.Services;

public class SharedService: ISharedService
{
    readonly JsonSerializerOptions _jsonOption;

    FormConfiguration _configuration;
    string _outputJson;

    public SharedService()
    {
        _configuration = FormConfiguration.Generate();
        _jsonOption = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };
    }

    #region properties

    public FormConfiguration Configuration => _configuration;

    #endregion

    public string SetFormJson(string json)
    {
        if (string.IsNullOrEmpty(json))
            return "Form JSON configuration not entered.";
        
        try
        {
            _configuration = JsonSerializer.Deserialize<FormConfiguration>(json, _jsonOption);
        }
        catch (JsonException)
        {
            return "Please check entered form JSON configuration.";
        }

        return null;
    }

    public string GetFormJson()
    {
        return JsonSerializer.Serialize(_configuration, _jsonOption) ?? string.Empty;
    }
}
