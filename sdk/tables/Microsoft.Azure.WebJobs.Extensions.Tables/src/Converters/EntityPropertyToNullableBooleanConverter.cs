// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class EntityPropertyToNullableBooleanConverter : IConverter<EntityProperty, bool?>
    {
        public bool? Convert(EntityProperty input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input.BooleanValue;
        }
    }
}