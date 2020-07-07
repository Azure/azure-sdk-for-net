﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Host.Tables.Converters
{
    internal class EntityPropertyToNullableDateTimeOffsetConverter : IConverter<EntityProperty, DateTimeOffset?>
    {
        public DateTimeOffset? Convert(EntityProperty input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return input.DateTimeOffsetValue;
        }
    }
}
