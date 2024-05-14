// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningPartialManagedServiceIdentity : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ManagedServiceIdentityType))
            {
                writer.WritePropertyName("type");
                writer.WriteStringValue(ManagedServiceIdentityType.Value.ToString());
            }
            if (Optional.IsCollectionDefined(UserAssignedIdentities))
            {
                writer.WritePropertyName("userAssignedIdentities");
                writer.WriteStartObject();
                foreach (var item in UserAssignedIdentities)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(item.Value.ToString()).RootElement);
#endif
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }
}
