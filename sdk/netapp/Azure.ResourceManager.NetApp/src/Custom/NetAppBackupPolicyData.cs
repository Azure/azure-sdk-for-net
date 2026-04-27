// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary> A class representing the NetAppBackupPolicy data model. </summary>
    public partial class NetAppBackupPolicyData : TrackedResourceData
    {
        // Backward-compat shim: prior SDK exposed this property as `Enabled`.
        /// <summary> The property to decide policy is enabled or not. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }
    }
}
