// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Text;

namespace Microsoft.TypeSpec.Generator.AspNetServer
{
    /// <summary>
    /// Helpers for translating TypeSpec identifiers (typically camelCase) into
    /// idiomatic C# names. Intentionally minimal; expand as more cases arise.
    /// </summary>
    internal static class NameUtilities
    {
        public static string ToPascalCase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }

            var sb = new StringBuilder(name.Length);
            bool capitalizeNext = true;
            foreach (var ch in name)
            {
                if (ch == '_' || ch == '-' || ch == ' ')
                {
                    capitalizeNext = true;
                    continue;
                }

                sb.Append(capitalizeNext ? char.ToUpper(ch, CultureInfo.InvariantCulture) : ch);
                capitalizeNext = false;
            }

            return sb.ToString();
        }
    }
}
