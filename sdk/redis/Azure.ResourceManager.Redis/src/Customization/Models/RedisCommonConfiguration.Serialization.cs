// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;
using  Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    [CodeGenSerialization(nameof(IsRdbBackupEnabled), DeserializationValueHook = nameof(ReadIsRdbBackupEnabled))]
    [CodeGenSerialization(nameof(IsAofBackupEnabled), DeserializationValueHook = nameof(ReadIsAofBackupEnabled))]
    [CodeGenSerialization(nameof(RdbBackupMaxSnapshotCount), SerializationValueHook = nameof(WriteRdbBackupMaxSnapshotCount), DeserializationValueHook = nameof(ReadRdbBackupMaxSnapshotCount))]
    // Generator-bug workaround (n1): when [CodeGenMember("AdditionalProperties")] is applied to
    // re-attach [WirePath] to the property bag, the emitter mis-emits the catch-all line in
    // DeserializeRedisCommonConfiguration as `additionalBinaryDataProperties.Add(...)` while the
    // local is declared `additionalProperties`. We suppress the generated method and re-implement
    // it below verbatim with the correct identifier.
    // Tracked: https://github.com/Azure/typespec-azure/issues/4331
    // TODO: remove once the generator fix lands.
    [CodeGenSuppress("DeserializeRedisCommonConfiguration", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class RedisCommonConfiguration : IJsonModel<RedisCommonConfiguration>
    {
        internal static RedisCommonConfiguration DeserializeRedisCommonConfiguration(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool? isRdbBackupEnabled = default;
            string rdbBackupFrequency = default;
            int? rdbBackupMaxSnapshotCount = default;
            string rdbStorageConnectionString = default;
            bool? isAofBackupEnabled = default;
            string aofStorageConnectionString0 = default;
            string aofStorageConnectionString1 = default;
            string maxFragmentationMemoryReserved = default;
            string maxMemoryPolicy = default;
            string maxMemoryReserved = default;
            string maxMemoryDelta = default;
            string maxClients = default;
            string notifyKeyspaceEvents = default;
            string preferredDataArchiveAuthMethod = default;
            string preferredDataPersistenceAuthMethod = default;
            string zonalConfiguration = default;
            string authNotRequired = default;
            string storageSubscriptionId = default;
            string isAadEnabled = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("rdb-backup-enabled"u8))
                {
                    ReadIsRdbBackupEnabled(prop, ref isRdbBackupEnabled);
                    continue;
                }
                if (prop.NameEquals("rdb-backup-frequency"u8))
                {
                    rdbBackupFrequency = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("rdb-backup-max-snapshot-count"u8))
                {
                    ReadRdbBackupMaxSnapshotCount(prop, ref rdbBackupMaxSnapshotCount);
                    continue;
                }
                if (prop.NameEquals("rdb-storage-connection-string"u8))
                {
                    rdbStorageConnectionString = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("aof-backup-enabled"u8))
                {
                    ReadIsAofBackupEnabled(prop, ref isAofBackupEnabled);
                    continue;
                }
                if (prop.NameEquals("aof-storage-connection-string-0"u8))
                {
                    aofStorageConnectionString0 = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("aof-storage-connection-string-1"u8))
                {
                    aofStorageConnectionString1 = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("maxfragmentationmemory-reserved"u8))
                {
                    maxFragmentationMemoryReserved = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("maxmemory-policy"u8))
                {
                    maxMemoryPolicy = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("maxmemory-reserved"u8))
                {
                    maxMemoryReserved = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("maxmemory-delta"u8))
                {
                    maxMemoryDelta = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("maxclients"u8))
                {
                    maxClients = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("notify-keyspace-events"u8))
                {
                    notifyKeyspaceEvents = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("preferred-data-archive-auth-method"u8))
                {
                    preferredDataArchiveAuthMethod = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("preferred-data-persistence-auth-method"u8))
                {
                    preferredDataPersistenceAuthMethod = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("zonal-configuration"u8))
                {
                    zonalConfiguration = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("authnotrequired"u8))
                {
                    authNotRequired = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("storage-subscription-id"u8))
                {
                    storageSubscriptionId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("aad-enabled"u8))
                {
                    isAadEnabled = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new RedisCommonConfiguration(
                isRdbBackupEnabled,
                rdbBackupFrequency,
                rdbBackupMaxSnapshotCount,
                rdbStorageConnectionString,
                isAofBackupEnabled,
                aofStorageConnectionString0,
                aofStorageConnectionString1,
                maxFragmentationMemoryReserved,
                maxMemoryPolicy,
                maxMemoryReserved,
                maxMemoryDelta,
                maxClients,
                notifyKeyspaceEvents,
                preferredDataArchiveAuthMethod,
                preferredDataPersistenceAuthMethod,
                zonalConfiguration,
                authNotRequired,
                storageSubscriptionId,
                isAadEnabled,
                additionalProperties);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void WriteRdbBackupMaxSnapshotCount(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (RdbBackupMaxSnapshotCount == null)
                return;
            writer.WriteStringValue(RdbBackupMaxSnapshotCount.Value.ToString(CultureInfo.InvariantCulture));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadIsRdbBackupEnabled(JsonProperty property, ref bool? IsRdbBackupEnabled)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            IsRdbBackupEnabled = property.Value.ValueKind == JsonValueKind.String ? string.Equals(property.Value.GetString(), "true", StringComparison.InvariantCultureIgnoreCase) : property.Value.GetBoolean();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadIsAofBackupEnabled(JsonProperty property, ref bool? IsAofBackupEnabled)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            IsAofBackupEnabled = property.Value.ValueKind == JsonValueKind.String ? string.Equals(property.Value.GetString(), "true", StringComparison.InvariantCultureIgnoreCase) : property.Value.GetBoolean();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadRdbBackupMaxSnapshotCount(JsonProperty property, ref int? RdbBackupMaxSnapshotCount)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
                return;

            if (!int.TryParse(property.Value.GetString(), out int rdbBackupMaxSnapshotCountValue))
            {
                throw new FormatException($"cannot parse {property.Value.GetString()} into an int for property {property.Name}");
            }
            RdbBackupMaxSnapshotCount = rdbBackupMaxSnapshotCountValue;
        }
    }
}
