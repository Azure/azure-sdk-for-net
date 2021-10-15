namespace Microsoft.Azure.Management.Kusto.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class representing an update to a Kusto cluster.
    /// </summary>
    public partial class ClusterUpdate : Resource
    {
        /// <summary>
        /// Initializes a new instance of the ClusterUpdate class.
        /// </summary>
        /// <param name="id">Fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}</param>
        /// <param name="name">The name of the resource</param>
        /// <param name="type">The type of the resource. E.g.
        /// "Microsoft.Compute/virtualMachines" or
        /// "Microsoft.Storage/storageAccounts"</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="location">Resource location.</param>
        /// <param name="sku">The SKU of the cluster.</param>
        /// <param name="identity">The identity of the cluster, if
        /// configured.</param>
        /// <param name="state">The state of the resource. Possible values
        /// include: 'Creating', 'Unavailable', 'Running', 'Deleting',
        /// 'Deleted', 'Stopping', 'Stopped', 'Starting', 'Updating'</param>
        /// <param name="provisioningState">The provisioned state of the
        /// resource. Possible values include: 'Running', 'Creating',
        /// 'Deleting', 'Succeeded', 'Failed', 'Moving'</param>
        /// <param name="uri">The cluster URI.</param>
        /// <param name="dataIngestionUri">The cluster data ingestion
        /// URI.</param>
        /// <param name="stateReason">The reason for the cluster's current
        /// state.</param>
        /// <param name="trustedExternalTenants">The cluster's external
        /// tenants.</param>
        /// <param name="optimizedAutoscale">Optimized auto scale
        /// definition.</param>
        /// <param name="enableDiskEncryption">A boolean value that indicates
        /// if the cluster's disks are encrypted.</param>
        /// <param name="enableStreamingIngest">A boolean value that indicates
        /// if the streaming ingest is enabled.</param>
        /// <param name="virtualNetworkConfiguration">Virtual network
        /// definition.</param>
        /// <param name="keyVaultProperties">KeyVault properties for the
        /// cluster encryption.</param>
        /// <param name="enablePurge">A boolean value that indicates if the
        /// purge operations are enabled.</param>
        /// <param name="languageExtensions">List of the cluster's language
        /// extensions.</param>
        /// <param name="enableDoubleEncryption">A boolean value that indicates
        /// if double encryption is enabled.</param>
        /// <param name="engineType">The engine type. Possible values include:
        /// 'V2', 'V3'</param>
        public ClusterUpdate(string id, string name, string type, IDictionary<string, string> tags, string location, AzureSku sku, Identity identity, string state, string provisioningState, string uri, string dataIngestionUri, string stateReason, IList<TrustedExternalTenant> trustedExternalTenants, OptimizedAutoscale optimizedAutoscale, bool? enableDiskEncryption, bool? enableStreamingIngest, VirtualNetworkConfiguration virtualNetworkConfiguration, KeyVaultProperties keyVaultProperties, bool? enablePurge, LanguageExtensionsList languageExtensions, bool? enableDoubleEncryption, string engineType)
            : base(id, name, type)
        {
            Tags = tags;
            Location = location;
            Sku = sku;
            Identity = identity;
            State = state;
            ProvisioningState = provisioningState;
            Uri = uri;
            DataIngestionUri = dataIngestionUri;
            StateReason = stateReason;
            TrustedExternalTenants = trustedExternalTenants;
            OptimizedAutoscale = optimizedAutoscale;
            EnableDiskEncryption = enableDiskEncryption;
            EnableStreamingIngest = enableStreamingIngest;
            VirtualNetworkConfiguration = virtualNetworkConfiguration;
            KeyVaultProperties = keyVaultProperties;
            EnablePurge = enablePurge;
            LanguageExtensions = languageExtensions;
            EnableDoubleEncryption = enableDoubleEncryption;
            EngineType = engineType;
            CustomInit();
        }
    }
}
