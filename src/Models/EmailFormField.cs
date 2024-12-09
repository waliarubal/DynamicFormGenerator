using System.Text.RegularExpressions;

namespace DynamicFormGenerator.Models;

public class EmailFormField : FormFieldBase
{
    const string EMAIL_PATTERN = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

    public override string IsDataValid()
    {
        string data;
        try
        {
            data = Convert.ToString(Data);
            data = data.Trim();
        }
        catch
        {
            return "Value is not a valid.";
        }

        if (IsRequired && string.IsNullOrEmpty(data))
            return "Value is required.";

        var regex = new Regex(EMAIL_PATTERN, RegexOptions.IgnoreCase);
        if(!string.IsNullOrEmpty(data) && !regex.IsMatch(data))
            return "Value is not valid.";

        return default;
    }
}
