// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;

namespace Azure.Containers.ContainerRegistry
{
    public partial class ContainerRepositoryProperties
    {
        internal static ContainerRepositoryProperties DeserializeContainerRepositoryProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string registry = default;
            string imageName = default;
            DateTimeOffset createdTime = default;
            DateTimeOffset lastUpdateTime = default;
            int manifestCount = default;
            int tagCount = default;
            bool? deleteEnabled = default;
            bool? writeEnabled = default;
            bool? listEnabled = default;
            bool? readEnabled = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("registry"u8))
                {
                    registry = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("imageName"u8))
                {
                    imageName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("createdTime"u8))
                {
                    createdTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("lastUpdateTime"u8))
                {
                    lastUpdateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("manifestCount"u8))
                {
                    manifestCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("tagCount"u8))
                {
                    tagCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("changeableAttributes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("deleteEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deleteEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("writeEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            writeEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("listEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            listEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("readEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            readEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new ContainerRepositoryProperties(
                registry,
                imageName,
                createdTime,
                lastUpdateTime,
                manifestCount,
                tagCount,
                deleteEnabled,
                writeEnabled,
                listEnabled,
                readEnabled);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static ContainerRepositoryProperties FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeContainerRepositoryProperties(document.RootElement);
        }
    }
}
