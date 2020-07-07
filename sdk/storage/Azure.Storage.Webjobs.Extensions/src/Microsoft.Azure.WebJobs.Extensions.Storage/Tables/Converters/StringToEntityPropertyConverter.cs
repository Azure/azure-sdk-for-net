// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Host.Tables.Converters
{
    internal class StringToEntityPropertyConverter : IConverter<string, EntityProperty>
    {
        public EntityProperty Convert(string input)
        {
            return new EntityProperty(input);
        }
    }
}
