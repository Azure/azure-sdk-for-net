// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal partial class PreDefinedTagsListResult
    {
        internal static PreDefinedTagsListResult DeserializeTagsListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PreDefinedTagData>> value = default;
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
                    List<PreDefinedTagData> array = new List<PreDefinedTagData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PreDefinedTagData.DeserializeTagDetails(item));
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
            return new PreDefinedTagsListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
