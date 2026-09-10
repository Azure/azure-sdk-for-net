// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis.Models
{
    // Legacy wire quirks preserved for back-compat:
    // - rdb-backup-enabled / aof-backup-enabled may arrive as either bool or string.
    // - rdb-backup-max-snapshot-count: int written/read as a JSON string.
    [CodeGenSerialization(nameof(IsRdbBackupEnabled), DeserializationValueHook = nameof(ReadIsRdbBackupEnabled))]
    [CodeGenSerialization(nameof(IsAofBackupEnabled), DeserializationValueHook = nameof(ReadIsAofBackupEnabled))]
    [CodeGenSerialization(nameof(RdbBackupMaxSnapshotCount), SerializationValueHook = nameof(WriteRdbBackupMaxSnapshotCount), DeserializationValueHook = nameof(ReadRdbBackupMaxSnapshotCount))]
    public partial class RedisCommonConfiguration
    {
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
