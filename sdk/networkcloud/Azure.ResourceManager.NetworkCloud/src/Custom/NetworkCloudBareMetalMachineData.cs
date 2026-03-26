// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    [CodeGenSuppress("NetworkCloudBareMetalMachineData", typeof(AzureLocation), typeof(string), typeof(AdministrativeCredentials), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(long), typeof(string), typeof(ExtendedLocation))]
    public partial class NetworkCloudBareMetalMachineData
    {
        // Backward compat: CACertificate was flattened in old autorest code but not in new generator.
        // Expose it through internal Properties to maintain API surface.

        /// <summary> The information of the certificate authority for the bare metal machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudCertificateInfo CACertificate => Properties?.CACertificate;

        /// <summary> The IPv4 address that is assigned to the bare metal machine during the cluster deployment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress OamIPv4Address => Properties?.OamIPv4Address;

        /// <summary> The IPv6 address that is assigned to the bare metal machine during the cluster deployment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OamIPv6Address => Properties?.OamIPv6Address;

        /// <summary> The OS image currently in the machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSImage => Properties?.OSImage;

        /// <summary> Initializes a new instance of <see cref="NetworkCloudBareMetalMachineData"/>. </summary>
        public NetworkCloudBareMetalMachineData(AzureLocation location, ExtendedLocation extendedLocation, string bmcConnectionString, AdministrativeCredentials bmcCredentials, string bmcMacAddress, string bootMacAddress, string machineDetails, string machineName, string machineSkuId, ResourceIdentifier rackId, long rackSlot, string serialNumber)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(bmcConnectionString, nameof(bmcConnectionString));
            Argument.AssertNotNull(bmcCredentials, nameof(bmcCredentials));
            Argument.AssertNotNull(bmcMacAddress, nameof(bmcMacAddress));
            Argument.AssertNotNull(bootMacAddress, nameof(bootMacAddress));
            Argument.AssertNotNull(machineDetails, nameof(machineDetails));
            Argument.AssertNotNull(machineName, nameof(machineName));
            Argument.AssertNotNull(machineSkuId, nameof(machineSkuId));
            Argument.AssertNotNull(rackId, nameof(rackId));
            Argument.AssertNotNull(serialNumber, nameof(serialNumber));
            Properties = new BareMetalMachineProperties(bmcConnectionString, bmcCredentials, bmcMacAddress, bootMacAddress, machineDetails, machineName, machineSkuId, rackId, rackSlot, serialNumber);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
