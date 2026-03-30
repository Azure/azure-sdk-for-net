// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // Backward compat: The old Swagger/AutoRest code defined a local ExtendedLocation model
    // (Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation) with string properties.
    // The new TypeSpec spec uses the ARM common type (Azure.ResourceManager.Resources.Models.ExtendedLocation).
    // This customization preserves the old public API surface:
    //   - Constructor accepting the local ExtendedLocation type
    //   - ExtendedLocation property returning the local type
    // The implicit conversion operator on the local ExtendedLocation type allows the generated
    // backward-compat ModelFactory methods to work correctly.
    [CodeGenSuppress("NetworkCloudBareMetalMachineData", typeof(AzureLocation), typeof(string), typeof(AdministrativeCredentials), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(long), typeof(string), typeof(ExtendedLocation))]
    [CodeGenSuppress("ExtendedLocation")]
    public partial class NetworkCloudBareMetalMachineData
    {
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
