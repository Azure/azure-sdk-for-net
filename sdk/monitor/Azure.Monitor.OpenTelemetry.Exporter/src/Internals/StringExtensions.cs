// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class StringExtensions
    {
        /// <summary>
        /// This method will truncate a string if that string exceeds a specified max length.
        /// </summary>
        /// <remarks>
        /// This method is a wrapper around <see cref="string.Substring(int, int)"/>.
        /// </remarks>
        /// <param name="input">A string to be evaluated.</param>
        /// <param name="maxLength">A specified length which is used to evaluate the input string.</param>
        /// <returns>The input string if less than max length, or a substring that begins at 0.</returns>
        public static string? Truncate(this string? input, int maxLength)
        {
            if (input == null)
            {
                return null;
            }

            if (maxLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxLength), "Must be a positive integer.");
            }

            return input.Length > maxLength
                ? input.Substring(0, maxLength)
                : input;
        }
    }
}
