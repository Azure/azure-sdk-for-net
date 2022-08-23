// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public abstract partial class CosmosDBAccountBackupPolicy : IUtf8JsonSerializable
    {
        internal static CosmosDBAccountBackupPolicy DeserializeCosmosDBAccountBackupPolicy(JsonElement element)
        {
            if (element.TryGetProperty("type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Periodic": return PeriodicModeBackupPolicy.DeserializePeriodicModeBackupPolicy(element);
                    case "Continuous": return ContinuousModeBackupPolicy.DeserializeContinuousModeBackupPolicy(element);
                }
            }
            throw new JsonException($"The deserialization of {typeof(CosmosDBAccountBackupPolicy)} failed because of the invalid discriminator value.");
        }
    }
}
