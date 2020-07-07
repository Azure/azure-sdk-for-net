// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToInt16Converter : IConverter<string, short>
    {
        public short Convert(string input)
        {
            return Int16.Parse(input, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
        }
    }
}
