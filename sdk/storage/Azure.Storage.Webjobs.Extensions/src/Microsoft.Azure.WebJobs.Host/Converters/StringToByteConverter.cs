// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToByteConverter : IConverter<string, byte>
    {
        public byte Convert(string input)
        {
           return Byte.Parse(input, NumberStyles.None, CultureInfo.InvariantCulture);
        }
    }
}
