// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Compute
{
    [CodeGenSuppress("global::Azure.Core.IUtf8JsonSerializable.Write", typeof(Utf8JsonWriter))]
    public partial class VirtualMachineScaleSetExtensionData : IUtf8JsonSerializable, IJsonModel<VirtualMachineScaleSetExtensionData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            // this part is added in this customization
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            // end of the customization
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(ForceUpdateTag))
            {
                writer.WritePropertyName("forceUpdateTag"u8);
                writer.WriteStringValue(ForceUpdateTag);
            }
            if (Optional.IsDefined(Publisher))
            {
                writer.WritePropertyName("publisher"u8);
                writer.WriteStringValue(Publisher);
            }
            if (Optional.IsDefined(ExtensionType))
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(ExtensionType);
            }
            if (Optional.IsDefined(TypeHandlerVersion))
            {
                writer.WritePropertyName("typeHandlerVersion"u8);
                writer.WriteStringValue(TypeHandlerVersion);
            }
            if (Optional.IsDefined(AutoUpgradeMinorVersion))
            {
                writer.WritePropertyName("autoUpgradeMinorVersion"u8);
                writer.WriteBooleanValue(AutoUpgradeMinorVersion.Value);
            }
            if (Optional.IsDefined(EnableAutomaticUpgrade))
            {
                writer.WritePropertyName("enableAutomaticUpgrade"u8);
                writer.WriteBooleanValue(EnableAutomaticUpgrade.Value);
            }
            if (Optional.IsDefined(Settings))
            {
                writer.WritePropertyName("settings"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Settings);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(Settings.ToString()).RootElement);
#endif
            }
            if (Optional.IsDefined(ProtectedSettings))
            {
                writer.WritePropertyName("protectedSettings");
#if NET6_0_OR_GREATER
				writer.WriteRawValue(ProtectedSettings);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(ProtectedSettings.ToString()).RootElement);
#endif
            }
            if (Optional.IsCollectionDefined(ProvisionAfterExtensions))
            {
                writer.WritePropertyName("provisionAfterExtensions"u8);
                writer.WriteStartArray();
                foreach (var item in ProvisionAfterExtensions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(SuppressFailures))
            {
                writer.WritePropertyName("suppressFailures"u8);
                writer.WriteBooleanValue(SuppressFailures.Value);
            }
            if (Optional.IsDefined(KeyVaultProtectedSettings))
            {
                writer.WritePropertyName("protectedSettingsFromKeyVault"u8);
                writer.WriteObjectValue(KeyVaultProtectedSettings);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
}
