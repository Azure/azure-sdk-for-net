// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ResourceMover.Models
{
    public partial class MoverOperationStatus
    {
        internal static MoverOperationStatus DeserializeMoverOperationStatus(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> name = default;
            Optional<string> status = default;
            Optional<DateTimeOffset> startTime = default;
            Optional<DateTimeOffset> endTime = default;
            Optional<MoverOperationStatusError> error = default;
            Optional<BinaryData> properties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("startTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    // This customization can be removed after this issue https://github.com/Azure/autorest.csharp/issues/2655 is resolved.
                    if (DateTimeOffset.TryParse(property.Value.GetString(), out var res))
                    {
                        startTime = res;
                    }
                    continue;
                }
                if (property.NameEquals("endTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    // This customization can be removed after this issue https://github.com/Azure/autorest.csharp/issues/2655 is resolved.
                    if (DateTimeOffset.TryParse(property.Value.GetString(), out var res))
                    {
                        endTime = res;
                    }
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        error = null;
                        continue;
                    }
                    error = MoverOperationStatusError.DeserializeMoverOperationStatusError(property.Value);
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    properties = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new MoverOperationStatus(id.Value, name.Value, status.Value, Optional.ToNullable(startTime), Optional.ToNullable(endTime), error.Value, properties.Value);
        }
    }
}
