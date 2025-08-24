// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudVirtualMachineConsole data model.
    /// Console represents the console of an on-premises Network Cloud virtual machine.
    /// </summary>
    public partial class NetworkCloudVirtualMachineConsoleData{
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVirtualMachineConsoleData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster manager associated with the cluster this virtual machine is created on. </param>
        /// <param name="enabled"> The indicator of whether the console access is enabled. </param>
        /// <param name="sshPublicKey"> The SSH public key that will be provisioned for user access. The user is expected to have the corresponding SSH private key for logging in. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/> or <paramref name="sshPublicKey"/> is null. </exception>
        public NetworkCloudVirtualMachineConsoleData(AzureLocation location, ExtendedLocation extendedLocation, ConsoleEnabled enabled, NetworkCloudSshPublicKey sshPublicKey)
        : this(location, enabled, sshPublicKey, extendedLocation)
        {
        }
    }
}
