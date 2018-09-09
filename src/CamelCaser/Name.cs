// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/CamelCaser/blob/master/LICENSE.md.

namespace CamelCaser
{
    using System.Diagnostics;
    using System.Text;

    public static class Name
    {
        public static string ToLowerCamelCase(this string name)
        {
            Debug.Assert(name != null);

            // `n` is the length of `name`.
            var n = name.Length;

            // `l` is the index of the first lower-case char; or `n` if there is none.
            int l;
            for (l = 0; l < n && char.IsUpper(name[l]); ++l);

            if (l == 0)
            {
                // `name` already begins with a lower-case char; no need to do anything:
                return name;
            }
            else if (l == n)
            {
                // `name` does not contain any lower-case chars; lower-case it as a whole:
                return name.ToLowerInvariant();
            }
            else if (1 < l)
            {
                // `name` begins with several upper-case chars; lower-case all but the last:
                --l;
            }

            // lower-case the first `l` chars, and append the remaining chars unmodified:
            var result = new StringBuilder(n);
            for (int i = 0; i < l; ++i)
            {
                result.Append(char.ToLowerInvariant(name[i]));
            }
            result.Append(name, l, n - l);

            return result.ToString();
        }
    }
}
