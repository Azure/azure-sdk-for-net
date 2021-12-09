// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class EntityPropertyToNullableEnumConverter<TEnum> : IConverter<EntityProperty, TEnum?>
        where TEnum : struct
    {
        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        static EntityPropertyToNullableEnumConverter()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidOperationException("The Type must be an Enum.");
            }
        }

        public TEnum? Convert(EntityProperty input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string unparsed = input.StringValue;
            if (unparsed == null)
            {
                return null;
            }

            return (TEnum)Enum.Parse(typeof(TEnum), unparsed);
        }
    }
}