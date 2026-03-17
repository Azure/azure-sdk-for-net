// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NetworkCloud
{
    // CodeGenSuppress for ConsoleExtendedLocation: old API returned NetworkCloud.Models.ExtendedLocation;
    // regenerated code returns Resources.Models.ExtendedLocation. This preserves the old return type.
    [CodeGenSuppress("ConsoleExtendedLocation")]
    public partial class NetworkCloudVirtualMachineData
    {
        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVirtualMachineData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudVirtualMachineData(AzureLocation location, ExtendedLocation extendedLocation, string adminUsername, NetworkAttachment cloudServicesNetworkAttachment, long cpuCores, long memorySizeInGB, NetworkCloudStorageProfile storageProfile, string vmImage)
            : this(location, adminUsername, cloudServicesNetworkAttachment, cpuCores, memorySizeInGB, storageProfile, vmImage, extendedLocation) { }

        // Backward compat: old API returned NetworkCloud.Models.ExtendedLocation; regenerated code
        // returns Resources.Models.ExtendedLocation. This preserves the old return type.
        /// <summary> The resource ID of the extended location on which the console will be found. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Models.ExtendedLocation ConsoleExtendedLocation
        {
            get
            {
                var baseLoc = Properties?.ConsoleExtendedLocation;
                if (baseLoc == null) return null;
                if (baseLoc is Models.ExtendedLocation ncLoc) return ncLoc;
                return new Models.ExtendedLocation(baseLoc.Name, baseLoc.ExtendedLocationType?.ToString());
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineProperties();
                }
                Properties.ConsoleExtendedLocation = value;
            }
        }
    }
}
