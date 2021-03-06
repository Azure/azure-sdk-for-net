// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearningServices.Models
{
    internal partial class DatastorePropertiesResourceArmPaginatedResult
    {
        internal static DatastorePropertiesResourceArmPaginatedResult DeserializeDatastorePropertiesResourceArmPaginatedResult(JsonElement element)
        {
            Optional<IReadOnlyList<DatastorePropertiesResource>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<DatastorePropertiesResource> array = new List<DatastorePropertiesResource>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DatastorePropertiesResource.DeserializeDatastorePropertiesResource(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new DatastorePropertiesResourceArmPaginatedResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
