// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToSingleConverter : IConverter<string, float>
    {
        public float Convert(string input)
        {
            const NumberStyles FloatWithoutWhitespace = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowExponent;

            return Single.Parse(input, FloatWithoutWhitespace, CultureInfo.InvariantCulture);
        }
    }
}
