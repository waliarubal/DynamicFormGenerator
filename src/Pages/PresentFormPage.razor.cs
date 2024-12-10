using DynamicFormGenerator.Components;
using DynamicFormGenerator.Models;
using DynamicFormGenerator.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Dynamic;

namespace DynamicFormGenerator.Pages;

public partial class PresentFormPage
{
    readonly IList<FormFieldDynamic> _fields = [];

    #region properties

    [Inject]
    NavigationManager NavigationManager { get; set; }

    [Inject]
    ISnackbar SnackbarService { get; set; }

    [Inject]
    IFormService FormService { get; set; }

    // Whenever a dynamic field is added, its reference is stored for accessing it in code.
    FormFieldDynamic FieldRef
    {
        set
        {
            _fields.Add(value);
        }
    }

    DynamicForm Form { get; set; }

    #endregion

    protected override void OnInitialized()
    {
        Form = FormService.GetDesign();
    }

    void Save()
    {
        bool isHavingError = false;
        foreach (var field in _fields)
            isHavingError |= field.Validate();

        if (isHavingError)
            return;

        dynamic formData = new ExpandoObject();

        foreach(var field in _fields)
        {
            switch (field.Field.FieldType)
            {
                case FormFieldType.Text:
                case FormFieldType.Email:
                case FormFieldType.Dropdown:
                    ((IDictionary<string, object>)formData)[field.Field.Label] = field.Value;
                    break;

                case FormFieldType.Number:
                    ((IDictionary<string, object>)formData)[field.Field.Label] = field.ValueInt;
                    break;

                case FormFieldType.Checkbox:
                    ((IDictionary<string, object>)formData)[field.Field.Label] = field.ValueBool;
                    break;
            }
        }

        FormService.SaveData(formData);
        NavigationManager.NavigateTo("/gathered-form-data");
    }
}
