// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: the previously shipped SDK exposed this type as a direct ResourceData-derived model.
    // Without restoring the direct base type, VMSS extension inline request bodies no longer serialize the extension name.
    // Suppress the generated resource-key helper because the Swagger payload has only the normal ARM name field and
    // the old SDK did not expose a separate VmssExtensionName property.
    [CodeGenSuppress("VmssExtensionName")]
    public partial class VirtualMachineScaleSetExtensionData : ResourceData
    {
        /// <summary> Writes the JSON representation of the model to the provided writer. </summary>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<VirtualMachineScaleSetExtensionData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(VirtualMachineScaleSetExtensionData)} does not support writing '{format}' format.");
            }
            if (options.Format == "W" && Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Properties))
            {
                writer.WritePropertyName("properties"u8);
                writer.WriteObjectValue(Properties, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        /// <summary> Initializes a new instance of VmssExtensionData. </summary>
        /// <param name="name"> The name. </param>
        // Backward compatibility: the previously shipped SDK exposed this name-only constructor.
        // Without chaining to the ResourceData base constructor, the constructor cannot set the now read-only ResourceData.Name property.
        public VirtualMachineScaleSetExtensionData(string name) : base(default, name, default, default)
        {
        }

        // Backward compatibility: the previously-shipped SDK exposed `ProtectedSettingsFromKeyVault` as a loosely-typed
        // BinaryData property. The TypeSpec spec types it as `KeyVaultSecretReference`, which is now surfaced as the
        // strongly-typed `KeyVaultProtectedSettings` (see G5 client.tsp clientName rename). This shim re-adds the
        // BinaryData accessor by serializing/deserializing through the typed property to preserve binary compatibility.
        /// <summary>
        /// The extensions protected settings that are passed by reference, and consumed from key vault.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData ProtectedSettingsFromKeyVault
        {
            get => KeyVaultProtectedSettings is null ? null : ((IJsonModel<KeyVaultSecretReference>)KeyVaultProtectedSettings).Write(ModelSerializationExtensions.WireOptions);
            set => KeyVaultProtectedSettings = value is null ? null : ModelReaderWriter.Read<KeyVaultSecretReference>(value, ModelSerializationExtensions.WireOptions, AzureResourceManagerComputeContext.Default);
        }
    }
}
