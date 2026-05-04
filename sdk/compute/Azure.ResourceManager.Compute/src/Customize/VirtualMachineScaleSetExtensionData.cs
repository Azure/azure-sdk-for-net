// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    public partial class VirtualMachineScaleSetExtensionData
    {
        /// <summary> Initializes a new instance of VmssExtensionData. </summary>
        /// <param name="name"> The name. </param>
        public VirtualMachineScaleSetExtensionData(string name) : this()
        {
            Name = name;
        }

        // Backward compatibility: the previously-shipped SDK exposed `ProtectedSettingsFromKeyVault` as a loosely-typed
        // BinaryData property. The TypeSpec spec types it as `KeyVaultSecretReference`, which is now surfaced as the
        // strongly-typed `KeyVaultProtectedSettings` (see G5 client.tsp clientName rename). This shim re-adds the
        // BinaryData accessor by serializing/deserializing through the typed property to preserve binary compatibility.
        /// <summary> The extensions protected settings that are passed by reference, and consumed from key vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData ProtectedSettingsFromKeyVault
        {
            get => KeyVaultProtectedSettings is null ? null : ((IJsonModel<KeyVaultSecretReference>)KeyVaultProtectedSettings).Write(ModelSerializationExtensions.WireOptions);
            set => KeyVaultProtectedSettings = value is null ? null : ModelReaderWriter.Read<KeyVaultSecretReference>(value, ModelSerializationExtensions.WireOptions, AzureResourceManagerComputeContext.Default);
        }
    }
}
