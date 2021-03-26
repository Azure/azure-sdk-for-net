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
            if (Optional.IsDefined(Parent))
            {
                writer.WritePropertyName("parent");
                if (!Parent.Equals(new ResourceType()))
                {
                    writer.WriteObjectValue(Parent);
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
            writer.WriteEndObject();
        }
    }
}
