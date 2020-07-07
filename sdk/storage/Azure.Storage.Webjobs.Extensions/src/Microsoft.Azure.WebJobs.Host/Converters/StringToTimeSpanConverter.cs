// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToTimeSpanConverter : IConverter<string, TimeSpan>
    {
        public TimeSpan Convert(string input)
        {
            return TimeSpan.ParseExact(input, "c", CultureInfo.InvariantCulture);
        }
    }
}
