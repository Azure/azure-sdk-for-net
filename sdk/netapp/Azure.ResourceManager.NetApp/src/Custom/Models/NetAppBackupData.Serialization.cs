// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppBackupData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Label))
            {
                writer.WritePropertyName("label"u8);
                writer.WriteStringValue(Label);
            }
            if (Optional.IsDefined(UseExistingSnapshot))
            {
                writer.WritePropertyName("useExistingSnapshot"u8);
                writer.WriteBooleanValue(UseExistingSnapshot.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static NetAppBackupData DeserializeNetAppBackupData(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<Azure.ResourceManager.Models.SystemData> systemData = default;
            Optional<string> backupId = default;
            Optional<DateTimeOffset> creationDate = default;
            Optional<string> provisioningState = default;
            Optional<long> size = default;
            Optional<string> label = default;
            Optional<NetAppBackupType> backupType = default;
            Optional<string> failureReason = default;
            Optional<string> volumeName = default;
            Optional<bool> useExistingSnapshot = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<Azure.ResourceManager.Models.SystemData>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("backupId"u8))
                        {
                            backupId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("creationDate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            creationDate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            provisioningState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("size"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            size = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("label"u8))
                        {
                            label = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("backupType"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            backupType = new NetAppBackupType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("failureReason"u8))
                        {
                            failureReason = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("volumeName"u8))
                        {
                            volumeName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("useExistingSnapshot"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            useExistingSnapshot = property0.Value.GetBoolean();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new NetAppBackupData(id, name, type, systemData.Value, location, backupId.Value, Optional.ToNullable(creationDate), provisioningState.Value, Optional.ToNullable(size), label.Value, Optional.ToNullable(backupType), failureReason.Value, volumeName.Value, Optional.ToNullable(useExistingSnapshot));
        }
    }
}
