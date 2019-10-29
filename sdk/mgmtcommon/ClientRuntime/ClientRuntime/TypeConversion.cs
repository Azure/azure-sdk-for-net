// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text;

namespace Microsoft.Rest
{
    /// <summary>
    /// Static conversion utility methods.
    /// </summary>
    public static class TypeConversion
    {
        /// <summary>
        /// Converts a string to a UTF8-encoded string.
        /// </summary>
        /// <param name="value">The string of base-64 digits to convert.</param>
        /// <returns>The UTF8-encoded string.</returns>
        public static string FromBase64String(string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Uses Uri.TryCreate to parse a string as a relative or absolute Uri.
        /// </summary>
        /// <param name="value">The string to parse.</param>
        /// <returns>Uri or null.</returns>
        public static Uri TryParseUri(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Uri uri;
                if (Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out uri))
                {
                    return uri;
                }
            }

            return null;
        }
    }
}