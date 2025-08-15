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
    /// A class representing the NetworkCloudVirtualMachine data model.
    /// VirtualMachine represents the on-premises Network Cloud virtual machine.
    /// </summary>
    public partial class NetworkCloudVirtualMachineData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVirtualMachineData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="adminUsername"> The name of the administrator to which the ssh public keys will be added into the authorized keys. </param>
        /// <param name="cloudServicesNetworkAttachment"> The cloud service network that provides platform-level services for the virtual machine. </param>
        /// <param name="cpuCores"> The number of CPU cores in the virtual machine. </param>
        /// <param name="memorySizeInGB"> The memory size of the virtual machine. Allocations are measured in gibibytes. </param>
        /// <param name="storageProfile"> The storage profile that specifies size and other parameters about the disks related to the virtual machine. </param>
        /// <param name="vmImage"> The virtual machine image that is currently provisioned to the OS disk, using the full url and tag notation used to pull the image. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="adminUsername"/>, <paramref name="cloudServicesNetworkAttachment"/>, <paramref name="storageProfile"/> or <paramref name="vmImage"/> is null. </exception>
        public NetworkCloudVirtualMachineData(AzureLocation location, ExtendedLocation extendedLocation, string adminUsername, NetworkAttachment cloudServicesNetworkAttachment, long cpuCores, long memorySizeInGB, NetworkCloudStorageProfile storageProfile, string vmImage)
            : this(location, adminUsername, cloudServicesNetworkAttachment, cpuCores, memorySizeInGB, storageProfile, vmImage, extendedLocation)
        {
        }
    }
}
