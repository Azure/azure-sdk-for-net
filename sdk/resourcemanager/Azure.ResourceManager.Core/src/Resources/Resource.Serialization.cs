// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the base resource used by all azure resources.
    /// </summary>
    public abstract partial class Resource
    {
        /// <summary>
        /// Serialize the input Resource object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input Resource object. </param>
        internal static void Serialize(Utf8JsonWriter writer, Resource value)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(value.Id))
            {
                writer.WritePropertyName("id");
                if (value.Id != null)
                {
                    ResourceIdentifier.Serialize(writer, value.Id);
                }
                else
                {
                    writer.WriteStartObject();
                    writer.WriteEndObject();
                }
            }
            if (Optional.IsDefined(value.Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(value.Name);
            }
            if (Optional.IsDefined(value.Type))
            {
                writer.WritePropertyName("type");
                ResourceType.Serialize(writer, value.Type);
            }
            writer.WriteEndObject();
        }
    }
}
