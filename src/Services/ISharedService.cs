using DynamicFormGenerator.Models;

namespace DynamicFormGenerator.Services;

public interface ISharedService
{
    FormConfiguration Configuration { get; }
    string SetFormJson(string json);
    string GetFormJson();
}
