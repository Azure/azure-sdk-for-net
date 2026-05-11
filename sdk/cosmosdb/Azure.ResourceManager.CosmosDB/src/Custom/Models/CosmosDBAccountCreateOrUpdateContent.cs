// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

// The MPG generator emits all flattened properties on the wrapper as get-only
// proxies onto the inner `DatabaseAccountCreateUpdateProperties` holder because
// the holder has required ctor parameters (locations, databaseAccountOfferType)
// and the generator cannot synthesize a lazy-create setter. The previously shipped
// AutoRest contract exposed these properties as { get; set; }. Suppress each
// get-only property and re-emit it with both accessors so the historical surface
// is preserved without touching wire-serialization.
//
// Notes:
//   * Identity, IPRules, KeyVaultKeyUri (Uri), NetworkAclBypassResourceIds
//     (IList<ResourceIdentifier>) and the flattened spread of properties are now
//     all driven by client.tsp customizations — no manual aliasing needed here.
//   * A back-compat 2-arg public ctor is restored to match the previously shipped
//     `(AzureLocation location, IEnumerable<CosmosDBAccountLocation> locations)`
//     signature; the generator only emits the 3-arg required-form ctor.

namespace Azure.ResourceManager.CosmosDB.Models
{
    [CodeGenSuppress("AnalyticalStorageSchemaType")]
    [CodeGenSuppress("ApiServerVersion")]
    [CodeGenSuppress("BackupPolicy")]
    [CodeGenSuppress("CapacityTotalThroughputLimit")]
    [CodeGenSuppress("ConnectorOffer")]
    [CodeGenSuppress("ConsistencyPolicy")]
    [CodeGenSuppress("CreateMode")]
    [CodeGenSuppress("CustomerManagedKeyStatus")]
    [CodeGenSuppress("DatabaseAccountOfferType")]
    [CodeGenSuppress("DefaultIdentity")]
    [CodeGenSuppress("DefaultPriorityLevel")]
    [CodeGenSuppress("DisableKeyBasedMetadataWriteAccess")]
    [CodeGenSuppress("DisableLocalAuth")]
    [CodeGenSuppress("EnableAutomaticFailover")]
    [CodeGenSuppress("EnableBurstCapacity")]
    [CodeGenSuppress("EnableCassandraConnector")]
    [CodeGenSuppress("EnableMultipleWriteLocations")]
    [CodeGenSuppress("EnablePartitionMerge")]
    [CodeGenSuppress("EnablePerRegionPerPartitionAutoscale")]
    [CodeGenSuppress("EnablePriorityBasedExecution")]
    [CodeGenSuppress("IsAnalyticalStorageEnabled")]
    [CodeGenSuppress("IsFreeTierEnabled")]
    [CodeGenSuppress("IsVirtualNetworkFilterEnabled")]
    [CodeGenSuppress("KeyVaultKeyUri")]
    [CodeGenSuppress("MinimalTlsVersion")]
    [CodeGenSuppress("NetworkAclBypass")]
    [CodeGenSuppress("PublicNetworkAccess")]
    [CodeGenSuppress("RestoreParameters")]
    public partial class CosmosDBAccountCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBAccountCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="locations"> An array that contains the georeplication locations enabled for the Cosmos DB account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locations"/> is null. </exception>
        public CosmosDBAccountCreateOrUpdateContent(AzureLocation location, IEnumerable<CosmosDBAccountLocation> locations)
            : this(location, locations, default)
        {
        }

        /// <summary> The consistency policy for the Cosmos DB account. </summary>
        [WirePath("properties.consistencyPolicy")]
        public ConsistencyPolicy ConsistencyPolicy
        {
            get => Properties.ConsistencyPolicy;
            set => Properties.ConsistencyPolicy = value;
        }

        /// <summary> Flag to indicate whether to enable/disable Virtual Network ACL rules. </summary>
        [WirePath("properties.isVirtualNetworkFilterEnabled")]
        public bool? IsVirtualNetworkFilterEnabled
        {
            get => Properties.IsVirtualNetworkFilterEnabled;
            set => Properties.IsVirtualNetworkFilterEnabled = value;
        }

