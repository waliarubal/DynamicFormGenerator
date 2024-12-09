using DynamicFormGenerator.Models;
using DynamicFormGenerator.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DynamicFormGenerator.Pages;

public partial class DefineFormPage
{
    #region properties

    [Inject]
    NavigationManager NavigationManager { get; set; }

    [Inject]
    ISnackbar SnackbarService { get; set; }

    [Inject]
    IFormService FormService { get; set; }

    string Json { get; set; } = string.Empty;

    public FormRecord Form { get; set; } = new();

    #endregion

    protected override void OnInitialized()
    {
        Form = FormService.GetDesign();
    }

    void GenerateSampleForm()
    {
        Form = FormService.GenerateSampleForm();
        SaveDesign();
    }

    void AddField()
    {
        Form.Fields.Add(new());
    }

    void DeleteField(FieldRecord record)
    {
        Form.Fields.Remove(record);
    }

    void ClearDesign()
    {
        Form.Title = string.Empty;
        Form.Fields.Clear();
        Json = string.Empty;
    }

    bool SaveDesign()
    {
        var isSaved = false;
        var error = FormService.SaveDesign(Form);
        if (string.IsNullOrEmpty(error))
        {

            isSaved = true;
            Json = FormService.GetDesignJson();
        }
            
        else
            SnackbarService.Add(error, severity: Severity.Error);

        return isSaved;
    }

    void PresentForm()
    {
        if(SaveDesign())
            NavigationManager.NavigateTo("/present-form");
    }
}
