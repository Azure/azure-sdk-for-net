// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Globalization;
using System.Numerics;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToBigIntegerConverter : IConverter<string, BigInteger>
    {
        public BigInteger Convert(string input)
        {
            return BigInteger.Parse(input, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);
        }
    }
}
