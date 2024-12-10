using DynamicFormGenerator.Models;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicFormGenerator.Services;

public class FormService : IFormService
{
    readonly JsonSerializerOptions _jsonOption;

    string _formJson;
    string _formDataJson;

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

    public DynamicForm GenerateSampleForm()
    {
        return new()
        {
            Title = "Sample Form",
            Fields =
            [
                new DynamicField
                {
                    FieldType = FormFieldType.Text,
                    Label = "Name",
                    IsRequired = true,
                },
                new DynamicField
                {
                    FieldType = FormFieldType.Email,
                    Label = "Email",
                    IsRequired = true,
                },
                new DynamicField
                {
                    FieldType = FormFieldType.Number,
                    Label = "Age",
                    Min = 18,
                    Max = 100
                },
                new DynamicField
                {
                    FieldType = FormFieldType.Dropdown,
                    Label = "Industry",
                    Values = ["Tech", "Production", "Health"],
                    IsRequired = true,
                },
                new DynamicField
                {
                    FieldType = FormFieldType.Checkbox,
                    Label = "Subscribe to Newsletter",
                    IsRequired = false,
                }
            ]
        };
    }

    public string SaveDesign(DynamicForm form)
    {
        var error = form.Validate();
        if (string.IsNullOrEmpty(error))
            _formJson = JsonSerializer.Serialize(form, _jsonOption);

        return error;
    }

    public DynamicForm GetDesign()
    {
        if (string.IsNullOrEmpty(_formJson))
            return new();

        return JsonSerializer.Deserialize<DynamicForm>(_formJson, _jsonOption);
    }

    public string GetDesignJson()
    {
        return _formJson;
    }

    public void SaveData(ExpandoObject data)
    {
        _formDataJson = JsonSerializer.Serialize(data, _jsonOption);
    }

    public string GetDataJson()
    {
        return _formDataJson;
    }
}
