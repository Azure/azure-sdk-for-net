// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: restore name constructor and KeyVaultProtectedSettings property alias.
    // The old SDK exposed ProtectedSettingsFromKeyVault as "KeyVaultProtectedSettings" (typed).
    // The generator now generates ProtectedSettingsFromKeyVault directly as KeyVaultSecretReference.
    public partial class VirtualMachineScaleSetExtensionData
    {
        /// <summary> Initializes a new instance of VmssExtensionData. </summary>
        /// <param name="name"> The name. </param>
        public VirtualMachineScaleSetExtensionData(string name) : this()
        {
            Name = name;
        }

        /// <summary> The extensions protected settings that are passed by reference, and consumed from key vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultSecretReference KeyVaultProtectedSettings
        {
            get => ProtectedSettingsFromKeyVault;
            set => ProtectedSettingsFromKeyVault = value;
        }
    }
}
