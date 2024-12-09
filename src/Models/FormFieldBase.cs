namespace DynamicFormGenerator.Models;

public abstract class FormFieldBase
{
    #region properties

    public string Label { get; set; }
    public object Data { get; set; }
    public bool IsRequired { get; set; }

    #endregion

    public abstract string IsDataValid();
}
