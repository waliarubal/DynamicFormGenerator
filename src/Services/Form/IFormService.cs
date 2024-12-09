using DynamicFormGenerator.Models;

namespace DynamicFormGenerator.Services;

public interface IFormService
{
    FormRecord GenerateSampleForm();
    string SaveDesign(FormRecord form);
    FormRecord GetDesign();
    string GetDesignJson();
}
