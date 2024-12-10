using System.Text.Json.Serialization;

namespace DynamicFormGenerator.Models;

public enum FormFieldType
{
    Text,
    Email,
    Number,
    Dropdown,
    Checkbox
}

public class DynamicField
{
    #region properties

    [JsonPropertyName("type")]
    public FormFieldType FieldType { get; set; }

    public string Label { get; set; }

    [JsonPropertyName("required")]
    public bool IsRequired { get; set; }

    public int? Min { get; set; }

    public int? Max { get; set; }

    public int? MinLength { get; set; }

    public int? MaxLength { get; set; }

    [JsonIgnore]
    public IList<string> Values { get; set; } = [];

    // we don't want to serialize empty list
    [JsonPropertyName("values")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IList<string> ValuesList 
    { 
        get => Values.Count > 0 ? Values : null;
        set => Values = value ?? []; 
    }

    #endregion

    public string Validate()
    {
        if (string.IsNullOrWhiteSpace(Label))
            return "Label for form field is required.";

        if (FieldType == FormFieldType.Number && Min.HasValue && Max.HasValue && Min > Max)
            return "Invalid acceptable number range.";

        if (FieldType == FormFieldType.Text && MinLength.HasValue && MaxLength.HasValue && MinLength > MaxLength)
            return "Invalid acceptable string length range.";

        if (FieldType == FormFieldType.Dropdown && Values.Count == 0)
            return "Selectable values are empty.";

        return default;
    }
}
