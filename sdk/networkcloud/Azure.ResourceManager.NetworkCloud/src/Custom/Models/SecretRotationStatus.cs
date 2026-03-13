// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.ClientModel.Primitives;
using SecretRotationStatusModel = Azure.ResourceManager.NetworkCloud.Models.SecretRotationStatus;

namespace Azure.ResourceManager.NetworkCloud.Models.Models
{
    internal static class SecretRotationStatus
    {
        internal static SecretRotationStatusModel DeserializeSecretRotationStatus(JsonElement element, ModelReaderWriterOptions options)
            => SecretRotationStatusModel.DeserializeSecretRotationStatus(element, options);
    }
}
