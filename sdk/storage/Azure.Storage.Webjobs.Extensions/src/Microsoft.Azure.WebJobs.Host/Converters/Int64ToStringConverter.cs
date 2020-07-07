// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class Int64ToStringConverter : IConverter<long, string>
    {
        public string Convert(long input)
        {
            return input.ToString(CultureInfo.InvariantCulture);
        }
    }
}
