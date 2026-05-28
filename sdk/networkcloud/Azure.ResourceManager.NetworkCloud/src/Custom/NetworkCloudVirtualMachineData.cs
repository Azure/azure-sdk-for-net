// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudVirtualMachineData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkCloudVirtualMachineData"/>. </summary>
        public NetworkCloudVirtualMachineData(AzureLocation location, ExtendedLocation extendedLocation, string adminUsername, NetworkAttachment cloudServicesNetworkAttachment, long cpuCores, long memorySizeInGB, NetworkCloudStorageProfile storageProfile, string vmImage)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(adminUsername, nameof(adminUsername));
            Argument.AssertNotNull(cloudServicesNetworkAttachment, nameof(cloudServicesNetworkAttachment));
            Argument.AssertNotNull(storageProfile, nameof(storageProfile));
            Argument.AssertNotNull(vmImage, nameof(vmImage));
            Properties = new VirtualMachineProperties(adminUsername, cloudServicesNetworkAttachment, cpuCores, memorySizeInGB, storageProfile, vmImage);
            ExtendedLocation = extendedLocation;
        }

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
                return new Models.ExtendedLocation(baseLoc.Name, baseLoc.ExtendedLocationType?.ToString());
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualMachineProperties();
                }
                if (value == null)
                {
                    Properties.ConsoleExtendedLocation = null;
                }
                else
                {
                    Properties.ConsoleExtendedLocation = new Azure.ResourceManager.Resources.Models.ExtendedLocation
                    {
                        Name = value.Name,
                        ExtendedLocationType = value.ExtendedLocationType != null
                            ? new Azure.ResourceManager.Resources.Models.ExtendedLocationType(value.ExtendedLocationType)
                            : (Azure.ResourceManager.Resources.Models.ExtendedLocationType?)null
                    };
                }
            }
        }
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
