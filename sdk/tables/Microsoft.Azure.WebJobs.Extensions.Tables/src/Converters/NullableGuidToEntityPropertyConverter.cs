// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class NullableGuidToEntityPropertyConverter : IConverter<Guid?, EntityProperty>
    {
        public EntityProperty Convert(Guid? input)
        {
            return new EntityProperty(input);
        }
    }
}