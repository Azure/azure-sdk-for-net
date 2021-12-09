// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class PocoToEntityPropertyConverter<TProperty> : IConverter<TProperty, EntityProperty>
    {
        public EntityProperty Convert(TProperty input)
        {
            string json = JsonConvert.SerializeObject(input, JsonSerialization.Settings);
            return new EntityProperty(json);
        }
    }
}