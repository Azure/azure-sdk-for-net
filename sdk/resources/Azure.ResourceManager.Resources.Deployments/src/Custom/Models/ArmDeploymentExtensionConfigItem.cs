// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Resources.Deployments.Models
{
    [CodeGenSerialization(nameof(ExtensionConfigPropertyType), "type", SerializationValueHook = nameof(SerializeExtensionConfigPropertyType), DeserializationValueHook = nameof(DeserializeExtensionConfigPropertyType))]
    public partial class ArmDeploymentExtensionConfigItem
    {
        // API version 2026-06-01 removed "type" from the service model. Keep the SDK 1.0.0
        // property and its JSON mapping for GA compatibility and older API-version payloads.
        /// <summary> The value type of the extension config property. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public ExtensionConfigPropertyType? ExtensionConfigPropertyType { get; }

        private void SerializeExtensionConfigPropertyType(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStringValue(ExtensionConfigPropertyType?.ToString());
        }

        private static void DeserializeExtensionConfigPropertyType(JsonProperty property, ref ExtensionConfigPropertyType? extensionConfigPropertyType, ModelReaderWriterOptions options)
        {
            extensionConfigPropertyType = property.Value.ValueKind == JsonValueKind.Null ? null : new ExtensionConfigPropertyType(property.Value.GetString());
        }
    }
}
