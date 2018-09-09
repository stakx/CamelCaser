using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CamelCaser
{
    public static class Name
    {
        public static string ToLowerCamelCase(this string name)
        {
            Debug.Assert(name != null);

            if (name.Length == 0 || char.IsLower(name[0]))
            {
                return name;
            }

            if (name.Length < 2)
            {
                return name.ToLowerInvariant();
            }

            if (char.IsLower(name[1]))
            {
                var result = new StringBuilder(name.Length);
                result.Append(char.ToLower(name[0]));
                result.Append(name, 1, name.Length - 1);
                return result.ToString();
            }

            if (name.All(c => char.IsUpper(c)))
            {
                return name.ToLowerInvariant();
            }

            throw new NotImplementedException();
        }
    }
}
