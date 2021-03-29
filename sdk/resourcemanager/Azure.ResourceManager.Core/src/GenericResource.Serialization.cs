// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a generic azure resource along with the instance operations that can be performed on it.
    /// </summary>
    public partial class GenericResource : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input GenericResourceData object.
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
                writer.WriteObjectValue(Id);
            }
            if (Optional.IsDefined(Data))
            {
                writer.WritePropertyName("data");
                writer.WriteObjectValue(Data);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        /// <param name="operations"> The operations object to copy the client parameters from. </param>
        internal static GenericResource DeserializeGenericResource(ResourceOperationsBase operations, JsonElement element)
        {
            Optional<GenericResourceData> data = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("data"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    data = GenericResourceData.DeserializeGenericResourceData(property.Value);
                    continue;
                }
            }
            return new GenericResource(operations, data);
        }
    }
}
