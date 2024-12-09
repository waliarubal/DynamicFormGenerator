namespace DynamicFormGenerator.Models;

public class TextFormField : FormFieldBase
{
    #region properties

    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }

    #endregion

    public override string IsDataValid()
    {
        string data;
        try
        {
            data = Convert.ToString(Data);
        }
        catch
        {
            return "Value is not a valid.";
        }

        if (IsRequired && string.IsNullOrEmpty(data))
            return "Value is required.";

        if (MinLength.HasValue && data.Length < MinLength.Value)
            return $"Value must be atleast {MinLength.Value} characters long.";

        if (MaxLength.HasValue && data.Length > MaxLength.Value)
            return $"Value must not be more than {MaxLength.Value} characters.";

        return default;
    }
}
