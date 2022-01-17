// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    public partial class PredefinedTagData
    {
        internal static PredefinedTagData DeserializeTagDetails(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> tagName = default;
            Optional<PredefinedTagCount> count = default;
            Optional<IReadOnlyList<PredefinedTagValue>> values = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tagName"))
                {
                    tagName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("count"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    count = PredefinedTagCount.DeserializeTagCount(property.Value);
                    continue;
                }
                if (property.NameEquals("values"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<PredefinedTagValue> array = new List<PredefinedTagValue>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PredefinedTagValue.DeserializeTagValue(item));
                    }
                    values = array;
                    continue;
                }
            }
            return new PredefinedTagData(id.Value, tagName.Value, count.Value, Optional.ToList(values));
        }
    }
}
