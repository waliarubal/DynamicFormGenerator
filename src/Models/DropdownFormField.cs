namespace DynamicFormGenerator.Models;

public class DropdownFormField: FormFieldBase
{
    #region properties

    public IList<string> Values { get; set; }

    #endregion

    public override string IsDataValid()
    {
        if (IsRequired && Data == null)
            return "Value is required.";
        
        if (Data != null && !Values.Contains(Data))
            return $"Value '{Data}' is invalid.";

        return default;
    }
}
