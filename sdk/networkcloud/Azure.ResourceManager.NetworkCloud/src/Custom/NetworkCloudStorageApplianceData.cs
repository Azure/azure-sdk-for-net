// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudStorageApplianceData
    {
        // Backward compat: CACertificate was flattened in old autorest code but not in new generator.

        /// <summary> The information of the certificate authority for the storage appliance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudCertificateInfo CACertificate => Properties?.CACertificate;

        /// <summary> The IPv4 address assigned to the storage appliance management network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress ManagementIPv4Address => Properties?.ManagementIPv4Address;

        // Backward compat: old API had ExtendedLocation as 2nd parameter; new API has it last.
        /// <summary> Initializes a new instance of <see cref="NetworkCloudStorageApplianceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudStorageApplianceData(AzureLocation location, ExtendedLocation extendedLocation, AdministrativeCredentials administratorCredentials, ResourceIdentifier rackId, long rackSlot, string serialNumber, string storageApplianceSkuId)
            : this(location, rackId, storageApplianceSkuId, rackSlot, serialNumber, administratorCredentials, extendedLocation) { }
        /// <summary> The extended location of the cluster associated with the resource. </summary>
        public Azure.ResourceManager.NetworkCloud.Models.ExtendedLocation ExtendedLocation { get; set; }
    }
}
