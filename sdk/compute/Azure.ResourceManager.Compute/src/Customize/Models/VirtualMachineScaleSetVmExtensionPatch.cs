// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: restore KeyVaultProtectedSettings property alias.
    // The old SDK exposed ProtectedSettingsFromKeyVault as "KeyVaultProtectedSettings" (typed).
    public partial class VirtualMachineScaleSetVmExtensionPatch
    {
        /// <summary> The extensions protected settings that are passed by reference, and consumed from key vault. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyVaultSecretReference KeyVaultProtectedSettings
        {
            get => ProtectedSettingsFromKeyVault;
            set => ProtectedSettingsFromKeyVault = value;
        }
    }
}
