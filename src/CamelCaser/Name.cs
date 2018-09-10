// Copyright (c) 2018 stakx
// License available at https://github.com/stakx/CamelCaser/blob/master/LICENSE.md.

namespace CamelCaser
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public static class Name
    {
        public static string ToLowerCamelCase(this string name, CamelCaseOptions options = default(CamelCaseOptions))
        {
            Debug.Assert(name != null);

            // `n` is the length of `name`.
            var n = name.Length;

            if (n == 1)
            {
                return name.ToLowerInvariant();
            }

            // `l` is the index of the first lower-case char; or `n` if there is none.
            int l;
            for (l = 0; l < n && char.IsUpper(name[l]); ++l);

            // `i` will be the index of the first character of the resulting name:
            int i = 0;

            if (l == 0)
            {
                // `name` already begins with a lower-case char; no need to do anything:
                return name;
            }
            else if (l == n)
            {
                // `name` does not contain any lower-case chars:

                if ((options & CamelCaseOptions.InterfaceName) != 0 && name[0] == 'I')
                {
                    // possibly an interface name; skip the initial 'I':
                    ++i;
                }
                else
                {
                    // no interface name; lower-case it as a whole:
                    return name.ToLowerInvariant();
                }
            }
            else if (1 < l)
            {
                // `name` begins with several upper-case chars

                if ((options & CamelCaseOptions.InterfaceName) != 0 && name[0] == 'I')
                {
                    // possibly an interface name; skip the initial 'I':
                    ++i;
                }

                if (i + 1 < l)
                {
                    // if more than one upper-case char (after an optional 'I'), lower-case all but the last:
                    --l;
                }
            }

            // lower-case the first `l` chars, and append the remaining chars unmodified:
            var result = new StringBuilder(n);
            for (; i < l; ++i)
            {
                result.Append(char.ToLowerInvariant(name[i]));
            }
            result.Append(name, l, n - l);

            return result.ToString();
        }
    }

    [Flags]
    public enum CamelCaseOptions
    {
        InterfaceName = 1,
    }
}
