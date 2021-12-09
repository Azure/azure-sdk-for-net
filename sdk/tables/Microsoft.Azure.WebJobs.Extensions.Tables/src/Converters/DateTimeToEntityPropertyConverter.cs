// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class DateTimeToEntityPropertyConverter : IConverter<DateTime, EntityProperty>
    {
        private static readonly DateTime MinimumValidValue = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public EntityProperty Convert(DateTime input)
        {
            ThrowIfUnsupportedValue(input);
            return new EntityProperty(input);
        }

        internal static void ThrowIfUnsupportedValue(DateTime input)
        {
            if (input < MinimumValidValue)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Azure Tables cannot store DateTime values before the " +
                                                                     "year 1601. Did you mean to use a nullable DateTime?");
            }
        }
    }
}