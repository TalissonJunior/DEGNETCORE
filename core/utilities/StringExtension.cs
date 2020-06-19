using System;
using System.Linq;

namespace DEGNETCORE.core.utilities
{
    public static class StringExtension
    {
        public static string ToPascalCase(this string str, bool removeSpecialChars = true)
        {                    
            if(!string.IsNullOrEmpty(str) && str.Length > 1)
            {   
                if(removeSpecialChars) {
                    // Remove underscore and make each first char to uppercase
                    if(str.IndexOf("_") > -1) {
                        var splitted = str.Split("_").ToList();

                        splitted = splitted.Select(s => 
                            Char.ToUpperInvariant(s[0]) + s.Substring(1)
                        ).ToList();

                        str = String.Join("", splitted);
                    }
                }

                return Char.ToUpperInvariant(str[0]) + str.Substring(1);
            }

            return str;
        }

        public static string ToCamelCase(this string str)
        {                    
            if(!string.IsNullOrEmpty(str) && str.Length > 1)
            {   
                return Char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}