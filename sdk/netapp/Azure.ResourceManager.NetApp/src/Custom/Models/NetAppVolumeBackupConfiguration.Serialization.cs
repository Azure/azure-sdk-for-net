// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeBackupConfiguration : IUtf8JsonSerializable
    {
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(BackupPolicyId))
            {
                writer.WritePropertyName("backupPolicyId");
                writer.WriteStringValue(BackupPolicyId);
            }
            if (Optional.IsDefined(IsPolicyEnforced))
            {
                writer.WritePropertyName("policyEnforced");
                writer.WriteBooleanValue(IsPolicyEnforced.Value);
            }
            if (Optional.IsDefined(VaultId))
            {
                writer.WritePropertyName("vaultId");
                writer.WriteStringValue(VaultId);
            }
            if (Optional.IsDefined(IsBackupEnabled))
            {
                writer.WritePropertyName("backupEnabled");
                writer.WriteBooleanValue(IsBackupEnabled.Value);
            }
            writer.WriteEndObject();
        }

        internal static NetAppVolumeBackupConfiguration DeserializeNetAppVolumeBackupConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ResourceIdentifier> backupPolicyId = default;
            Optional<bool> policyEnforced = default;
            Optional<bool> backupEnabled = default;
            Optional<ResourceIdentifier> vaultId = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("backupPolicyId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    backupPolicyId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("policyEnforced"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    policyEnforced = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("backupEnabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    backupEnabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("vaultId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    vaultId = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
            }
            return new NetAppVolumeBackupConfiguration(backupPolicyId.Value, Optional.ToNullable(policyEnforced), Optional.ToNullable(backupEnabled)){ VaultId = vaultId };
        }
    }
}
