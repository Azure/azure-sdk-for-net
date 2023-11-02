namespace Azure.ResourceManager.Kusto
{
    public partial class KustoAttachedDatabaseConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>, System.Collections.IEnumerable
    {
        protected KustoAttachedDatabaseConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> Get(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>> GetAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> GetIfExists(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>> GetIfExistsAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoAttachedDatabaseConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoAttachedDatabaseConfigurationData() { }
        public System.Collections.Generic.IReadOnlyList<string> AttachedDatabaseNames { get { throw null; } }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public string DatabaseNameOverride { get { throw null; } set { } }
        public string DatabaseNamePrefix { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
    }
    public partial class KustoAttachedDatabaseConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoAttachedDatabaseConfigurationResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string attachedDatabaseConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoClusterResource>, System.Collections.IEnumerable
    {
        protected KustoClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Kusto.KustoClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.Kusto.KustoClusterData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoClusterData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public KustoClusterData(Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.KustoSku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.AcceptedAudience> AcceptedAudiences { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedIPRangeList { get { throw null; } }
        public System.Uri ClusterUri { get { throw null; } }
        public System.Uri DataIngestionUri { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterEngineType? EngineType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAutoStopEnabled { get { throw null; } set { } }
        public bool? IsDiskEncryptionEnabled { get { throw null; } set { } }
        public bool? IsDoubleEncryptionEnabled { get { throw null; } set { } }
        public bool? IsPurgeEnabled { get { throw null; } set { } }
        public bool? IsStreamingIngestEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.MigrationClusterProperties MigrationCluster { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType? PublicIPType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterState? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.KustoClusterTrustedExternalTenant> TrustedExternalTenants { get { throw null; } }
        public string VirtualClusterGraduationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterVirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class KustoClusterPrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected KustoClusterPrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> GetIfExists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>> GetIfExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoClusterPrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoClusterPrincipalAssignmentData() { }
        public System.Guid? AadObjectId { get { throw null; } }
        public string ClusterPrincipalId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use ClusterPrincipalId instead.", false)]
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class KustoClusterPrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoClusterPrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoClusterResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoClusterResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoAttachedDatabaseConfigurationNameAvailability(Azure.ResourceManager.Kusto.Models.KustoAttachedDatabaseConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoAttachedDatabaseConfigurationNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoAttachedDatabaseConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoClusterPrincipalAssignmentNameAvailability(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoClusterPrincipalAssignmentNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoDatabaseNameAvailability(Azure.ResourceManager.Kusto.Models.KustoDatabaseNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoDatabaseNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoDatabaseNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoManagedPrivateEndpointNameAvailability(Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoManagedPrivateEndpointNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckNameAvailabilitySandboxCustomImage(Azure.ResourceManager.Kusto.Models.SandboxCustomImagesCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckNameAvailabilitySandboxCustomImageAsync(Azure.ResourceManager.Kusto.Models.SandboxCustomImagesCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachFollowerDatabases(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoFollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachFollowerDatabasesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoFollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DiagnoseVirtualNetworkResult> DiagnoseVirtualNetwork(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DiagnoseVirtualNetworkResult>> DiagnoseVirtualNetworkAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoAvailableSkuDetails> GetAvailableSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoAvailableSkuDetails> GetAvailableSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoFollowerDatabaseDefinition> GetFollowerDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoFollowerDatabaseDefinition> GetFollowerDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource> GetKustoAttachedDatabaseConfiguration(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource>> GetKustoAttachedDatabaseConfigurationAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationCollection GetKustoAttachedDatabaseConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource> GetKustoClusterPrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource>> GetKustoClusterPrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentCollection GetKustoClusterPrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDatabaseResource> GetKustoDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDatabaseResource>> GetKustoDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoDatabaseCollection GetKustoDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> GetKustoManagedPrivateEndpoint(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>> GetKustoManagedPrivateEndpointAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointCollection GetKustoManagedPrivateEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> GetKustoPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> GetKustoPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionCollection GetKustoPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> GetKustoPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>> GetKustoPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateLinkResourceCollection GetKustoPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> GetLanguageExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> GetLanguageExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.OutboundNetworkDependenciesEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.OutboundNetworkDependenciesEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.SandboxCustomImageResource> GetSandboxCustomImage(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.SandboxCustomImageResource>> GetSandboxCustomImageAsync(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.SandboxCustomImageCollection GetSandboxCustomImages() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Migrate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.ClusterMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.ClusterMigrateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoClusterPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.KustoClusterPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoDatabaseResource>, System.Collections.IEnumerable
    {
        protected KustoDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Kusto.KustoDatabaseData data, Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole? callerRole = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Kusto.KustoDatabaseData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Kusto.KustoDatabaseData data, Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole? callerRole = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Kusto.KustoDatabaseData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoDatabaseResource> GetAll(int? top, string skiptoken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoDatabaseResource> GetAllAsync(int? top, string skiptoken, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoDatabaseData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class KustoDatabasePrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected KustoDatabasePrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> GetIfExists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>> GetIfExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoDatabasePrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoDatabasePrincipalAssignmentData() { }
        public System.Guid? AadObjectId { get { throw null; } }
        public string DatabasePrincipalId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release. Please use DatabasePrincipalId instead.", false)]
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class KustoDatabasePrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoDatabasePrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoDatabaseResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> AddPrincipals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalList databasePrincipalsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> AddPrincipalsAsync(Azure.ResourceManager.Kusto.Models.DatabasePrincipalList databasePrincipalsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoDatabasePrincipalAssignmentNameAvailability(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoDatabasePrincipalAssignmentNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoDataConnectionNameAvailability(Azure.ResourceManager.Kusto.Models.KustoDataConnectionNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoDataConnectionNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoDataConnectionNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoScriptNameAvailability(Azure.ResourceManager.Kusto.Models.KustoScriptNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoScriptNameAvailabilityAsync(Azure.ResourceManager.Kusto.Models.KustoScriptNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource> GetKustoDatabasePrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource>> GetKustoDatabasePrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentCollection GetKustoDatabasePrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDataConnectionResource> GetKustoDataConnection(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDataConnectionResource>> GetKustoDataConnectionAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoDataConnectionCollection GetKustoDataConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoScriptResource> GetKustoScript(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoScriptResource>> GetKustoScriptAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoScriptCollection GetKustoScripts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> GetPrincipals(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> GetPrincipalsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.DatabaseInviteFollowerResult> InviteFollowerDatabase(Azure.ResourceManager.Kusto.Models.DatabaseInviteFollowerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.DatabaseInviteFollowerResult>> InviteFollowerDatabaseAsync(Azure.ResourceManager.Kusto.Models.DatabaseInviteFollowerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> RemovePrincipals(Azure.ResourceManager.Kusto.Models.DatabasePrincipalList databasePrincipalsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> RemovePrincipalsAsync(Azure.ResourceManager.Kusto.Models.DatabasePrincipalList databasePrincipalsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDatabaseData data, Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole? callerRole = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDatabaseData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDatabaseData data, Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole? callerRole = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDatabaseData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DataConnectionValidationResults> ValidateDataConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.DataConnectionValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.Models.DataConnectionValidationResults>> ValidateDataConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.Models.DataConnectionValidationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoDataConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoDataConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoDataConnectionResource>, System.Collections.IEnumerable
    {
        protected KustoDataConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDataConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Kusto.KustoDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDataConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Kusto.KustoDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDataConnectionResource> Get(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoDataConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoDataConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDataConnectionResource>> GetAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoDataConnectionResource> GetIfExists(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoDataConnectionResource>> GetIfExistsAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoDataConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoDataConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoDataConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoDataConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoDataConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoDataConnectionData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class KustoDataConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoDataConnectionResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoDataConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName, string dataConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoDataConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoDataConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDataConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoDataConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KustoExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoClusterNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.KustoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoClusterNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.KustoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource GetKustoAttachedDatabaseConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> GetKustoCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> GetKustoClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource GetKustoClusterPrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoClusterResource GetKustoClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoClusterCollection GetKustoClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Kusto.KustoClusterResource> GetKustoClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoClusterResource> GetKustoClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource GetKustoDatabasePrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoDatabaseResource GetKustoDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoDataConnectionResource GetKustoDataConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetKustoEligibleSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetKustoEligibleSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource GetKustoManagedPrivateEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource GetKustoPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoPrivateLinkResource GetKustoPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoScriptResource GetKustoScriptResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Kusto.SandboxCustomImageResource GetSandboxCustomImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoManagedPrivateEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>, System.Collections.IEnumerable
    {
        protected KustoManagedPrivateEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> Get(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>> GetAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> GetIfExists(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>> GetIfExistsAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoManagedPrivateEndpointData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoManagedPrivateEndpointData() { }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public string PrivateLinkResourceRegion { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
    }
    public partial class KustoManagedPrivateEndpointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoManagedPrivateEndpointResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string managedPrivateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class KustoScriptCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoScriptResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoScriptResource>, System.Collections.IEnumerable
    {
        protected KustoScriptCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoScriptResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Kusto.KustoScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoScriptResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scriptName, Azure.ResourceManager.Kusto.KustoScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoScriptResource> Get(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoScriptResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoScriptResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoScriptResource>> GetAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoScriptResource> GetIfExists(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.KustoScriptResource>> GetIfExistsAsync(string scriptName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.KustoScriptResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.KustoScriptResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.KustoScriptResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoScriptResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoScriptData : Azure.ResourceManager.Models.ResourceData
    {
        public KustoScriptData() { }
        public string ForceUpdateTag { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public string ScriptContent { get { throw null; } set { } }
        public System.Uri ScriptUri { get { throw null; } set { } }
        public string ScriptUriSasToken { get { throw null; } set { } }
        public bool? ShouldContinueOnErrors { get { throw null; } set { } }
    }
    public partial class KustoScriptResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoScriptResource() { }
        public virtual Azure.ResourceManager.Kusto.KustoScriptData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string databaseName, string scriptName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoScriptResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoScriptResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoScriptResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.KustoScriptResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.KustoScriptData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxCustomImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.SandboxCustomImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.SandboxCustomImageResource>, System.Collections.IEnumerable
    {
        protected SandboxCustomImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.SandboxCustomImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sandboxCustomImageName, Azure.ResourceManager.Kusto.SandboxCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.SandboxCustomImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sandboxCustomImageName, Azure.ResourceManager.Kusto.SandboxCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.SandboxCustomImageResource> Get(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.SandboxCustomImageResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.SandboxCustomImageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.SandboxCustomImageResource>> GetAsync(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Kusto.SandboxCustomImageResource> GetIfExists(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Kusto.SandboxCustomImageResource>> GetIfExistsAsync(string sandboxCustomImageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Kusto.SandboxCustomImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Kusto.SandboxCustomImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Kusto.SandboxCustomImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.SandboxCustomImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SandboxCustomImageData : Azure.ResourceManager.Models.ResourceData
    {
        public SandboxCustomImageData() { }
        public Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage? Language { get { throw null; } set { } }
        public string LanguageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public string RequirementsFileContent { get { throw null; } set { } }
    }
    public partial class SandboxCustomImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SandboxCustomImageResource() { }
        public virtual Azure.ResourceManager.Kusto.SandboxCustomImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string sandboxCustomImageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.SandboxCustomImageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.SandboxCustomImageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.SandboxCustomImageResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.SandboxCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Kusto.SandboxCustomImageResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Kusto.SandboxCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Kusto.Mocking
{
    public partial class MockableKustoArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKustoArmClient() { }
        public virtual Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationResource GetKustoAttachedDatabaseConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentResource GetKustoClusterPrincipalAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoClusterResource GetKustoClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentResource GetKustoDatabasePrincipalAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoDatabaseResource GetKustoDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoDataConnectionResource GetKustoDataConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointResource GetKustoManagedPrivateEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionResource GetKustoPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoPrivateLinkResource GetKustoPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoScriptResource GetKustoScriptResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Kusto.SandboxCustomImageResource GetSandboxCustomImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKustoResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKustoResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource> GetKustoCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.KustoClusterResource>> GetKustoClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Kusto.KustoClusterCollection GetKustoClusters() { throw null; }
    }
    public partial class MockableKustoSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKustoSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult> CheckKustoClusterNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.KustoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult>> CheckKustoClusterNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.KustoClusterNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.KustoClusterResource> GetKustoClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.KustoClusterResource> GetKustoClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetKustoEligibleSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetKustoEligibleSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetSkus(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Kusto.Models.KustoSkuDescription> GetSkusAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Kusto.Models
{
    public partial class AcceptedAudience
    {
        public AcceptedAudience() { }
        public string Value { get { throw null; } set { } }
    }
    public static partial class ArmKustoModelFactory
    {
        public static Azure.ResourceManager.Kusto.Models.DatabaseInviteFollowerResult DatabaseInviteFollowerResult(string generatedInvitation = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DataConnectionValidationResult DataConnectionValidationResult(string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DataConnectionValidationResults DataConnectionValidationResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.DataConnectionValidationResult> value = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.DiagnoseVirtualNetworkResult DiagnoseVirtualNetworkResult(System.Collections.Generic.IEnumerable<string> findings = null) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoAttachedDatabaseConfigurationData KustoAttachedDatabaseConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), string databaseName = null, Azure.Core.ResourceIdentifier clusterResourceId = null, System.Collections.Generic.IEnumerable<string> attachedDatabaseNames = null, Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind? defaultPrincipalsModificationKind = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind?), Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties tableLevelSharingProperties = null, string databaseNameOverride = null, string databaseNamePrefix = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoAvailableSkuDetails KustoAvailableSkuDetails(string resourceType = null, Azure.ResourceManager.Kusto.Models.KustoSku sku = null, Azure.ResourceManager.Kusto.Models.KustoCapacity capacity = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoCapacity KustoCapacity(Azure.ResourceManager.Kusto.Models.KustoScaleType scaleType = default(Azure.ResourceManager.Kusto.Models.KustoScaleType), int minimum = 0, int maximum = 0, int @default = 0) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoClusterData KustoClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Kusto.Models.KustoSku sku = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Kusto.Models.KustoClusterState? state = default(Azure.ResourceManager.Kusto.Models.KustoClusterState?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), System.Uri clusterUri = null, System.Uri dataIngestionUri = null, string stateReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoClusterTrustedExternalTenant> trustedExternalTenants = null, Azure.ResourceManager.Kusto.Models.OptimizedAutoscale optimizedAutoscale = null, bool? isDiskEncryptionEnabled = default(bool?), bool? isStreamingIngestEnabled = default(bool?), Azure.ResourceManager.Kusto.Models.KustoClusterVirtualNetworkConfiguration virtualNetworkConfiguration = null, Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties keyVaultProperties = null, bool? isPurgeEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> languageExtensionsValue = null, bool? isDoubleEncryptionEnabled = default(bool?), Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess?), System.Collections.Generic.IEnumerable<string> allowedIPRangeList = null, Azure.ResourceManager.Kusto.Models.KustoClusterEngineType? engineType = default(Azure.ResourceManager.Kusto.Models.KustoClusterEngineType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.AcceptedAudience> acceptedAudiences = null, bool? isAutoStopEnabled = default(bool?), Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag? restrictOutboundNetworkAccess = default(Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag?), System.Collections.Generic.IEnumerable<string> allowedFqdnList = null, Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType? publicIPType = default(Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType?), string virtualClusterGraduationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Kusto.Models.MigrationClusterProperties migrationCluster = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPatch KustoClusterPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Kusto.Models.KustoSku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.Kusto.Models.KustoClusterState? state, Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState, System.Uri uri, System.Uri dataIngestionUri, string stateReason, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoClusterTrustedExternalTenant> trustedExternalTenants, Azure.ResourceManager.Kusto.Models.OptimizedAutoscale optimizedAutoscale, bool? isDiskEncryptionEnabled, bool? isStreamingIngestEnabled, Azure.ResourceManager.Kusto.Models.KustoClusterVirtualNetworkConfiguration virtualNetworkConfiguration, Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties keyVaultProperties, bool? isPurgeEnabled, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> languageExtensionsValue, bool? isDoubleEncryptionEnabled, Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess? publicNetworkAccess, System.Collections.Generic.IEnumerable<string> allowedIPRangeList, Azure.ResourceManager.Kusto.Models.KustoClusterEngineType? engineType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.AcceptedAudience> acceptedAudiences, bool? isAutoStopEnabled, Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag? restrictOutboundNetworkAccess, System.Collections.Generic.IEnumerable<string> allowedFqdnList, Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType? publicIPType, string virtualClusterGraduationProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Kusto.Models.MigrationClusterProperties migrationCluster) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPatch KustoClusterPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Kusto.Models.KustoSku sku = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Kusto.Models.KustoClusterState? state = default(Azure.ResourceManager.Kusto.Models.KustoClusterState?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), System.Uri uri = null, System.Uri dataIngestionUri = null, string stateReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoClusterTrustedExternalTenant> trustedExternalTenants = null, Azure.ResourceManager.Kusto.Models.OptimizedAutoscale optimizedAutoscale = null, bool? isDiskEncryptionEnabled = default(bool?), bool? isStreamingIngestEnabled = default(bool?), Azure.ResourceManager.Kusto.Models.KustoClusterVirtualNetworkConfiguration virtualNetworkConfiguration = null, Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties keyVaultProperties = null, bool? isPurgeEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> languageExtensionsValue = null, bool? isDoubleEncryptionEnabled = default(bool?), Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess?), System.Collections.Generic.IEnumerable<string> allowedIPRangeList = null, Azure.ResourceManager.Kusto.Models.KustoClusterEngineType? engineType = default(Azure.ResourceManager.Kusto.Models.KustoClusterEngineType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.AcceptedAudience> acceptedAudiences = null, bool? isAutoStopEnabled = default(bool?), Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag? restrictOutboundNetworkAccess = default(Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag?), System.Collections.Generic.IEnumerable<string> allowedFqdnList = null, Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType? publicIPType = default(Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType?), string virtualClusterGraduationProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Kusto.Models.MigrationClusterProperties migrationCluster = null) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoClusterPrincipalAssignmentData KustoClusterPrincipalAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string clusterPrincipalId = null, Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole? role = default(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType? principalType = default(Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType?), string tenantName = null, string principalName = null, Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), System.Guid? aadObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoCosmosDBDataConnection KustoCosmosDBDataConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string tableName = null, string mappingRuleName = null, Azure.Core.ResourceIdentifier managedIdentityResourceId = null, System.Guid? managedIdentityObjectId = default(System.Guid?), Azure.Core.ResourceIdentifier cosmosDBAccountResourceId = null, string cosmosDBDatabase = null, string cosmosDBContainer = null, System.DateTimeOffset? retrievalStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoDatabaseData KustoDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string kind = "Unknown") { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal KustoDatabasePrincipal(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole role = default(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole), string name = null, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType principalType = default(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType), string fqn = null, string email = null, string appId = null, string tenantName = null) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoDatabasePrincipalAssignmentData KustoDatabasePrincipalAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string databasePrincipalId = null, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole? role = default(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType? principalType = default(Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType?), string tenantName = null, string principalName = null, Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), System.Guid? aadObjectId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoDataConnectionData KustoDataConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string kind = "Unknown") { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataConnection KustoEventGridDataConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier storageAccountResourceId = null, Azure.Core.ResourceIdentifier eventGridResourceId = null, Azure.Core.ResourceIdentifier eventHubResourceId = null, string consumerGroup = null, string tableName = null, string mappingRuleName = null, Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat? dataFormat = default(Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat?), bool? isFirstRecordIgnored = default(bool?), Azure.ResourceManager.Kusto.Models.BlobStorageEventType? blobStorageEventType = default(Azure.ResourceManager.Kusto.Models.BlobStorageEventType?), Azure.Core.ResourceIdentifier managedIdentityResourceId = null, System.Guid? managedIdentityObjectId = default(System.Guid?), Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting? databaseRouting = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataConnection KustoEventHubDataConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier eventHubResourceId = null, string consumerGroup = null, string tableName = null, string mappingRuleName = null, Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat? dataFormat = default(Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat?), System.Collections.Generic.IEnumerable<string> eventSystemProperties = null, Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType? compression = default(Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), Azure.Core.ResourceIdentifier managedIdentityResourceId = null, System.Guid? managedIdentityObjectId = default(System.Guid?), Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting? databaseRouting = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting?), System.DateTimeOffset? retrievalStartOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoFollowerDatabaseDefinition KustoFollowerDatabaseDefinition(Azure.Core.ResourceIdentifier clusterResourceId = null, string attachedDatabaseConfigurationName = null, string databaseName = null, Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties tableLevelSharingProperties = null, Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin? databaseShareOrigin = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataConnection KustoIotHubDataConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.Core.ResourceIdentifier iotHubResourceId = null, string consumerGroup = null, string tableName = null, string mappingRuleName = null, Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat? dataFormat = default(Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat?), System.Collections.Generic.IEnumerable<string> eventSystemProperties = null, string sharedAccessPolicyName = null, Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting? databaseRouting = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting?), System.DateTimeOffset? retrievalStartOn = default(System.DateTimeOffset?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoManagedPrivateEndpointData KustoManagedPrivateEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateLinkResourceId = null, string privateLinkResourceRegion = null, string groupId = null, string requestMessage = null, Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoNameAvailabilityResult KustoNameAvailabilityResult(bool? nameAvailable = default(bool?), string name = null, string message = null, Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason? reason = default(Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason?)) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData KustoPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Kusto.Models.KustoPrivateLinkServiceConnectionStateProperty connectionState = null, string groupId = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoPrivateLinkResourceData KustoPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoPrivateLinkServiceConnectionStateProperty KustoPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoReadOnlyFollowingDatabase KustoReadOnlyFollowingDatabase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), System.TimeSpan? softDeletePeriod = default(System.TimeSpan?), System.TimeSpan? hotCachePeriod = default(System.TimeSpan?), float? statisticsSize = default(float?), string leaderClusterResourceId = null, string attachedDatabaseConfigurationName = null, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind? principalsModificationKind = default(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind?), Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties tableLevelSharingProperties = null, string originalDatabaseName = null, Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin? databaseShareOrigin = default(Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin?), System.DateTimeOffset? suspensionStartOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoReadWriteDatabase KustoReadWriteDatabase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?), System.TimeSpan? softDeletePeriod = default(System.TimeSpan?), System.TimeSpan? hotCachePeriod = default(System.TimeSpan?), float? statisticsSize = default(float?), bool? isFollowed = default(bool?), Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties keyVaultProperties = null, System.DateTimeOffset? suspensionStartOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoResourceSkuCapabilities KustoResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoResourceSkuZoneDetails KustoResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoResourceSkuCapabilities> capabilities = null) { throw null; }
        public static Azure.ResourceManager.Kusto.KustoScriptData KustoScriptData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Uri scriptUri = null, string scriptUriSasToken = null, string scriptContent = null, string forceUpdateTag = null, bool? shouldContinueOnErrors = default(bool?), Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuDescription KustoSkuDescription(string resourceType = null, string name = null, string tier = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoSkuLocationInfoItem> locationInfo = null, System.Collections.Generic.IEnumerable<System.BinaryData> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuLocationInfoItem KustoSkuLocationInfoItem(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.KustoResourceSkuZoneDetails> zoneDetails = null) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.MigrationClusterProperties MigrationClusterProperties(string id = null, System.Uri uri = null, System.Uri dataIngestionUri = null, Azure.ResourceManager.Kusto.Models.MigrationClusterRole? role = default(Azure.ResourceManager.Kusto.Models.MigrationClusterRole?)) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.OutboundNetworkDependenciesEndpoint OutboundNetworkDependenciesEndpoint(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? etag = default(Azure.ETag?), string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Kusto.Models.EndpointDependency> endpoints = null, Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Kusto.SandboxCustomImageData SandboxCustomImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage? language = default(Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage?), string languageVersion = null, string requirementsFileContent = null, Azure.ResourceManager.Kusto.Models.KustoProvisioningState? provisioningState = default(Azure.ResourceManager.Kusto.Models.KustoProvisioningState?)) { throw null; }
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
    public partial class ClusterMigrateContent
    {
        public ClusterMigrateContent(string clusterResourceId) { }
        public string ClusterResourceId { get { throw null; } }
    }
    public partial class DatabaseInviteFollowerContent
    {
        public DatabaseInviteFollowerContent(string inviteeEmail) { }
        public string InviteeEmail { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
    }
    public partial class DatabaseInviteFollowerResult
    {
        internal DatabaseInviteFollowerResult() { }
        public string GeneratedInvitation { get { throw null; } }
    }
    public partial class DatabasePrincipalList
    {
        public DatabasePrincipalList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipal> Value { get { throw null; } }
    }
    public partial class DataConnectionValidationContent
    {
        public DataConnectionValidationContent() { }
        public string DataConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.KustoDataConnectionData Properties { get { throw null; } set { } }
    }
    public partial class DataConnectionValidationResult
    {
        internal DataConnectionValidationResult() { }
        public string ErrorMessage { get { throw null; } }
    }
    public partial class DataConnectionValidationResults
    {
        internal DataConnectionValidationResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.Models.DataConnectionValidationResult> Value { get { throw null; } }
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
        public string IPAddress { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubMessagesCompressionType : System.IEquatable<Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubMessagesCompressionType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType GZip { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType left, Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType left, Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoAttachedDatabaseConfigurationNameAvailabilityContent
    {
        public KustoAttachedDatabaseConfigurationNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.AttachedDatabaseType ResourceType { get { throw null; } }
    }
    public partial class KustoAvailableSkuDetails
    {
        internal KustoAvailableSkuDetails() { }
        public Azure.ResourceManager.Kusto.Models.KustoCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoSku Sku { get { throw null; } }
    }
    public partial class KustoCapacity
    {
        internal KustoCapacity() { }
        public int Default { get { throw null; } }
        public int Maximum { get { throw null; } }
        public int Minimum { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoScaleType ScaleType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterEngineType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterEngineType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterEngineType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterEngineType V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterEngineType V3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterEngineType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterEngineType left, Azure.ResourceManager.Kusto.Models.KustoClusterEngineType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterEngineType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterEngineType left, Azure.ResourceManager.Kusto.Models.KustoClusterEngineType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoClusterNameAvailabilityContent
    {
        public KustoClusterNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterNetworkAccessFlag : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterNetworkAccessFlag(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag left, Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag left, Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoClusterPatch : Azure.ResourceManager.Models.TrackedResourceData
    {
        public KustoClusterPatch(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.AcceptedAudience> AcceptedAudiences { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedFqdnList { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedIPRangeList { get { throw null; } }
        public System.Uri DataIngestionUri { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterEngineType? EngineType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAutoStopEnabled { get { throw null; } set { } }
        public bool? IsDiskEncryptionEnabled { get { throw null; } set { } }
        public bool? IsDoubleEncryptionEnabled { get { throw null; } set { } }
        public bool? IsPurgeEnabled { get { throw null; } set { } }
        public bool? IsStreamingIngestEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.MigrationClusterProperties MigrationCluster { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.KustoPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType? PublicIPType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterNetworkAccessFlag? RestrictOutboundNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterState? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.KustoClusterTrustedExternalTenant> TrustedExternalTenants { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string VirtualClusterGraduationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterVirtualNetworkConfiguration VirtualNetworkConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    public partial class KustoClusterPrincipalAssignmentNameAvailabilityContent
    {
        public KustoClusterPrincipalAssignmentNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterPrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterPrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType MicrosoftKustoClustersPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterPrincipalRole : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterPrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole AllDatabasesAdmin { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole AllDatabasesViewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole left, Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole left, Azure.ResourceManager.Kusto.Models.KustoClusterPrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterPublicIPType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterPublicIPType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType DualStack { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType IPv4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType left, Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType left, Azure.ResourceManager.Kusto.Models.KustoClusterPublicIPType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess left, Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess left, Azure.ResourceManager.Kusto.Models.KustoClusterPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterState : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterState(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Creating { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Migrated { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Running { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Starting { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Unavailable { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterState left, Azure.ResourceManager.Kusto.Models.KustoClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterState left, Azure.ResourceManager.Kusto.Models.KustoClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoClusterTrustedExternalTenant
    {
        public KustoClusterTrustedExternalTenant() { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterType MicrosoftKustoClusters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterType left, Azure.ResourceManager.Kusto.Models.KustoClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterType left, Azure.ResourceManager.Kusto.Models.KustoClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoClusterVirtualNetworkConfiguration
    {
        public KustoClusterVirtualNetworkConfiguration(string subnetId, string enginePublicIPId, string dataManagementPublicIPId) { }
        public string DataManagementPublicIPId { get { throw null; } set { } }
        public string EnginePublicIPId { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoClusterVnetState? State { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoClusterVnetState : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoClusterVnetState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoClusterVnetState(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterVnetState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoClusterVnetState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoClusterVnetState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoClusterVnetState left, Azure.ResourceManager.Kusto.Models.KustoClusterVnetState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoClusterVnetState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoClusterVnetState left, Azure.ResourceManager.Kusto.Models.KustoClusterVnetState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoCosmosDBDataConnection : Azure.ResourceManager.Kusto.KustoDataConnectionData
    {
        public KustoCosmosDBDataConnection() { }
        public Azure.Core.ResourceIdentifier CosmosDBAccountResourceId { get { throw null; } set { } }
        public string CosmosDBContainer { get { throw null; } set { } }
        public string CosmosDBDatabase { get { throw null; } set { } }
        public System.Guid? ManagedIdentityObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RetrievalStartOn { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabaseCallerRole : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabaseCallerRole(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole Admin { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole left, Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole left, Azure.ResourceManager.Kusto.Models.KustoDatabaseCallerRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabaseDefaultPrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabaseDefaultPrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.KustoDatabaseDefaultPrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoDatabaseNameAvailabilityContent
    {
        public KustoDatabaseNameAvailabilityContent(string name, Azure.ResourceManager.Kusto.Models.KustoDatabaseResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseResourceType ResourceType { get { throw null; } }
    }
    public partial class KustoDatabasePrincipal
    {
        public KustoDatabasePrincipal(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole role, string name, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType principalType) { }
        public string AppId { get { throw null; } set { } }
        public string Email { get { throw null; } set { } }
        public string Fqn { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole Role { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class KustoDatabasePrincipalAssignmentNameAvailabilityContent
    {
        public KustoDatabasePrincipalAssignmentNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabasePrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabasePrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType MicrosoftKustoClustersDatabasesPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabasePrincipalRole : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabasePrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole Admin { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole Ingestor { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole Monitor { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole UnrestrictedViewer { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole User { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole Viewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabasePrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabasePrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabasePrincipalType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabasePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType App { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType left, Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KustoDatabaseResourceType
    {
        MicrosoftKustoClustersDatabases = 0,
        MicrosoftKustoClustersAttachedDatabaseConfigurations = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabaseRouting : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabaseRouting(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting Multi { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting left, Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting left, Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDatabaseShareOrigin : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDatabaseShareOrigin(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin DataShare { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin Direct { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin Other { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin left, Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin left, Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoDatabaseTableLevelSharingProperties
    {
        public KustoDatabaseTableLevelSharingProperties() { }
        public System.Collections.Generic.IList<string> ExternalTablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> ExternalTablesToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> FunctionsToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> FunctionsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToInclude { get { throw null; } }
    }
    public partial class KustoDataConnectionNameAvailabilityContent
    {
        public KustoDataConnectionNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDataConnectionType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoDataConnectionType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoDataConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoDataConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoDataConnectionType MicrosoftKustoClustersDatabasesDataConnections { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoDataConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoDataConnectionType left, Azure.ResourceManager.Kusto.Models.KustoDataConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoDataConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoDataConnectionType left, Azure.ResourceManager.Kusto.Models.KustoDataConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoEventGridDataConnection : Azure.ResourceManager.Kusto.KustoDataConnectionData
    {
        public KustoEventGridDataConnection() { }
        public Azure.ResourceManager.Kusto.Models.BlobStorageEventType? BlobStorageEventType { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting? DatabaseRouting { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat? DataFormat { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventGridResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public bool? IsFirstRecordIgnored { get { throw null; } set { } }
        public System.Guid? ManagedIdentityObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoEventGridDataFormat : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoEventGridDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat ApacheAvro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat MultiJson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Orc { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Psv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Raw { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat SingleJson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Tsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat Txt { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat W3CLogFile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat left, Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat left, Azure.ResourceManager.Kusto.Models.KustoEventGridDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoEventHubDataConnection : Azure.ResourceManager.Kusto.KustoDataConnectionData
    {
        public KustoEventHubDataConnection() { }
        public Azure.ResourceManager.Kusto.Models.EventHubMessagesCompressionType? Compression { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting? DatabaseRouting { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat? DataFormat { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public System.Guid? ManagedIdentityObjectId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RetrievalStartOn { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoEventHubDataFormat : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoEventHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat ApacheAvro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat MultiJson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Orc { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Psv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Raw { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat SingleJson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Tsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat Txt { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat W3CLogFile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat left, Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat left, Azure.ResourceManager.Kusto.Models.KustoEventHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoFollowerDatabaseDefinition
    {
        public KustoFollowerDatabaseDefinition(Azure.Core.ResourceIdentifier clusterResourceId, string attachedDatabaseConfigurationName) { }
        public string AttachedDatabaseConfigurationName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin? DatabaseShareOrigin { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } }
    }
    public partial class KustoIotHubDataConnection : Azure.ResourceManager.Kusto.KustoDataConnectionData
    {
        public KustoIotHubDataConnection() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseRouting? DatabaseRouting { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat? DataFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier IotHubResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? RetrievalStartOn { get { throw null; } set { } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoIotHubDataFormat : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoIotHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat ApacheAvro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat MultiJson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Orc { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Psv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Raw { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat SingleJson { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Tsv { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat Txt { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat W3CLogFile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat left, Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat left, Azure.ResourceManager.Kusto.Models.KustoIotHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoKeyVaultProperties
    {
        public KustoKeyVaultProperties() { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserIdentity { get { throw null; } set { } }
    }
    public partial class KustoLanguageExtension
    {
        public KustoLanguageExtension() { }
        public string LanguageExtensionCustomImageName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName? LanguageExtensionImageName { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName? LanguageExtensionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoLanguageExtensionImageName : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoLanguageExtensionImageName(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName Python3108DL { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName Python3_10_8 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName Python3_6_5 { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName Python3_9_12 { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName Python3_9_12IncludeDeepLearning { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName PythonCustomImage { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName R { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName left, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName left, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionImageName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoLanguageExtensionList
    {
        public KustoLanguageExtensionList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Kusto.Models.KustoLanguageExtension> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoLanguageExtensionName : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoLanguageExtensionName(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName Python { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName R { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName left, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName left, Azure.ResourceManager.Kusto.Models.KustoLanguageExtensionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoManagedPrivateEndpointNameAvailabilityContent
    {
        public KustoManagedPrivateEndpointNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoManagedPrivateEndpointsType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoManagedPrivateEndpointsType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType MicrosoftKustoClustersManagedPrivateEndpoints { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType left, Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType left, Azure.ResourceManager.Kusto.Models.KustoManagedPrivateEndpointsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoNameAvailabilityResult
    {
        internal KustoNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason left, Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason left, Azure.ResourceManager.Kusto.Models.KustoNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoPrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoPrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType App { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType Group { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType left, Azure.ResourceManager.Kusto.Models.KustoPrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoPrivateLinkServiceConnectionStateProperty
    {
        public KustoPrivateLinkServiceConnectionStateProperty() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoProvisioningState : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoProvisioningState left, Azure.ResourceManager.Kusto.Models.KustoProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoProvisioningState left, Azure.ResourceManager.Kusto.Models.KustoProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoReadOnlyFollowingDatabase : Azure.ResourceManager.Kusto.KustoDatabaseData
    {
        public KustoReadOnlyFollowingDatabase() { }
        public string AttachedDatabaseConfigurationName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseShareOrigin? DatabaseShareOrigin { get { throw null; } }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public string LeaderClusterResourceId { get { throw null; } }
        public string OriginalDatabaseName { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabasePrincipalsModificationKind? PrincipalsModificationKind { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } }
        public float? StatisticsSize { get { throw null; } }
        public System.DateTimeOffset? SuspensionStartOn { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoDatabaseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } }
    }
    public partial class KustoReadWriteDatabase : Azure.ResourceManager.Kusto.KustoDatabaseData
    {
        public KustoReadWriteDatabase() { }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public bool? IsFollowed { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } set { } }
        public float? StatisticsSize { get { throw null; } }
        public System.DateTimeOffset? SuspensionStartOn { get { throw null; } }
    }
    public partial class KustoResourceSkuCapabilities
    {
        internal KustoResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class KustoResourceSkuZoneDetails
    {
        internal KustoResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.Models.KustoResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoScaleType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoScaleType left, Azure.ResourceManager.Kusto.Models.KustoScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoScaleType left, Azure.ResourceManager.Kusto.Models.KustoScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoScriptNameAvailabilityContent
    {
        public KustoScriptNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.KustoScriptType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoScriptType : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoScriptType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoScriptType MicrosoftKustoClustersDatabasesScripts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoScriptType left, Azure.ResourceManager.Kusto.Models.KustoScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoScriptType left, Azure.ResourceManager.Kusto.Models.KustoScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoSku
    {
        public KustoSku(Azure.ResourceManager.Kusto.Models.KustoSkuName name, Azure.ResourceManager.Kusto.Models.KustoSkuTier tier) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Kusto.Models.KustoSkuTier Tier { get { throw null; } set { } }
    }
    public partial class KustoSkuDescription
    {
        internal KustoSkuDescription() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.Models.KustoSkuLocationInfoItem> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Restrictions { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class KustoSkuLocationInfoItem
    {
        internal KustoSkuLocationInfoItem() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Kusto.Models.KustoResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoSkuName : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName DevNoSlaStandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName DevNoSlaStandardE2aV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD16dV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD32dV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardD32dV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardDS13V21TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardDS13V22TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardDS14V23TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardDS14V24TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16adsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16asV43TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16asV44TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16asV53TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16asV54TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16aV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16dV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16dV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16sV43TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16sV44TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16sV53TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE16sV54TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE2adsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE2aV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE2dV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE2dV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE4adsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE4aV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE4dV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE4dV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE64iV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE80idsV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8adsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8asV41TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8asV42TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8asV51TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8asV52TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8aV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8dV4 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8dV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8sV41TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8sV42TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8sV51TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardE8sV52TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardEC16adsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardEC16asV53TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardEC16asV54TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardEC8adsV5 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardEC8asV51TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardEC8asV52TBPS { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL16asV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL16s { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL16sV2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL16sV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL32asV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL32sV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL4s { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL8asV3 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL8s { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL8sV2 { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuName StandardL8sV3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoSkuName left, Azure.ResourceManager.Kusto.Models.KustoSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoSkuName left, Azure.ResourceManager.Kusto.Models.KustoSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoSkuTier : System.IEquatable<Azure.ResourceManager.Kusto.Models.KustoSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.KustoSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.KustoSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.KustoSkuTier left, Azure.ResourceManager.Kusto.Models.KustoSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.KustoSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.KustoSkuTier left, Azure.ResourceManager.Kusto.Models.KustoSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationClusterProperties
    {
        internal MigrationClusterProperties() { }
        public System.Uri DataIngestionUri { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Kusto.Models.MigrationClusterRole? Role { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationClusterRole : System.IEquatable<Azure.ResourceManager.Kusto.Models.MigrationClusterRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationClusterRole(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.MigrationClusterRole Destination { get { throw null; } }
        public static Azure.ResourceManager.Kusto.Models.MigrationClusterRole Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.MigrationClusterRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.MigrationClusterRole left, Azure.ResourceManager.Kusto.Models.MigrationClusterRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.MigrationClusterRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.MigrationClusterRole left, Azure.ResourceManager.Kusto.Models.MigrationClusterRole right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.ResourceManager.Kusto.Models.KustoProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxCustomImageLanguage : System.IEquatable<Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxCustomImageLanguage(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage Python { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage left, Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage left, Azure.ResourceManager.Kusto.Models.SandboxCustomImageLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxCustomImagesCheckNameContent
    {
        public SandboxCustomImagesCheckNameContent(string name) { }
        public Azure.ResourceManager.Kusto.Models.SandboxCustomImageType ImageType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxCustomImageType : System.IEquatable<Azure.ResourceManager.Kusto.Models.SandboxCustomImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxCustomImageType(string value) { throw null; }
        public static Azure.ResourceManager.Kusto.Models.SandboxCustomImageType MicrosoftKustoClustersSandboxCustomImages { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Kusto.Models.SandboxCustomImageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Kusto.Models.SandboxCustomImageType left, Azure.ResourceManager.Kusto.Models.SandboxCustomImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Kusto.Models.SandboxCustomImageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Kusto.Models.SandboxCustomImageType left, Azure.ResourceManager.Kusto.Models.SandboxCustomImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