        /// <summary> Enables automatic failover of the write region in the rare event that the region is unavailable due to an outage. </summary>
        [WirePath("properties.enableAutomaticFailover")]
        public bool? EnableAutomaticFailover
        {
            get => Properties.EnableAutomaticFailover;
            set => Properties.EnableAutomaticFailover = value;
        }

        /// <summary> Enables the account to write in multiple locations. </summary>
        [WirePath("properties.enableMultipleWriteLocations")]
        public bool? EnableMultipleWriteLocations
        {
            get => Properties.EnableMultipleWriteLocations;
            set => Properties.EnableMultipleWriteLocations = value;
        }

        /// <summary> Enables the cassandra connector on the Cosmos DB C* account. </summary>
        [WirePath("properties.enableCassandraConnector")]
        public bool? EnableCassandraConnector
        {
            get => Properties.EnableCassandraConnector;
            set => Properties.EnableCassandraConnector = value;
        }

        /// <summary> The cassandra connector offer type for the Cosmos DB database C* account. </summary>
        [WirePath("properties.connectorOffer")]
        public ConnectorOffer? ConnectorOffer
        {
            get => Properties.ConnectorOffer;
            set => Properties.ConnectorOffer = value;
        }

        /// <summary> Disable write operations on metadata resources via account keys. </summary>
        [WirePath("properties.disableKeyBasedMetadataWriteAccess")]
        public bool? DisableKeyBasedMetadataWriteAccess
        {
            get => Properties.DisableKeyBasedMetadataWriteAccess;
            set => Properties.DisableKeyBasedMetadataWriteAccess = value;
        }

        /// <summary> The URI of the key vault. </summary>
        [WirePath("properties.keyVaultKeyUri")]
        public Uri KeyVaultKeyUri
        {
            get => Properties.KeyVaultKeyUri;
            set => Properties.KeyVaultKeyUri = value;
        }

        /// <summary> The default identity for accessing key vault used in features like customer managed keys. </summary>
        [WirePath("properties.defaultIdentity")]
        public string DefaultIdentity
        {
            get => Properties.DefaultIdentity;
            set => Properties.DefaultIdentity = value;
        }

        /// <summary> Whether requests from Public Network are allowed. </summary>
        [WirePath("properties.publicNetworkAccess")]
        public CosmosDBPublicNetworkAccess? PublicNetworkAccess
        {
            get => Properties.PublicNetworkAccess;
            set => Properties.PublicNetworkAccess = value;
        }

        /// <summary> Flag to indicate whether Free Tier is enabled. </summary>
        [WirePath("properties.enableFreeTier")]
        public bool? IsFreeTierEnabled
        {
            get => Properties.IsFreeTierEnabled;
            set => Properties.IsFreeTierEnabled = value;
        }

        /// <summary> Flag to indicate whether to enable storage analytics. </summary>
        [WirePath("properties.enableAnalyticalStorage")]
        public bool? IsAnalyticalStorageEnabled
        {
            get => Properties.IsAnalyticalStorageEnabled;
            set => Properties.IsAnalyticalStorageEnabled = value;
        }

        /// <summary> Describes the type of schema for analytical storage. </summary>
        [WirePath("properties.analyticalStorageConfiguration.schemaType")]
        public AnalyticalStorageSchemaType? AnalyticalStorageSchemaType
        {
            get => Properties.AnalyticalStorageSchemaType;
            set => Properties.AnalyticalStorageSchemaType = value;
        }

        /// <summary> Describes the mode of account creation. </summary>
        [WirePath("properties.createMode")]
        public CosmosDBAccountCreateMode? CreateMode
        {
            get => Properties.CreateMode;
            set => Properties.CreateMode = value;
        }

        /// <summary> The object representing the policy for taking backups on an account. </summary>
        [WirePath("properties.backupPolicy")]
        public CosmosDBAccountBackupPolicy BackupPolicy
        {
            get => Properties.BackupPolicy;
            set => Properties.BackupPolicy = value;
        }

