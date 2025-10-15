using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfFormDemo.Extensions
{
    public static class EnumExtensions
    {// Convert enum to display string
        public static string ToDisplayString(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes?.Length > 0)
                return attributes[0].Name;

            // Convert camel case to spaces
            return System.Text.RegularExpressions.Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1 $2");
        }

        // Get all enum values as ObservableCollection<string>
        public static ObservableCollection<string> GetDisplayValues<TEnum>() where TEnum : Enum
        {
            return new ObservableCollection<string>(
                Enum.GetValues(typeof(TEnum))
                    .Cast<TEnum>()
                    .Select(e => e.ToDisplayString())
            );
        }

        // Parse display string back to enum
        public static TEnum ParseDisplayString<TEnum>(string displayString) where TEnum : Enum
        {
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                if (value.ToDisplayString() == displayString)
                    return value;
            }
            throw new ArgumentException($"Invalid display string: {displayString}");
        }
    }
}
