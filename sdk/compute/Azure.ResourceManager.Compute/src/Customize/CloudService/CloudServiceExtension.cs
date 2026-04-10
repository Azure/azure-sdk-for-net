// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class CloudServiceExtension
    {
        /// <summary> Initializes a new instance of CloudServiceExtension. </summary>
        public CloudServiceExtension()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; set; }

        /// <summary> The publisher. </summary>
        public string Publisher { get; set; }

        /// <summary> The extension type. </summary>
        public string CloudServiceExtensionPropertiesType { get; set; }

        /// <summary> The type handler version. </summary>
        public string TypeHandlerVersion { get; set; }

        /// <summary> Whether to auto-upgrade minor version. </summary>
        public bool? AutoUpgradeMinorVersion { get; set; }

        /// <summary> The settings. </summary>
        public string Settings { get; set; }

        /// <summary> The protected settings. </summary>
        public string ProtectedSettings { get; set; }

        /// <summary> The protected settings from key vault. </summary>
        public CloudServiceVaultAndSecretReference ProtectedSettingsFromKeyVault { get; set; }

        /// <summary> The force update tag. </summary>
        public string ForceUpdateTag { get; set; }

        /// <summary> The provisioning state. </summary>
        public string ProvisioningState { get; }

        /// <summary> The roles applied to. </summary>
        public IList<string> RolesAppliedTo { get; set; }
    }
}
