// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Converters
{
    internal class EntityPropertyToPocoConverter<TProperty> : IConverter<EntityProperty, TProperty>
    {
        public TProperty Convert(EntityProperty input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            string json = input.StringValue;
            if (json == null)
            {
                throw new InvalidOperationException("The String property must not be null for JSON objects.");
            }

            return JsonConvert.DeserializeObject<TProperty>(json, JsonSerialization.Settings);
        }
    }
}