// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The MPG generator emits these flattened properties as get-only because the
    // underlying DatabaseAccountCreateUpdateProperties is exposed via an internal
    // get-only Properties accessor. Baseline (AutoRest) shipped them as { get; set; }.
    // Re-declare each flattened property with a setter that lazily creates the
    // inner Properties when needed, preserving the historical SDK surface.
    [CodeGenSuppress("ConsistencyPolicy")]
    [CodeGenSuppress("DatabaseAccountOfferType")]
    [CodeGenSuppress("IsVirtualNetworkFilterEnabled")]
    [CodeGenSuppress("EnableAutomaticFailover")]
    [CodeGenSuppress("EnableMultipleWriteLocations")]
    [CodeGenSuppress("EnableCassandraConnector")]
    [CodeGenSuppress("ConnectorOffer")]
    [CodeGenSuppress("DisableKeyBasedMetadataWriteAccess")]
    [CodeGenSuppress("KeyVaultKeyUri")]
    [CodeGenSuppress("DefaultIdentity")]
    [CodeGenSuppress("PublicNetworkAccess")]
    [CodeGenSuppress("IsFreeTierEnabled")]
    [CodeGenSuppress("IsAnalyticalStorageEnabled")]
    [CodeGenSuppress("CreateMode")]
    [CodeGenSuppress("BackupPolicy")]
    [CodeGenSuppress("NetworkAclBypass")]
    [CodeGenSuppress("DisableLocalAuth")]
    [CodeGenSuppress("RestoreParameters")]
    [CodeGenSuppress("EnablePartitionMerge")]
    [CodeGenSuppress("EnableBurstCapacity")]
    [CodeGenSuppress("MinimalTlsVersion")]
    [CodeGenSuppress("CustomerManagedKeyStatus")]
    [CodeGenSuppress("EnablePriorityBasedExecution")]
    [CodeGenSuppress("DefaultPriorityLevel")]
    [CodeGenSuppress("EnablePerRegionPerPartitionAutoscale")]
    [CodeGenSuppress("ApiServerVersion")]
    [CodeGenSuppress("AnalyticalStorageSchemaType")]
    [CodeGenSuppress("CapacityTotalThroughputLimit")]
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("CosmosDBAccountCreateOrUpdateContent", typeof(DatabaseAccountCreateUpdateProperties))]
    public partial class CosmosDBAccountCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBAccountCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location of the resource group to which the resource belongs. </param>
        /// <param name="locations"> An array that contains the georeplication locations enabled for the Cosmos DB account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locations"/> is null. </exception>
        public CosmosDBAccountCreateOrUpdateContent(AzureLocation location, System.Collections.Generic.IEnumerable<CosmosDBAccountLocation> locations)
        {
            Argument.AssertNotNull(locations, nameof(locations));
            Location = location;
            Properties = new DatabaseAccountCreateUpdateProperties(default(AzureLocation), default(CosmosDBAccountOfferType));
        }

        [WirePath("properties")]
        internal DatabaseAccountCreateUpdateProperties Properties { get; set; }

        /// <summary>The consistency policy for the Cosmos DB account.</summary>
        [WirePath("properties.consistencyPolicy")]
        public ConsistencyPolicy ConsistencyPolicy
        {
            get => Properties is null ? default : Properties.ConsistencyPolicy;
            set
            {
                if (Properties == null)
                { return; }
                Properties.ConsistencyPolicy = value;
            }
        }

        /// <summary>The offer type for the Cosmos DB database account.</summary>
        [WirePath("properties.databaseAccountOfferType")]
        public CosmosDBAccountOfferType DatabaseAccountOfferType
        {
            get => Properties is null ? default : Properties.DatabaseAccountOfferType;
            set
            {
                if (Properties == null)
                { return; }
                Properties.DatabaseAccountOfferType = value;
            }
        }

        /// <summary>Flag to indicate whether to enable/disable Virtual Network ACL rules.</summary>
        [WirePath("properties.isVirtualNetworkFilterEnabled")]
        public bool? IsVirtualNetworkFilterEnabled
        {
            get => Properties is null ? default : Properties.IsVirtualNetworkFilterEnabled;
            set
            {
                if (Properties == null)
                { return; }
                Properties.IsVirtualNetworkFilterEnabled = value;
            }
        }

        /// <summary>Enables automatic failover of the write region in the rare event that the region is unavailable due to an outage. Automatic failover will result in a new write region for the account and is chosen based on the failover priorities configured for the account.</summary>
        [WirePath("properties.enableAutomaticFailover")]
        public bool? EnableAutomaticFailover
        {
            get => Properties is null ? default : Properties.EnableAutomaticFailover;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnableAutomaticFailover = value;
            }
        }

        /// <summary>Enables the account to write in multiple locations.</summary>
        [WirePath("properties.enableMultipleWriteLocations")]
        public bool? EnableMultipleWriteLocations
        {
            get => Properties is null ? default : Properties.EnableMultipleWriteLocations;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnableMultipleWriteLocations = value;
            }
        }

        /// <summary>Enables the cassandra connector on the Cosmos DB C* account.</summary>
        [WirePath("properties.enableCassandraConnector")]
        public bool? EnableCassandraConnector
        {
            get => Properties is null ? default : Properties.EnableCassandraConnector;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnableCassandraConnector = value;
            }
        }

        /// <summary>The cassandra connector offer type for the Cosmos DB database C* account.</summary>
        [WirePath("properties.connectorOffer")]
        public ConnectorOffer? ConnectorOffer
        {
            get => Properties is null ? default : Properties.ConnectorOffer;
            set
            {
                if (Properties == null)
                { return; }
                Properties.ConnectorOffer = value;
            }
        }

        /// <summary>Disable write operations on metadata resources (databases, containers, throughput) via account keys.</summary>
        [WirePath("properties.disableKeyBasedMetadataWriteAccess")]
        public bool? DisableKeyBasedMetadataWriteAccess
        {
            get => Properties is null ? default : Properties.DisableKeyBasedMetadataWriteAccess;
            set
            {
                if (Properties == null)
                { return; }
                Properties.DisableKeyBasedMetadataWriteAccess = value;
            }
        }

        /// <summary>The URI of the key vault.</summary>
        [WirePath("properties.keyVaultKeyUri")]
        public string KeyVaultKeyUri
        {
            get => Properties is null ? default : Properties.KeyVaultKeyUri;
            set
            {
                if (Properties == null)
                { return; }
                Properties.KeyVaultKeyUri = value;
            }
        }

        /// <summary>The default identity for accessing key vault used in features like customer managed keys. The default identity needs to be explicitly set by the users. It can be "FirstPartyIdentity", "SystemAssignedIdentity" and more.</summary>
        [WirePath("properties.defaultIdentity")]
        public string DefaultIdentity
        {
            get => Properties is null ? default : Properties.DefaultIdentity;
            set
            {
                if (Properties == null)
                { return; }
                Properties.DefaultIdentity = value;
            }
        }

        /// <summary>Whether requests from Public Network are allowed.</summary>
        [WirePath("properties.publicNetworkAccess")]
        public CosmosDBPublicNetworkAccess? PublicNetworkAccess
        {
            get => Properties is null ? default : Properties.PublicNetworkAccess;
            set
            {
                if (Properties == null)
                { return; }
                Properties.PublicNetworkAccess = value;
            }
        }

        /// <summary>Flag to indicate whether Free Tier is enabled.</summary>
        [WirePath("properties.enableFreeTier")]
        public bool? IsFreeTierEnabled
        {
            get => Properties is null ? default : Properties.IsFreeTierEnabled;
            set
            {
                if (Properties == null)
                { return; }
                Properties.IsFreeTierEnabled = value;
            }
        }

        /// <summary>Flag to indicate whether to enable storage analytics.</summary>
        [WirePath("properties.enableAnalyticalStorage")]
        public bool? IsAnalyticalStorageEnabled
        {
            get => Properties is null ? default : Properties.IsAnalyticalStorageEnabled;
            set
            {
                if (Properties == null)
                { return; }
                Properties.IsAnalyticalStorageEnabled = value;
            }
        }

        /// <summary>Enum to indicate the mode of account creation.</summary>
        [WirePath("properties.createMode")]
        public CosmosDBAccountCreateMode? CreateMode
        {
            get => Properties is null ? default : Properties.CreateMode;
            set
            {
                if (Properties == null)
                { return; }
                Properties.CreateMode = value;
            }
        }

        /// <summary>The object representing the policy for taking backups on an account.</summary>
        [WirePath("properties.backupPolicy")]
        public CosmosDBAccountBackupPolicy BackupPolicy
        {
            get => Properties is null ? default : Properties.BackupPolicy;
            set
            {
                if (Properties == null)
                { return; }
                Properties.BackupPolicy = value;
            }
        }

        /// <summary>Indicates what services are allowed to bypass firewall checks.</summary>
        [WirePath("properties.networkAclBypass")]
        public NetworkAclBypass? NetworkAclBypass
        {
            get => Properties is null ? default : Properties.NetworkAclBypass;
            set
            {
                if (Properties == null)
                { return; }
                Properties.NetworkAclBypass = value;
            }
        }

        /// <summary>Opt-out of local authentication and ensure only MSI and AAD can be used exclusively for authentication.</summary>
        [WirePath("properties.disableLocalAuth")]
        public bool? DisableLocalAuth
        {
            get => Properties is null ? default : Properties.DisableLocalAuth;
            set
            {
                if (Properties == null)
                { return; }
                Properties.DisableLocalAuth = value;
            }
        }

        /// <summary>Parameters to indicate the information about the restore.</summary>
        [WirePath("properties.restoreParameters")]
        public CosmosDBAccountRestoreParameters RestoreParameters
        {
            get => Properties is null ? default : Properties.RestoreParameters;
            set
            {
                if (Properties == null)
                { return; }
                Properties.RestoreParameters = value;
            }
        }

        /// <summary>Flag to indicate enabling/disabling of Partition Merge feature on the account.</summary>
        [WirePath("properties.enablePartitionMerge")]
        public bool? EnablePartitionMerge
        {
            get => Properties is null ? default : Properties.EnablePartitionMerge;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnablePartitionMerge = value;
            }
        }

        /// <summary>Flag to indicate enabling/disabling of Burst Capacity Preview feature on the account.</summary>
        [WirePath("properties.enableBurstCapacity")]
        public bool? EnableBurstCapacity
        {
            get => Properties is null ? default : Properties.EnableBurstCapacity;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnableBurstCapacity = value;
            }
        }

        /// <summary>Indicates the minimum allowed Tls version. The default is Tls 1.0, except for Cassandra and Mongo API's, which only work with Tls 1.2.</summary>
        [WirePath("properties.minimalTlsVersion")]
        public CosmosDBMinimalTlsVersion? MinimalTlsVersion
        {
            get => Properties is null ? default : Properties.MinimalTlsVersion;
            set
            {
                if (Properties == null)
                { return; }
                Properties.MinimalTlsVersion = value;
            }
        }

        /// <summary>Indicates the status of the Customer Managed Key feature on the account. In case there are errors, the property provides troubleshooting guidance.</summary>
        [WirePath("properties.customerManagedKeyStatus")]
        public string CustomerManagedKeyStatus
        {
            get => Properties is null ? default : Properties.CustomerManagedKeyStatus;
            set
            {
                if (Properties == null)
                { return; }
                Properties.CustomerManagedKeyStatus = value;
            }
        }

        /// <summary>Flag to indicate enabling/disabling of Priority Based Execution Preview feature on the account.</summary>
        [WirePath("properties.enablePriorityBasedExecution")]
        public bool? EnablePriorityBasedExecution
        {
            get => Properties is null ? default : Properties.EnablePriorityBasedExecution;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnablePriorityBasedExecution = value;
            }
        }

        /// <summary>Enum to indicate default Priority Level of request for Priority Based Execution.</summary>
        [WirePath("properties.defaultPriorityLevel")]
        public DefaultPriorityLevel? DefaultPriorityLevel
        {
            get => Properties is null ? default : Properties.DefaultPriorityLevel;
            set
            {
                if (Properties == null)
                { return; }
                Properties.DefaultPriorityLevel = value;
            }
        }

        /// <summary>Flag to indicate enabling/disabling of Per-Region Per-partition autoscale Preview feature on the account.</summary>
        [WirePath("properties.enablePerRegionPerPartitionAutoscale")]
        public bool? EnablePerRegionPerPartitionAutoscale
        {
            get => Properties is null ? default : Properties.EnablePerRegionPerPartitionAutoscale;
            set
            {
                if (Properties == null)
                { return; }
                Properties.EnablePerRegionPerPartitionAutoscale = value;
            }
        }

        /// <summary>Describes the version of the MongoDB account.</summary>
        [WirePath("properties.apiProperties.serverVersion")]
        public CosmosDBServerVersion? ApiServerVersion
        {
            get => Properties is null ? default : Properties.ApiServerVersion;
            set
            {
                if (Properties == null)
                { return; }
                Properties.ApiServerVersion = value;
            }
        }

        /// <summary>Describes the types of schema for analytical storage.</summary>
        [WirePath("properties.analyticalStorageConfiguration.schemaType")]
        public AnalyticalStorageSchemaType? AnalyticalStorageSchemaType
        {
            get => Properties is null ? default : Properties.AnalyticalStorageSchemaType;
            set
            {
                if (Properties == null)
                { return; }
                Properties.AnalyticalStorageSchemaType = value;
            }
        }

        /// <summary>The total throughput limit imposed on the account. A totalThroughputLimit of 2000 imposes a strict limit of max throughput that can be provisioned on that account to be 2000. A totalThroughputLimit of -1 indicates no limits on provisioning of throughput.</summary>
        [WirePath("properties.capacity.totalThroughputLimit")]
        public int? CapacityTotalThroughputLimit
        {
            get => Properties is null ? default : Properties.CapacityTotalThroughputLimit;
            set
            {
                if (Properties == null)
                { return; }
                Properties.CapacityTotalThroughputLimit = value;
            }
        }
    }
}
