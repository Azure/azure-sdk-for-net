// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Qumulo.Models;

namespace Azure.ResourceManager.Qumulo
{
    [CodeGenSerialization(nameof(InitialCapacity), "initialCapacity")]
    public partial class QumuloFileSystemResourceData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="QumuloFileSystemResourceData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="marketplaceDetails"> Marketplace details. </param>
        /// <param name="storageSku"> Storage Sku. </param>
        /// <param name="userDetails"> User Details. </param>
        /// <param name="delegatedSubnetId"> Delegated subnet id for Vnet injection. </param>
        /// <param name="adminPassword"> Initial administrator password of the resource. </param>
        /// <param name="initialCapacity"> Storage capacity in TB. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="marketplaceDetails"/>, <paramref name="userDetails"/>, <paramref name="delegatedSubnetId"/> or <paramref name="adminPassword"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public QumuloFileSystemResourceData(AzureLocation location, MarketplaceDetails marketplaceDetails, StorageSku storageSku, QumuloUserDetails userDetails, string delegatedSubnetId, string adminPassword, int initialCapacity) : this(location)
        {
            MarketplaceDetails = marketplaceDetails;
            StorageSku = storageSku;
            UserDetails = userDetails;
            DelegatedSubnetId = delegatedSubnetId;
            AdminPassword = adminPassword;
            InitialCapacity = initialCapacity;
        }

        /// <summary>
        /// Storage Sku.
        /// This property has been deprecated, please use <see cref="StorageSkuName"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageSku StorageSku
        {
            get => StorageSkuName.ToStorageSku();
            set => StorageSkuName = value.ToSerialString();
        }

        /// <summary>
        /// Storage capacity in TB.
        /// This property has been removed since api-version 2024-06-19
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int InitialCapacity { get; set; }

        /// <summary>
        /// Provisioning State of the resource.
        /// Please use <see cref="ArmProvisioningState"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public QumuloProvisioningState? ProvisioningState => ArmProvisioningState?.ToString().ToQumuloProvisioningState();
    }
}
