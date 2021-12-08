// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class NullableDateTimeOffsetToEntityPropertyConverter : IConverter<DateTimeOffset?, EntityProperty>
    {
        public EntityProperty Convert(DateTimeOffset? input)
        {
            if (input.HasValue)
            {
                DateTimeToEntityPropertyConverter.ThrowIfUnsupportedValue(input.Value.UtcDateTime);
            }

            return new EntityProperty(input);
        }
    }
}