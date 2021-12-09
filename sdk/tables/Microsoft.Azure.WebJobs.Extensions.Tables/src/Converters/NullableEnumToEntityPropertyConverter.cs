// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class NullableEnumToEntityPropertyConverter<TEnum> : IConverter<TEnum?, EntityProperty>
        where TEnum : struct
    {
        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        static NullableEnumToEntityPropertyConverter()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new InvalidOperationException("The Type must be an Enum.");
            }
        }

        public EntityProperty Convert(TEnum? input)
        {
            if (!input.HasValue)
            {
                return EntityProperty.GeneratePropertyForString(null);
            }

            return new EntityProperty(input.Value.ToString());
        }
    }
}