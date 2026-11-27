// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSerialization(nameof(SourceVersion), SerializationValueHook = nameof(SerializeSourceVersion), DeserializationValueHook = nameof(DeserializeSourceVersion))]
    [CodeGenSerialization(nameof(TargetVersion), SerializationValueHook = nameof(SerializeTargetVersion), DeserializationValueHook = nameof(DeserializeTargetVersion))]
    public partial class PostgreSqlMajorVersionUpgradeSequence
    {
        // Keep the published extensible enum even though the service schema now uses a string.
        /// <summary> The source PostgreSQL version. </summary>
        [CodeGenMember("SourceVersion")]
        [WirePath("sourceVersion")]
        public PostgreSqlFlexibleServerVersion? SourceVersion { get; }

        // Keep the published extensible enum even though the service schema now uses a string.
        /// <summary> The target PostgreSQL version. </summary>
        [CodeGenMember("TargetVersion")]
        [WirePath("targetVersion")]
        public PostgreSqlFlexibleServerVersion? TargetVersion { get; }

        private void SerializeSourceVersion(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(SourceVersion.Value.ToString());

        private static void DeserializeSourceVersion(JsonProperty property, ref PostgreSqlFlexibleServerVersion? sourceVersion)
            => sourceVersion = property.Value.GetString();

        private void SerializeTargetVersion(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(TargetVersion.Value.ToString());

        private static void DeserializeTargetVersion(JsonProperty property, ref PostgreSqlFlexibleServerVersion? targetVersion)
            => targetVersion = property.Value.GetString();
    }
}
