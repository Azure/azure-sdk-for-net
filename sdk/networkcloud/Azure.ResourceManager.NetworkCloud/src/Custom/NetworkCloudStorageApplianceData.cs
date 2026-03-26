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
    [CodeGenSuppress("NetworkCloudStorageApplianceData", typeof(AzureLocation), typeof(ResourceIdentifier), typeof(string), typeof(long), typeof(string), typeof(AdministrativeCredentials), typeof(ExtendedLocation))]
    public partial class NetworkCloudStorageApplianceData
    {
        // Backward compat: CACertificate was flattened in old autorest code but not in new generator.

        /// <summary> The information of the certificate authority for the storage appliance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudCertificateInfo CACertificate => Properties?.CACertificate;

        /// <summary> The IPv4 address assigned to the storage appliance management network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress ManagementIPv4Address => Properties?.ManagementIPv4Address;

        /// <summary> Initializes a new instance of <see cref="NetworkCloudStorageApplianceData"/>. </summary>
        public NetworkCloudStorageApplianceData(AzureLocation location, ExtendedLocation extendedLocation, AdministrativeCredentials administratorCredentials, ResourceIdentifier rackId, long rackSlot, string serialNumber, string storageApplianceSkuId)
            : base(location)
        {
            Argument.AssertNotNull(extendedLocation, nameof(extendedLocation));
            Argument.AssertNotNull(administratorCredentials, nameof(administratorCredentials));
            Argument.AssertNotNull(rackId, nameof(rackId));
            Argument.AssertNotNull(serialNumber, nameof(serialNumber));
            Argument.AssertNotNull(storageApplianceSkuId, nameof(storageApplianceSkuId));
            Properties = new StorageApplianceProperties(rackId, storageApplianceSkuId, rackSlot, serialNumber, administratorCredentials);
            ExtendedLocation = extendedLocation;
        }

        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
