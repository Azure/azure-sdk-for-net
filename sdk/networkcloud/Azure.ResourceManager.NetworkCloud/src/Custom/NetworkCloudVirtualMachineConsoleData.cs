// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudVirtualMachineConsoleData
    {
        // Backward compat: old API had ExtendedLocation as 2nd parameter and NetworkCloudSshPublicKey;
        // new API has string keyData and ExtendedLocation last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVirtualMachineConsoleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudVirtualMachineConsoleData(AzureLocation location, ExtendedLocation extendedLocation, ConsoleEnabled enabled, NetworkCloudSshPublicKey sshPublicKey)
            : this(location, enabled, sshPublicKey?.KeyData, extendedLocation) { }
    }
}
