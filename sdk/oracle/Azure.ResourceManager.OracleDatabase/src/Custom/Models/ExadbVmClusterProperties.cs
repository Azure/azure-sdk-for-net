// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class ExadbVmClusterProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExadbVmClusterProperties"/>. </summary>
        /// <param name="vnetId"> VNET for network connectivity. </param>
        /// <param name="subnetId"> Client subnet. </param>
        /// <param name="displayName"> Display Name. </param>
        /// <param name="enabledEcpuCount"> The number of ECPUs to enable for an Exadata VM cluster on Exascale Infrastructure. </param>
        /// <param name="exascaleDBStorageVaultId"> The Azure Resource ID of the Exadata Database Storage Vault. </param>
        /// <param name="hostname"> The hostname for the  Exadata VM cluster on Exascale Infrastructure. </param>
        /// <param name="nodeCount"> The number of nodes in the Exadata VM cluster on Exascale Infrastructure. </param>
        /// <param name="shape"> The shape of the Exadata VM cluster on Exascale Infrastructure resource. </param>
        /// <param name="sshPublicKeys"> The public key portion of one or more key pairs used for SSH access to the Exadata VM cluster on Exascale Infrastructure. </param>
        /// <param name="totalEcpuCount"> The number of Total ECPUs for an Exadata VM cluster on Exascale Infrastructure. </param>
        /// <param name="vmFileSystemStorage"> Filesystem storage details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vnetId"/>, <paramref name="subnetId"/>, <paramref name="displayName"/>, <paramref name="exascaleDBStorageVaultId"/>, <paramref name="hostname"/>, <paramref name="shape"/>, <paramref name="sshPublicKeys"/> or <paramref name="vmFileSystemStorage"/> is null. </exception>
        public ExadbVmClusterProperties(ResourceIdentifier vnetId, ResourceIdentifier subnetId, string displayName, int enabledEcpuCount, ResourceIdentifier exascaleDBStorageVaultId, string hostname, int nodeCount, string shape, IEnumerable<string> sshPublicKeys, int totalEcpuCount, ExadbVmClusterStorageDetails vmFileSystemStorage)
        {
            Argument.AssertNotNull(vnetId, nameof(vnetId));
            Argument.AssertNotNull(subnetId, nameof(subnetId));
            Argument.AssertNotNull(displayName, nameof(displayName));
            Argument.AssertNotNull(exascaleDBStorageVaultId, nameof(exascaleDBStorageVaultId));
            Argument.AssertNotNull(hostname, nameof(hostname));
            Argument.AssertNotNull(shape, nameof(shape));
            Argument.AssertNotNull(sshPublicKeys, nameof(sshPublicKeys));
            Argument.AssertNotNull(vmFileSystemStorage, nameof(vmFileSystemStorage));

            VnetId = vnetId;
            SubnetId = subnetId;
            DisplayName = displayName;
            EnabledEcpuCount = enabledEcpuCount;
            ExascaleDBStorageVaultId = exascaleDBStorageVaultId;
            Hostname = hostname;
            NodeCount = nodeCount;
            NsgCidrs = new ChangeTrackingList<CloudVmClusterNsgCidr>();
            Shape = shape;
            SshPublicKeys = sshPublicKeys.ToList();
            TotalEcpuCount = totalEcpuCount;
            VmFileSystemStorage = vmFileSystemStorage;
            ScanIPIds = new ChangeTrackingList<string>();
            VipIds = new ChangeTrackingList<string>();
        }
    }
}
