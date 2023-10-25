// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Redis.Models
{
    public partial class RedisCommonConfiguration : IUtf8JsonSerializable
    {
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(IsRdbBackupEnabled))
            {
                writer.WritePropertyName("rdb-backup-enabled"u8);
                writer.WriteBooleanValue(IsRdbBackupEnabled.Value);
            }
            if (Optional.IsDefined(RdbBackupFrequency))
            {
                writer.WritePropertyName("rdb-backup-frequency"u8);
                writer.WriteStringValue(RdbBackupFrequency);
            }
            if (Optional.IsDefined(RdbBackupMaxSnapshotCount))
            {
                writer.WritePropertyName("rdb-backup-max-snapshot-count"u8);
                writer.WriteStringValue(RdbBackupMaxSnapshotCount.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (Optional.IsDefined(RdbStorageConnectionString))
            {
                writer.WritePropertyName("rdb-storage-connection-string"u8);
                writer.WriteStringValue(RdbStorageConnectionString);
            }
            if (Optional.IsDefined(IsAofBackupEnabled))
            {
                writer.WritePropertyName("aof-backup-enabled"u8);
                writer.WriteBooleanValue(IsAofBackupEnabled.Value);
            }
            if (Optional.IsDefined(AofStorageConnectionString0))
            {
                writer.WritePropertyName("aof-storage-connection-string-0"u8);
                writer.WriteStringValue(AofStorageConnectionString0);
            }
            if (Optional.IsDefined(AofStorageConnectionString1))
            {
                writer.WritePropertyName("aof-storage-connection-string-1"u8);
                writer.WriteStringValue(AofStorageConnectionString1);
            }
            if (Optional.IsDefined(MaxFragmentationMemoryReserved))
            {
                writer.WritePropertyName("maxfragmentationmemory-reserved"u8);
                writer.WriteStringValue(MaxFragmentationMemoryReserved);
            }
            if (Optional.IsDefined(MaxMemoryPolicy))
            {
                writer.WritePropertyName("maxmemory-policy"u8);
                writer.WriteStringValue(MaxMemoryPolicy);
            }
            if (Optional.IsDefined(MaxMemoryReserved))
            {
                writer.WritePropertyName("maxmemory-reserved"u8);
                writer.WriteStringValue(MaxMemoryReserved);
            }
            if (Optional.IsDefined(MaxMemoryDelta))
            {
                writer.WritePropertyName("maxmemory-delta"u8);
                writer.WriteStringValue(MaxMemoryDelta);
            }
            if (Optional.IsDefined(PreferredDataPersistenceAuthMethod))
            {
                writer.WritePropertyName("preferred-data-persistence-auth-method"u8);
                writer.WriteStringValue(PreferredDataPersistenceAuthMethod);
            }
            if (Optional.IsDefined(AuthNotRequired))
            {
                writer.WritePropertyName("authnotrequired"u8);
                writer.WriteStringValue(AuthNotRequired);
            }
            if (Optional.IsDefined(StorageSubscriptionId))
            {
                writer.WritePropertyName("storage-subscription-id"u8);
                writer.WriteStringValue(StorageSubscriptionId);
            }
            foreach (var item in AdditionalProperties)
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

        internal static RedisCommonConfiguration DeserializeRedisCommonConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> rdbBackupEnabled = default;
            Optional<string> rdbBackupFrequency = default;
            Optional<int> rdbBackupMaxSnapshotCount = default;
            Optional<string> rdbStorageConnectionString = default;
            Optional<bool> aofBackupEnabled = default;
            Optional<string> aofStorageConnectionString0 = default;
            Optional<string> aofStorageConnectionString1 = default;
            Optional<string> maxfragmentationmemoryReserved = default;
            Optional<string> maxmemoryPolicy = default;
            Optional<string> maxmemoryReserved = default;
            Optional<string> maxmemoryDelta = default;
            Optional<string> maxclients = default;
            Optional<string> preferredDataArchiveAuthMethod = default;
            Optional<string> preferredDataPersistenceAuthMethod = default;
            Optional<string> zonalConfiguration = default;
            Optional<string> authnotrequired = default;
            Optional<string> storageSubscriptionId = default;
            IDictionary<string, BinaryData> additionalProperties = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rdb-backup-enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }

                    rdbBackupEnabled = property.Value.ValueKind == JsonValueKind.String
                        ? string.Equals(property.Value.GetString(), "true", StringComparison.InvariantCultureIgnoreCase)
                        : property.Value.GetBoolean();

                    continue;
                }
                if (property.NameEquals("rdb-backup-frequency"u8))
                {
                    rdbBackupFrequency = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("rdb-backup-max-snapshot-count"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    if (!int.TryParse(property.Value.GetString(), out int rdbBackupMaxSnapshotCountValue))
                    {
                        throw new FormatException($"cannot parse {property.Value.GetString()} into an int for property {property.Name}");
                    }
                    rdbBackupMaxSnapshotCount = rdbBackupMaxSnapshotCountValue;
                    continue;
                }
                if (property.NameEquals("rdb-storage-connection-string"u8))
                {
                    rdbStorageConnectionString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("aof-backup-enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }

                    aofBackupEnabled = property.Value.ValueKind == JsonValueKind.String
                        ? string.Equals(property.Value.GetString(), "true", StringComparison.InvariantCultureIgnoreCase)
                        : property.Value.GetBoolean();

                    continue;
                }
                if (property.NameEquals("aof-storage-connection-string-0"u8))
                {
                    aofStorageConnectionString0 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("aof-storage-connection-string-1"u8))
                {
                    aofStorageConnectionString1 = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxfragmentationmemory-reserved"u8))
                {
                    maxfragmentationmemoryReserved = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxmemory-policy"u8))
                {
                    maxmemoryPolicy = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxmemory-reserved"u8))
                {
                    maxmemoryReserved = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxmemory-delta"u8))
                {
                    maxmemoryDelta = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxclients"u8))
                {
                    maxclients = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("preferred-data-archive-auth-method"u8))
                {
                    preferredDataArchiveAuthMethod = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("preferred-data-persistence-auth-method"u8))
                {
                    preferredDataPersistenceAuthMethod = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("zonal-configuration"u8))
                {
                    zonalConfiguration = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("authnotrequired"u8))
                {
                    authnotrequired = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("storage-subscription-id"u8))
                {
                    storageSubscriptionId = property.Value.GetString();
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
            additionalProperties = additionalPropertiesDictionary;
            return new RedisCommonConfiguration(Optional.ToNullable(rdbBackupEnabled), rdbBackupFrequency.Value, Optional.ToNullable(rdbBackupMaxSnapshotCount), rdbStorageConnectionString.Value, Optional.ToNullable(aofBackupEnabled), aofStorageConnectionString0.Value, aofStorageConnectionString1.Value, maxfragmentationmemoryReserved.Value, maxmemoryPolicy.Value, maxmemoryReserved.Value, maxmemoryDelta.Value, maxclients.Value, preferredDataArchiveAuthMethod.Value, preferredDataPersistenceAuthMethod.Value, zonalConfiguration.Value, authnotrequired.Value, storageSubscriptionId.Value, additionalProperties);
        }
    }
}
