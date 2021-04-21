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
    public partial class SubResourceReadOnly : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input SubResourceReadOnly object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input JSON element to a SubResourceReadOnly object.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized.</param>
        /// <returns>Deserialized SubResourceReadOnly object.</returns>
        internal static SubResourceReadOnly DeserializeSubResourceReadOnly(JsonElement element)
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
            return new SubResourceReadOnly(id.Value);
        }
    }
}
