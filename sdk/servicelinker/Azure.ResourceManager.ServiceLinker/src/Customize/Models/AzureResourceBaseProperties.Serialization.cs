// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    public abstract partial class AzureResourceBaseProperties : IUtf8JsonSerializable
    {
        internal static AzureResourceBaseProperties DeserializeAzureResourceBaseProperties(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "KeyVault": return AzureKeyVaultProperties.DeserializeAzureKeyVaultProperties(element);
                }
            }
            throw new JsonException($"The deserialization of {typeof(AzureResourceBaseProperties)} failed because of the invalid discriminator value.");
        }
    }
}
