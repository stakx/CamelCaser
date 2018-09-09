using System;
using System.Diagnostics;

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

            throw new NotImplementedException();
        }
    }
}
