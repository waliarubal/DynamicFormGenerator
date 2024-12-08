namespace DynamicFormGenerator.Models;

public class FormConfiguration
{
    public string Title { get; set; }

    public IList<FormField> Fields { get; set; }

    internal static FormConfiguration Generate()
    {
        return new()
        {
            Title = "Sample Form",
            Fields =
            [
                new()
                {
                    Type = FormFieldType.Text,
                    Label = "Name",
                    Required = true,
                },
                new()
                {
                    Type = FormFieldType.Email,
                    Label = "Email",
                    Required = true,
                },
                new()
                {
                    Type = FormFieldType.Number,
                    Label = "Age",
                    Min = 18,
                    Max = 100
                },
                new()
                {
                    Type = FormFieldType.Dropdown,
                    Label = "Industry",
                    Values = ["Texch", "Production", "Health"],
                    Required = true,
                },
                new()
                {
                    Type = FormFieldType.Checkbox,
                    Label = "Subscribe to Newsletter",
                    Required = false,
                }
            ]
        };
    }
}
