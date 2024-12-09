namespace DynamicFormGenerator.Models;

public class FormConfiguration
{
    public string Title { get; set; }
    public IList<FormFieldBase> Fields { get; set; } = [];
}
