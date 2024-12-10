using DynamicFormGenerator.Models;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace DynamicFormGenerator.Components;

public partial class FormFieldDynamic
{
    const string EMAIL_PATTERN = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
        + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
        + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

    #region properties

    [Parameter]
    public DynamicField Field { get; set; }

    public string Value { get; set; }

    public int ValueInt { get; set; }

    public bool ValueBool { get; set; }

    string Placeholder => $"Enter value for {Field.Label}.";

    string ErrorText { get; set; }

    bool IsHavingError { get; set; }

    #endregion

    public bool Validate()
    {
        ErrorText = GetValidationMessage();
        IsHavingError = !string.IsNullOrEmpty(ErrorText);
        return IsHavingError;
    }

    string GetValidationMessage()
    {
        switch (Field.FieldType)
        {
            case FormFieldType.Text:
                if (Field.IsRequired && string.IsNullOrEmpty(Value))
                    return "Value is required.";

                if (Field.MinLength.HasValue && Value.Length < Field.MinLength)
                    return $"Value must be atleast {Field.MinLength} characters long.";

                if (Field.MaxLength.HasValue && Value.Length > Field.MaxLength)
                    return $"Value must not be more than {Field.MaxLength} characters.";
                break;

            case FormFieldType.Email:
                if (Field.IsRequired && string.IsNullOrEmpty(Value))
                    return "Value is required.";

                var regex = new Regex(EMAIL_PATTERN, RegexOptions.IgnoreCase);
                if (!string.IsNullOrEmpty(Value) && !regex.IsMatch(Value))
                    return "Value is not a valid email address.";
                break;

            case FormFieldType.Number:
                if (Field.Min.HasValue && ValueInt < Field.Min)
                    return $"Value must be greater than {Field.Min}.";

                if (Field.Max.HasValue && ValueInt > Field.Max)
                    return $"Value must be smaller than {Field.Max}.";
                break;

            case FormFieldType.Dropdown:
                if (Field.IsRequired && string.IsNullOrEmpty(Value))
                    return "Value is required.";
                
                if (!Field.Values.Contains(Value))
                    return "Selected value is not valid.";
                break;
        }

        return default;
    }
}
