namespace DynamicFormGenerator.Models;

public class FormRecord
{
    #region properties

    public string Title { get; set; } = string.Empty;

    public IList<FieldRecord> Fields { get; set; } = [];

    #endregion

    public string Validate()
    {
        if (string.IsNullOrWhiteSpace(Title))
            return "Form title is required.";

        if (Fields == null || Fields.Count == 0)
            return "Form must have atleast one field.";

        foreach (var field in Fields)
        {
            var error = field.Validate();
            if (string.IsNullOrEmpty(error))
                continue;

            return error;
        }

        return default;
    }
}
