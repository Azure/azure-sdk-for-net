namespace Azure.ResourceManager.Kusto
{
    public partial class AttachedDatabaseConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>, System.Collections.IEnumerable
    {
        protected AttachedDatabaseConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> Get(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>> GetAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttachedDatabaseConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public AttachedDatabaseConfigurationData() { }
        public System.Collections.Generic.IReadOnlyList<string> AttachedDatabaseNames { get { throw null; } }
        public string ClusterResourceId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.TableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
    }
    public partial class AttachedDatabaseConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttachedDatabaseConfigurationResource() { }
        public virtual Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string attachedDatabaseConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ClusterResource>, System.Collections.IEnumerable
    {
        protected ClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Kusto.ClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Kusto.ClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.ClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.ClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.ClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.ClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.AzureSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.AcceptedAudiences> AcceptedAudiences { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedIPRangeList { get { throw null; } }
        public System.Uri DataIngestionUri { get { throw null; } }
        public bool? EnableAutoStop { get { throw null; } set { } }
        public bool? EnableDiskEncryption { get { throw null; } set { } }
        public bool? EnableDoubleEncryption { get { throw null; } set { } }
        public bool? EnablePurge { get { throw null; } set { } }
        public bool? EnableStreamingIngest { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.EngineType? EngineType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.LanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.PublicIPType? PublicIPType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.AzureSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.State? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.TrustedExternalTenant> TrustedExternalTenants { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string VirtualClusterGraduationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class ClusterPrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected ClusterPrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterPrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterPrincipalAssignmentData() { }
        public string AadObjectId { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class ClusterPrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterPrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterResource() { }
        public virtual Azure.ResourceManager.Kusto.ClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.LanguageExtensionsList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.LanguageExtensionsList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityAttachedDatabaseConfiguration(Azure.ResourceManager.Kusto.Models.AttachedDatabaseConfigurationsCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityAttachedDatabaseConfigurationAsync(Azure.ResourceManager.Kusto.Models.AttachedDatabaseConfigurationsCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityClusterPrincipalAssignment(Azure.ResourceManager.Kusto.Models.ClusterPrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityClusterPrincipalAssignmentAsync(Azure.ResourceManager.Kusto.Models.ClusterPrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityDatabase(Azure.ResourceManager.Kusto.Models.CheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityDatabaseAsync(Azure.ResourceManager.Kusto.Models.CheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityManagedPrivateEndpoint(Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityManagedPrivateEndpointAsync(Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachFollowerDatabases(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.FollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachFollowerDatabasesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.FollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DiagnoseVirtualNetworkResult> DiagnoseVirtualNetwork(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DiagnoseVirtualNetworkResult>> DiagnoseVirtualNetworkAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource> GetAttachedDatabaseConfiguration(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource>> GetAttachedDatabaseConfigurationAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationCollection GetAttachedDatabaseConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource> GetClusterPrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource>> GetClusterPrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentCollection GetClusterPrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.FollowerDatabaseDefinition> GetFollowerDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.FollowerDatabaseDefinition> GetFollowerDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> GetKustoPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> GetKustoPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionCollection GetKustoPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> GetKustoPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>> GetKustoPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateLinkResourceCollection GetKustoPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.LanguageExtension> GetLanguageExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.LanguageExtension> GetLanguageExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> GetManagedPrivateEndpoint(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>> GetManagedPrivateEndpointAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.ManagedPrivateEndpointCollection GetManagedPrivateEndpoints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.OutboundNetworkDependenciesEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.OutboundNetworkDependenciesEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.AzureResourceSku> GetSkusByResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.AzureResourceSku> GetSkusByResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.LanguageExtensionsList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.LanguageExtensionsList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.ClusterPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.ClusterPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Kusto.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Kusto.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class DatabasePrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected DatabasePrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabasePrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabasePrincipalAssignmentData() { }
        public string AadObjectId { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class DatabasePrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabasePrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.Kusto.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> AddPrincipals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalListRequest databasePrincipalsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> AddPrincipalsAsync(Azure.ResourceManager.Kusto.Models.DatabasePrincipalListRequest databasePrincipalsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityDatabasePrincipalAssignment(Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityDatabasePrincipalAssignmentAsync(Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityDataConnection(Azure.ResourceManager.Kusto.Models.DataConnectionCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityDataConnectionAsync(Azure.ResourceManager.Kusto.Models.DataConnectionCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityScript(Azure.ResourceManager.Kusto.Models.ScriptCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityScriptAsync(Azure.ResourceManager.Kusto.Models.ScriptCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DataConnectionValidationListResult> DataConnectionValidationDataConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.DataConnectionValidation dataConnectionValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DataConnectionValidationListResult>> DataConnectionValidationDataConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.DataConnectionValidation dataConnectionValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource> GetDatabasePrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource>> GetDatabasePrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentCollection GetDatabasePrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DataConnectionResource> GetDataConnection(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DataConnectionResource>> GetDataConnectionAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.DataConnectionCollection GetDataConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> GetPrincipals(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> GetPrincipalsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ScriptResource> GetScript(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ScriptResource>> GetScriptAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.ScriptCollection GetScripts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> RemovePrincipals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalListRequest databasePrincipalsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> RemovePrincipalsAsync(Azure.ResourceManager.Kusto.Models.DatabasePrincipalListRequest databasePrincipalsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.DataConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.DataConnectionResource>, System.Collections.IEnumerable
    {
        protected DataConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DataConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Kusto.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DataConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Kusto.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DataConnectionResource> Get(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.DataConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.DataConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DataConnectionResource>> GetAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.DataConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.DataConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.DataConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.DataConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public DataConnectionData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class DataConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataConnectionResource() { }
        public virtual Azure.ResourceManager.Kusto.DataConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName, string dataConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.DataConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.DataConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DataConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.DataConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KustoExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult> CheckNameAvailabilityCluster(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.ClusterCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.CheckNameResult>> CheckNameAvailabilityClusterAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.ClusterCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.AttachedDatabaseConfigurationResource GetAttachedDatabaseConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Kusto.ClusterResource> GetCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ClusterResource>> GetClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.ClusterPrincipalAssignmentResource GetClusterPrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.ClusterResource GetClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.ClusterCollection GetClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Kusto.ClusterResource> GetClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Kusto.ClusterResource> GetClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.DatabasePrincipalAssignmentResource GetDatabasePrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.DataConnectionResource GetDataConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource GetKustoPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoPrivateLinkResource GetKustoPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource GetManagedPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Kusto.Models.OperationResult> GetOperationsResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.OperationResult>> GetOperationsResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response GetOperationsResultsLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> GetOperationsResultsLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.ScriptResource GetScriptResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Kusto.Models.SkuDescription> GetSkusClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.SkuDescription> GetSkusClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected KustoPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Kusto.Models.KustoPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public string GroupId { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class KustoPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected KustoPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected ManagedPrivateEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.Kusto.ManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.Kusto.ManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> Get(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>> GetAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedPrivateEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedPrivateEndpointData() { }
        public string GroupId { get { throw null; } set { } }
        public string PrivateLinkResourceId { get { throw null; } set { } }
        public string PrivateLinkResourceRegion { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
    }
    public partial class ManagedPrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedPrivateEndpointResource() { }
        public virtual Azure.ResourceManager.Kusto.ManagedPrivateEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string managedPrivateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.ManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ManagedPrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.ManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScriptCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ScriptResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ScriptResource>, System.Collections.IEnumerable
    {
        protected ScriptCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ScriptResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Kusto.ScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ScriptResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Kusto.ScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ScriptResource> Get(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.ScriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.ScriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ScriptResource>> GetAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.ScriptResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.ScriptResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.ScriptResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.ScriptResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScriptData : Azure.ResourceManager.Models.ResourceData
    {
        public ScriptData() { }
        public bool? ContinueOnErrors { get { throw null; } set { } }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
        public string ScriptUrlSasToken { get { throw null; } set { } }
    }
    public partial class ScriptResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScriptResource() { }
        public virtual Azure.ResourceManager.Kusto.ScriptData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName, string scriptName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.ScriptResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.ScriptResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ScriptResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.ScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.ScriptResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.ScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Kusto.Models
{
    public partial class AcceptedAudiences
    {
        public AcceptedAudiences() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class AttachedDatabaseConfigurationsCheckNameContent
    {
        public AttachedDatabaseConfigurationsCheckNameContent(string name) { }
        public Azure.ResourceManager.Kusto.Models.AttachedDatabaseType DatabaseType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttachedDatabaseType : System.IEquatable<Azure.ResourceManager.Kusto.Models.AttachedDatabaseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttachedDatabaseType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.AttachedDatabaseType MicrosoftKustoClustersAttachedDatabaseConfigurations { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.AttachedDatabaseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.AttachedDatabaseType left, Azure.ResourceManager.Kusto.Models.AttachedDatabaseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.AttachedDatabaseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.AttachedDatabaseType left, Azure.ResourceManager.Kusto.Models.AttachedDatabaseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureCapacity
    {
        internal AzureCapacity() { }
        public int Default { get { throw null; } }
        public int Maximum { get { throw null; } }
        public int Minimum { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.AzureScaleType ScaleType { get { throw null; } }
    }
    public partial class AzureResourceSku
    {
        internal AzureResourceSku() { }
        public Azure.ResourceManager.Kusto.Models.AzureCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.AzureSku Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureScaleType : System.IEquatable<Azure.ResourceManager.Kusto.Models.AzureScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.AzureScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.AzureScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.AzureScaleType left, Azure.ResourceManager.Kusto.Models.AzureScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.AzureScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.AzureScaleType left, Azure.ResourceManager.Kusto.Models.AzureScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSku
    {
        public AzureSku(Azure.ResourceManager.Kusto.Models.AzureSkuName name, Azure.ResourceManager.Kusto.Models.AzureSkuTier tier) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.AzureSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.AzureSkuTier Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSkuName : System.IEquatable<Azure.ResourceManager.Kusto.Models.AzureSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName DevNoSLAStandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName DevNoSLAStandardE2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD16DV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD32DV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardD32DV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardDS13V21TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardDS13V22TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardDS14V23TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardDS14V24TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16AsV43TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16AsV44TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16AsV53TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16AsV54TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16AV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16SV43TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16SV44TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16SV53TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE16SV54TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE2AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE2AV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE4AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE4AV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE64IV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE80IdsV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8AdsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8AsV41TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8AsV42TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8AsV51TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8AsV52TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8AV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8SV41TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8SV42TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8SV51TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardE8SV52TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardL16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuName StandardL8SV2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.AzureSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.AzureSkuName left, Azure.ResourceManager.Kusto.Models.AzureSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.AzureSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.AzureSkuName left, Azure.ResourceManager.Kusto.Models.AzureSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureSkuTier : System.IEquatable<Azure.ResourceManager.Kusto.Models.AzureSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.AzureSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.AzureSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.AzureSkuTier left, Azure.ResourceManager.Kusto.Models.AzureSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.AzureSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.AzureSkuTier left, Azure.ResourceManager.Kusto.Models.AzureSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobStorageEventType : System.IEquatable<Azure.ResourceManager.Kusto.Models.BlobStorageEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobStorageEventType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.BlobStorageEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.BlobStorageEventType MicrosoftStorageBlobRenamed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.BlobStorageEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.BlobStorageEventType left, Azure.ResourceManager.Kusto.Models.BlobStorageEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.BlobStorageEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.BlobStorageEventType left, Azure.ResourceManager.Kusto.Models.BlobStorageEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameContent
    {
        public CheckNameContent(string name, Azure.ResourceManager.Kusto.Models.KustoResourceType kustoResourceType) { }
        public Azure.ResourceManager.Kusto.Models.KustoResourceType KustoResourceType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CheckNameResult
    {
        internal CheckNameResult() { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.Reason? Reason { get { throw null; } }
    }
    public partial class ClusterCheckNameContent
    {
        public ClusterCheckNameContent(string name) { }
        public Azure.ResourceManager.Kusto.Models.ClusterType ClusterType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterNetworkAccessFlag : System.IEquatable<Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterNetworkAccessFlag(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag left, Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag left, Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ClusterPatch(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.AcceptedAudiences> AcceptedAudiences { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedIPRangeList { get { throw null; } }
        public System.Uri DataIngestionUri { get { throw null; } }
        public bool? EnableAutoStop { get { throw null; } set { } }
        public bool? EnableDiskEncryption { get { throw null; } set { } }
        public bool? EnableDoubleEncryption { get { throw null; } set { } }
        public bool? EnablePurge { get { throw null; } set { } }
        public bool? EnableStreamingIngest { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.EngineType? EngineType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.LanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.PublicIPType? PublicIPType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ClusterNetworkAccessFlag? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.AzureSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.State? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.TrustedExternalTenant> TrustedExternalTenants { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string VirtualClusterGraduationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.VirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
    }
    public partial class ClusterPrincipalAssignmentCheckNameContent
    {
        public ClusterPrincipalAssignmentCheckNameContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType PrincipalAssignmentType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPrincipalRole : System.IEquatable<Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole AllDatabasesAdmin { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole AllDatabasesViewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole left, Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole left, Azure.ResourceManager.Kusto.Models.ClusterPrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterType : System.IEquatable<Azure.ResourceManager.Kusto.Models.ClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.ClusterType MicrosoftKustoClusters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.ClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.ClusterType left, Azure.ResourceManager.Kusto.Models.ClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.ClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.ClusterType left, Azure.ResourceManager.Kusto.Models.ClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Compression : System.IEquatable<Azure.ResourceManager.Kusto.Models.Compression>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Compression(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.Compression GZip { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.Compression None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.Compression other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.Compression left, Azure.ResourceManager.Kusto.Models.Compression right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.Compression (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.Compression left, Azure.ResourceManager.Kusto.Models.Compression right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabasePrincipal
    {
        public DatabasePrincipal(Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole role, string name, Azure.ResourceManager.Kusto.Models.DatabasePrincipalType principalType) { }
        public string AppId { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Fqn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.DatabasePrincipalType PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole Role { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class DatabasePrincipalAssignmentCheckNameContent
    {
        public DatabasePrincipalAssignmentCheckNameContent(string name) { }
        public Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType AssignmentType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabasePrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabasePrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType MicrosoftKustoClustersDatabasesPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.DatabasePrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabasePrincipalListRequest
    {
        public DatabasePrincipalListRequest() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.DatabasePrincipal> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabasePrincipalRole : System.IEquatable<Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabasePrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole Admin { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole Ingestor { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole Monitor { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole UnrestrictedViewer { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole User { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole Viewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole left, Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole left, Azure.ResourceManager.Kusto.Models.DatabasePrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabasePrincipalType : System.IEquatable<Azure.ResourceManager.Kusto.Models.DatabasePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabasePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalType App { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabasePrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.DatabasePrincipalType left, Azure.ResourceManager.Kusto.Models.DatabasePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.DatabasePrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.DatabasePrincipalType left, Azure.ResourceManager.Kusto.Models.DatabasePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseRouting : System.IEquatable<Azure.ResourceManager.Kusto.Models.DatabaseRouting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseRouting(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DatabaseRouting Multi { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DatabaseRouting Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.DatabaseRouting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.DatabaseRouting left, Azure.ResourceManager.Kusto.Models.DatabaseRouting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.DatabaseRouting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.DatabaseRouting left, Azure.ResourceManager.Kusto.Models.DatabaseRouting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataConnectionCheckNameContent
    {
        public DataConnectionCheckNameContent(string name) { }
        public Azure.ResourceManager.Kusto.Models.DataConnectionType ConnectionType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataConnectionType : System.IEquatable<Azure.ResourceManager.Kusto.Models.DataConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DataConnectionType MicrosoftKustoClustersDatabasesDataConnections { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.DataConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.DataConnectionType left, Azure.ResourceManager.Kusto.Models.DataConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.DataConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.DataConnectionType left, Azure.ResourceManager.Kusto.Models.DataConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataConnectionValidation
    {
        public DataConnectionValidation() { }
        public string DataConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.DataConnectionData Properties { get { throw null; } set { } }
    }
    public partial class DataConnectionValidationListResult
    {
        internal DataConnectionValidationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.Models.DataConnectionValidationResult> Value { get { throw null; } }
    }
    public partial class DataConnectionValidationResult
    {
        internal DataConnectionValidationResult() { }
        public string ErrorMessage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultPrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultPrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.DefaultPrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnoseVirtualNetworkResult
    {
        internal DiagnoseVirtualNetworkResult() { }
        public System.Collections.Generic.IReadOnlyList<string> Findings { get { throw null; } }
    }
    public partial class EndpointDependency
    {
        public EndpointDependency() { }
        public string DomainName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.EndpointDetail> EndpointDetails { get { throw null; } }
    }
    public partial class EndpointDetail
    {
        public EndpointDetail() { }
        public int? Port { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EngineType : System.IEquatable<Azure.ResourceManager.Kusto.Models.EngineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EngineType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.EngineType V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EngineType V3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.EngineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.EngineType left, Azure.ResourceManager.Kusto.Models.EngineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.EngineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.EngineType left, Azure.ResourceManager.Kusto.Models.EngineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridDataConnection : Azure.ResourceManager.Kusto.DataConnectionData
    {
        public EventGridDataConnection() { }
        public Azure.ResourceManager.Kusto.Models.BlobStorageEventType? BlobStorageEventType { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.DatabaseRouting? DatabaseRouting { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.EventGridDataFormat? DataFormat { get { throw null; } set { } }
        public string EventGridResourceId { get { throw null; } set { } }
        public string EventHubResourceId { get { throw null; } set { } }
        public bool? IgnoreFirstRecord { get { throw null; } set { } }
        public string ManagedIdentityObjectId { get { throw null; } }
        public string ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridDataFormat : System.IEquatable<Azure.ResourceManager.Kusto.Models.EventGridDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Apacheavro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Multijson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat ORC { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat PSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat RAW { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Singlejson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat TSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat TXT { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventGridDataFormat W3Clogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.EventGridDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.EventGridDataFormat left, Azure.ResourceManager.Kusto.Models.EventGridDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.EventGridDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.EventGridDataFormat left, Azure.ResourceManager.Kusto.Models.EventGridDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubDataConnection : Azure.ResourceManager.Kusto.DataConnectionData
    {
        public EventHubDataConnection() { }
        public Azure.ResourceManager.Kusto.Models.Compression? Compression { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.DatabaseRouting? DatabaseRouting { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.EventHubDataFormat? DataFormat { get { throw null; } set { } }
        public string EventHubResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public string ManagedIdentityObjectId { get { throw null; } }
        public string ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubDataFormat : System.IEquatable<Azure.ResourceManager.Kusto.Models.EventHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Apacheavro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Multijson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat ORC { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat PSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat RAW { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Singlejson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat TSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat TXT { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubDataFormat W3Clogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.EventHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.EventHubDataFormat left, Azure.ResourceManager.Kusto.Models.EventHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.EventHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.EventHubDataFormat left, Azure.ResourceManager.Kusto.Models.EventHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FollowerDatabaseDefinition
    {
        public FollowerDatabaseDefinition(string clusterResourceId, string attachedDatabaseConfigurationName) { }
        public string AttachedDatabaseConfigurationName { get { throw null; } set { } }
        public string ClusterResourceId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } }
    }
    public partial class IotHubDataConnection : Azure.ResourceManager.Kusto.DataConnectionData
    {
        public IotHubDataConnection() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.DatabaseRouting? DatabaseRouting { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.IotHubDataFormat? DataFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public string IotHubResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubDataFormat : System.IEquatable<Azure.ResourceManager.Kusto.Models.IotHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Apacheavro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Multijson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat ORC { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat PSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat RAW { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Singlejson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat TSV { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat TXT { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.IotHubDataFormat W3Clogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.IotHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.IotHubDataFormat left, Azure.ResourceManager.Kusto.Models.IotHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.IotHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.IotHubDataFormat left, Azure.ResourceManager.Kusto.Models.IotHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserIdentity { get { throw null; } set { } }
    }
    public partial class KustoPrivateLinkServiceConnectionStateProperty
    {
        public KustoPrivateLinkServiceConnectionStateProperty() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public enum KustoResourceType
    {
        MicrosoftKustoClustersDatabases = 0,
        MicrosoftKustoClustersAttachedDatabaseConfigurations = 1,
    }
    public partial class LanguageExtension
    {
        public LanguageExtension() { }
        public Azure.ResourceManager.Kusto.Models.LanguageExtensionName? LanguageExtensionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LanguageExtensionName : System.IEquatable<Azure.ResourceManager.Kusto.Models.LanguageExtensionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LanguageExtensionName(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.LanguageExtensionName Python { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.LanguageExtensionName R { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.LanguageExtensionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.LanguageExtensionName left, Azure.ResourceManager.Kusto.Models.LanguageExtensionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.LanguageExtensionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.LanguageExtensionName left, Azure.ResourceManager.Kusto.Models.LanguageExtensionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LanguageExtensionsList
    {
        public LanguageExtensionsList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.LanguageExtension> Value { get { throw null; } }
    }
    public partial class ManagedPrivateEndpointsCheckNameContent
    {
        public ManagedPrivateEndpointsCheckNameContent(string name) { }
        public Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType EndpointsType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedPrivateEndpointsType : System.IEquatable<Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedPrivateEndpointsType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType MicrosoftKustoClustersManagedPrivateEndpoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType left, Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType left, Azure.ResourceManager.Kusto.Models.ManagedPrivateEndpointsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationResult
    {
        internal OperationResult() { }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationKind { get { throw null; } }
        public string OperationState { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.Status? Status { get { throw null; } }
    }
    public partial class OptimizedAutoscale
    {
        public OptimizedAutoscale(int version, bool isEnabled, int minimum, int maximum) { }
        public bool IsEnabled { get { throw null; } set { } }
        public int Maximum { get { throw null; } set { } }
        public int Minimum { get { throw null; } set { } }
        public int Version { get { throw null; } set { } }
    }
    public partial class OutboundNetworkDependenciesEndpoint : Azure.ResourceManager.Models.ResourceData
    {
        public OutboundNetworkDependenciesEndpoint() { }
        public string Category { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.EndpointDependency> Endpoints { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType MicrosoftKustoClustersPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.PrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalType : System.IEquatable<Azure.ResourceManager.Kusto.Models.PrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.PrincipalType App { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.PrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.PrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.PrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.PrincipalType left, Azure.ResourceManager.Kusto.Models.PrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.PrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.PrincipalType left, Azure.ResourceManager.Kusto.Models.PrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Kusto.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.ProvisioningState left, Azure.ResourceManager.Kusto.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.ProvisioningState left, Azure.ResourceManager.Kusto.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicIPType : System.IEquatable<Azure.ResourceManager.Kusto.Models.PublicIPType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicIPType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.PublicIPType DualStack { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.PublicIPType IPv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.PublicIPType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.PublicIPType left, Azure.ResourceManager.Kusto.Models.PublicIPType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.PublicIPType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.PublicIPType left, Azure.ResourceManager.Kusto.Models.PublicIPType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Kusto.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.PublicNetworkAccess left, Azure.ResourceManager.Kusto.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.PublicNetworkAccess left, Azure.ResourceManager.Kusto.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReadOnlyFollowingDatabase : Azure.ResourceManager.Kusto.DatabaseData
    {
        public ReadOnlyFollowingDatabase() { }
        public string AttachedDatabaseConfigurationName { get { throw null; } }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public string LeaderClusterResourceId { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.PrincipalsModificationKind? PrincipalsModificationKind { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } }
        public float? StatisticsSize { get { throw null; } }
    }
    public partial class ReadWriteDatabase : Azure.ResourceManager.Kusto.DatabaseData
    {
        public ReadWriteDatabase() { }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public bool? IsFollowed { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } set { } }
        public float? StatisticsSize { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.Kusto.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.Reason left, Azure.ResourceManager.Kusto.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.Reason left, Azure.ResourceManager.Kusto.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScriptCheckNameContent
    {
        public ScriptCheckNameContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.ScriptType ScriptType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.Kusto.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.ScriptType MicrosoftKustoClustersDatabasesScripts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.ScriptType left, Azure.ResourceManager.Kusto.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.ScriptType left, Azure.ResourceManager.Kusto.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuDescription
    {
        internal SkuDescription() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.Models.SkuLocationInfoItem> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class SkuLocationInfoItem
    {
        internal SkuLocationInfoItem() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.Kusto.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.State Creating { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Deleted { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Deleting { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Running { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Starting { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Stopped { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Stopping { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Unavailable { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.State Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.State left, Azure.ResourceManager.Kusto.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.State left, Azure.ResourceManager.Kusto.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.Kusto.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.Status Canceled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.Status Running { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.Status Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.Status left, Azure.ResourceManager.Kusto.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.Status left, Azure.ResourceManager.Kusto.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TableLevelSharingProperties
    {
        public TableLevelSharingProperties() { }
        public System.Collections.Generic.IList<string> ExternalTablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> ExternalTablesToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToInclude { get { throw null; } }
    }
    public partial class TrustedExternalTenant
    {
        public TrustedExternalTenant() { }
        public string Value { get { throw null; } set { } }
    }
    public partial class VirtualNetworkConfiguration
    {
        public VirtualNetworkConfiguration(string subnetId, string enginePublicIPId, string dataManagementPublicIPId) { }
        public string DataManagementPublicIPId { get { throw null; } set { } }
        public string EnginePublicIPId { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
}
