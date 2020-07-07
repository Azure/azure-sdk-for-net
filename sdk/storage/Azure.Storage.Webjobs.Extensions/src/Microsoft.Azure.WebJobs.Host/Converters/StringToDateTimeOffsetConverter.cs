// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToDateTimeOffsetConverter : IConverter<string, DateTimeOffset>
    {
        public DateTimeOffset Convert(string input)
        {
            return DateTimeOffset.ParseExact(input, "O", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
        }
    }
}
