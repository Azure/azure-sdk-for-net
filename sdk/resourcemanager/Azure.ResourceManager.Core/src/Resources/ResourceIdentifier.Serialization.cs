// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Canonical Representation of a Resource Identity.
    /// </summary>
    public abstract partial class ResourceIdentifier : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input ResourceIdentifier object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(ResourceType))
            {
                writer.WritePropertyName("resourceType");
                writer.WriteObjectValue(ResourceType);
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Parent))
            {
                writer.WritePropertyName("parent");
                writer.WriteObjectValue(Parent);
            }
            if (Optional.IsDefined(IsChild))
            {
                writer.WritePropertyName("isChild");
                writer.WriteBooleanValue(IsChild);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="resourceIdentifier"> The output ResourceIdentifier object. </param>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static void DeserializeResourceIdentifier(ResourceIdentifier resourceIdentifier, JsonElement element)
        {
            Optional<ResourceType> resourceType = default;
            Optional<string> name = default;
            Optional<ResourceIdentifier> parent = default;
            Optional<bool> isChild = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("resourceType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ToString().Equals("{\"namespace\":\"\",\"rootResourceType\":{},\"type\":\"\",\"types\":[]}"))
                    {
                        continue;
                    }
                    resourceType = ResourceType.DeserializeResourceType(property.Value);
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("parent"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || string.IsNullOrEmpty(property.Value.GetProperty("resourceType").GetProperty("namespace").GetString()))
                    {
                        continue;
                    }
                    DeserializeResourceIdentifier(parent.Value, property.Value);
                    continue;
                }
                if (property.NameEquals("isChild"))
                {
                    isChild = property.Value.GetBoolean();
                    continue;
                }
            }
            resourceIdentifier.ResourceType = resourceType;
            resourceIdentifier.Name = name;
            resourceIdentifier.Parent = parent;
            resourceIdentifier.IsChild = isChild;
        }
    }
}
