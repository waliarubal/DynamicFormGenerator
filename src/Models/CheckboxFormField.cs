namespace DynamicFormGenerator.Models;

public class CheckboxFormField : FormFieldBase
{
    public override string IsDataValid()
    {
        if (IsRequired && Data == null)
            return "Value is required.";

        bool data;
        try
        {
            data = Convert.ToBoolean(Data);
        }
        catch
        {
            return "Value is not a valid.";
        }

        return default;
    }
}
