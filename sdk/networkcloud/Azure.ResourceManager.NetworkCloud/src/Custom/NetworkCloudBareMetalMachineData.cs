// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    /// <summary>
    /// A class representing the NetworkCloudBareMetalMachine data model.
    /// BareMetalMachine represents the physical machine in the rack.
    /// </summary>
    public partial class NetworkCloudBareMetalMachineData
    {
         /// <summary> Initializes a new instance of <see cref="NetworkCloudBareMetalMachineData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="extendedLocation"> The extended location of the cluster associated with the resource. </param>
        /// <param name="bmcConnectionString"> The connection string for the baseboard management controller including IP address and protocol. </param>
        /// <param name="bmcCredentials"> The credentials of the baseboard management controller on this bare metal machine. </param>
        /// <param name="bmcMacAddress"> The MAC address of the BMC device. </param>
        /// <param name="bootMacAddress"> The MAC address of a NIC connected to the PXE network. </param>
        /// <param name="machineDetails"> The custom details provided by the customer. </param>
        /// <param name="machineName"> The OS-level hostname assigned to this machine. </param>
        /// <param name="machineSkuId"> The unique internal identifier of the bare metal machine SKU. </param>
        /// <param name="rackId"> The resource ID of the rack where this bare metal machine resides. </param>
        /// <param name="rackSlot"> The rack slot in which this bare metal machine is located, ordered from the bottom up i.e. the lowest slot is 1. </param>
        /// <param name="serialNumber"> The serial number of the bare metal machine. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="extendedLocation"/>, <paramref name="bmcConnectionString"/>, <paramref name="bmcCredentials"/>, <paramref name="bmcMacAddress"/>, <paramref name="bootMacAddress"/>, <paramref name="machineDetails"/>, <paramref name="machineName"/>, <paramref name="machineSkuId"/>, <paramref name="rackId"/> or <paramref name="serialNumber"/> is null. </exception>
        public NetworkCloudBareMetalMachineData(AzureLocation location, ExtendedLocation extendedLocation, string bmcConnectionString, AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, string machineDetails, string machineName, string machineSkuId, ResourceIdentifier rackId, long rackSlot, string serialNumber)
            : this(location, bmcConnectionString, bmcCredentials, bmcMacAddress, bootMacAddress, machineDetails, machineName, machineSkuId, rackId, rackSlot, serialNumber, extendedLocation)
        {
        }
    }
}
