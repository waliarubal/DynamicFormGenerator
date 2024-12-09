namespace DynamicFormGenerator.Models;

public class NumberFormField: FormFieldBase
{

    #region properties

    public int? Min { get; set; }
    public int? Max { get; set; }

    #endregion

    public override string IsDataValid()
    {
        if (IsRequired && Data == null)
            return "Value is required.";

        int data;
        try
        {
            data = Convert.ToInt32(Data);
        }
        catch
        {
            return "Value is not a valid.";
        }

        if (Min.HasValue && data < Min.Value)
            return $"Value must be greater than {Min.Value}.";

        if (Max.HasValue && data > Max.Value)
            return $"Value must be smaller than {Max.Value}.";

        return default;
    }
}
