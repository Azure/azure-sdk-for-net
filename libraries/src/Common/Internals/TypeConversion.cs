//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Text;
using System.Xml;

namespace Microsoft.WindowsAzure.Common.Internals
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

        /// <summary>
        /// Convert a TimeSpan into an 8601 formatted string.
        /// </summary>
        /// <param name="timespan">The timespan to convert.</param>
        /// <returns>The TimeSpan in 8601 format.</returns>
        public static string To8601String(this TimeSpan timespan)
        {
            return XmlConvert.ToString(timespan);
        }

        /// <summary>
        /// Convert a string from ISO 8601 format to a TimeSpan instance.
        /// </summary>
        /// <param name="value">Value to parse</param>
        /// <returns>The resulting timespan</returns>
        public static TimeSpan From8601TimeSpan(string value)
        {
            return XmlConvert.ToTimeSpan(value);
        }
    }
}
