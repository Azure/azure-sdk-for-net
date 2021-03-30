// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Structure representing a resource type.
    /// </summary>
    public sealed partial class ResourceType : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input ResourceType object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Namespace))
            {
                writer.WritePropertyName("namespace");
                writer.WriteStringValue(Namespace);
            }
            if (Optional.IsDefined(RootResourceType))
            {
                writer.WritePropertyName("rootResourceType");
                if (!RootResourceType.Equals(new ResourceType()))
                {
                    writer.WriteObjectValue(RootResourceType);
                }
                else
                {
                    writer.WriteStartObject();
                    writer.WriteEndObject();
                }
            }
            if (Optional.IsDefined(Type))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(Type);
            }
            if (Optional.IsDefined(Types))
            {
                writer.WritePropertyName("types");
                writer.WriteStartArray();
                foreach (var item in Types)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static ResourceType DeserializeResourceType(JsonElement element)
        {
            Optional<string> nameSpace = default;
            Optional<ResourceType> rootResourceType = default;
            Optional<string> type = default;
            Optional<IList<string>> types = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("namespace"))
                {
                    nameSpace = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rootResourceType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ToString().Equals("{}"))
                    {
                        continue;
                    }
                    rootResourceType = DeserializeResourceType(property.Value);
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("types"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> list = new List<string>();
                    foreach (var property0 in property.Value.EnumerateArray())
                    {
                        list.Add(property0.GetString());
                    }
                    types = list;
                    continue;
                }
            }
            return new ResourceType(nameSpace.Value + "/" + type.Value);
        }
    }
}
