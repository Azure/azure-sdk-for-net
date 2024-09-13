// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace CodeGenerationLibrary
{
    using System.Collections.Generic;
    using System.Globalization;

    public class StringUtilities
    {
        private static readonly IReadOnlyList<string> acronymList = new List<string>
            {
                "os",
                "vm",
                "ip"
            };

        public static string ToCamelCase(string str)
        {
            foreach (string s in acronymList)
            {
                if (str.StartsWith(s, ignoreCase: true, culture: CultureInfo.CurrentCulture))
                {
                    return s.ToLower() + str.Substring(s.Length);
                }
            }

            return char.ToLower(str[0]) + str.Substring(1);
        }

        public static string ToPascalCase(string str)
        {
            foreach (string s in acronymList)
            {
                if (str.StartsWith(s, ignoreCase: true, culture: CultureInfo.CurrentCulture))
                {
                    return s.ToUpper() + str.Substring(s.Length);
                }
            }

            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
