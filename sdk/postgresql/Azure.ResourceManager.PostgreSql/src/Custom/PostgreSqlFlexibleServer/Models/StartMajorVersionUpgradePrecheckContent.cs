// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSerialization(nameof(TargetVersion), SerializationValueHook = nameof(SerializeTargetVersion), DeserializationValueHook = nameof(DeserializeTargetVersion))]
    public partial class StartMajorVersionUpgradePrecheckContent
    {
        // Preserve the published constructor and property types after the service changed to a string.
        /// <summary> The target major version to upgrade to. </summary>
        [CodeGenMember("TargetVersion")]
        [WirePath("targetVersion")]
        public PostgreSqlFlexibleServerVersion TargetVersion { get; }

        private void SerializeTargetVersion(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(TargetVersion.ToString());

        private static void DeserializeTargetVersion(JsonProperty property, ref PostgreSqlFlexibleServerVersion targetVersion)
            => targetVersion = new PostgreSqlFlexibleServerVersion(property.Value.GetString());
    }
}
