// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

// MPG flattens nested `properties: DatabaseAccountCreateUpdateProperties` into get-only
// proxies on this wrapper because DatabaseAccountCreateUpdateProperties has no
// parameterless public constructor (its `locations` and `databaseAccountOfferType`
// are required), so PropertyHelpers.GetFlags returns IsReadOnly=false but
// BuildSetterForSafeFlatten cannot synthesize a lazy-create setter and the setter
// is dropped. JsonModelWriteCore writes the inner Properties object directly
// (writer.WriteObjectValue(Properties, options)), so re-emitting the proxies with
// setters that mutate the always-non-null Properties leaf preserves wire shape.
//
// This partial also restores three type-drifts vs the previous AutoRest contract:
//   * IPRules (uppercase P) alias for the new IpRules
//   * KeyVaultKeyUri exposed as System.Uri (inner is string)
//   * NetworkAclBypassResourceIds exposed as IList<ResourceIdentifier> (inner is IList<string>)
// And restores the Identity property dropped by `OmitProperties<..., "identity">` in
// client.tsp. Identity is API-surface only; the wrapper spec omits it, so values set
// here are NOT serialized to the wire. Service-side wire-serialization for Identity
// requires a spec change (remove "identity" from OmitProperties).

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
    [CodeGenSuppress("NetworkAclBypassResourceIds")]
    [CodeGenSuppress("PublicNetworkAccess")]
    [CodeGenSuppress("RestoreParameters")]
    public partial class CosmosDBAccountCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBAccountCreateOrUpdateContent"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="locations"> An array that contains the georeplication locations enabled for the Cosmos DB account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="locations"/> is null. </exception>
        public CosmosDBAccountCreateOrUpdateContent(AzureLocation location, IEnumerable<CosmosDBAccountLocation> locations) : base(location)
        {
            Argument.AssertNotNull(locations, nameof(locations));

            Properties = new DatabaseAccountCreateUpdateProperties(locations, default);
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
            get => Properties.AnalyticalStorageConfiguration?.SchemaType;
            set
            {
                if (value.HasValue)
                {
                    Properties.AnalyticalStorageConfiguration ??= new AnalyticalStorageConfiguration();
                    Properties.AnalyticalStorageConfiguration.SchemaType = value;
                }
                else if (Properties.AnalyticalStorageConfiguration is not null)
                {
                    Properties.AnalyticalStorageConfiguration.SchemaType = value;
                }
            }
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
            get => Properties.Capacity?.TotalThroughputLimit;
            set
            {
                if (value.HasValue)
                {
                    Properties.Capacity ??= new CosmosDBAccountCapacity();
                    Properties.Capacity.TotalThroughputLimit = value.Value;
                }
                else if (Properties.Capacity is not null)
                {
                    Properties.Capacity.TotalThroughputLimit = default;
                }
            }
        }

        /// <summary> Flag to indicate enabling/disabling of Materialized Views on the Cosmos DB account. </summary>
        [WirePath("properties.enableMaterializedViews")]
        public bool? EnableMaterializedViews
        {
            get => Properties.EnableMaterializedViews;
            set => Properties.EnableMaterializedViews = value;
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

        /// <summary> Enables enabling/disabling of MultipleWriteLocations on Cosmos DB. </summary>
        [WirePath("properties.enableMultipleWriteLocations")]
        public bool? EnableMultipleWriteLocations
        {
            get => Properties.EnableMultipleWriteLocations;
            set => Properties.EnableMultipleWriteLocations = value;
        }

        /// <summary> Enables the cassandra connector on Cosmos DB. </summary>
        [WirePath("properties.enableCassandraConnector")]
        public bool? EnableCassandraConnector
        {
            get => Properties.EnableCassandraConnector;
            set => Properties.EnableCassandraConnector = value;
        }

        /// <summary> The offer type for the database. </summary>
        [WirePath("properties.databaseAccountOfferType")]
        public CosmosDBAccountOfferType DatabaseAccountOfferType
        {
            get => Properties.DatabaseAccountOfferType;
            set => Properties.DatabaseAccountOfferType = value;
        }

        /// <summary> Describes the ServerVersion of an a MongoDB account. </summary>
        [WirePath("properties.apiProperties.serverVersion")]
        public CosmosDBServerVersion? ApiServerVersion
        {
            get => Properties.ApiProperties?.ServerVersion;
            set
            {
                if (value.HasValue)
                {
                    Properties.ApiProperties ??= new ApiProperties();
                    Properties.ApiProperties.ServerVersion = value;
                }
                else if (Properties.ApiProperties is not null)
                {
                    Properties.ApiProperties.ServerVersion = value;
                }
            }
        }

        // ----- Type-drift restorations (additive aliases / typed wrappers) -----

        /// <summary> List of IpRules. Back-compat alias for <see cref="IpRules"/>. </summary>
        public IList<CosmosDBIPAddressOrRange> IPRules => IpRules;

        /// <summary> The URI of the key vault. Back-compat wrapper for the inner string. </summary>
        [WirePath("properties.keyVaultKeyUri")]
        public Uri KeyVaultKeyUri
        {
            get => Properties.KeyVaultKeyUri is null ? null : new Uri(Properties.KeyVaultKeyUri);
            set => Properties.KeyVaultKeyUri = value?.AbsoluteUri;
        }

        /// <summary> An array of resource IDs allowed to bypass the network ACL. Back-compat <see cref="ResourceIdentifier"/> view over the inner <see cref="IList{T}"/> of strings. </summary>
        [WirePath("properties.networkAclBypassResourceIds")]
        public IList<ResourceIdentifier> NetworkAclBypassResourceIds
            => Properties.NetworkAclBypassResourceIds is null ? null : new ResourceIdentifierStringListView(Properties.NetworkAclBypassResourceIds);

        /// <summary>
        /// Back-compat surface only. The TypeSpec wrapper for this body model omits "identity"
        /// (see client.tsp <c>OmitProperties&lt;DatabaseAccountCreateUpdateParameters, "identity"&gt;</c>),
        /// so values assigned here are NOT serialized to the wire. To restore wire-serialization,
        /// remove "identity" from the OmitProperties list in client.tsp.
        /// </summary>
        public ManagedServiceIdentity Identity { get; set; }

        /// <summary> Live-view <see cref="IList{T}"/> of <see cref="ResourceIdentifier"/> over the underlying <see cref="IList{T}"/> of strings. Mutations on this view propagate to the inner string list and therefore to the wire. </summary>
        private sealed class ResourceIdentifierStringListView : IList<ResourceIdentifier>
        {
            private readonly IList<string> _inner;
            public ResourceIdentifierStringListView(IList<string> inner) => _inner = inner;

            public ResourceIdentifier this[int index]
            {
                get => _inner[index] is null ? null : new ResourceIdentifier(_inner[index]);
                set => _inner[index] = value?.ToString();
            }

            public int Count => _inner.Count;
            public bool IsReadOnly => _inner.IsReadOnly;
            public void Add(ResourceIdentifier item) => _inner.Add(item?.ToString());
            public void Clear() => _inner.Clear();
            public bool Contains(ResourceIdentifier item) => _inner.Contains(item?.ToString());
            public void CopyTo(ResourceIdentifier[] array, int arrayIndex)
            {
                if (array is null) throw new ArgumentNullException(nameof(array));
                for (int i = 0; i < _inner.Count; i++)
                    array[arrayIndex + i] = _inner[i] is null ? null : new ResourceIdentifier(_inner[i]);
            }
            public IEnumerator<ResourceIdentifier> GetEnumerator()
            {
                foreach (var s in _inner)
                    yield return s is null ? null : new ResourceIdentifier(s);
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public int IndexOf(ResourceIdentifier item) => _inner.IndexOf(item?.ToString());
            public void Insert(int index, ResourceIdentifier item) => _inner.Insert(index, item?.ToString());
            public bool Remove(ResourceIdentifier item) => _inner.Remove(item?.ToString());
            public void RemoveAt(int index) => _inner.RemoveAt(index);
        }
    }
}
