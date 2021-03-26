// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Structure representing a resource type.
    /// </summary>
    public sealed partial class ResourceType
    {
        /// <summary>
        /// Serialize the input ResourceType object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input ResourceType object. </param>
        internal static void Serialize(Utf8JsonWriter writer, ResourceType value)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(value.Namespace))
            {
                writer.WritePropertyName("namespace");
                writer.WriteStringValue(value.Namespace);
            }
            if (Optional.IsDefined(value.Parent))
            {
                writer.WritePropertyName("parent");
                if (!value.Parent.Equals(new ResourceType()))
                {
                    Serialize(writer, value.Parent);
                }
                else
                {
                    writer.WriteStartObject();
                    writer.WriteEndObject();
                }
            }
            if (Optional.IsDefined(value.Type))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(value.Type);
            }
            writer.WriteEndObject();
        }
    }
}
