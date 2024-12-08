using MudBlazor;

namespace DynamicFormGenerator.Pages;

public partial class DefineFormPage
{
    #region properties

    public string Json { get; set; } = string.Empty;

    #endregion

    protected override void OnInitialized()
    {
        Json = StateService.GetFormJson();
    }

    void PresentForm()
    {
        var error = StateService.SetFormJson(Json);
        if (string.IsNullOrEmpty(error))
            NavigationManager.NavigateTo("/present-form");
        else
            SnackbarService.Add(error, severity: Severity.Error);
    }
}
