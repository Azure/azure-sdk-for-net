// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using System;
using System.Text;
using System.Xml;

namespace Hyak.Common.Internals
{
    /// <summary>
    /// Static type conversion utility methods.
    /// </summary>
    public static class TypeConversion
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its  equivalent 
        /// string representation that is encoded with base-64 digits.
        /// </summary>
        /// <param name="value">An array of 8-bit unsigned integers.</param>
        /// <returns>The string representation, in base 64, of the contents of 
        /// value.</returns>
        public static string ToBase64String(string value)
        {
            return value != null ? Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) : null;
        }

        /// <summary>
        /// Decodes all the bytes in the specified byte array into a string.
        /// </summary>
        /// <param name="value">The byte array containing the sequence of bytes 
        /// to decode.</param>
        /// <returns>A string that contains the results of decoding the 
        /// specified sequence of bytes.</returns>
        public static string BytesToString(byte[] value)
        {
            if (value != null)
            {
                return Encoding.UTF8.GetString(value, 0, value.Length);
            }

            return null;
        }

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-64
        /// digits, to a UTF8-encoded string.
        /// </summary>
        /// <param name="value">The base 64-encoded string to convert.</param>
        /// <returns>Returns a string.</returns>
        public static string FromBase64String(string value)
        {
            return BytesToString(Convert.FromBase64String(value));
        }

        /// <summary>
        /// Uses Uri::TryCreate method to safely attempt to parse a 
        /// string value and return its Uri representation. Supports
        /// relative Uris.
        /// </summary>
        /// <param name="value">The Uri string.</param>
        /// <returns>Returns a new Uri instance or null.</returns>
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
