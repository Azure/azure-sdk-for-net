// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
