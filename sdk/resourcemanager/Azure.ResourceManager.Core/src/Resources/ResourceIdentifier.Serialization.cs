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
    public sealed partial class ResourceIdentifier : IUtf8JsonSerializable
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
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(Id);
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
            if (Optional.IsDefined(ResourceGroup))
            {
                writer.WritePropertyName("resourceGroup");
                writer.WriteStringValue(ResourceGroup);
            }
            if (Optional.IsDefined(Subscription))
            {
                writer.WritePropertyName("subscription");
                writer.WriteStringValue(Subscription);
            }
            if (Optional.IsDefined(Type))
            {
                writer.WritePropertyName("type");
                writer.WriteObjectValue(Type);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static ResourceIdentifier DeserializeResourceIdentifier(JsonElement element)
        {
            Optional<string> id = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new ResourceIdentifier(id.Value);
        }
    }
}
