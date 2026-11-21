// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSerialization(nameof(TargetVersion), SerializationValueHook = nameof(SerializeTargetVersion), DeserializationValueHook = nameof(DeserializeTargetVersion))]
    public partial class MajorVersionUpgradePrecheckProperties
    {
        // Keep the published extensible enum even though the service schema now uses a string.
        /// <summary> The target PostgreSQL major version for the upgrade. </summary>
        [CodeGenMember("TargetVersion")]
        [WirePath("targetVersion")]
        public PostgreSqlFlexibleServerVersion? TargetVersion { get; }

        private void SerializeTargetVersion(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(TargetVersion.Value.ToString());

        private static void DeserializeTargetVersion(JsonProperty property, ref PostgreSqlFlexibleServerVersion? targetVersion)
            => targetVersion = property.Value.GetString();
    }
}
