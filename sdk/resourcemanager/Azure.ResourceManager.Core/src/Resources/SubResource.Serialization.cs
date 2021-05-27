// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing a sub-resource that contains only the ID.
    /// </summary>
    public partial class SubResource<TIdentifier> : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input SubResource object.
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
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input JSON element to a SubResource object.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized.</param>
        /// <returns>Deserialized SubResource object.</returns>
        internal static SubResource<TIdentifier> DeserializeSubResource(JsonElement element)
        {
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new SubResource<TIdentifier>(id);
        }
    }
}
