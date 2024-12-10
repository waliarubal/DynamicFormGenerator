using DynamicFormGenerator.Services;
using Microsoft.AspNetCore.Components;

namespace DynamicFormGenerator.Pages;

public partial class GatheredFormDataPage
{
    #region properties

    [Inject]
    IFormService FormService { get; set; }

    string DataJson { get; set; }

    #endregion

    protected override void OnInitialized()
    {
        DataJson = FormService.GetDataJson();
    }
}
