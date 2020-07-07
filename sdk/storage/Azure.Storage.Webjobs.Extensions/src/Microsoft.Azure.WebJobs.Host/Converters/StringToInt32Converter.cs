// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToInt32Converter : IConverter<string, int>
    {
        public int Convert(string input)
        {
            return Int32.Parse(input, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
        }
    }
}
