using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TodoStudent.Shared.Extensions;

public static class Extensions
{
    /// <summary>
    ///     A generic extension method that aids in reflecting 
    ///     and retrieving any attribute that is applied to an `T`.
    /// </summary>
    public static TAttribute GetAttribute<TAttribute>(this object model)
        where TAttribute : Attribute
    {
        return model.GetType()
            .GetMember(model.ToString())
            .First()
            .GetCustomAttribute<TAttribute>();
    }

    public static DisplayAttribute? GetDAttribute(this object? model)
    {
        if (model == null)
        {
            return null;
        }
        else
        {
            return model.GetType()
                .GetMember(model.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>();
        }
    }
}