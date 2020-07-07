// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class GuidToStringConverter : IConverter<Guid, string>
    {
        public string Convert(Guid input)
        {
            // Use the default format "D" (adds hyphens but not braces): 00000000-0000-0000-0000-000000000000
            return input.ToString();
        }
    }
}
