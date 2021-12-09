// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class NullableDateTimeToEntityPropertyConverter : IConverter<DateTime?, EntityProperty>
    {
        public EntityProperty Convert(DateTime? input)
        {
            if (input.HasValue)
            {
                DateTimeToEntityPropertyConverter.ThrowIfUnsupportedValue(input.Value);
            }

            return new EntityProperty(input);
        }
    }
}