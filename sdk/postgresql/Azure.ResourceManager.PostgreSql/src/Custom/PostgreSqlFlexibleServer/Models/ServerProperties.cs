// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSerialization(nameof(Version), SerializationValueHook = nameof(SerializeVersion), DeserializationValueHook = nameof(DeserializeVersion))]
    internal partial class ServerProperties
    {
        // Preserve the published version type, including the flattened server data property.
        /// <summary> Major version of PostgreSQL database engine. </summary>
        [CodeGenMember("Version")]
        [WirePath("version")]
        public PostgreSqlFlexibleServerVersion? Version { get; set; }

        private void SerializeVersion(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => writer.WriteStringValue(Version.Value.ToString());

        private static void DeserializeVersion(JsonProperty property, ref PostgreSqlFlexibleServerVersion? version)
            => version = property.Value.GetString();
    }
}
