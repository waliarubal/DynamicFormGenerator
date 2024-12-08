namespace DynamicFormGenerator.Models;

public enum FormFieldType
{
    Text,
    Email,
    Number,
    Dropdown,
    Checkbox
}

public class FormField
{
    public FormFieldType Type { get; set; }

    public string Label { get; set; }

    public bool Required { get; set; }

    public IList<string> Values { get; set; }

    public int? Min {  get; set; }

    public int? Max { get; set; }
}
