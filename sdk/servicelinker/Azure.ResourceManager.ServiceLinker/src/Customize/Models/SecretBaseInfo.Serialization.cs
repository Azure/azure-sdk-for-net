// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    public abstract partial class SecretBaseInfo : IUtf8JsonSerializable
    {
        internal static SecretBaseInfo DeserializeSecretBaseInfo(JsonElement element)
        {
            if (element.TryGetProperty("secretType", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "keyVaultSecretReference": return KeyVaultSecretReferenceSecretInfo.DeserializeKeyVaultSecretReferenceSecretInfo(element);
                    case "keyVaultSecretUri": return KeyVaultSecretUriSecretInfo.DeserializeKeyVaultSecretUriSecretInfo(element);
                    case "rawValue": return RawValueSecretInfo.DeserializeRawValueSecretInfo(element);
                }
            }
            throw new JsonException($"The deserialization of {typeof(SecretBaseInfo)} failed because of the invalid discriminator value.");
        }
    }
}
