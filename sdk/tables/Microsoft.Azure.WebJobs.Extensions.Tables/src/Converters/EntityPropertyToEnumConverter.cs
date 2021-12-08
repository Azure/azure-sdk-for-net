// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class EntityPropertyToEnumConverter<TProperty> : IConverter<EntityProperty, TProperty>
    {
        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        static EntityPropertyToEnumConverter()
        {
            if (!typeof(TProperty).IsEnum)
            {
                throw new InvalidOperationException("The Type must be an Enum.");
            }
        }

        public TProperty Convert(EntityProperty input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string unparsed = input.StringValue;

            if (unparsed == null)
            {
                throw new InvalidOperationException("Enum property value must not be null.");
            }

            return (TProperty)Enum.Parse(typeof(TProperty), unparsed);
        }
    }
}