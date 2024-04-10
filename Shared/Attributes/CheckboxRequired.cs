using System.ComponentModel.DataAnnotations;

namespace Shared.Attributes;

public class CheckboxRequired : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }
}
