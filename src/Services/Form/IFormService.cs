using DynamicFormGenerator.Models;
using System.Dynamic;

namespace DynamicFormGenerator.Services;

public interface IFormService
{
    DynamicForm GenerateSampleForm();
    string SaveDesign(DynamicForm form);
    DynamicForm GetDesign();
    string GetDesignJson();
    void SaveData(ExpandoObject data);
    string GetDataJson();
}
