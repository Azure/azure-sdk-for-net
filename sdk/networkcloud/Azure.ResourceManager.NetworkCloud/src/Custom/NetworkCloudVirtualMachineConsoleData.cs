// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    [CodeGenSuppress("NetworkCloudVirtualMachineConsoleData", typeof(AzureLocation), typeof(ConsoleEnabled), typeof(string), typeof(ExtendedLocation))]
    public partial class NetworkCloudVirtualMachineConsoleData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVirtualMachineConsoleData"/>. </summary>
        public NetworkCloudVirtualMachineConsoleData(AzureLocation location, ExtendedLocation extendedLocation, ConsoleEnabled enabled, NetworkCloudSshPublicKey sshPublicKey)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Properties = new ConsoleProperties(enabled, sshPublicKey?.KeyData);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
