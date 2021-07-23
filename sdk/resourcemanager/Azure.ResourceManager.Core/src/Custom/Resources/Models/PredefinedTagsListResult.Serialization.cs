// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    internal partial class PredefinedTagsListResult
    {
        internal static PredefinedTagsListResult DeserializeTagsListResult(JsonElement element)
        {
            Optional<IReadOnlyList<PredefinedTagData>> value = default;
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
                    List<PredefinedTagData> array = new List<PredefinedTagData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PredefinedTagData.DeserializeTagDetails(item));
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
            return new PredefinedTagsListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
