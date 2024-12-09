using DynamicFormGenerator.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicFormGenerator.Services;

public class FormService : IFormService
{
    readonly JsonSerializerOptions _jsonOption;

    string _formJson;

    public FormService()
    {
        _jsonOption = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };
    }

    public FormRecord GenerateSampleForm()
    {
        return new()
        {
            Title = "Sample Form",
            Fields =
            [
                new FieldRecord
                {
                    FieldType = FormFieldType.Text,
                    Label = "Name",
                    IsRequired = true,
                },
                new FieldRecord
                {
                    FieldType = FormFieldType.Email,
                    Label = "Email",
                    IsRequired = true,
                },
                new FieldRecord
                {
                    FieldType = FormFieldType.Number,
                    Label = "Age",
                    Min = 18,
                    Max = 100
                },
                new FieldRecord
                {
                    FieldType = FormFieldType.Dropdown,
                    Label = "Industry",
                    Values = ["Tech", "Production", "Health"],
                    IsRequired = true,
                },
                new FieldRecord
                {
                    FieldType = FormFieldType.Checkbox,
                    Label = "Subscribe to Newsletter",
                    IsRequired = false,
                }
            ]
        };
    }

    public string SaveDesign(FormRecord form)
    {
        var error = form.Validate();
        if (string.IsNullOrEmpty(error))
            _formJson = JsonSerializer.Serialize(form, _jsonOption);

        return error;
    }

    public FormRecord GetDesign()
    {
        if (string.IsNullOrEmpty(_formJson))
            return new();

        return JsonSerializer.Deserialize<FormRecord>(_formJson);
    }

    public string GetDesignJson()
    {
        return _formJson;
    }
   

    //public string SetFormJson(string json)
    //{
    //    if (string.IsNullOrEmpty(json))
    //        return "Form JSON configuration not entered.";

    //    try
    //    {
    //        _configuration = JsonSerializer.Deserialize<FormConfiguration>(json, _jsonOption);
    //    }
    //    catch (JsonException)
    //    {
    //        return "Please check entered form JSON configuration.";
    //    }

    //    return null;
    //}

    //public string GetFormJson()
    //{
    //    return JsonSerializer.Serialize(_configuration, _jsonOption) ?? string.Empty;
    //}
}
