// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToDoubleConverter : IConverter<string, double>
    {
        public double Convert(string input)
        {
            const NumberStyles FloatWithoutWhitespace = 
                NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent;

            return Double.Parse(input, FloatWithoutWhitespace, CultureInfo.InvariantCulture);
        }
    }
}
