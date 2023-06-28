// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Globalization;
using System.Text;

namespace Azure.Security.KeyVault
{
    internal static partial class Extensions
    {
        /// <summary>
        /// Return the hexadecimal representation of the <paramref name="source"/> byte array.
        /// </summary>
        /// <param name="source">The byte array to format.</param>
        /// <returns>The hexadecimal representation of the <paramref name="source"/> byte array, or <c>null</c> if <paramref name="source"/> is null.</returns>
        public static string ToHexString(this byte[] source)
        {
            if (source is null)
            {
                return null;
            }

            StringBuilder sb = new(source.Length * 2);
            for (int i = 0; i < source.Length; i++)
            {
                sb.Append(source[i].ToString("x2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }
    }
}
