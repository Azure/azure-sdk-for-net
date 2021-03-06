// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    internal partial class SqlTriggerListResult
    {
        internal static SqlTriggerListResult DeserializeSqlTriggerListResult(JsonElement element)
        {
            Optional<IReadOnlyList<SqlTriggerGetResults>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<SqlTriggerGetResults> array = new List<SqlTriggerGetResults>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SqlTriggerGetResults.DeserializeSqlTriggerGetResults(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new SqlTriggerListResult(Optional.ToList(value));
        }
    }
}
