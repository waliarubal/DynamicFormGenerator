using DynamicFormGenerator.Models;
using Microsoft.AspNetCore.Components;

namespace DynamicFormGenerator.Components;

public partial class FormField
{
    readonly IList<FormFieldType> _fieldTypes;

    public FormField() { 
        _fieldTypes = new List<FormFieldType>(Enum.GetValues<FormFieldType>());
    }

    #region properties

    IList<FormFieldType> FieldTypes => _fieldTypes;

    string Value { get; set; } = string.Empty;

    [Parameter]
    public EventCallback<FieldRecord> OnDeleted { get; set; }

    [Parameter]
    public FieldRecord Field { get; set; }

    #endregion

    async void RaiseOnDeleted()
    {
        await OnDeleted.InvokeAsync(Field);
    }

    void AddItem()
    {
        if (string.IsNullOrEmpty(Value))
            return;

        Field.Values.Add(Value);
        Value = string.Empty;
    }
}
