// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToUInt64Converter : IConverter<string, ulong>
    {
        public ulong Convert(string input)
        {
            return UInt64.Parse(input, NumberStyles.None, CultureInfo.InvariantCulture);
        }
    }
}
