﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupStatus
    {
        internal static NetAppVolumeBackupStatus DeserializeNetAppVolumeBackupStatus(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> healthy = default;
            Optional<NetAppRelationshipStatus> relationshipStatus = default;
            Optional<NetAppMirrorState> mirrorState = default;
            Optional<string> unhealthyReason = default;
            Optional<string> errorMessage = default;
            Optional<long> lastTransferSize = default;
            Optional<string> lastTransferType = default;
            Optional<long> totalTransferBytes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("healthy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    healthy = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("relationshipStatus"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    relationshipStatus = new NetAppRelationshipStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("mirrorState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mirrorState = new NetAppMirrorState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("unhealthyReason"u8))
                {
                    unhealthyReason = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorMessage"u8))
                {
                    errorMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastTransferSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastTransferSize = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("lastTransferType"u8))
                {
                    lastTransferType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("totalTransferBytes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    totalTransferBytes = property.Value.GetInt64();
                    continue;
                }
            }
            return new NetAppVolumeBackupStatus(Optional.ToNullable(healthy), Optional.ToNullable(relationshipStatus), Optional.ToNullable(mirrorState), unhealthyReason.Value, errorMessage.Value, Optional.ToNullable(lastTransferSize), lastTransferType.Value, Optional.ToNullable(totalTransferBytes));
        }
    }
}
