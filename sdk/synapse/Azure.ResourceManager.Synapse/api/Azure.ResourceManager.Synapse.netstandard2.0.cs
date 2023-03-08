namespace Azure.ResourceManager.Synapse
{
    public partial class SynapseAadOnlyAuthenticationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>, System.Collections.IEnumerable
    {
        protected SynapseAadOnlyAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> Get(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseAadOnlyAuthenticationData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseAadOnlyAuthenticationData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsAadOnlyAuthenticationEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.AadAuthenticationState? State { get { throw null; } }
    }
    public partial class SynapseAadOnlyAuthenticationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseAadOnlyAuthenticationResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseAttachedDatabaseConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>, System.Collections.IEnumerable
    {
        protected SynapseAttachedDatabaseConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> Get(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>> GetAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseAttachedDatabaseConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseAttachedDatabaseConfigurationData() { }
        public System.Collections.Generic.IReadOnlyList<string> AttachedDatabaseNames { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KustoPoolResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseTableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
    }
    public partial class SynapseAttachedDatabaseConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseAttachedDatabaseConfigurationResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string attachedDatabaseConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseBigDataPoolInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>, System.Collections.IEnumerable
    {
        protected SynapseBigDataPoolInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bigDataPoolName, Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoData info, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bigDataPoolName, Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoData info, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> Get(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> GetAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseBigDataPoolInfoData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SynapseBigDataPoolInfoData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Synapse.Models.BigDataPoolAutoPauseProperties AutoPause { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BigDataPoolAutoScaleProperties AutoScale { get { throw null; } set { } }
        public int? CacheSize { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.BigDataPoolLibraryInfo> CustomLibraries { get { throw null; } }
        public string DefaultSparkLogFolder { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseDynamicExecutorAllocation DynamicExecutorAllocation { get { throw null; } set { } }
        public bool? IsAutotuneEnabled { get { throw null; } set { } }
        public bool? IsComputeIsolationEnabled { get { throw null; } set { } }
        public bool? IsSessionLevelPackagesEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastSucceededOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.BigDataPoolLibraryRequirements LibraryRequirements { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize? NodeSize { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily? NodeSizeFamily { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BigDataPoolSparkConfigProperties SparkConfigProperties { get { throw null; } set { } }
        public string SparkEventsFolder { get { throw null; } set { } }
        public string SparkVersion { get { throw null; } set { } }
    }
    public partial class SynapseBigDataPoolInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseBigDataPoolInfoResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string bigDataPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> Update(Azure.ResourceManager.Synapse.Models.SynapseBigDataPoolInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.SynapseBigDataPoolInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseClusterPrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected SynapseClusterPrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseClusterPrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseClusterPrincipalAssignmentData() { }
        public System.Guid? AadObjectId { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapsePrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class SynapseClusterPrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseClusterPrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDatabaseResource>, System.Collections.IEnumerable
    {
        protected SynapseDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Synapse.SynapseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Synapse.SynapseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseDatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDatabaseData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class SynapseDatabasePrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected SynapseDatabasePrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseDatabasePrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDatabasePrincipalAssignmentData() { }
        public System.Guid? AadObjectId { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapsePrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class SynapseDatabasePrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDatabasePrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string databaseName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDatabaseResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult> CheckKustoPoolDatabasePrincipalAssignmentNameAvailability(Azure.ResourceManager.Synapse.Models.KustoPoolDatabasePrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult>> CheckKustoPoolDatabasePrincipalAssignmentNameAvailabilityAsync(Azure.ResourceManager.Synapse.Models.KustoPoolDatabasePrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult> CheckKustoPoolDataConnectionNameAvailability(Azure.ResourceManager.Synapse.Models.KustoPoolDataConnectionNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult>> CheckKustoPoolDataConnectionNameAvailabilityAsync(Azure.ResourceManager.Synapse.Models.KustoPoolDataConnectionNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource> GetSynapseDatabasePrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource>> GetSynapseDatabasePrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentCollection GetSynapseDatabasePrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> GetSynapseDataConnection(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>> GetSynapseDataConnectionAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDataConnectionCollection GetSynapseDataConnections() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SynapseDataConnectionValidationListResult> ValidateDataConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseDataConnectionValidation synapseDataConnectionValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SynapseDataConnectionValidationListResult>> ValidateDataConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseDataConnectionValidation synapseDataConnectionValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDataConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>, System.Collections.IEnumerable
    {
        protected SynapseDataConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Synapse.SynapseDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Synapse.SynapseDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> Get(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>> GetAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseDataConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDataConnectionData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class SynapseDataConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDataConnectionResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDataConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string databaseName, string dataConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDataMaskingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDataMaskingPolicyData() { }
        public string ApplicationPrincipals { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataMaskingState? DataMaskingState { get { throw null; } set { } }
        public string ExemptPrincipals { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public string MaskingLevel { get { throw null; } }
    }
    public partial class SynapseDataMaskingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDataMaskingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> GetSynapseDataMaskingRule(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>> GetSynapseDataMaskingRuleAsync(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDataMaskingRuleCollection GetSynapseDataMaskingRules() { throw null; }
    }
    public partial class SynapseDataMaskingRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>, System.Collections.IEnumerable
    {
        protected SynapseDataMaskingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataMaskingRuleName, Azure.ResourceManager.Synapse.SynapseDataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataMaskingRuleName, Azure.ResourceManager.Synapse.SynapseDataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> Get(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>> GetAsync(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseDataMaskingRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDataMaskingRuleData() { }
        public string AliasName { get { throw null; } set { } }
        public string ColumnName { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataMaskingFunction? MaskingFunction { get { throw null; } set { } }
        public string NumberFrom { get { throw null; } set { } }
        public string NumberTo { get { throw null; } set { } }
        public string PrefixSize { get { throw null; } set { } }
        public string ReplacementString { get { throw null; } set { } }
        public string RuleId { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataMaskingRuleState? RuleState { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SuffixSize { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class SynapseDataMaskingRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDataMaskingRuleResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDataMaskingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string dataMaskingRuleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDataWarehouseUserActivityCollection : Azure.ResourceManager.ArmCollection
    {
        protected SynapseDataWarehouseUserActivityCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource> Get(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDataWarehouseUserActivityData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDataWarehouseUserActivityData() { }
        public int? ActiveQueriesCount { get { throw null; } }
    }
    public partial class SynapseDataWarehouseUserActivityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDataWarehouseUserActivityResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseDedicatedSqlMinimalTlsSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>, System.Collections.IEnumerable
    {
        protected SynapseDedicatedSqlMinimalTlsSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName dedicatedSQLminimalTlsSettingsName, Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName dedicatedSQLminimalTlsSettingsName, Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> Get(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>> GetAsync(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseDedicatedSqlMinimalTlsSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseDedicatedSqlMinimalTlsSettingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string MinimalTlsVersion { get { throw null; } set { } }
    }
    public partial class SynapseDedicatedSqlMinimalTlsSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseDedicatedSqlMinimalTlsSettingResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dedicatedSQLminimalTlsSettingsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseEncryptionProtectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>, System.Collections.IEnumerable
    {
        protected SynapseEncryptionProtectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Synapse.SynapseEncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Synapse.SynapseEncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> Get(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseEncryptionProtectorData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseEncryptionProtectorData() { }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ServerKeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public System.BinaryData Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class SynapseEncryptionProtectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseEncryptionProtectorResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseEncryptionProtectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseEncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseEncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseExtendedServerBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected SynapseExtendedServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseExtendedServerBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseExtendedServerBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsDevopsAuditEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SynapseExtendedServerBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseExtendedServerBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseExtendedSqlPoolBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseExtendedSqlPoolBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SynapseExtendedSqlPoolBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseExtendedSqlPoolBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SynapseExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult> CheckKustoPoolNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult>> CheckKustoPoolNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.Models.KustoPoolSkuDescription> GetSkusKustoPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.KustoPoolSkuDescription> GetSkusKustoPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource GetSynapseAadOnlyAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource GetSynapseAttachedDatabaseConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource GetSynapseBigDataPoolInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource GetSynapseClusterPrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDatabasePrincipalAssignmentResource GetSynapseDatabasePrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDatabaseResource GetSynapseDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDataConnectionResource GetSynapseDataConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyResource GetSynapseDataMaskingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDataMaskingRuleResource GetSynapseDataMaskingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource GetSynapseDataWarehouseUserActivityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource GetSynapseDedicatedSqlMinimalTlsSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource GetSynapseEncryptionProtectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource GetSynapseExtendedServerBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyResource GetSynapseExtendedSqlPoolBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource GetSynapseGeoBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource GetSynapseIntegrationRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource GetSynapseIPFirewallRuleInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseKeyResource GetSynapseKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseKustoPoolResource GetSynapseKustoPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseLibraryResource GetSynapseLibraryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseMaintenanceWindowOptionResource GetSynapseMaintenanceWindowOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseMaintenanceWindowResource GetSynapseMaintenanceWindowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingResource GetSynapseManagedIdentitySqlControlSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationResource GetSynapseMetadataSyncConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource GetSynapsePrivateEndpointConnectionForPrivateLinkHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource GetSynapsePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetSynapsePrivateLinkHub(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> GetSynapsePrivateLinkHubAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource GetSynapsePrivateLinkHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapsePrivateLinkHubCollection GetSynapsePrivateLinkHubs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetSynapsePrivateLinkHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetSynapsePrivateLinkHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapsePrivateLinkResource GetSynapsePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource GetSynapseRecoverableSqlPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseReplicationLinkResource GetSynapseReplicationLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource GetSynapseRestorableDroppedSqlPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseRestorePointResource GetSynapseRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource GetSynapseSensitivityLabelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource GetSynapseServerBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource GetSynapseServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource GetSynapseServerVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource GetSynapseSparkConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyResource GetSynapseSqlPoolBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource GetSynapseSqlPoolColumnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource GetSynapseSqlPoolConnectionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolResource GetSynapseSqlPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource GetSynapseSqlPoolSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource GetSynapseSqlPoolSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource GetSynapseSqlPoolTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource GetSynapseSqlPoolVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource GetSynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource GetSynapseTransparentDataEncryptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource GetSynapseVulnerabilityAssessmentScanRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource GetSynapseWorkloadClassifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource GetSynapseWorkloadGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetSynapseWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkspaceAdministratorResource GetSynapseWorkspaceAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> GetSynapseWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource GetSynapseWorkspacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkspaceResource GetSynapseWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkspaceCollection GetSynapseWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetSynapseWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetSynapseWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapseWorkspaceSqlAdministratorResource GetSynapseWorkspaceSqlAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SynapseGeoBackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected SynapseGeoBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseGeoBackupPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseGeoBackupPolicyData(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyState state) { }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyState State { get { throw null; } set { } }
        public string StorageType { get { throw null; } }
    }
    public partial class SynapseGeoBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseGeoBackupPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseIntegrationRuntimeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>, System.Collections.IEnumerable
    {
        protected SynapseIntegrationRuntimeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> Get(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseIntegrationRuntimeData(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeProperties Properties { get { throw null; } set { } }
    }
    public partial class SynapseIntegrationRuntimeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseIntegrationRuntimeResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string integrationRuntimeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DisableInteractiveQuery(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DisableInteractiveQueryAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation EnableInteractiveQuery(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> EnableInteractiveQueryAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadata(Azure.ResourceManager.Synapse.Models.SynapseGetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadataAsync(Azure.ResourceManager.Synapse.Models.SynapseGetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeys> GetIntegrationRuntimeAuthKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeys>> GetIntegrationRuntimeAuthKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeConnectionInfo> GetIntegrationRuntimeConnectionInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeConnectionInfo>> GetIntegrationRuntimeConnectionInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeMonitoringResult> GetIntegrationRuntimeMonitoringData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeMonitoringResult>> GetIntegrationRuntimeMonitoringDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNode> GetIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNode>> GetIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeNodeIPAddress> GetIntegrationRuntimeNodeIPAddress(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeNodeIPAddress>> GetIntegrationRuntimeNodeIPAddressAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatusResult> GetIntegrationRuntimeStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatusResult>> GetIntegrationRuntimeStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadataStatusResult> RefreshIntegrationRuntimeObjectMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadataStatusResult>> RefreshIntegrationRuntimeObjectMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeys> RegenerateIntegrationRuntimeAuthKey(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeys>> RegenerateIntegrationRuntimeAuthKeyAsync(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatusResult> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatusResult>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncIntegrationRuntimeCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncIntegrationRuntimeCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> Update(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNode(string nodeName, Azure.ResourceManager.Synapse.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNode>> UpdateIntegrationRuntimeNodeAsync(string nodeName, Azure.ResourceManager.Synapse.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseIPFirewallRuleInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>, System.Collections.IEnumerable
    {
        protected SynapseIPFirewallRuleInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseIPFirewallRuleInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseIPFirewallRuleInfoData() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseProvisioningState? ProvisioningState { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class SynapseIPFirewallRuleInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseIPFirewallRuleInfoResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseKeyResource>, System.Collections.IEnumerable
    {
        protected SynapseKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Synapse.SynapseKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Synapse.SynapseKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseKeyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseKeyData() { }
        public bool? IsActiveCmk { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
    }
    public partial class SynapseKeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseKeyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKeyResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKeyResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseKustoPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>, System.Collections.IEnumerable
    {
        protected SynapseKustoPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kustoPoolName, Azure.ResourceManager.Synapse.SynapseKustoPoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kustoPoolName, Azure.ResourceManager.Synapse.SynapseKustoPoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> Get(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> GetAsync(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseKustoPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SynapseKustoPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.SynapseDataSourceSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri DataIngestionUri { get { throw null; } }
        public bool? EnablePurge { get { throw null; } set { } }
        public bool? EnableStreamingIngest { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseLanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseOptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataSourceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolState? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public System.Guid? WorkspaceUid { get { throw null; } set { } }
    }
    public partial class SynapseKustoPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseKustoPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseKustoPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionsList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionsList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult> CheckKustoPoolChildResourceNameAvailability(Azure.ResourceManager.Synapse.Models.KustoPoolChildResourceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult>> CheckKustoPoolChildResourceNameAvailabilityAsync(Azure.ResourceManager.Synapse.Models.KustoPoolChildResourceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult> CheckKustoPoolPrincipalAssignmentNameAvailability(Azure.ResourceManager.Synapse.Models.KustoPoolPrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult>> CheckKustoPoolPrincipalAssignmentNameAvailabilityAsync(Azure.ResourceManager.Synapse.Models.KustoPoolPrincipalAssignmentNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachFollowerDatabases(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseFollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachFollowerDatabasesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseFollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseKustoPoolPrivateLinkData> GetAllKustoPoolPrivateLinkData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseKustoPoolPrivateLinkData> GetAllKustoPoolPrivateLinkDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseFollowerDatabaseDefinition> GetFollowerDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseFollowerDatabaseDefinition> GetFollowerDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseLanguageExtension> GetLanguageExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseLanguageExtension> GetLanguageExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseDataSourceResourceSku> GetSkusByResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseDataSourceResourceSku> GetSkusByResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource> GetSynapseAttachedDatabaseConfiguration(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationResource>> GetSynapseAttachedDatabaseConfigurationAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseAttachedDatabaseConfigurationCollection GetSynapseAttachedDatabaseConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource> GetSynapseClusterPrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentResource>> GetSynapseClusterPrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseClusterPrincipalAssignmentCollection GetSynapseClusterPrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabaseResource> GetSynapseDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDatabaseResource>> GetSynapseDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDatabaseCollection GetSynapseDatabases() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionsList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionsList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseKustoPoolPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseKustoPoolPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseLibraryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseLibraryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseLibraryResource>, System.Collections.IEnumerable
    {
        protected SynapseLibraryCollection() { }
        public virtual Azure.Response<bool> Exists(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseLibraryResource> Get(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseLibraryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseLibraryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseLibraryResource>> GetAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseLibraryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseLibraryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseLibraryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseLibraryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseLibraryData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseLibraryData() { }
        public string ContainerName { get { throw null; } set { } }
        public string CreatorId { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningStatus { get { throw null; } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.DateTimeOffset? UploadedOn { get { throw null; } set { } }
    }
    public partial class SynapseLibraryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseLibraryResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseLibraryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string libraryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseLibraryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseLibraryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseMaintenanceWindowData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseMaintenanceWindowData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseMaintenanceWindowTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class SynapseMaintenanceWindowOptionData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseMaintenanceWindowOptionData() { }
        public bool? AllowMultipleMaintenanceWindowsPerCycle { get { throw null; } set { } }
        public int? DefaultDurationInMinutes { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseMaintenanceWindowTimeRange> MaintenanceWindowCycles { get { throw null; } }
        public int? MinCycles { get { throw null; } set { } }
        public int? MinDurationInMinutes { get { throw null; } set { } }
        public int? TimeGranularityInMinutes { get { throw null; } set { } }
    }
    public partial class SynapseMaintenanceWindowOptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseMaintenanceWindowOptionResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseMaintenanceWindowOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseMaintenanceWindowOptionResource> Get(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseMaintenanceWindowOptionResource>> GetAsync(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseMaintenanceWindowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseMaintenanceWindowResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseMaintenanceWindowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Synapse.SynapseMaintenanceWindowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Synapse.SynapseMaintenanceWindowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseMaintenanceWindowResource> Get(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseMaintenanceWindowResource>> GetAsync(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseManagedIdentitySqlControlSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseManagedIdentitySqlControlSettingData() { }
        public Azure.ResourceManager.Synapse.Models.SynapseGrantSqlControlToManagedIdentity GrantSqlControlToManagedIdentity { get { throw null; } set { } }
    }
    public partial class SynapseManagedIdentitySqlControlSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseManagedIdentitySqlControlSettingResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseMetadataSyncConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseMetadataSyncConfigurationData() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? SyncIntervalInMinutes { get { throw null; } set { } }
    }
    public partial class SynapseMetadataSyncConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseMetadataSyncConfigurationResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapsePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected SynapsePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapsePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapsePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class SynapsePrivateEndpointConnectionForPrivateLinkHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>, System.Collections.IEnumerable
    {
        protected SynapsePrivateEndpointConnectionForPrivateLinkHubCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapsePrivateEndpointConnectionForPrivateLinkHubData : Azure.ResourceManager.Models.ResourceData
    {
        internal SynapsePrivateEndpointConnectionForPrivateLinkHubData() { }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class SynapsePrivateEndpointConnectionForPrivateLinkHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapsePrivateEndpointConnectionForPrivateLinkHubResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateLinkHubName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapsePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapsePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapsePrivateLinkHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>, System.Collections.IEnumerable
    {
        protected SynapsePrivateLinkHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateLinkHubName, Azure.ResourceManager.Synapse.SynapsePrivateLinkHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateLinkHubName, Azure.ResourceManager.Synapse.SynapsePrivateLinkHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> Get(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> GetAsync(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapsePrivateLinkHubData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SynapsePrivateLinkHubData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.PrivateEndpointConnectionForPrivateLinkHubBasic> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public partial class SynapsePrivateLinkHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapsePrivateLinkHubResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateLinkHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource> GetSynapsePrivateEndpointConnectionForPrivateLinkHub(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubResource>> GetSynapsePrivateEndpointConnectionForPrivateLinkHubAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionForPrivateLinkHubCollection GetSynapsePrivateEndpointConnectionForPrivateLinkHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> GetSynapsePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>> GetSynapsePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkResourceCollection GetSynapsePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> Update(Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapsePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapsePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateLinkHubName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapsePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SynapsePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapsePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapsePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapsePrivateLinkResourceData() { }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class SynapseRecoverableSqlPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>, System.Collections.IEnumerable
    {
        protected SynapseRecoverableSqlPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> Get(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>> GetAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseRecoverableSqlPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseRecoverableSqlPoolData() { }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class SynapseRecoverableSqlPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseRecoverableSqlPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseReplicationLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>, System.Collections.IEnumerable
    {
        protected SynapseReplicationLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> Get(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>> GetAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseReplicationLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseReplicationLinkData() { }
        public bool? IsTerminationAllowed { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PartnerDatabase { get { throw null; } }
        public Azure.Core.AzureLocation? PartnerLocation { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseReplicationRole? PartnerRole { get { throw null; } }
        public string PartnerServer { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseReplicationState? ReplicationState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseReplicationRole? Role { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class SynapseReplicationLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseReplicationLinkResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseReplicationLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string linkId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseRestorableDroppedSqlPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>, System.Collections.IEnumerable
    {
        protected SynapseRestorableDroppedSqlPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> Get(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>> GetAsync(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseRestorableDroppedSqlPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseRestorableDroppedSqlPoolData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string MaxSizeBytes { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class SynapseRestorableDroppedSqlPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseRestorableDroppedSqlPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string restorableDroppedSqlPoolId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseRestorePointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseRestorePointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseRestorePointResource>, System.Collections.IEnumerable
    {
        protected SynapseRestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorePointResource> Get(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseRestorePointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseRestorePointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorePointResource>> GetAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseRestorePointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseRestorePointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseRestorePointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseRestorePointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseRestorePointData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseRestorePointData() { }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? RestorePointCreationOn { get { throw null; } }
        public string RestorePointLabel { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseRestorePointType? RestorePointType { get { throw null; } }
    }
    public partial class SynapseRestorePointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseRestorePointResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseRestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorePointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorePointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSensitivityLabelCollection : Azure.ResourceManager.ArmCollection
    {
        protected SynapseSensitivityLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> Get(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSensitivityLabelData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSensitivityLabelData() { }
        public string ColumnName { get { throw null; } }
        public string InformationType { get { throw null; } set { } }
        public System.Guid? InformationTypeId { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } }
        public System.Guid? LabelId { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelRank? Rank { get { throw null; } set { } }
        public string SchemaName { get { throw null; } }
        public string TableName { get { throw null; } }
    }
    public partial class SynapseSensitivityLabelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSensitivityLabelResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSensitivityLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseServerBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected SynapseServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseServerBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseServerBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsDevopsAuditEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SynapseServerBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseServerBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected SynapseServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseServerSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public bool? EnableEmailToAccountAdmins { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SynapseServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseServerVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected SynapseServerVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseServerVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseServerVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class SynapseServerVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseServerVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSparkConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>, System.Collections.IEnumerable
    {
        protected SynapseSparkConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> Get(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>> GetAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSparkConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSparkConfigurationData(System.Collections.Generic.IDictionary<string, string> configs) { }
        public System.Collections.Generic.IList<string> Annotations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigMergeRule { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Configs { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Notes { get { throw null; } set { } }
    }
    public partial class SynapseSparkConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSparkConfigurationResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSparkConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sparkConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SynapseSqlPoolBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>, System.Collections.IEnumerable
    {
        protected SynapseSqlPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlPoolName, Azure.ResourceManager.Synapse.SynapseSqlPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlPoolName, Azure.ResourceManager.Synapse.SynapseSqlPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> Get(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> GetAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSqlPoolColumnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>, System.Collections.IEnumerable
    {
        protected SynapseSqlPoolColumnCollection() { }
        public virtual Azure.Response<bool> Exists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> Get(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>> GetAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSqlPoolColumnData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolColumnData() { }
        public Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType? ColumnType { get { throw null; } set { } }
        public bool? IsComputed { get { throw null; } }
    }
    public partial class SynapseSqlPoolColumnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolColumnResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolColumnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName, string tableName, string columnName) { throw null; }
        public virtual Azure.Response DisableRecommendationSqlPoolSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationSqlPoolSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendationSqlPoolSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationSqlPoolSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> GetSynapseSensitivityLabel(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource>> GetSynapseSensitivityLabelAsync(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSensitivityLabelCollection GetSynapseSensitivityLabels() { throw null; }
    }
    public partial class SynapseSqlPoolConnectionPolicyCollection : Azure.ResourceManager.ArmCollection
    {
        protected SynapseSqlPoolConnectionPolicyCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolConnectionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolConnectionPolicyData() { }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProxyDnsName { get { throw null; } set { } }
        public string ProxyPort { get { throw null; } set { } }
        public string RedirectionState { get { throw null; } set { } }
        public string SecurityEnabledAccess { get { throw null; } set { } }
        public string State { get { throw null; } set { } }
        public string UseServerDefault { get { throw null; } set { } }
        public string Visibility { get { throw null; } set { } }
    }
    public partial class SynapseSqlPoolConnectionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolConnectionPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SynapseSqlPoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Collation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode? CreateMode { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class SynapseSqlPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseRestorePointResource> CreateSqlPoolRestorePoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlPoolCreateRestorePointContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseRestorePointResource>> CreateSqlPoolRestorePointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlPoolCreateRestorePointContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> GetCurrentSqlPoolSensitivityLabels(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> GetCurrentSqlPoolSensitivityLabelsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> GetRecommendedSqlPoolSensitivityLabels(bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSensitivityLabelResource> GetRecommendedSqlPoolSensitivityLabelsAsync(bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SqlPoolUsage> GetSqlPoolUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SqlPoolUsage> GetSqlPoolUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDataMaskingPolicyResource GetSynapseDataMaskingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityCollection GetSynapseDataWarehouseUserActivities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource> GetSynapseDataWarehouseUserActivity(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDataWarehouseUserActivityResource>> GetSynapseDataWarehouseUserActivityAsync(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseExtendedSqlPoolBlobAuditingPolicyResource GetSynapseExtendedSqlPoolBlobAuditingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyCollection GetSynapseGeoBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource> GetSynapseGeoBackupPolicy(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseGeoBackupPolicyResource>> GetSynapseGeoBackupPolicyAsync(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseMaintenanceWindowResource GetSynapseMaintenanceWindow() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseMaintenanceWindowOptionResource GetSynapseMaintenanceWindowOption() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseMetadataSyncConfigurationResource GetSynapseMetadataSyncConfiguration() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource> GetSynapseReplicationLink(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseReplicationLinkResource>> GetSynapseReplicationLinkAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseReplicationLinkCollection GetSynapseReplicationLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorePointResource> GetSynapseRestorePoint(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorePointResource>> GetSynapseRestorePointAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseRestorePointCollection GetSynapseRestorePoints() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolBlobAuditingPolicyResource GetSynapseSqlPoolBlobAuditingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyCollection GetSynapseSqlPoolConnectionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource> GetSynapseSqlPoolConnectionPolicy(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolConnectionPolicyResource>> GetSynapseSqlPoolConnectionPolicyAsync(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> GetSynapseSqlPoolSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>> GetSynapseSqlPoolSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaCollection GetSynapseSqlPoolSchemas() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyCollection GetSynapseSqlPoolSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> GetSynapseSqlPoolSecurityAlertPolicy(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>> GetSynapseSqlPoolSecurityAlertPolicyAsync(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> GetSynapseSqlPoolVulnerabilityAssessment(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>> GetSynapseSqlPoolVulnerabilityAssessmentAsync(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentCollection GetSynapseSqlPoolVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> GetSynapseTransparentDataEncryption(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>> GetSynapseTransparentDataEncryptionAsync(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionCollection GetSynapseTransparentDataEncryptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> GetSynapseWorkloadGroup(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>> GetSynapseWorkloadGroupAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkloadGroupCollection GetSynapseWorkloadGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Rename(Azure.ResourceManager.Synapse.Models.SynapseResourceMoveDefinition synapseResourceMoveDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameAsync(Azure.ResourceManager.Synapse.Models.SynapseResourceMoveDefinition synapseResourceMoveDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use Update(WaitUntil waitUntil, SynapseSqlPoolPatch patch, CancellationToken cancellationToken = default).", false)]
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> Update(Azure.ResourceManager.Synapse.Models.SynapseSqlPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseSqlPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use UpdateAsync(WaitUntil waitUntil, SynapseSqlPoolPatch patch, CancellationToken cancellationToken = default).", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.SynapseSqlPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseSqlPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSqlPoolRecommendedSensitivityLabel(Azure.ResourceManager.Synapse.Models.SynapseRecommendedSensitivityLabelUpdateOperationListResult synapseRecommendedSensitivityLabelUpdateOperationListResult, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSqlPoolRecommendedSensitivityLabelAsync(Azure.ResourceManager.Synapse.Models.SynapseRecommendedSensitivityLabelUpdateOperationListResult synapseRecommendedSensitivityLabelUpdateOperationListResult, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSqlPoolSensitivityLabel(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelUpdateListResult synapseSensitivityLabelUpdateListResult, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSqlPoolSensitivityLabelAsync(Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelUpdateListResult synapseSensitivityLabelUpdateListResult, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>, System.Collections.IEnumerable
    {
        protected SynapseSqlPoolSchemaCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSqlPoolSchemaData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolSchemaData() { }
    }
    public partial class SynapseSqlPoolSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolSchemaResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> GetSynapseSqlPoolTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>> GetSynapseSqlPoolTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolTableCollection GetSynapseSqlPoolTables() { throw null; }
    }
    public partial class SynapseSqlPoolSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected SynapseSqlPoolSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSqlPoolSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public bool? EnableEmailToAccountAdmins { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SynapseSqlPoolSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>, System.Collections.IEnumerable
    {
        protected SynapseSqlPoolTableCollection() { }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSqlPoolTableData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolTableData() { }
    }
    public partial class SynapseSqlPoolTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolTableResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource> GetSynapseSqlPoolColumn(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolColumnResource>> GetSynapseSqlPoolColumnAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolColumnCollection GetSynapseSqlPoolColumns() { throw null; }
    }
    public partial class SynapseSqlPoolVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected SynapseSqlPoolVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseSqlPoolVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class SynapseSqlPoolVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource> GetSynapseSqlPoolVulnerabilityAssessmentRuleBaseline(string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource>> GetSynapseSqlPoolVulnerabilityAssessmentRuleBaselineAsync(string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineCollection GetSynapseSqlPoolVulnerabilityAssessmentRuleBaselines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> GetSynapseVulnerabilityAssessmentScanRecord(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>> GetSynapseVulnerabilityAssessmentScanRecordAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordCollection GetSynapseVulnerabilityAssessmentScanRecords() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolVulnerabilityAssessmentRuleBaselineCollection : Azure.ResourceManager.ArmCollection
    {
        protected SynapseSqlPoolVulnerabilityAssessmentRuleBaselineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource> Get(string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource>> GetAsync(string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SqlPoolVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } }
    }
    public partial class SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentPolicyBaselineName baselineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseSqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseTransparentDataEncryptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>, System.Collections.IEnumerable
    {
        protected SynapseTransparentDataEncryptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> Get(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseTransparentDataEncryptionData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseTransparentDataEncryptionData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionStatus? Status { get { throw null; } set { } }
    }
    public partial class SynapseTransparentDataEncryptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseTransparentDataEncryptionResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName transparentDataEncryptionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseTransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseVulnerabilityAssessmentScanRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>, System.Collections.IEnumerable
    {
        protected SynapseVulnerabilityAssessmentScanRecordCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> Get(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>> GetAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseVulnerabilityAssessmentScanRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseVulnerabilityAssessmentScanRecordData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanError> Errors { get { throw null; } }
        public int? NumberOfFailedSecurityChecks { get { throw null; } }
        public string ScanId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState? State { get { throw null; } }
        public string StorageContainerPath { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType? TriggerType { get { throw null; } }
    }
    public partial class SynapseVulnerabilityAssessmentScanRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseVulnerabilityAssessmentScanRecordResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SqlPoolVulnerabilityAssessmentScansExport> Export(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SqlPoolVulnerabilityAssessmentScansExport>> ExportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseVulnerabilityAssessmentScanRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateScan(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateScanAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkloadClassifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>, System.Collections.IEnumerable
    {
        protected SynapseWorkloadClassifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Synapse.SynapseWorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Synapse.SynapseWorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> Get(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>> GetAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseWorkloadClassifierData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseWorkloadClassifierData() { }
        public string Context { get { throw null; } set { } }
        public string EndTime { get { throw null; } set { } }
        public string Importance { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MemberName { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class SynapseWorkloadClassifierResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseWorkloadClassifierResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkloadClassifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string workloadGroupName, string workloadClassifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkloadGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>, System.Collections.IEnumerable
    {
        protected SynapseWorkloadGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Synapse.SynapseWorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Synapse.SynapseWorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> Get(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>> GetAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseWorkloadGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseWorkloadGroupData() { }
        public string Importance { get { throw null; } set { } }
        public int? MaxResourcePercent { get { throw null; } set { } }
        public double? MaxResourcePercentPerRequest { get { throw null; } set { } }
        public int? MinResourcePercent { get { throw null; } set { } }
        public double? MinResourcePercentPerRequest { get { throw null; } set { } }
        public int? QueryExecutionTimeout { get { throw null; } set { } }
    }
    public partial class SynapseWorkloadGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseWorkloadGroupResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkloadGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string workloadGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource> GetSynapseWorkloadClassifier(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkloadClassifierResource>> GetSynapseWorkloadClassifierAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkloadClassifierCollection GetSynapseWorkloadClassifiers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkloadGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkspaceAadAdminInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseWorkspaceAadAdminInfoData() { }
        public string AdministratorType { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class SynapseWorkspaceAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseWorkspaceAdministratorResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspaceAadAdminInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>, System.Collections.IEnumerable
    {
        protected SynapseWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Synapse.SynapseWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Synapse.SynapseWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SynapseWorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.Core.ResourceIdentifier AdlaResourceId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConnectivityEndpoints { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataLakeStorageAccountDetails DefaultDataLakeStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseEncryptionDetails Encryption { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ExtraProperties { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? InitialWorkspaceAdminObjectId { get { throw null; } set { } }
        public bool? IsAadOnlyAuthenticationEnabled { get { throw null; } set { } }
        public bool? IsTrustedServiceBypassEnabled { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public string ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PurviewResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string SqlAdministratorLogin { get { throw null; } set { } }
        public string SqlAdministratorLoginPassword { get { throw null; } set { } }
        public string VirtualNetworkComputeSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseWorkspaceRepositoryConfiguration WorkspaceRepositoryConfiguration { get { throw null; } set { } }
        public System.Guid? WorkspaceUid { get { throw null; } }
    }
    public partial class SynapseWorkspacePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseWorkspacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkspacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SynapseWorkspacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynapseWorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseWorkspaceResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource> GetSynapseAadOnlyAuthentication(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationResource>> GetSynapseAadOnlyAuthenticationAsync(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseAadOnlyAuthenticationCollection GetSynapseAadOnlyAuthentications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource> GetSynapseBigDataPoolInfo(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoResource>> GetSynapseBigDataPoolInfoAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseBigDataPoolInfoCollection GetSynapseBigDataPoolInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource> GetSynapseDedicatedSqlMinimalTlsSetting(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingResource>> GetSynapseDedicatedSqlMinimalTlsSettingAsync(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseDedicatedSqlMinimalTlsSettingCollection GetSynapseDedicatedSqlMinimalTlsSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource> GetSynapseEncryptionProtector(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseEncryptionProtectorResource>> GetSynapseEncryptionProtectorAsync(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseEncryptionProtectorCollection GetSynapseEncryptionProtectors() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyCollection GetSynapseExtendedServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource> GetSynapseExtendedServerBlobAuditingPolicy(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseExtendedServerBlobAuditingPolicyResource>> GetSynapseExtendedServerBlobAuditingPolicyAsync(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource> GetSynapseIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeResource>> GetSynapseIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseIntegrationRuntimeCollection GetSynapseIntegrationRuntimes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource> GetSynapseIPFirewallRuleInfo(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoResource>> GetSynapseIPFirewallRuleInfoAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseIPFirewallRuleInfoCollection GetSynapseIPFirewallRuleInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKeyResource> GetSynapseKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKeyResource>> GetSynapseKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseKeyCollection GetSynapseKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource> GetSynapseKustoPool(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseKustoPoolResource>> GetSynapseKustoPoolAsync(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseKustoPoolCollection GetSynapseKustoPools() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseLibraryCollection GetSynapseLibraries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseLibraryResource> GetSynapseLibrary(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseLibraryResource>> GetSynapseLibraryAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseManagedIdentitySqlControlSettingResource GetSynapseManagedIdentitySqlControlSetting() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> GetSynapsePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>> GetSynapsePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionCollection GetSynapsePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource> GetSynapseRecoverableSqlPool(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolResource>> GetSynapseRecoverableSqlPoolAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseRecoverableSqlPoolCollection GetSynapseRecoverableSqlPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource> GetSynapseRestorableDroppedSqlPool(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolResource>> GetSynapseRestorableDroppedSqlPoolAsync(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseRestorableDroppedSqlPoolCollection GetSynapseRestorableDroppedSqlPools() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyCollection GetSynapseServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource> GetSynapseServerBlobAuditingPolicy(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerBlobAuditingPolicyResource>> GetSynapseServerBlobAuditingPolicyAsync(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyCollection GetSynapseServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource> GetSynapseServerSecurityAlertPolicy(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerSecurityAlertPolicyResource>> GetSynapseServerSecurityAlertPolicyAsync(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource> GetSynapseServerVulnerabilityAssessment(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentResource>> GetSynapseServerVulnerabilityAssessmentAsync(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseServerVulnerabilityAssessmentCollection GetSynapseServerVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource> GetSynapseSparkConfiguration(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSparkConfigurationResource>> GetSynapseSparkConfigurationAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSparkConfigurationCollection GetSynapseSparkConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource> GetSynapseSqlPool(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseSqlPoolResource>> GetSynapseSqlPoolAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseSqlPoolCollection GetSynapseSqlPools() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspaceAdministratorResource GetSynapseWorkspaceAdministratorResource() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource> GetSynapseWorkspacePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResource>> GetSynapseWorkspacePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspacePrivateLinkResourceCollection GetSynapseWorkspacePrivateLinkResources() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspaceSqlAdministratorResource GetSynapseWorkspaceSqlAdministratorResource() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SynapseServerUsage> GetWorkspaceManagedSqlServerUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SynapseServerUsage> GetWorkspaceManagedSqlServerUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.ReplaceAllFirewallRulesOperationResult> ReplaceAllIpFirewallRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.ReplaceAllIPFirewallRulesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.ReplaceAllFirewallRulesOperationResult>> ReplaceAllIpFirewallRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.ReplaceAllIPFirewallRulesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SynapseWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkspaceSqlAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynapseWorkspaceSqlAdministratorResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspaceAadAdminInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceSqlAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SynapseWorkspaceSqlAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SynapseWorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceSqlAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapseWorkspaceSqlAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Synapse.Mock
{
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkHubCollection GetSynapsePrivateLinkHubs() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapseWorkspaceCollection GetSynapseWorkspaces() { throw null; }
    }
    public partial class SynapseKustoPoolResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SynapseKustoPoolResourceExtensionClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult> CheckKustoPoolNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityResult>> CheckKustoPoolNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.KustoPoolNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.KustoPoolSkuDescription> GetSkusKustoPools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.KustoPoolSkuDescription> GetSkusKustoPoolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapsePrivateLinkHubResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SynapsePrivateLinkHubResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetSynapsePrivateLinkHubs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapsePrivateLinkHubResource> GetSynapsePrivateLinkHubsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynapseWorkspaceResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SynapseWorkspaceResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetSynapseWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SynapseWorkspaceResource> GetSynapseWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Synapse.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AadAuthenticationState : System.IEquatable<Azure.ResourceManager.Synapse.Models.AadAuthenticationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AadAuthenticationState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.AadAuthenticationState Consistent { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.AadAuthenticationState InConsistent { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.AadAuthenticationState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.AadAuthenticationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.AadAuthenticationState left, Azure.ResourceManager.Synapse.Models.AadAuthenticationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.AadAuthenticationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.AadAuthenticationState left, Azure.ResourceManager.Synapse.Models.AadAuthenticationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BigDataPoolAutoPauseProperties
    {
        public BigDataPoolAutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class BigDataPoolAutoScaleProperties
    {
        public BigDataPoolAutoScaleProperties() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    public partial class BigDataPoolLibraryInfo
    {
        public BigDataPoolLibraryInfo() { }
        public string ContainerName { get { throw null; } set { } }
        public string CreatorId { get { throw null; } }
        public string LibraryInfoType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningStatus { get { throw null; } }
        public System.DateTimeOffset? UploadedOn { get { throw null; } set { } }
    }
    public partial class BigDataPoolLibraryRequirements
    {
        public BigDataPoolLibraryRequirements() { }
        public string Content { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BigDataPoolNodeSize : System.IEquatable<Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BigDataPoolNodeSize(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize Large { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize Medium { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize Small { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize XLarge { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize XXLarge { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize XXXLarge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize left, Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize left, Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BigDataPoolNodeSizeFamily : System.IEquatable<Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BigDataPoolNodeSizeFamily(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily HardwareAcceleratedFpga { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily HardwareAcceleratedGpu { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily MemoryOptimized { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily left, Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily left, Azure.ResourceManager.Synapse.Models.BigDataPoolNodeSizeFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BigDataPoolSparkConfigProperties
    {
        public BigDataPoolSparkConfigProperties() { }
        public Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType? ConfigurationType { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class IntegrationRuntimeRegenerateKeyContent
    {
        public IntegrationRuntimeRegenerateKeyContent() { }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName? KeyName { get { throw null; } set { } }
    }
    public partial class KekIdentityProperties
    {
        public KekIdentityProperties() { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityId { get { throw null; } set { } }
        public System.BinaryData UseSystemAssignedIdentity { get { throw null; } set { } }
    }
    public partial class KustoPoolChildResourceNameAvailabilityContent
    {
        public KustoPoolChildResourceNameAvailabilityContent(string name, Azure.ResourceManager.Synapse.Models.KustoPoolDatabaseType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolDatabaseType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoPoolCompressionType : System.IEquatable<Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoPoolCompressionType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType GZip { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType left, Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType left, Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoPoolDatabasePrincipalAssignmentNameAvailabilityContent
    {
        public KustoPoolDatabasePrincipalAssignmentNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType ResourceType { get { throw null; } }
    }
    public enum KustoPoolDatabaseType
    {
        MicrosoftSynapseWorkspacesKustoPoolsDatabases = 0,
        MicrosoftSynapseWorkspacesKustoPoolsAttachedDatabaseConfigurations = 1,
    }
    public partial class KustoPoolDataConnectionNameAvailabilityContent
    {
        public KustoPoolDataConnectionNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType ResourceType { get { throw null; } }
    }
    public partial class KustoPoolNameAvailabilityContent
    {
        public KustoPoolNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolType ResourceType { get { throw null; } }
    }
    public partial class KustoPoolNameAvailabilityResult
    {
        internal KustoPoolNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason? Reason { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoPoolNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoPoolNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason left, Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason left, Azure.ResourceManager.Synapse.Models.KustoPoolNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoPoolPrincipalAssignmentNameAvailabilityContent
    {
        public KustoPoolPrincipalAssignmentNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType ResourceType { get { throw null; } }
    }
    public partial class KustoPoolSkuDescription
    {
        internal KustoPoolSkuDescription() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.KustoPoolSkuLocationInfoItem> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
    }
    public partial class KustoPoolSkuLocationInfoItem
    {
        internal KustoPoolSkuLocationInfoItem() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoPoolSkuSize : System.IEquatable<Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoPoolSkuSize(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize ExtraSmall { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize Large { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize Medium { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize left, Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize left, Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoPoolState : System.IEquatable<Azure.ResourceManager.Synapse.Models.KustoPoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoPoolState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Creating { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Running { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Starting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Stopping { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Unavailable { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.KustoPoolState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.KustoPoolState left, Azure.ResourceManager.Synapse.Models.KustoPoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.KustoPoolState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.KustoPoolState left, Azure.ResourceManager.Synapse.Models.KustoPoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoPoolType : System.IEquatable<Azure.ResourceManager.Synapse.Models.KustoPoolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoPoolType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.KustoPoolType MicrosoftSynapseWorkspacesKustoPools { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.KustoPoolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.KustoPoolType left, Azure.ResourceManager.Synapse.Models.KustoPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.KustoPoolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.KustoPoolType left, Azure.ResourceManager.Synapse.Models.KustoPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubBasic
    {
        internal PrivateEndpointConnectionForPrivateLinkHubBasic() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class ReplaceAllFirewallRulesOperationResult
    {
        internal ReplaceAllFirewallRulesOperationResult() { }
        public string OperationId { get { throw null; } }
    }
    public partial class ReplaceAllIPFirewallRulesContent
    {
        public ReplaceAllIPFirewallRulesContent() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Synapse.Models.SynapseIPFirewallRuleProperties> IPFirewallRules { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Synapse.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ResourceProvisioningState left, Azure.ResourceManager.Synapse.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ResourceProvisioningState left, Azure.ResourceManager.Synapse.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlPoolColumnDataType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlPoolColumnDataType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType BigInt { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Binary { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Bit { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Char { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Date { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType DateTime { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType DateTime2 { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType DateTimeOffset { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Decimal { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Float { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Geography { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Geometry { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Hierarchyid { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Image { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Int { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Money { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Nchar { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Ntext { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Numeric { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Nvarchar { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Real { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType SmallDateTime { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType SmallInt { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType SmallMoney { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType SqlVariant { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Sysname { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Text { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Time { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Timestamp { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType TinyInt { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType UniqueIdentifier { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Varbinary { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Varchar { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType left, Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType left, Azure.ResourceManager.Synapse.Models.SqlPoolColumnDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlPoolConnectionPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlPoolConnectionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName left, Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName left, Azure.ResourceManager.Synapse.Models.SqlPoolConnectionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlPoolCreateMode : System.IEquatable<Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlPoolCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode Recovery { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode left, Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode left, Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlPoolCreateRestorePointContent
    {
        public SqlPoolCreateRestorePointContent(string restorePointLabel) { }
        public string RestorePointLabel { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlPoolSecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlPoolSecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName left, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName left, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlPoolStorageAccountType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlPoolStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType Grs { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType Lrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType left, Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType left, Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlPoolUsage
    {
        internal SqlPoolUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SqlPoolVulnerabilityAssessmentRuleBaselineItem
    {
        public SqlPoolVulnerabilityAssessmentRuleBaselineItem(System.Collections.Generic.IEnumerable<string> result) { }
        public System.Collections.Generic.IList<string> Result { get { throw null; } }
    }
    public partial class SqlPoolVulnerabilityAssessmentScansExport : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolVulnerabilityAssessmentScansExport() { }
        public string ExportedReportLocation { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerSecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerSecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName left, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName left, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseAadOnlyAuthenticationName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseAadOnlyAuthenticationName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName left, Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName left, Azure.ResourceManager.Synapse.Models.SynapseAadOnlyAuthenticationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseBigDataPoolInfoPatch
    {
        public SynapseBigDataPoolInfoPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseBlobAuditingPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseBlobAuditingPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName left, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName left, Azure.ResourceManager.Synapse.Models.SynapseBlobAuditingPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SynapseBlobAuditingPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseBlobStorageEventType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseBlobStorageEventType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType MicrosoftStorageBlobRenamed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType left, Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType left, Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseClusterPrincipalRole : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseClusterPrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole AllDatabasesAdmin { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole AllDatabasesViewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole left, Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole left, Azure.ResourceManager.Synapse.Models.SynapseClusterPrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseCmdkeySetup : Azure.ResourceManager.Synapse.Models.SynapseCustomSetupBase
    {
        public SynapseCmdkeySetup(System.BinaryData targetName, System.BinaryData userName, Azure.ResourceManager.Synapse.Models.SynapseSecretBase password) { }
        public Azure.ResourceManager.Synapse.Models.SynapseSecretBase Password { get { throw null; } set { } }
        public System.BinaryData TargetName { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    public partial class SynapseComponentSetup : Azure.ResourceManager.Synapse.Models.SynapseCustomSetupBase
    {
        public SynapseComponentSetup(string componentName) { }
        public string ComponentName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSecretBase LicenseKey { get { throw null; } set { } }
    }
    public abstract partial class SynapseCustomSetupBase
    {
        protected SynapseCustomSetupBase() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDatabasePrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDatabasePrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType MicrosoftSynapseWorkspacesKustoPoolsDatabasesPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDatabasePrincipalRole : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDatabasePrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole Admin { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole Ingestor { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole Monitor { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole UnrestrictedViewer { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole User { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole Viewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole left, Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole left, Azure.ResourceManager.Synapse.Models.SynapseDatabasePrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDataConnectionType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDataConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType MicrosoftSynapseWorkspacesKustoPoolsDatabasesDataConnections { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType left, Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType left, Azure.ResourceManager.Synapse.Models.SynapseDataConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseDataConnectionValidation
    {
        public SynapseDataConnectionValidation() { }
        public string DataConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.SynapseDataConnectionData Properties { get { throw null; } set { } }
    }
    public partial class SynapseDataConnectionValidationListResult
    {
        internal SynapseDataConnectionValidationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseDataConnectionValidationResult> Value { get { throw null; } }
    }
    public partial class SynapseDataConnectionValidationResult
    {
        internal SynapseDataConnectionValidationResult() { }
        public string ErrorMessage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDataFlowComputeType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDataFlowComputeType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType General { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType left, Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType left, Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseDataLakeStorageAccountDetails
    {
        public SynapseDataLakeStorageAccountDetails() { }
        public System.Uri AccountUri { get { throw null; } set { } }
        public bool? CreateManagedPrivateEndpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public enum SynapseDataMaskingFunction
    {
        Default = 0,
        Ccn = 1,
        Email = 2,
        Number = 3,
        Ssn = 4,
        Text = 5,
    }
    public enum SynapseDataMaskingRuleState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum SynapseDataMaskingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class SynapseDataSourceCapacity
    {
        internal SynapseDataSourceCapacity() { }
        public int Default { get { throw null; } }
        public int Maximum { get { throw null; } }
        public int Minimum { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType ScaleType { get { throw null; } }
    }
    public partial class SynapseDataSourceResourceSku
    {
        internal SynapseDataSourceResourceSku() { }
        public Azure.ResourceManager.Synapse.Models.SynapseDataSourceCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataSourceSku Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDataSourceScaleType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDataSourceScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType left, Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType left, Azure.ResourceManager.Synapse.Models.SynapseDataSourceScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseDataSourceSku
    {
        public SynapseDataSourceSku(Azure.ResourceManager.Synapse.Models.SynapseSkuName name, Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize size) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolSkuSize Size { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDataWarehouseUserActivityName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDataWarehouseUserActivityName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName left, Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName left, Azure.ResourceManager.Synapse.Models.SynapseDataWarehouseUserActivityName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDayOfWeek : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek left, Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek left, Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDedicatedSqlMinimalTlsSettingName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDedicatedSqlMinimalTlsSettingName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName left, Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName left, Azure.ResourceManager.Synapse.Models.SynapseDedicatedSqlMinimalTlsSettingName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseDefaultPrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseDefaultPrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.SynapseDefaultPrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SynapseDesiredState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class SynapseDynamicExecutorAllocation
    {
        public SynapseDynamicExecutorAllocation() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MaxExecutors { get { throw null; } set { } }
        public int? MinExecutors { get { throw null; } set { } }
    }
    public partial class SynapseEncryptionDetails
    {
        public SynapseEncryptionDetails() { }
        public Azure.ResourceManager.Synapse.Models.WorkspaceCustomerManagedKeyDetails Cmk { get { throw null; } set { } }
        public bool? IsDoubleEncryptionEnabled { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseEncryptionProtectorName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseEncryptionProtectorName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName left, Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName left, Azure.ResourceManager.Synapse.Models.SynapseEncryptionProtectorName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseEntityReference
    {
        public SynapseEntityReference() { }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType? IntegrationRuntimeEntityReferenceType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
    }
    public partial class SynapseEnvironmentVariableSetup : Azure.ResourceManager.Synapse.Models.SynapseCustomSetupBase
    {
        public SynapseEnvironmentVariableSetup(string variableName, string variableValue) { }
        public string VariableName { get { throw null; } set { } }
        public string VariableValue { get { throw null; } set { } }
    }
    public partial class SynapseEventGridDataConnection : Azure.ResourceManager.Synapse.SynapseDataConnectionData
    {
        public SynapseEventGridDataConnection() { }
        public Azure.ResourceManager.Synapse.Models.SynapseBlobStorageEventType? BlobStorageEventType { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat? DataFormat { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public bool? IgnoreFirstRecord { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseEventGridDataFormat : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseEventGridDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat ApacheAvro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat MultiJson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Orc { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Psv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Raw { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat SingleJson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Tsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat Txt { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat W3CLogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat left, Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat left, Azure.ResourceManager.Synapse.Models.SynapseEventGridDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseEventHubDataConnection : Azure.ResourceManager.Synapse.SynapseDataConnectionData
    {
        public SynapseEventHubDataConnection() { }
        public Azure.ResourceManager.Synapse.Models.KustoPoolCompressionType? Compression { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat? DataFormat { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseEventHubDataFormat : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseEventHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat ApacheAvro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat MultiJson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Orc { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Psv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Raw { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat SingleJson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Tsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat Txt { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat W3CLogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat left, Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat left, Azure.ResourceManager.Synapse.Models.SynapseEventHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseFollowerDatabaseDefinition
    {
        public SynapseFollowerDatabaseDefinition(Azure.Core.ResourceIdentifier kustoPoolResourceId, string attachedDatabaseConfigurationName) { }
        public string AttachedDatabaseConfigurationName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } }
        public Azure.Core.ResourceIdentifier KustoPoolResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseGeoBackupPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseGeoBackupPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName left, Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName left, Azure.ResourceManager.Synapse.Models.SynapseGeoBackupPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SynapseGeoBackupPolicyState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class SynapseGetSsisObjectMetadataContent
    {
        public SynapseGetSsisObjectMetadataContent() { }
        public string MetadataPath { get { throw null; } set { } }
    }
    public partial class SynapseGrantSqlControlToManagedIdentity
    {
        public SynapseGrantSqlControlToManagedIdentity() { }
        public Azure.ResourceManager.Synapse.Models.SynapseGrantSqlControlToManagedIdentityState? ActualState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDesiredState? DesiredState { get { throw null; } set { } }
    }
    public enum SynapseGrantSqlControlToManagedIdentityState
    {
        Unknown = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeAuthKeyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeAuthKeyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName AuthKey1 { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName AuthKey2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAuthKeyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeAuthKeys
    {
        internal SynapseIntegrationRuntimeAuthKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeAutoUpdate : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeAutoUpdate(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate Off { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeComputeProperties
    {
        public SynapseIntegrationRuntimeComputeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public int? NumberOfNodes { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeVnetProperties VnetProperties { get { throw null; } set { } }
    }
    public partial class SynapseIntegrationRuntimeConnectionInfo
    {
        internal SynapseIntegrationRuntimeConnectionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public System.BinaryData IdentityCertThumbprint { get { throw null; } }
        public bool? IsIdentityCertExprired { get { throw null; } }
        public string PublicKey { get { throw null; } }
        public string ServiceToken { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeCustomSetupScriptProperties
    {
        public SynapseIntegrationRuntimeCustomSetupScriptProperties() { }
        public System.Uri BlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSecureString SasToken { get { throw null; } set { } }
    }
    public partial class SynapseIntegrationRuntimeDataFlowProperties
    {
        public SynapseIntegrationRuntimeDataFlowProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? Cleanup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class SynapseIntegrationRuntimeDataProxyProperties
    {
        public SynapseIntegrationRuntimeDataProxyProperties() { }
        public Azure.ResourceManager.Synapse.Models.SynapseEntityReference ConnectVia { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseEntityReference StagingLinkedService { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeEdition : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeEdition(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition Enterprise { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeEntityReferenceType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeEntityReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType IntegrationRuntimeReference { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEntityReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeInternalChannelEncryptionMode : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeInternalChannelEncryptionMode(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode NotEncrypted { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode NotSet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode SslEncrypted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeLicenseType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeMonitoringResult
    {
        internal SynapseIntegrationRuntimeMonitoringResult() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeNodeMonitoringResult> Nodes { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeNodeIPAddress
    {
        internal SynapseIntegrationRuntimeNodeIPAddress() { }
        public System.Net.IPAddress IPAddress { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeNodeMonitoringResult
    {
        internal SynapseIntegrationRuntimeNodeMonitoringResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public int? AvailableMemoryInMB { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public int? ConcurrentJobsRunning { get { throw null; } }
        public int? CpuUtilization { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public float? ReceivedBytes { get { throw null; } }
        public float? SentBytes { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint
    {
        internal SynapseIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeOutboundNetworkDependenciesEndpoint> Endpoints { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeOutboundNetworkDependenciesEndpoint
    {
        internal SynapseIntegrationRuntimeOutboundNetworkDependenciesEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeOutboundNetworkDependenciesEndpointDetails> EndpointDetails { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeOutboundNetworkDependenciesEndpointDetails
    {
        internal SynapseIntegrationRuntimeOutboundNetworkDependenciesEndpointDetails() { }
        public int? Port { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimePatch
    {
        public SynapseIntegrationRuntimePatch() { }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } set { } }
        public string UpdateDelayOffset { get { throw null; } set { } }
    }
    public partial class SynapseIntegrationRuntimeProperties
    {
        public SynapseIntegrationRuntimeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    public partial class SynapseIntegrationRuntimeSsisCatalogInfo
    {
        public SynapseIntegrationRuntimeSsisCatalogInfo() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseSecureString CatalogAdminPassword { get { throw null; } set { } }
        public string CatalogAdminUserName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier? CatalogPricingTier { get { throw null; } set { } }
        public System.Uri CatalogServerEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeSsisCatalogPricingTier : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeSsisCatalogPricingTier(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier PremiumRS { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeSsisProperties
    {
        public SynapseIntegrationRuntimeSsisProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisCatalogInfo CatalogInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeEdition? Edition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseCustomSetupBase> ExpressCustomSetupProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeLicenseType? LicenseType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeState : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Initial { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Limited { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Offline { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Online { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Starting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeStatus
    {
        internal SynapseIntegrationRuntimeStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState? State { get { throw null; } }
    }
    public partial class SynapseIntegrationRuntimeStatusResult
    {
        internal SynapseIntegrationRuntimeStatusResult() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatus Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIntegrationRuntimeUpdateResult : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIntegrationRuntimeUpdateResult(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult Fail { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult Succeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult left, Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIntegrationRuntimeVnetProperties
    {
        public SynapseIntegrationRuntimeVnetProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicIPs { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Guid? VnetId { get { throw null; } set { } }
    }
    public partial class SynapseIotHubDataConnection : Azure.ResourceManager.Synapse.SynapseDataConnectionData
    {
        public SynapseIotHubDataConnection() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat? DataFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier IotHubResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseIotHubDataFormat : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseIotHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat ApacheAvro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Csv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat MultiJson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Orc { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Psv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Raw { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat SingleJson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Tsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat Txt { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat W3CLogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat left, Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat left, Azure.ResourceManager.Synapse.Models.SynapseIotHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseIPFirewallRuleProperties
    {
        public SynapseIPFirewallRuleProperties() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseProvisioningState? ProvisioningState { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class SynapseKustoPoolPatch : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseKustoPoolPatch() { }
        public System.Uri DataIngestionUri { get { throw null; } }
        public bool? EnablePurge { get { throw null; } set { } }
        public bool? EnableStreamingIngest { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseLanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseOptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseDataSourceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolState? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public System.Guid? WorkspaceUid { get { throw null; } set { } }
    }
    public partial class SynapseKustoPoolPrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseKustoPoolPrivateLinkData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class SynapseLanguageExtension
    {
        public SynapseLanguageExtension() { }
        public Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName? LanguageExtensionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseLanguageExtensionName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseLanguageExtensionName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName Python { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName R { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName left, Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName left, Azure.ResourceManager.Synapse.Models.SynapseLanguageExtensionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseLanguageExtensionsList
    {
        public SynapseLanguageExtensionsList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseLanguageExtension> Value { get { throw null; } }
    }
    public partial class SynapseLinkedIntegrationRuntime
    {
        internal SynapseLinkedIntegrationRuntime() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public string DataFactoryLocation { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class SynapseLinkedIntegrationRuntimeKeyAuthorization : Azure.ResourceManager.Synapse.Models.SynapseLinkedIntegrationRuntimeType
    {
        public SynapseLinkedIntegrationRuntimeKeyAuthorization(Azure.ResourceManager.Synapse.Models.SynapseSecureString key) { }
        public Azure.ResourceManager.Synapse.Models.SynapseSecureString Key { get { throw null; } set { } }
    }
    public partial class SynapseLinkedIntegrationRuntimeRbacAuthorization : Azure.ResourceManager.Synapse.Models.SynapseLinkedIntegrationRuntimeType
    {
        public SynapseLinkedIntegrationRuntimeRbacAuthorization(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
    }
    public abstract partial class SynapseLinkedIntegrationRuntimeType
    {
        protected SynapseLinkedIntegrationRuntimeType() { }
    }
    public partial class SynapseMaintenanceWindowTimeRange
    {
        public SynapseMaintenanceWindowTimeRange() { }
        public Azure.ResourceManager.Synapse.Models.SynapseDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.TimeSpan? StartOn { get { throw null; } set { } }
    }
    public partial class SynapseManagedIntegrationRuntime : Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeProperties
    {
        public SynapseManagedIntegrationRuntime() { }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeSsisProperties SsisProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeState? State { get { throw null; } }
        public string TypeManagedVirtualNetworkType { get { throw null; } set { } }
    }
    public partial class SynapseManagedIntegrationRuntimeError
    {
        internal SynapseManagedIntegrationRuntimeError() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class SynapseManagedIntegrationRuntimeNode
    {
        internal SynapseManagedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeError> Errors { get { throw null; } }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseManagedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseManagedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus Available { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus Recycling { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseManagedIntegrationRuntimeOperationResult
    {
        internal SynapseManagedIntegrationRuntimeOperationResult() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ManagedIntegrationRuntimeOperationResultType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public string Result { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class SynapseManagedIntegrationRuntimeStatus : Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatus
    {
        internal SynapseManagedIntegrationRuntimeStatus() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeOperationResult LastOperation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseManagedIntegrationRuntimeError> OtherErrors { get { throw null; } }
    }
    public partial class SynapseManagedVirtualNetworkSettings
    {
        public SynapseManagedVirtualNetworkSettings() { }
        public System.Collections.Generic.IList<string> AllowedAadTenantIdsForLinking { get { throw null; } }
        public bool? EnableLinkedAccessCheckOnTargetResource { get { throw null; } set { } }
        public bool? PreventDataExfiltration { get { throw null; } set { } }
    }
    public partial class SynapseOptimizedAutoscale
    {
        public SynapseOptimizedAutoscale(int version, bool isEnabled, int minimum, int maximum) { }
        public bool IsEnabled { get { throw null; } set { } }
        public int Maximum { get { throw null; } set { } }
        public int Minimum { get { throw null; } set { } }
        public int Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapsePrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapsePrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType MicrosoftSynapseWorkspacesKustoPoolsPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.SynapsePrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapsePrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapsePrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapsePrincipalType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapsePrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapsePrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalType App { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapsePrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapsePrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapsePrincipalType left, Azure.ResourceManager.Synapse.Models.SynapsePrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapsePrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapsePrincipalType left, Azure.ResourceManager.Synapse.Models.SynapsePrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapsePrivateEndpointConnectionProperties
    {
        internal SynapsePrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class SynapsePrivateLinkHubPatch
    {
        public SynapsePrivateLinkHubPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SynapsePrivateLinkResourceProperties
    {
        internal SynapsePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class SynapsePrivateLinkServiceConnectionState
    {
        public SynapsePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseProvisioningState : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseProvisioningState DeleteError { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseProvisioningState left, Azure.ResourceManager.Synapse.Models.SynapseProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseProvisioningState left, Azure.ResourceManager.Synapse.Models.SynapseProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseReadOnlyFollowingDatabase : Azure.ResourceManager.Synapse.SynapseDatabaseData
    {
        public SynapseReadOnlyFollowingDatabase() { }
        public string AttachedDatabaseConfigurationName { get { throw null; } }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public string LeaderClusterResourceId { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapsePrincipalsModificationKind? PrincipalsModificationKind { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } }
        public float? StatisticsSize { get { throw null; } }
    }
    public partial class SynapseReadWriteDatabase : Azure.ResourceManager.Synapse.SynapseDatabaseData
    {
        public SynapseReadWriteDatabase() { }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public bool? IsFollowed { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } set { } }
        public float? StatisticsSize { get { throw null; } }
    }
    public partial class SynapseRecommendedSensitivityLabelUpdate : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseRecommendedSensitivityLabelUpdate() { }
        public string Column { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseRecommendedSensitivityLabelUpdateKind? Op { get { throw null; } set { } }
        public string Schema { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public enum SynapseRecommendedSensitivityLabelUpdateKind
    {
        Enable = 0,
        Disable = 1,
    }
    public partial class SynapseRecommendedSensitivityLabelUpdateOperationListResult
    {
        public SynapseRecommendedSensitivityLabelUpdateOperationListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseRecommendedSensitivityLabelUpdate> Operations { get { throw null; } }
    }
    public enum SynapseReplicationRole
    {
        Primary = 0,
        Secondary = 1,
        NonReadableSecondary = 2,
        Source = 3,
        Copy = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseReplicationState : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseReplicationState CatchUp { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseReplicationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseReplicationState Seeding { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseReplicationState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseReplicationState left, Azure.ResourceManager.Synapse.Models.SynapseReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseReplicationState left, Azure.ResourceManager.Synapse.Models.SynapseReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseResourceMoveDefinition
    {
        public SynapseResourceMoveDefinition(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
    }
    public enum SynapseRestorePointType
    {
        Continuous = 0,
        Discrete = 1,
    }
    public abstract partial class SynapseSecretBase
    {
        protected SynapseSecretBase() { }
    }
    public partial class SynapseSecureString : Azure.ResourceManager.Synapse.Models.SynapseSecretBase
    {
        public SynapseSecureString(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public enum SynapseSecurityAlertPolicyState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class SynapseSelfHostedIntegrationRuntime : Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeProperties
    {
        public SynapseSelfHostedIntegrationRuntime() { }
        public Azure.ResourceManager.Synapse.Models.SynapseLinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
    }
    public partial class SynapseSelfHostedIntegrationRuntimeNode
    {
        internal SynapseSelfHostedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public bool? IsActiveDispatcher { get { throw null; } }
        public System.DateTimeOffset? LastConnectedOn { get { throw null; } }
        public System.DateTimeOffset? LastEndUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStartedOn { get { throw null; } }
        public System.DateTimeOffset? LastStartUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStopOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeUpdateResult? LastUpdateResult { get { throw null; } }
        public string MachineName { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public System.DateTimeOffset? RegisterOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseSelfHostedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseSelfHostedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus InitializeFailed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus Limited { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus Online { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseSelfHostedIntegrationRuntimeStatus : Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeStatus
    {
        internal SynapseSelfHostedIntegrationRuntimeStatus() { }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateEta { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseIntegrationRuntimeInternalChannelEncryptionMode? InternalChannelEncryption { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseLinkedIntegrationRuntime> Links { get { throw null; } }
        public string LocalTimeZoneOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NewerVersions { get { throw null; } }
        public string NodeCommunicationChannelEncryptionMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseSelfHostedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public string PushedVersion { get { throw null; } }
        public System.DateTimeOffset? ScheduledUpdateOn { get { throw null; } }
        public string ServiceRegion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceUrls { get { throw null; } }
        public string TaskQueueId { get { throw null; } }
        public string UpdateDelayOffset { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    public enum SynapseSensitivityLabelRank
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
    }
    public enum SynapseSensitivityLabelSource
    {
        Current = 0,
        Recommended = 1,
    }
    public partial class SynapseSensitivityLabelUpdate : Azure.ResourceManager.Models.ResourceData
    {
        public SynapseSensitivityLabelUpdate() { }
        public string Column { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelUpdateKind? Op { get { throw null; } set { } }
        public string Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.SynapseSensitivityLabelData SensitivityLabel { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public enum SynapseSensitivityLabelUpdateKind
    {
        Set = 0,
        Remove = 1,
    }
    public partial class SynapseSensitivityLabelUpdateListResult
    {
        public SynapseSensitivityLabelUpdateListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SynapseSensitivityLabelUpdate> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseServerKeyType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseServerKeyType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseServerKeyType ServiceManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseServerKeyType left, Azure.ResourceManager.Synapse.Models.SynapseServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseServerKeyType left, Azure.ResourceManager.Synapse.Models.SynapseServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseServerUsage
    {
        internal SynapseServerUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SynapseSku
    {
        public SynapseSku() { }
        public int? Capacity { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseSkuName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseSkuName ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSkuName StorageOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseSkuName left, Azure.ResourceManager.Synapse.Models.SynapseSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseSkuName left, Azure.ResourceManager.Synapse.Models.SynapseSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseSparkConfigurationType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseSparkConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType Artifact { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType File { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType left, Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType left, Azure.ResourceManager.Synapse.Models.SynapseSparkConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseSqlPoolPatch
    {
        public SynapseSqlPoolPatch() { }
        public string Collation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SqlPoolCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SqlPoolStorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SynapseSsisEnvironment : Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadata
    {
        internal SynapseSsisEnvironment() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseSsisVariable> Variables { get { throw null; } }
    }
    public partial class SynapseSsisEnvironmentReference
    {
        internal SynapseSsisEnvironmentReference() { }
        public string EnvironmentFolderName { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public long? Id { get { throw null; } }
        public string ReferenceType { get { throw null; } }
    }
    public partial class SynapseSsisFolder : Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadata
    {
        internal SynapseSsisFolder() { }
    }
    public abstract partial class SynapseSsisObjectMetadata
    {
        protected SynapseSsisObjectMetadata() { }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SynapseSsisObjectMetadataStatusResult
    {
        internal SynapseSsisObjectMetadataStatusResult() { }
        public string Error { get { throw null; } }
        public string Name { get { throw null; } }
        public string Properties { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SynapseSsisPackage : Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadata
    {
        internal SynapseSsisPackage() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseSsisParameter> Parameters { get { throw null; } }
        public long? ProjectId { get { throw null; } }
        public long? ProjectVersion { get { throw null; } }
    }
    public partial class SynapseSsisParameter
    {
        internal SynapseSsisParameter() { }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DesignDefaultValue { get { throw null; } }
        public long? Id { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public bool? IsSensitive { get { throw null; } }
        public string Name { get { throw null; } }
        public string SensitiveDefaultValue { get { throw null; } }
        public bool? ValueSet { get { throw null; } }
        public string ValueType { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class SynapseSsisProject : Azure.ResourceManager.Synapse.Models.SynapseSsisObjectMetadata
    {
        internal SynapseSsisProject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseSsisEnvironmentReference> EnvironmentRefs { get { throw null; } }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SynapseSsisParameter> Parameters { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class SynapseSsisVariable
    {
        internal SynapseSsisVariable() { }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public bool? IsSensitive { get { throw null; } }
        public string Name { get { throw null; } }
        public string SensitiveValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SynapseTableLevelSharingProperties
    {
        public SynapseTableLevelSharingProperties() { }
        public System.Collections.Generic.IList<string> ExternalTablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> ExternalTablesToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> MaterializedViewsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> TablesToInclude { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseTransparentDataEncryptionName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseTransparentDataEncryptionName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName left, Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName left, Azure.ResourceManager.Synapse.Models.SynapseTransparentDataEncryptionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SynapseTransparentDataEncryptionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseVulnerabilityAssessmentName : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseVulnerabilityAssessmentName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName left, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName left, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SynapseVulnerabilityAssessmentPolicyBaselineName
    {
        Master = 0,
        Default = 1,
    }
    public partial class SynapseVulnerabilityAssessmentRecurringScansProperties
    {
        public SynapseVulnerabilityAssessmentRecurringScansProperties() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public bool? EnableEmailToAccountAdmins { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class SynapseVulnerabilityAssessmentScanError
    {
        internal SynapseVulnerabilityAssessmentScanError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseVulnerabilityAssessmentScanState : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseVulnerabilityAssessmentScanState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState Failed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState FailedToRun { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState left, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState left, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynapseVulnerabilityAssessmentScanTriggerType : System.IEquatable<Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynapseVulnerabilityAssessmentScanTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.Synapse.Models.SynapseVulnerabilityAssessmentScanTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseWorkspaceKeyDetails
    {
        public SynapseWorkspaceKeyDetails() { }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class SynapseWorkspacePatch
    {
        public SynapseWorkspacePatch() { }
        public Azure.ResourceManager.Synapse.Models.SynapseEncryptionDetails Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PurviewResourceId { get { throw null; } set { } }
        public string SqlAdministratorLoginPassword { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SynapseWorkspaceRepositoryConfiguration WorkspaceRepositoryConfiguration { get { throw null; } set { } }
    }
    public partial class SynapseWorkspaceRepositoryConfiguration
    {
        public SynapseWorkspaceRepositoryConfiguration() { }
        public string AccountName { get { throw null; } set { } }
        public string CollaborationBranch { get { throw null; } set { } }
        public string HostName { get { throw null; } set { } }
        public string LastCommitId { get { throw null; } set { } }
        public string ProjectName { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RootFolder { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string WorkspaceRepositoryConfigurationType { get { throw null; } set { } }
    }
    public partial class UpdateIntegrationRuntimeNodeContent
    {
        public UpdateIntegrationRuntimeNodeContent() { }
        public int? ConcurrentJobsLimit { get { throw null; } set { } }
    }
    public partial class WorkspaceCustomerManagedKeyDetails
    {
        public WorkspaceCustomerManagedKeyDetails() { }
        public Azure.ResourceManager.Synapse.Models.KekIdentityProperties KekIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseWorkspaceKeyDetails Key { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspacePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspacePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess left, Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess left, Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
