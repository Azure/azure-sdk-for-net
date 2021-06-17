// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    public partial class PreDefinedTagValue
    {
        internal static PreDefinedTagValue DeserializeTagValue(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> tagValue = default;
            Optional<PreDefinedTagCount> count = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tagValue"))
                {
                    tagValue = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("count"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    count = PreDefinedTagCount.DeserializeTagCount(property.Value);
                    continue;
                }
            }
            return new PreDefinedTagValue(id.Value, tagValue.Value, count.Value);
        }
    }
}
