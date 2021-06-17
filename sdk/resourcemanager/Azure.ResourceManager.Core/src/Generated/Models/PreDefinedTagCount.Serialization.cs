﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    public partial class PreDefinedTagCount
    {
        internal static PreDefinedTagCount DeserializeTagCount(JsonElement element)
        {
            Optional<string> type = default;
            Optional<int> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    value = property.Value.GetInt32();
                    continue;
                }
            }
            return new PreDefinedTagCount(type.Value, Optional.ToNullable(value));
        }
    }
}
