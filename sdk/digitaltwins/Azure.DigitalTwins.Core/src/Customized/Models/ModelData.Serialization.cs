// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    public partial class ModelData
    {
        // This class definition overrides deserialization implementation in order to turn the **object** type definitions for displayName and description into
        // dictionaries, as defined in swagger comments.

        internal static ModelData DeserializeModelData(JsonElement element)
        {
            Dictionary<string, string> displayName = default;
            Dictionary<string, string> description = default;
            string id = default;
            DateTimeOffset? uploadTime = default;
            bool? decommissioned = default;
            string model = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("displayName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    // manual change: deserialize as a dictionary
                    displayName = JsonSerializer.Deserialize<Dictionary<string, string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    // manual change: deserialize as a dictionary
                    description = JsonSerializer.Deserialize<Dictionary<string, string>>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("uploadTime"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    uploadTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("decommissioned"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    decommissioned = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("model"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    model = property.Value.GetRawText();
                    continue;
                }
            }
            return new ModelData(displayName, description, id, uploadTime, decommissioned, model);
        }
    }
}
