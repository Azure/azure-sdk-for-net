// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class Int64ToEntityPropertyConverter : IConverter<long, EntityProperty>
    {
        public EntityProperty Convert(long input)
        {
            return new EntityProperty(input);
        }
    }
}