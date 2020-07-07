// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToUInt32Converter : IConverter<string, uint>
    {
        public uint Convert(string input)
        {
            return UInt32.Parse(input, NumberStyles.None, CultureInfo.InvariantCulture);
        }
    }
}
