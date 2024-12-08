namespace DynamicFormGenerator.Layout;

public partial class MainLayout
{
    bool IsDrawerOpen { get; set; }

    void ToggleDrawer()
    {
        IsDrawerOpen = !IsDrawerOpen;
    }
}
