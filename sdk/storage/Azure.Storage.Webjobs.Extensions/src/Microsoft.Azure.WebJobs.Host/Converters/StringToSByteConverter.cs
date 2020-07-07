// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToSByteConverter : IConverter<string, sbyte>
    {
        public sbyte Convert(string input)
        {
            return SByte.Parse(input, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
        }
    }
}
