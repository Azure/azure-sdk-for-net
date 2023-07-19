// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    internal static class DateTimeOffsetParser
    {
        private static readonly IFormatProvider s_provider = CultureInfo.InvariantCulture.DateTimeFormat;

        /// <summary>
        /// Parses string and returns DateTimeOffset adjusted to UTC time.
        /// </summary>
        /// <param name="input"> String representation of date time</param>
        /// <returns> DateTimeOffset adjusted to UTC time. </returns>
        /// <exception cref="ArgumentException"></exception>
        public static DateTimeOffset ParseAndGetDateTimeOffset(string input)
        {
            Argument.AssertNotNullOrWhiteSpace(input, nameof(input));

            var parseSuccessful = DateTimeOffset.TryParse(
                input,
                s_provider,
                DateTimeStyles.AdjustToUniversal,
                out DateTimeOffset sampleAsDateTimeOffset);

            if (parseSuccessful)
            {
                return sampleAsDateTimeOffset;
            }

            throw new ArgumentException("Invalid date time format");
        }
    }
}
