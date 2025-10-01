// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.Provisioning.Tests
{
    internal static class StringHelpers
    {
        public static string NormalizeLineEndings(this string input)
        {
            // Normalize line endings to LF
            return Regex.Replace(input, @"\r\n?", "\n");
        }
    }
}
