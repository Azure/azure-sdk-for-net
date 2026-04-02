// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shims: IPAddressType/OSType renamed to IpAddressType/OsType in TypeSpec migration.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerCapabilities
    {
        /// <summary> The ip address type of the capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IPAddressType => IpAddressType;

        /// <summary> The OS type of the capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSType => OsType;
    }
}
