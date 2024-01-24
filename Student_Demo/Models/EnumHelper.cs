using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Student_Demo.Models;

public static class EnumHelper
{
    public static SelectList GetSelectList<TEnum>() where TEnum : Enum
    {
        var values = Enum.GetValues(typeof(TEnum))
                         .Cast<TEnum>()
                         .Select(e => new SelectListItem
                         {
                             Value = e.ToString(),
                             Text = Enum.GetName(typeof(TEnum), e)
                         });

        return new SelectList(values, "Value", "Text");
    }
}
