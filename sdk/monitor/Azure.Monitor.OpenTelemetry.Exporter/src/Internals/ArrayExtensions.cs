// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class ArrayExtensions
    {
        /// <summary>
        /// Builds a comma delimited string of the components of an array.
        /// </summary>
        /// <remarks>
        /// For example: new int[] { 1, 2, 3 } would be returned as "1,2,3".
        /// </remarks>
        /// <param name="input">An array to be evaluated.</param>
        /// <returns>A comma delimited string of the components of the input array.</returns>
        [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(input))]
        public static string? ToCommaDelimitedString(this Array? input)
        {
            return ToCommaDelimitedString(input, CultureInfo.InvariantCulture);
        }

        // This overload is used for testing purposes only.
        internal static string? ToCommaDelimitedString(this Array? input, CultureInfo cultureInfo)
        {
            if (input == null)
            {
                return null;
            }

            StringBuilder sb = new(input.Length);
            foreach (var item in input)
            {
                if (item != null)
                {
                    sb.Append(Convert.ToString(item, cultureInfo));
                    sb.Append(',');
                }
            }

            // remove trailing comma
            if (sb.Length > 0)
            {
                sb.Length--;
            }

            return sb.ToString();
        }
    }
}
