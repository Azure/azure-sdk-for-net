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
    public sealed partial class ResourceIdentifier
    {
        /// <summary>
        /// Serialize the input ResourceIdentifier object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input ResourceIdentifier object. </param>
        internal static void Serialize(Utf8JsonWriter writer, ResourceIdentifier value)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(value.Id))
            {
                writer.WritePropertyName("id");
                writer.WriteStringValue(value.Id);
            }
            if (Optional.IsDefined(value.Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(value.Name);
            }
            if (Optional.IsDefined(value.Parent))
            {
                writer.WritePropertyName("parent");
                if (value.Parent != null)
                {
                    Serialize(writer, value.Parent);
                }
                else
                {
                    writer.WriteStartObject();
                    writer.WriteEndObject();
                }
            }
            if (Optional.IsDefined(value.ResourceGroup))
            {
                writer.WritePropertyName("resourceGroup");
                writer.WriteStringValue(value.ResourceGroup);
            }
            if (Optional.IsDefined(value.Subscription))
            {
                writer.WritePropertyName("subscription");
                writer.WriteStringValue(value.Subscription);
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
