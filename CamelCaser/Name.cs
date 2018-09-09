// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/CamelCaser/blob/master/LICENSE.md.

using System.Diagnostics;
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

            var result = new StringBuilder(name.Length);

            if (char.IsLower(name[1]))
            {
                result.Append(char.ToLower(name[0]));
                result.Append(name, 1, name.Length - 1);
                return result.ToString();
            }

            int i, n;

            for (i = 0, n = name.Length - 1; i <= n; ++i)
            {
                if (i != n && char.IsLower(name[i + 1]))
                {
                    break;
                }

                result.Append(char.ToLower(name[i]));
            }

            if (i < name.Length)
            {
                result.Append(name, i, name.Length - i);
            }

            return result.ToString();
        }
    }
}
