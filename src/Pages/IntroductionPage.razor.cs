using Microsoft.AspNetCore.Components;

namespace DynamicFormGenerator.Pages;

public partial class IntroductionPage
{
    
    void Step1() => NavigationManager.NavigateTo("/define-form");

    void Step2() => NavigationManager.NavigateTo("/present-form");

    void Step3() => NavigationManager.NavigateTo("/gathered-form-data");
    
}