        /// <summary> Indicates what services are allowed to bypass firewall checks. </summary>
        [WirePath("properties.networkAclBypass")]
        public NetworkAclBypass? NetworkAclBypass
        {
            get => Properties.NetworkAclBypass;
            set => Properties.NetworkAclBypass = value;
        }

        /// <summary> Opt-out of local authentication and ensure only MSI and AAD can be used exclusively for authentication. </summary>
        [WirePath("properties.disableLocalAuth")]
        public bool? DisableLocalAuth
        {
            get => Properties.DisableLocalAuth;
            set => Properties.DisableLocalAuth = value;
        }

        /// <summary> Parameters to indicate the information about the restore. </summary>
        [WirePath("properties.restoreParameters")]
        public CosmosDBAccountRestoreParameters RestoreParameters
        {
            get => Properties.RestoreParameters;
            set => Properties.RestoreParameters = value;
        }

        /// <summary> The total throughput limit imposed on the account. </summary>
        [WirePath("properties.capacity.totalThroughputLimit")]
        public int? CapacityTotalThroughputLimit
        {
            get => Properties.CapacityTotalThroughputLimit;
            set => Properties.CapacityTotalThroughputLimit = value;
        }

        /// <summary> Flag to indicate enabling/disabling of Partition Merge feature on the account. </summary>
        [WirePath("properties.enablePartitionMerge")]
        public bool? EnablePartitionMerge
        {
            get => Properties.EnablePartitionMerge;
            set => Properties.EnablePartitionMerge = value;
        }

        /// <summary> Flag to indicate enabling/disabling of Burst Capacity Preview feature on the account. </summary>
        [WirePath("properties.enableBurstCapacity")]
        public bool? EnableBurstCapacity
        {
            get => Properties.EnableBurstCapacity;
            set => Properties.EnableBurstCapacity = value;
        }

        /// <summary> Indicates the minimum allowed Tls version. </summary>
        [WirePath("properties.minimalTlsVersion")]
        public CosmosDBMinimalTlsVersion? MinimalTlsVersion
        {
            get => Properties.MinimalTlsVersion;
            set => Properties.MinimalTlsVersion = value;
        }

        /// <summary> Indicates the status of the Customer Managed Key feature on the account. </summary>
        [WirePath("properties.customerManagedKeyStatus")]
        public string CustomerManagedKeyStatus
        {
            get => Properties.CustomerManagedKeyStatus;
            set => Properties.CustomerManagedKeyStatus = value;
        }

        /// <summary> Flag to indicate enabling/disabling of Priority Based Execution Preview feature on the account. </summary>
        [WirePath("properties.enablePriorityBasedExecution")]
        public bool? EnablePriorityBasedExecution
        {
            get => Properties.EnablePriorityBasedExecution;
            set => Properties.EnablePriorityBasedExecution = value;
        }

        /// <summary> Enum to indicate default Priority Level of request for Priority Based Execution. </summary>
        [WirePath("properties.defaultPriorityLevel")]
        public DefaultPriorityLevel? DefaultPriorityLevel
        {
            get => Properties.DefaultPriorityLevel;
            set => Properties.DefaultPriorityLevel = value;
        }

        /// <summary> Flag to indicate enabling/disabling of Per-Region Per-partition autoscale Preview feature on the account. </summary>
        [WirePath("properties.enablePerRegionPerPartitionAutoscale")]
        public bool? EnablePerRegionPerPartitionAutoscale
        {
            get => Properties.EnablePerRegionPerPartitionAutoscale;
            set => Properties.EnablePerRegionPerPartitionAutoscale = value;
        }

        /// <summary> Describes the ServerVersion of an a MongoDB account. </summary>
        [WirePath("properties.apiProperties.serverVersion")]
        public CosmosDBServerVersion? ApiServerVersion
        {
            get => Properties.ApiServerVersion;
            set => Properties.ApiServerVersion = value;
        }

        /// <summary> The offer type for the database. </summary>
        [WirePath("properties.databaseAccountOfferType")]
        public CosmosDBAccountOfferType DatabaseAccountOfferType
        {
            get => Properties.DatabaseAccountOfferType;
            set => Properties.DatabaseAccountOfferType = value;
        }
    }
}
