// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

[assembly:CodeGenSuppressType("ContainerRegistryImportSource")]
namespace Azure.ResourceManager.ContainerRegistry.Models
{
    public partial class ContainerRegistryImportSource : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ResourceId))
            {
                writer.WritePropertyName("resourceId");
                writer.WriteStringValue(ResourceId);
            }
#pragma warning disable CS0618 // obsolete
            if (Optional.IsDefined(RegistryUri))
            {
                writer.WritePropertyName("registryUri");
                writer.WriteStringValue(RegistryUri.AbsoluteUri);
            }
#pragma warning restore CS0618 // obsolete
            if (Optional.IsDefined(RegistryAddress))
            {
                writer.WritePropertyName("registryUri");
                writer.WriteStringValue(RegistryAddress);
            }
            if (Optional.IsDefined(Credentials))
            {
                writer.WritePropertyName("credentials");
                writer.WriteObjectValue(Credentials);
            }
            writer.WritePropertyName("sourceImage");
            writer.WriteStringValue(SourceImage);
            writer.WriteEndObject();
        }
    }
}
