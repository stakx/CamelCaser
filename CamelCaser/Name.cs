using System;
using System.Diagnostics;

namespace CamelCaser
{
    public static class Name
    {
        public static string ToLowerCamelCase(this string name)
        {
            Debug.Assert(name != null);

            if (name.Length == 0)
            {
                return name;
            }

            throw new NotImplementedException();
        }
    }
}
