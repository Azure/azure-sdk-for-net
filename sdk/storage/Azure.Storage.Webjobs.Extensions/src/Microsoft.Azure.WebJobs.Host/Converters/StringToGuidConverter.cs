// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Converters
{
    internal class StringToGuidConverter : IConverter<string, Guid>
    {
        public Guid Convert(string input)
        {
            return Guid.ParseExact(input, "D");
        }
    }
}
