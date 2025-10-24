// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Generator.Management.Utilities
{
    internal static class StringExtensions
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            // Handle acronyms: if string starts with 2+ uppercase letters,
            // lowercase all leading uppercase letters except the last one if it's followed by a lowercase letter
            // Examples: ETag -> etag, ID -> id, XMLParser -> xmlParser, HTTPClient -> httpClient
            if (str.Length > 1 && char.IsUpper(str[1]))
            {
                int uppercaseCount = 1;
                while (uppercaseCount < str.Length && char.IsUpper(str[uppercaseCount]))
                {
                    uppercaseCount++;
                }

                // If all characters are uppercase, lowercase them all
                // Examples: ID -> id, HTTP -> http
                if (uppercaseCount == str.Length)
                {
                    return str.ToLower();
                }
                // If we have 3+ uppercase letters followed by lowercase, keep the last uppercase as-is
                // (it's the start of the next word). Examples: XMLParser -> xmlParser, HTTPClient -> httpClient
                else if (uppercaseCount > 2)
                {
                    return string.Concat(str.AsSpan(0, uppercaseCount - 1).ToString().ToLower(), str.AsSpan(uppercaseCount - 1).ToString());
                }
                // If we have exactly 2 uppercase letters followed by lowercase, lowercase both
                // Examples: ETag -> etag, IDentifier -> identifier
                else
                {
                    return string.Concat(str.AsSpan(0, uppercaseCount).ToString().ToLower(), str.AsSpan(uppercaseCount).ToString());
                }
            }

            return string.Concat(char.ToLower(str[0]), str.AsSpan(1).ToString());
        }
    }
}
