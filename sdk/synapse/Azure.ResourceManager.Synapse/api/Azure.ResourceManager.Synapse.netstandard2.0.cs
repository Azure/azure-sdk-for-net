namespace Azure.ResourceManager.Synapse
{
    public partial class AttachedDatabaseConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>, System.Collections.IEnumerable
    {
        protected AttachedDatabaseConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string attachedDatabaseConfigurationName, Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> Get(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>> GetAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AttachedDatabaseConfigurationData : Azure.ResourceManager.Models.ResourceData
    {
        public AttachedDatabaseConfigurationData() { }
        public System.Collections.Generic.IReadOnlyList<string> AttachedDatabaseNames { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind? DefaultPrincipalsModificationKind { get { throw null; } set { } }
        public string KustoPoolResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.TableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
    }
    public partial class AttachedDatabaseConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AttachedDatabaseConfigurationResource() { }
        public virtual Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string attachedDatabaseConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureADOnlyAuthenticationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>, System.Collections.IEnumerable
    {
        protected AzureADOnlyAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> Get(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>> GetAsync(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureADOnlyAuthenticationData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureADOnlyAuthenticationData() { }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.StateValue? State { get { throw null; } }
    }
    public partial class AzureADOnlyAuthenticationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureADOnlyAuthenticationResource() { }
        public virtual Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BigDataPoolResourceInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>, System.Collections.IEnumerable
    {
        protected BigDataPoolResourceInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bigDataPoolName, Azure.ResourceManager.Synapse.BigDataPoolResourceInfoData info, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bigDataPoolName, Azure.ResourceManager.Synapse.BigDataPoolResourceInfoData info, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> Get(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> GetAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BigDataPoolResourceInfoData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BigDataPoolResourceInfoData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Synapse.Models.AutoPauseProperties AutoPause { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.AutoScaleProperties AutoScale { get { throw null; } set { } }
        public int? CacheSize { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.LibraryInfo> CustomLibraries { get { throw null; } }
        public string DefaultSparkLogFolder { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.DynamicExecutorAllocation DynamicExecutorAllocation { get { throw null; } set { } }
        public bool? IsAutotuneEnabled { get { throw null; } set { } }
        public bool? IsComputeIsolationEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastSucceededTimestamp { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.LibraryRequirements LibraryRequirements { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.NodeSize? NodeSize { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.NodeSizeFamily? NodeSizeFamily { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public bool? SessionLevelPackagesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SparkConfigProperties SparkConfigProperties { get { throw null; } set { } }
        public string SparkEventsFolder { get { throw null; } set { } }
        public string SparkVersion { get { throw null; } set { } }
    }
    public partial class BigDataPoolResourceInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BigDataPoolResourceInfoResource() { }
        public virtual Azure.ResourceManager.Synapse.BigDataPoolResourceInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string bigDataPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> Update(Azure.ResourceManager.Synapse.Models.BigDataPoolResourceInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.BigDataPoolResourceInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ClusterPrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected ClusterPrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterPrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ClusterPrincipalAssignmentData() { }
        public string AadObjectId { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class ClusterPrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterPrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DatabaseResource>, System.Collections.IEnumerable
    {
        protected DatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Synapse.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.Synapse.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.DatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.DatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.DatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.DatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabaseData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabaseData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
    }
    public partial class DatabasePrincipalAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>, System.Collections.IEnumerable
    {
        protected DatabasePrincipalAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string principalAssignmentName, Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> Get(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>> GetAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabasePrincipalAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public DatabasePrincipalAssignmentData() { }
        public string AadObjectId { get { throw null; } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.PrincipalType? PrincipalType { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole? Role { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public string TenantName { get { throw null; } }
    }
    public partial class DatabasePrincipalAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabasePrincipalAssignmentResource() { }
        public virtual Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string databaseName, string principalAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabaseResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabaseResource() { }
        public virtual Azure.ResourceManager.Synapse.DatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult> CheckNameAvailabilityKustoPoolDatabasePrincipalAssignment(Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult>> CheckNameAvailabilityKustoPoolDatabasePrincipalAssignmentAsync(Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult> CheckNameAvailabilityKustoPoolDataConnection(Azure.ResourceManager.Synapse.Models.DataConnectionCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult>> CheckNameAvailabilityKustoPoolDataConnectionAsync(Azure.ResourceManager.Synapse.Models.DataConnectionCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.DataConnectionValidationListResult> DataConnectionValidationKustoPoolDataConnection(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.DataConnectionValidation dataConnectionValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.DataConnectionValidationListResult>> DataConnectionValidationKustoPoolDataConnectionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.DataConnectionValidation dataConnectionValidation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource> GetDatabasePrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource>> GetDatabasePrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentCollection GetDatabasePrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataConnectionResource> GetDataConnection(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataConnectionResource>> GetDataConnectionAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.DataConnectionCollection GetDataConnections() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DataConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DataConnectionResource>, System.Collections.IEnumerable
    {
        protected DataConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Synapse.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataConnectionName, Azure.ResourceManager.Synapse.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataConnectionResource> Get(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.DataConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.DataConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataConnectionResource>> GetAsync(string dataConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.DataConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DataConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.DataConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DataConnectionResource>.GetEnumerator() { throw null; }
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
        public virtual Azure.ResourceManager.Synapse.DataConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName, string databaseName, string dataConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DataConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataMaskingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public DataMaskingPolicyData() { }
        public string ApplicationPrincipals { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.DataMaskingState? DataMaskingState { get { throw null; } set { } }
        public string ExemptPrincipals { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public string MaskingLevel { get { throw null; } }
    }
    public partial class DataMaskingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMaskingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.DataMaskingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataMaskingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DataMaskingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataMaskingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DataMaskingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataMaskingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataMaskingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataMaskingRuleResource> GetDataMaskingRule(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataMaskingRuleResource>> GetDataMaskingRuleAsync(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.DataMaskingRuleCollection GetDataMaskingRules() { throw null; }
    }
    public partial class DataMaskingRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DataMaskingRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DataMaskingRuleResource>, System.Collections.IEnumerable
    {
        protected DataMaskingRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataMaskingRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataMaskingRuleName, Azure.ResourceManager.Synapse.DataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataMaskingRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataMaskingRuleName, Azure.ResourceManager.Synapse.DataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataMaskingRuleResource> Get(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.DataMaskingRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.DataMaskingRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataMaskingRuleResource>> GetAsync(string dataMaskingRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.DataMaskingRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DataMaskingRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.DataMaskingRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DataMaskingRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataMaskingRuleData : Azure.ResourceManager.Models.ResourceData
    {
        public DataMaskingRuleData() { }
        public string AliasName { get { throw null; } set { } }
        public string ColumnName { get { throw null; } set { } }
        public string IdPropertiesId { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.DataMaskingFunction? MaskingFunction { get { throw null; } set { } }
        public string NumberFrom { get { throw null; } set { } }
        public string NumberTo { get { throw null; } set { } }
        public string PrefixSize { get { throw null; } set { } }
        public string ReplacementString { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.DataMaskingRuleState? RuleState { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SuffixSize { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class DataMaskingRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataMaskingRuleResource() { }
        public virtual Azure.ResourceManager.Synapse.DataMaskingRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string dataMaskingRuleName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataMaskingRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataMaskingRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataMaskingRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DataMaskingRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DataMaskingRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataWarehouseUserActivityCollection : Azure.ResourceManager.ArmCollection
    {
        protected DataWarehouseUserActivityCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource> Get(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource>> GetAsync(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataWarehouseUserActivityData : Azure.ResourceManager.Models.ResourceData
    {
        public DataWarehouseUserActivityData() { }
        public int? ActiveQueriesCount { get { throw null; } }
    }
    public partial class DataWarehouseUserActivityResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataWarehouseUserActivityResource() { }
        public virtual Azure.ResourceManager.Synapse.DataWarehouseUserActivityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedSQLminimalTlsSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>, System.Collections.IEnumerable
    {
        protected DedicatedSQLminimalTlsSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName dedicatedSQLminimalTlsSettingsName, Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName dedicatedSQLminimalTlsSettingsName, Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> Get(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>> GetAsync(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedSQLminimalTlsSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public DedicatedSQLminimalTlsSettingData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string MinimalTlsVersion { get { throw null; } set { } }
    }
    public partial class DedicatedSQLminimalTlsSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedSQLminimalTlsSettingResource() { }
        public virtual Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dedicatedSQLminimalTlsSettingsName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionProtectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.EncryptionProtectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.EncryptionProtectorResource>, System.Collections.IEnumerable
    {
        protected EncryptionProtectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.EncryptionProtectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Synapse.EncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.EncryptionProtectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, Azure.ResourceManager.Synapse.EncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.EncryptionProtectorResource> Get(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.EncryptionProtectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.EncryptionProtectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.EncryptionProtectorResource>> GetAsync(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.EncryptionProtectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.EncryptionProtectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.EncryptionProtectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.EncryptionProtectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EncryptionProtectorData : Azure.ResourceManager.Models.ResourceData
    {
        public EncryptionProtectorData() { }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ServerKeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ServerKeyType? ServerKeyType { get { throw null; } set { } }
        public string Subregion { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class EncryptionProtectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EncryptionProtectorResource() { }
        public virtual Azure.ResourceManager.Synapse.EncryptionProtectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.EncryptionProtectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.EncryptionProtectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revalidate(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevalidateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.EncryptionProtectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.EncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.EncryptionProtectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.EncryptionProtectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected ExtendedServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> Get(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtendedServerBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtendedServerBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsDevopsAuditEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ExtendedServerBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedServerBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtendedSqlPoolBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ExtendedSqlPoolBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string PredicateExpression { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ExtendedSqlPoolBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtendedSqlPoolBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GeoBackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected GeoBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Synapse.GeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, Azure.ResourceManager.Synapse.GeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> Get(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GeoBackupPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public GeoBackupPolicyData(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyState state) { }
        public string Kind { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.GeoBackupPolicyState State { get { throw null; } set { } }
        public string StorageType { get { throw null; } }
    }
    public partial class GeoBackupPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GeoBackupPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.GeoBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.GeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.GeoBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationRuntimeResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationRuntimeResource() { }
        public virtual Azure.ResourceManager.Synapse.IntegrationRuntimeResourceData Data { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> Get(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadata(Azure.ResourceManager.Synapse.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SsisObjectMetadata> GetAllIntegrationRuntimeObjectMetadataAsync(Azure.ResourceManager.Synapse.Models.GetSsisObjectMetadataContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>> GetAsync(string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeys> GetIntegrationRuntimeAuthKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeys>> GetIntegrationRuntimeAuthKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeConnectionInfo> GetIntegrationRuntimeConnectionInfo(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeConnectionInfo>> GetIntegrationRuntimeConnectionInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeMonitoringData> GetIntegrationRuntimeMonitoringData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeMonitoringData>> GetIntegrationRuntimeMonitoringDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNode> GetIntegrationRuntimeNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNode>> GetIntegrationRuntimeNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeNodeIPAddress> GetIntegrationRuntimeNodeIpAddres(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeNodeIPAddress>> GetIntegrationRuntimeNodeIpAddresAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatusResponse> GetIntegrationRuntimeStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatusResponse>> GetIntegrationRuntimeStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SsisObjectMetadataStatusResponse> RefreshIntegrationRuntimeObjectMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.SsisObjectMetadataStatusResponse>> RefreshIntegrationRuntimeObjectMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeys> RegenerateIntegrationRuntimeAuthKey(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeys>> RegenerateIntegrationRuntimeAuthKeyAsync(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatusResponse> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatusResponse>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SyncIntegrationRuntimeCredential(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncIntegrationRuntimeCredentialAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> Update(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNode> UpdateIntegrationRuntimeNode(string nodeName, Azure.ResourceManager.Synapse.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNode>> UpdateIntegrationRuntimeNodeAsync(string nodeName, Azure.ResourceManager.Synapse.Models.UpdateIntegrationRuntimeNodeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Upgrade(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpgradeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationRuntimeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>, System.Collections.IEnumerable
    {
        protected IntegrationRuntimeResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.Synapse.IntegrationRuntimeResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationRuntimeName, Azure.ResourceManager.Synapse.IntegrationRuntimeResourceData data, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> Get(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>> GetAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationRuntimeResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public IntegrationRuntimeResourceData(Azure.ResourceManager.Synapse.Models.IntegrationRuntime properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntime Properties { get { throw null; } set { } }
    }
    public partial class IPFirewallRuleInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>, System.Collections.IEnumerable
    {
        protected IPFirewallRuleInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Synapse.IPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleName, Azure.ResourceManager.Synapse.IPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> Get(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>> GetAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IPFirewallRuleInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public IPFirewallRuleInfoData() { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class IPFirewallRuleInfoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IPFirewallRuleInfoResource() { }
        public virtual Azure.ResourceManager.Synapse.IPFirewallRuleInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.IPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.IPFirewallRuleInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.KeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.KeyResource>, System.Collections.IEnumerable
    {
        protected KeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Synapse.KeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.Synapse.KeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.KeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.KeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.KeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.KeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.KeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.KeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KeyData : Azure.ResourceManager.Models.ResourceData
    {
        public KeyData() { }
        public bool? IsActiveCMK { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
    }
    public partial class KeyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KeyResource() { }
        public virtual Azure.ResourceManager.Synapse.KeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KeyResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KeyResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.KeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.KeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KustoPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.KustoPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.KustoPoolResource>, System.Collections.IEnumerable
    {
        protected KustoPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KustoPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kustoPoolName, Azure.ResourceManager.Synapse.KustoPoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KustoPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kustoPoolName, Azure.ResourceManager.Synapse.KustoPoolData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource> Get(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.KustoPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.KustoPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource>> GetAsync(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.KustoPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.KustoPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.KustoPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.KustoPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KustoPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public KustoPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.AzureSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public System.Uri DataIngestionUri { get { throw null; } }
        public bool? EnablePurge { get { throw null; } set { } }
        public bool? EnableStreamingIngest { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.LanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.AzureSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.State? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string WorkspaceUID { get { throw null; } set { } }
    }
    public partial class KustoPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KustoPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.KustoPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.LanguageExtensionsList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.LanguageExtensionsList languageExtensionsToAdd, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult> CheckNameAvailabilityKustoPoolChildResource(Azure.ResourceManager.Synapse.Models.DatabaseCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult>> CheckNameAvailabilityKustoPoolChildResourceAsync(Azure.ResourceManager.Synapse.Models.DatabaseCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult> CheckNameAvailabilityKustoPoolPrincipalAssignment(Azure.ResourceManager.Synapse.Models.ClusterPrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult>> CheckNameAvailabilityKustoPoolPrincipalAssignmentAsync(Azure.ResourceManager.Synapse.Models.ClusterPrincipalAssignmentCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string kustoPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachFollowerDatabases(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.FollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachFollowerDatabasesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.FollowerDatabaseDefinition followerDatabaseToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource> GetAttachedDatabaseConfiguration(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource>> GetAttachedDatabaseConfigurationAsync(string attachedDatabaseConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationCollection GetAttachedDatabaseConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource> GetClusterPrincipalAssignment(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource>> GetClusterPrincipalAssignmentAsync(string principalAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentCollection GetClusterPrincipalAssignments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DatabaseResource> GetDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DatabaseResource>> GetDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.DatabaseCollection GetDatabases() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.FollowerDatabaseDefinition> GetFollowerDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.FollowerDatabaseDefinition> GetFollowerDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.LanguageExtension> GetLanguageExtensions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.LanguageExtension> GetLanguageExtensionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.AzureResourceSku> GetSkusByResource(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.AzureResourceSku> GetSkusByResourceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveLanguageExtensions(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.LanguageExtensionsList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveLanguageExtensionsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.LanguageExtensionsList languageExtensionsToRemove, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KustoPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.KustoPoolPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.KustoPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.KustoPoolPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LibraryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LibraryResource() { }
        public virtual Azure.ResourceManager.Synapse.LibraryResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string libraryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.LibraryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.LibraryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LibraryResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.LibraryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.LibraryResource>, System.Collections.IEnumerable
    {
        protected LibraryResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.LibraryResource> Get(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.LibraryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.LibraryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.LibraryResource>> GetAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.LibraryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.LibraryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.LibraryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.LibraryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LibraryResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public LibraryResourceData() { }
        public string ContainerName { get { throw null; } set { } }
        public string CreatorId { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public string NamePropertiesName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningStatus { get { throw null; } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.DateTimeOffset? UploadedTimestamp { get { throw null; } set { } }
    }
    public partial class MaintenanceWindowData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceWindowData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.MaintenanceWindowTimeRange> TimeRanges { get { throw null; } }
    }
    public partial class MaintenanceWindowOptionData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceWindowOptionData() { }
        public bool? AllowMultipleMaintenanceWindowsPerCycle { get { throw null; } set { } }
        public int? DefaultDurationInMinutes { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.MaintenanceWindowTimeRange> MaintenanceWindowCycles { get { throw null; } }
        public int? MinCycles { get { throw null; } set { } }
        public int? MinDurationInMinutes { get { throw null; } set { } }
        public int? TimeGranularityInMinutes { get { throw null; } set { } }
    }
    public partial class MaintenanceWindowOptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceWindowOptionResource() { }
        public virtual Azure.ResourceManager.Synapse.MaintenanceWindowOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.MaintenanceWindowOptionResource> Get(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.MaintenanceWindowOptionResource>> GetAsync(string maintenanceWindowOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceWindowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceWindowResource() { }
        public virtual Azure.ResourceManager.Synapse.MaintenanceWindowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Synapse.MaintenanceWindowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string maintenanceWindowName, Azure.ResourceManager.Synapse.MaintenanceWindowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.MaintenanceWindowResource> Get(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.MaintenanceWindowResource>> GetAsync(string maintenanceWindowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedIdentitySqlControlSettingsModelData : Azure.ResourceManager.Models.ResourceData
    {
        public ManagedIdentitySqlControlSettingsModelData() { }
        public Azure.ResourceManager.Synapse.Models.ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity GrantSqlControlToManagedIdentity { get { throw null; } set { } }
    }
    public partial class ManagedIdentitySqlControlSettingsModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedIdentitySqlControlSettingsModelResource() { }
        public virtual Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MetadataSyncConfigData : Azure.ResourceManager.Models.ResourceData
    {
        public MetadataSyncConfigData() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? SyncIntervalInMinutes { get { throw null; } set { } }
    }
    public partial class MetadataSyncConfigResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MetadataSyncConfigResource() { }
        public virtual Azure.ResourceManager.Synapse.MetadataSyncConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.MetadataSyncConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.MetadataSyncConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.MetadataSyncConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.MetadataSyncConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.MetadataSyncConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.MetadataSyncConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionForPrivateLinkHubCollection() { }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubData : Azure.ResourceManager.Models.ResourceData
    {
        internal PrivateEndpointConnectionForPrivateLinkHubData() { }
        public Azure.ResourceManager.Synapse.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionForPrivateLinkHubResource() { }
        public virtual Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateLinkHubName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkHubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkHubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.PrivateLinkHubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateLinkHubName, Azure.ResourceManager.Synapse.PrivateLinkHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateLinkHubName, Azure.ResourceManager.Synapse.PrivateLinkHubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> Get(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.PrivateLinkHubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.PrivateLinkHubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> GetAsync(string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.PrivateLinkHubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.PrivateLinkHubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkHubData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PrivateLinkHubData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.PrivateEndpointConnectionForPrivateLinkHubBasic> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } set { } }
    }
    public partial class PrivateLinkHubPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkHubPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateLinkHubName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkHubPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkHubPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkHubResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkHubResource() { }
        public virtual Azure.ResourceManager.Synapse.PrivateLinkHubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateLinkHubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource> GetPrivateEndpointConnectionForPrivateLinkHub(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource>> GetPrivateEndpointConnectionForPrivateLinkHubAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubCollection GetPrivateEndpointConnectionForPrivateLinkHubs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource> GetPrivateLinkHubPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource>> GetPrivateLinkHubPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResourceCollection GetPrivateLinkHubPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> Update(Azure.ResourceManager.Synapse.Models.PrivateLinkHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.PrivateLinkHubPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoverableSqlPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>, System.Collections.IEnumerable
    {
        protected RecoverableSqlPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> Get(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>> GetAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoverableSqlPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public RecoverableSqlPoolData() { }
        public string Edition { get { throw null; } }
        public string ElasticPoolName { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
    }
    public partial class RecoverableSqlPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoverableSqlPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.RecoverableSqlPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ReplicationLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ReplicationLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ReplicationLinkResource>, System.Collections.IEnumerable
    {
        protected ReplicationLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ReplicationLinkResource> Get(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.ReplicationLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.ReplicationLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ReplicationLinkResource>> GetAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.ReplicationLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ReplicationLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.ReplicationLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ReplicationLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public ReplicationLinkData() { }
        public bool? IsTerminationAllowed { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string PartnerDatabase { get { throw null; } }
        public string PartnerLocation { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ReplicationRole? PartnerRole { get { throw null; } }
        public string PartnerServer { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ReplicationMode { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ReplicationState? ReplicationState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ReplicationRole? Role { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class ReplicationLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationLinkResource() { }
        public virtual Azure.ResourceManager.Synapse.ReplicationLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string linkId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ReplicationLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ReplicationLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorableDroppedSqlPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>, System.Collections.IEnumerable
    {
        protected RestorableDroppedSqlPoolCollection() { }
        public virtual Azure.Response<bool> Exists(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> Get(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>> GetAsync(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorableDroppedSqlPoolData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorableDroppedSqlPoolData() { }
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
    public partial class RestorableDroppedSqlPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorableDroppedSqlPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string restorableDroppedSqlPoolId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RestorePointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.RestorePointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.RestorePointResource>, System.Collections.IEnumerable
    {
        protected RestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RestorePointResource> Get(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.RestorePointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.RestorePointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RestorePointResource>> GetAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.RestorePointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.RestorePointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.RestorePointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.RestorePointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RestorePointData : Azure.ResourceManager.Models.ResourceData
    {
        public RestorePointData() { }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? RestorePointCreationOn { get { throw null; } }
        public string RestorePointLabel { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.RestorePointType? RestorePointType { get { throw null; } }
    }
    public partial class RestorePointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RestorePointResource() { }
        public virtual Azure.ResourceManager.Synapse.RestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string restorePointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RestorePointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RestorePointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SensitivityLabelCollection : Azure.ResourceManager.ArmCollection
    {
        protected SensitivityLabelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SensitivityLabelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SensitivityLabelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SensitivityLabelResource> Get(Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SensitivityLabelResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SensitivityLabelData : Azure.ResourceManager.Models.ResourceData
    {
        public SensitivityLabelData() { }
        public string ColumnName { get { throw null; } }
        public string InformationType { get { throw null; } set { } }
        public string InformationTypeId { get { throw null; } set { } }
        public bool? IsDisabled { get { throw null; } }
        public string LabelId { get { throw null; } set { } }
        public string LabelName { get { throw null; } set { } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SensitivityLabelRank? Rank { get { throw null; } set { } }
        public string SchemaName { get { throw null; } }
        public string TableName { get { throw null; } }
    }
    public partial class SensitivityLabelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SensitivityLabelResource() { }
        public virtual Azure.ResourceManager.Synapse.SensitivityLabelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName, string tableName, string columnName, Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SensitivityLabelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SensitivityLabelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SensitivityLabelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SensitivityLabelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SensitivityLabelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerBlobAuditingPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerBlobAuditingPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> Get(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsDevopsAuditEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public int? QueueDelayMs { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected ServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class ServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected ServerVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class ServerVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SparkConfigurationResource() { }
        public virtual Azure.ResourceManager.Synapse.SparkConfigurationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sparkConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SparkConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SparkConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SparkConfigurationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SparkConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SparkConfigurationResource>, System.Collections.IEnumerable
    {
        protected SparkConfigurationResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SparkConfigurationResource> Get(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SparkConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SparkConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SparkConfigurationResource>> GetAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SparkConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SparkConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SparkConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SparkConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SparkConfigurationResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SparkConfigurationResourceData(System.Collections.Generic.IDictionary<string, string> configs) { }
        public System.Collections.Generic.IList<string> Annotations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigMergeRule { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Configs { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Notes { get { throw null; } set { } }
    }
    public partial class SqlPoolBlobAuditingPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolBlobAuditingPolicyData() { }
        public System.Collections.Generic.IList<string> AuditActionsAndGroups { get { throw null; } }
        public bool? IsAzureMonitorTargetEnabled { get { throw null; } set { } }
        public bool? IsStorageSecondaryKeyInUse { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public System.Guid? StorageAccountSubscriptionId { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SqlPoolBlobAuditingPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolBlobAuditingPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolResource>, System.Collections.IEnumerable
    {
        protected SqlPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlPoolName, Azure.ResourceManager.Synapse.SqlPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlPoolName, Azure.ResourceManager.Synapse.SqlPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> Get(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SqlPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SqlPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> GetAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SqlPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SqlPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlPoolColumnCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolColumnResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolColumnResource>, System.Collections.IEnumerable
    {
        protected SqlPoolColumnCollection() { }
        public virtual Azure.Response<bool> Exists(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolColumnResource> Get(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SqlPoolColumnResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SqlPoolColumnResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolColumnResource>> GetAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SqlPoolColumnResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolColumnResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SqlPoolColumnResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolColumnResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlPoolColumnData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolColumnData() { }
        public Azure.ResourceManager.Synapse.Models.ColumnDataType? ColumnType { get { throw null; } set { } }
        public bool? IsComputed { get { throw null; } }
    }
    public partial class SqlPoolColumnResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolColumnResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolColumnData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName, string tableName, string columnName) { throw null; }
        public virtual Azure.Response DisableRecommendationSqlPoolSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableRecommendationSqlPoolSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableRecommendationSqlPoolSensitivityLabel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableRecommendationSqlPoolSensitivityLabelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolColumnResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolColumnResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SensitivityLabelResource> GetSensitivityLabel(Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SensitivityLabelResource>> GetSensitivityLabelAsync(Azure.ResourceManager.Synapse.Models.SensitivityLabelSource sensitivityLabelSource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SensitivityLabelCollection GetSensitivityLabels() { throw null; }
    }
    public partial class SqlPoolConnectionPolicyCollection : Azure.ResourceManager.ArmCollection
    {
        protected SqlPoolConnectionPolicyCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource> Get(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolConnectionPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolConnectionPolicyData() { }
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
    public partial class SqlPoolConnectionPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolConnectionPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SqlPoolData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Collation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class SqlPoolResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.RestorePointResource> CreateSqlPoolRestorePoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.CreateSqlPoolRestorePointDefinition createSqlPoolRestorePointDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.RestorePointResource>> CreateSqlPoolRestorePointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.CreateSqlPoolRestorePointDefinition createSqlPoolRestorePointDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SensitivityLabelResource> GetCurrentSqlPoolSensitivityLabels(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SensitivityLabelResource> GetCurrentSqlPoolSensitivityLabelsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.DataMaskingPolicyResource GetDataMaskingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Synapse.DataWarehouseUserActivityCollection GetDataWarehouseUserActivities() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource> GetDataWarehouseUserActivity(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource>> GetDataWarehouseUserActivityAsync(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName dataWarehouseUserActivityName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyResource GetExtendedSqlPoolBlobAuditingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Synapse.GeoBackupPolicyCollection GetGeoBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.GeoBackupPolicyResource> GetGeoBackupPolicy(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.GeoBackupPolicyResource>> GetGeoBackupPolicyAsync(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName geoBackupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetLocationHeaderResultSqlPoolOperationResult(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetLocationHeaderResultSqlPoolOperationResultAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.MaintenanceWindowResource GetMaintenanceWindow() { throw null; }
        public virtual Azure.ResourceManager.Synapse.MaintenanceWindowOptionResource GetMaintenanceWindowOption() { throw null; }
        public virtual Azure.ResourceManager.Synapse.MetadataSyncConfigResource GetMetadataSyncConfig() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SensitivityLabelResource> GetRecommendedSqlPoolSensitivityLabels(bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SensitivityLabelResource> GetRecommendedSqlPoolSensitivityLabelsAsync(bool? includeDisabledRecommendations = default(bool?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ReplicationLinkResource> GetReplicationLink(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ReplicationLinkResource>> GetReplicationLinkAsync(string linkId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.ReplicationLinkCollection GetReplicationLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RestorePointResource> GetRestorePoint(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RestorePointResource>> GetRestorePointAsync(string restorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.RestorePointCollection GetRestorePoints() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyResource GetSqlPoolBlobAuditingPolicy() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyCollection GetSqlPoolConnectionPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource> GetSqlPoolConnectionPolicy(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource>> GetSqlPoolConnectionPolicyAsync(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName connectionPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SqlPoolOperation> GetSqlPoolOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SqlPoolOperation> GetSqlPoolOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> GetSqlPoolSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>> GetSqlPoolSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolSchemaCollection GetSqlPoolSchemas() { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyCollection GetSqlPoolSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> GetSqlPoolSecurityAlertPolicy(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>> GetSqlPoolSecurityAlertPolicyAsync(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.SqlPoolUsage> GetSqlPoolUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SqlPoolUsage> GetSqlPoolUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> GetSqlPoolVulnerabilityAssessment(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>> GetSqlPoolVulnerabilityAssessmentAsync(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentCollection GetSqlPoolVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> GetTransparentDataEncryption(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>> GetTransparentDataEncryptionAsync(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.TransparentDataEncryptionCollection GetTransparentDataEncryptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkloadGroupResource> GetWorkloadGroup(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkloadGroupResource>> GetWorkloadGroupAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.WorkloadGroupCollection GetWorkloadGroups() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Pause(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> PauseAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Rename(Azure.ResourceManager.Synapse.Models.ResourceMoveDefinition resourceMoveDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RenameAsync(Azure.ResourceManager.Synapse.Models.ResourceMoveDefinition resourceMoveDefinition, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<System.BinaryData> Resume(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<System.BinaryData>> ResumeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> Update(Azure.ResourceManager.Synapse.Models.SqlPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> UpdateAsync(Azure.ResourceManager.Synapse.Models.SqlPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSqlPoolRecommendedSensitivityLabel(Azure.ResourceManager.Synapse.Models.RecommendedSensitivityLabelUpdateList recommendedSensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSqlPoolRecommendedSensitivityLabelAsync(Azure.ResourceManager.Synapse.Models.RecommendedSensitivityLabelUpdateList recommendedSensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateSqlPoolSensitivityLabel(Azure.ResourceManager.Synapse.Models.SensitivityLabelUpdateList sensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateSqlPoolSensitivityLabelAsync(Azure.ResourceManager.Synapse.Models.SensitivityLabelUpdateList sensitivityLabelUpdateList, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>, System.Collections.IEnumerable
    {
        protected SqlPoolSchemaCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlPoolSchemaData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolSchemaData() { }
    }
    public partial class SqlPoolSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolSchemaResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolTableResource> GetSqlPoolTable(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolTableResource>> GetSqlPoolTableAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolTableCollection GetSqlPoolTables() { throw null; }
    }
    public partial class SqlPoolSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected SqlPoolSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> Get(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlPoolSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolSecurityAlertPolicyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public bool? EmailAccountAdmins { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
    }
    public partial class SqlPoolSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.SqlPoolSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolTableCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolTableResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolTableResource>, System.Collections.IEnumerable
    {
        protected SqlPoolTableCollection() { }
        public virtual Azure.Response<bool> Exists(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolTableResource> Get(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SqlPoolTableResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SqlPoolTableResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolTableResource>> GetAsync(string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SqlPoolTableResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolTableResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SqlPoolTableResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolTableResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlPoolTableData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolTableData() { }
    }
    public partial class SqlPoolTableResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolTableResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolTableData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string schemaName, string tableName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolTableResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolTableResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolColumnResource> GetSqlPoolColumn(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolColumnResource>> GetSqlPoolColumnAsync(string columnName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolColumnCollection GetSqlPoolColumns() { throw null; }
    }
    public partial class SqlPoolVulnerabilityAssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>, System.Collections.IEnumerable
    {
        protected SqlPoolVulnerabilityAssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> Get(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>> GetAsync(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlPoolVulnerabilityAssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolVulnerabilityAssessmentData() { }
        public Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentRecurringScansProperties RecurringScans { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageContainerPath { get { throw null; } set { } }
        public string StorageContainerSasKey { get { throw null; } set { } }
    }
    public partial class SqlPoolVulnerabilityAssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolVulnerabilityAssessmentResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource> GetSqlPoolVulnerabilityAssessmentRuleBaseline(string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource>> GetSqlPoolVulnerabilityAssessmentRuleBaselineAsync(string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineCollection GetSqlPoolVulnerabilityAssessmentRuleBaselines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> GetVulnerabilityAssessmentScanRecord(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>> GetVulnerabilityAssessmentScanRecordAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordCollection GetVulnerabilityAssessmentScanRecords() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolVulnerabilityAssessmentRuleBaselineCollection : Azure.ResourceManager.ArmCollection
    {
        protected SqlPoolVulnerabilityAssessmentRuleBaselineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource> Get(string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource>> GetAsync(string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlPoolVulnerabilityAssessmentRuleBaselineData : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolVulnerabilityAssessmentRuleBaselineData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SqlPoolVulnerabilityAssessmentRuleBaselineItem> BaselineResults { get { throw null; } }
    }
    public partial class SqlPoolVulnerabilityAssessmentRuleBaselineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlPoolVulnerabilityAssessmentRuleBaselineResource() { }
        public virtual Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string ruleId, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentPolicyBaselineName baselineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SynapseExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult> CheckNameAvailabilityKustoPool(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.KustoPoolCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.CheckNameResult>> CheckNameAvailabilityKustoPoolAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.Synapse.Models.KustoPoolCheckNameContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.AttachedDatabaseConfigurationResource GetAttachedDatabaseConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource GetAzureADOnlyAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource GetBigDataPoolResourceInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ClusterPrincipalAssignmentResource GetClusterPrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DatabasePrincipalAssignmentResource GetDatabasePrincipalAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DatabaseResource GetDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DataConnectionResource GetDataConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DataMaskingPolicyResource GetDataMaskingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DataMaskingRuleResource GetDataMaskingRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DataWarehouseUserActivityResource GetDataWarehouseUserActivityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource GetDedicatedSQLminimalTlsSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.EncryptionProtectorResource GetEncryptionProtectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource GetExtendedServerBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ExtendedSqlPoolBlobAuditingPolicyResource GetExtendedSqlPoolBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.GeoBackupPolicyResource GetGeoBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.IntegrationRuntimeResource GetIntegrationRuntimeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource GetIPFirewallRuleInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.KeyResource GetKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.Models.Operation> GetKustoOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.Operation> GetKustoOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.KustoPoolResource GetKustoPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.LibraryResource GetLibraryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.MaintenanceWindowOptionResource GetMaintenanceWindowOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.MaintenanceWindowResource GetMaintenanceWindowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelResource GetManagedIdentitySqlControlSettingsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.MetadataSyncConfigResource GetMetadataSyncConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.PrivateEndpointConnectionForPrivateLinkHubResource GetPrivateEndpointConnectionForPrivateLinkHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource> GetPrivateLinkHub(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.PrivateLinkHubResource>> GetPrivateLinkHubAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateLinkHubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.PrivateLinkHubPrivateLinkResource GetPrivateLinkHubPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.PrivateLinkHubResource GetPrivateLinkHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.PrivateLinkHubCollection GetPrivateLinkHubs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.PrivateLinkHubResource> GetPrivateLinkHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.PrivateLinkHubResource> GetPrivateLinkHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.RecoverableSqlPoolResource GetRecoverableSqlPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ReplicationLinkResource GetReplicationLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource GetRestorableDroppedSqlPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.RestorePointResource GetRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SensitivityLabelResource GetSensitivityLabelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource GetServerBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource GetServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource GetServerVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.Models.SkuDescription> GetSkusKustoPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.SkuDescription> GetSkusKustoPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.SparkConfigurationResource GetSparkConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolBlobAuditingPolicyResource GetSqlPoolBlobAuditingPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolColumnResource GetSqlPoolColumnResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolConnectionPolicyResource GetSqlPoolConnectionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolResource GetSqlPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolSchemaResource GetSqlPoolSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolSecurityAlertPolicyResource GetSqlPoolSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolTableResource GetSqlPoolTableResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentResource GetSqlPoolVulnerabilityAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SqlPoolVulnerabilityAssessmentRuleBaselineResource GetSqlPoolVulnerabilityAssessmentRuleBaselineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource GetSynapsePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.TransparentDataEncryptionResource GetTransparentDataEncryptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource GetVulnerabilityAssessmentScanRecordResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkloadClassifierResource GetWorkloadClassifierResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkloadGroupResource GetWorkloadGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkspaceAdministratorResource GetWorkspaceAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource GetWorkspacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Synapse.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Synapse.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Synapse.WorkspaceSqlAdministratorResource GetWorkspaceSqlAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
    public partial class SynapsePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SynapsePrivateLinkResourceData() { }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class TransparentDataEncryptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>, System.Collections.IEnumerable
    {
        protected TransparentDataEncryptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, Azure.ResourceManager.Synapse.TransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, Azure.ResourceManager.Synapse.TransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> Get(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>> GetAsync(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TransparentDataEncryptionData : Azure.ResourceManager.Models.ResourceData
    {
        public TransparentDataEncryptionData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionStatus? Status { get { throw null; } set { } }
    }
    public partial class TransparentDataEncryptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TransparentDataEncryptionResource() { }
        public virtual Azure.ResourceManager.Synapse.TransparentDataEncryptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName transparentDataEncryptionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.TransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.TransparentDataEncryptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.TransparentDataEncryptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VulnerabilityAssessmentScanRecordCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>, System.Collections.IEnumerable
    {
        protected VulnerabilityAssessmentScanRecordCollection() { }
        public virtual Azure.Response<bool> Exists(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> Get(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>> GetAsync(string scanId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VulnerabilityAssessmentScanRecordData : Azure.ResourceManager.Models.ResourceData
    {
        public VulnerabilityAssessmentScanRecordData() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanError> Errors { get { throw null; } }
        public int? NumberOfFailedSecurityChecks { get { throw null; } }
        public string ScanId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState? State { get { throw null; } }
        public string StorageContainerPath { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType? TriggerType { get { throw null; } }
    }
    public partial class VulnerabilityAssessmentScanRecordResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VulnerabilityAssessmentScanRecordResource() { }
        public virtual Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, string scanId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.Models.SqlPoolVulnerabilityAssessmentScansExport> Export(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.Models.SqlPoolVulnerabilityAssessmentScansExport>> ExportAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.VulnerabilityAssessmentScanRecordResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateScan(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateScanAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadClassifierCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkloadClassifierResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkloadClassifierResource>, System.Collections.IEnumerable
    {
        protected WorkloadClassifierCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadClassifierResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Synapse.WorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadClassifierResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadClassifierName, Azure.ResourceManager.Synapse.WorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkloadClassifierResource> Get(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.WorkloadClassifierResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.WorkloadClassifierResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkloadClassifierResource>> GetAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.WorkloadClassifierResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkloadClassifierResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.WorkloadClassifierResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkloadClassifierResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadClassifierData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadClassifierData() { }
        public string Context { get { throw null; } set { } }
        public string EndTime { get { throw null; } set { } }
        public string Importance { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string MemberName { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class WorkloadClassifierResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadClassifierResource() { }
        public virtual Azure.ResourceManager.Synapse.WorkloadClassifierData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string workloadGroupName, string workloadClassifierName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkloadClassifierResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkloadClassifierResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadClassifierResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadClassifierResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkloadClassifierData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkloadGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkloadGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkloadGroupResource>, System.Collections.IEnumerable
    {
        protected WorkloadGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Synapse.WorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadGroupName, Azure.ResourceManager.Synapse.WorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkloadGroupResource> Get(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.WorkloadGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.WorkloadGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkloadGroupResource>> GetAsync(string workloadGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.WorkloadGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkloadGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.WorkloadGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkloadGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadGroupData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkloadGroupData() { }
        public string Importance { get { throw null; } set { } }
        public int? MaxResourcePercent { get { throw null; } set { } }
        public double? MaxResourcePercentPerRequest { get { throw null; } set { } }
        public int? MinResourcePercent { get { throw null; } set { } }
        public double? MinResourcePercentPerRequest { get { throw null; } set { } }
        public int? QueryExecutionTimeout { get { throw null; } set { } }
    }
    public partial class WorkloadGroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadGroupResource() { }
        public virtual Azure.ResourceManager.Synapse.WorkloadGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string sqlPoolName, string workloadGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkloadGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkloadGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkloadClassifierResource> GetWorkloadClassifier(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkloadClassifierResource>> GetWorkloadClassifierAsync(string workloadClassifierName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.WorkloadClassifierCollection GetWorkloadClassifiers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkloadGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkloadGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceAadAdminInfoData : Azure.ResourceManager.Models.ResourceData
    {
        public WorkspaceAadAdminInfoData() { }
        public string AdministratorType { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class WorkspaceAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceAdministratorResource() { }
        public virtual Azure.ResourceManager.Synapse.WorkspaceAadAdminInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Synapse.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Synapse.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.WorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.WorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkspaceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AdlaResourceId { get { throw null; } }
        public bool? AzureADOnlyAuthentication { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConnectivityEndpoints { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.DataLakeStorageAccountDetails DefaultDataLakeStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.EncryptionDetails Encryption { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ExtraProperties { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string InitialWorkspaceAdminObjectId { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public string ManagedVirtualNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PurviewResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Settings { get { throw null; } }
        public string SqlAdministratorLogin { get { throw null; } set { } }
        public string SqlAdministratorLoginPassword { get { throw null; } set { } }
        public bool? TrustedServiceBypassEnabled { get { throw null; } set { } }
        public string VirtualNetworkComputeSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.WorkspaceRepositoryConfiguration WorkspaceRepositoryConfiguration { get { throw null; } set { } }
        public System.Guid? WorkspaceUID { get { throw null; } }
    }
    public partial class WorkspacePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected WorkspacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.Synapse.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource> GetAzureADOnlyAuthentication(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationResource>> GetAzureADOnlyAuthenticationAsync(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName azureADOnlyAuthenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.AzureADOnlyAuthenticationCollection GetAzureADOnlyAuthentications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource> GetBigDataPoolResourceInfo(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.BigDataPoolResourceInfoResource>> GetBigDataPoolResourceInfoAsync(string bigDataPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.BigDataPoolResourceInfoCollection GetBigDataPoolResourceInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource> GetDedicatedSQLminimalTlsSetting(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingResource>> GetDedicatedSQLminimalTlsSettingAsync(string dedicatedSQLminimalTlsSettingsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.DedicatedSQLminimalTlsSettingCollection GetDedicatedSQLminimalTlsSettings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.EncryptionProtectorResource> GetEncryptionProtector(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.EncryptionProtectorResource>> GetEncryptionProtectorAsync(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName encryptionProtectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.EncryptionProtectorCollection GetEncryptionProtectors() { throw null; }
        public virtual Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyCollection GetExtendedServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource> GetExtendedServerBlobAuditingPolicy(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ExtendedServerBlobAuditingPolicyResource>> GetExtendedServerBlobAuditingPolicyAsync(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource> GetIntegrationRuntimeResource(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IntegrationRuntimeResource>> GetIntegrationRuntimeResourceAsync(string integrationRuntimeName, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.IntegrationRuntimeResourceCollection GetIntegrationRuntimeResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource> GetIPFirewallRuleInfo(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.IPFirewallRuleInfoResource>> GetIPFirewallRuleInfoAsync(string ruleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.IPFirewallRuleInfoCollection GetIPFirewallRuleInfos() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KeyResource> GetKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KeyResource>> GetKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.KeyCollection GetKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource> GetKustoPool(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.KustoPoolResource>> GetKustoPoolAsync(string kustoPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.KustoPoolCollection GetKustoPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.LibraryResource> GetLibraryResource(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.LibraryResource>> GetLibraryResourceAsync(string libraryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.LibraryResourceCollection GetLibraryResources() { throw null; }
        public virtual Azure.ResourceManager.Synapse.ManagedIdentitySqlControlSettingsModelResource GetManagedIdentitySqlControlSettingsModel() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource> GetRecoverableSqlPool(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RecoverableSqlPoolResource>> GetRecoverableSqlPoolAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.RecoverableSqlPoolCollection GetRecoverableSqlPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource> GetRestorableDroppedSqlPool(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolResource>> GetRestorableDroppedSqlPoolAsync(string restorableDroppedSqlPoolId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.RestorableDroppedSqlPoolCollection GetRestorableDroppedSqlPools() { throw null; }
        public virtual Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyCollection GetServerBlobAuditingPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource> GetServerBlobAuditingPolicy(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerBlobAuditingPolicyResource>> GetServerBlobAuditingPolicyAsync(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName blobAuditingPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyCollection GetServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource> GetServerSecurityAlertPolicy(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerSecurityAlertPolicyResource>> GetServerSecurityAlertPolicyAsync(Azure.ResourceManager.Synapse.Models.SqlServerSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName vulnerabilityAssessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SparkConfigurationResource> GetSparkConfigurationResource(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SparkConfigurationResource>> GetSparkConfigurationResourceAsync(string sparkConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SparkConfigurationResourceCollection GetSparkConfigurationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource> GetSqlPool(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SqlPoolResource>> GetSqlPoolAsync(string sqlPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SqlPoolCollection GetSqlPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource> GetSynapsePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionResource>> GetSynapsePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.SynapsePrivateEndpointConnectionCollection GetSynapsePrivateEndpointConnections() { throw null; }
        public virtual Azure.ResourceManager.Synapse.WorkspaceAdministratorResource GetWorkspaceAdministrator() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Synapse.Models.ServerUsage> GetWorkspaceManagedSqlServerUsages(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Synapse.Models.ServerUsage> GetWorkspaceManagedSqlServerUsagesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource> GetWorkspacePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspacePrivateLinkResource>> GetWorkspacePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Synapse.WorkspacePrivateLinkResourceCollection GetWorkspacePrivateLinkResources() { throw null; }
        public virtual Azure.ResourceManager.Synapse.WorkspaceSqlAdministratorResource GetWorkspaceSqlAdministrator() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.ReplaceAllFirewallRulesOperationResponse> ReplaceAllIpFirewallRule(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.ReplaceAllIPFirewallRulesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.Models.ReplaceAllFirewallRulesOperationResponse>> ReplaceAllIpFirewallRuleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.ReplaceAllIPFirewallRulesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.Models.WorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceSqlAdministratorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceSqlAdministratorResource() { }
        public virtual Azure.ResourceManager.Synapse.WorkspaceAadAdminInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceSqlAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Synapse.WorkspaceSqlAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Synapse.WorkspaceAadAdminInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Synapse.WorkspaceSqlAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Synapse.WorkspaceSqlAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Synapse.Models
{
    public enum ActualState
    {
        Unknown = 0,
        Enabling = 1,
        Enabled = 2,
        Disabling = 3,
        Disabled = 4,
    }
    public partial class AutoPauseProperties
    {
        public AutoPauseProperties() { }
        public int? DelayInMinutes { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class AutoScaleProperties
    {
        public AutoScaleProperties() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureADOnlyAuthenticationName : System.IEquatable<Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureADOnlyAuthenticationName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName left, Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName left, Azure.ResourceManager.Synapse.Models.AzureADOnlyAuthenticationName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureCapacity
    {
        internal AzureCapacity() { }
        public int Default { get { throw null; } }
        public int Maximum { get { throw null; } }
        public int Minimum { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.AzureScaleType ScaleType { get { throw null; } }
    }
    public partial class AzureResourceSku
    {
        internal AzureResourceSku() { }
        public Azure.ResourceManager.Synapse.Models.AzureCapacity Capacity { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.AzureSku Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureScaleType : System.IEquatable<Azure.ResourceManager.Synapse.Models.AzureScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.AzureScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.AzureScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.AzureScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.AzureScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.AzureScaleType left, Azure.ResourceManager.Synapse.Models.AzureScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.AzureScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.AzureScaleType left, Azure.ResourceManager.Synapse.Models.AzureScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureSku
    {
        public AzureSku(Azure.ResourceManager.Synapse.Models.SynapseSkuName name, Azure.ResourceManager.Synapse.Models.SkuSize size) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SkuSize Size { get { throw null; } set { } }
    }
    public partial class BigDataPoolResourceInfoPatch
    {
        public BigDataPoolResourceInfoPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobAuditingPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobAuditingPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName left, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName left, Azure.ResourceManager.Synapse.Models.BlobAuditingPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum BlobAuditingPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobStorageEventType : System.IEquatable<Azure.ResourceManager.Synapse.Models.BlobStorageEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobStorageEventType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.BlobStorageEventType MicrosoftStorageBlobCreated { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.BlobStorageEventType MicrosoftStorageBlobRenamed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.BlobStorageEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.BlobStorageEventType left, Azure.ResourceManager.Synapse.Models.BlobStorageEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.BlobStorageEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.BlobStorageEventType left, Azure.ResourceManager.Synapse.Models.BlobStorageEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameResult
    {
        internal CheckNameResult() { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.Reason? Reason { get { throw null; } }
    }
    public partial class ClusterPrincipalAssignmentCheckNameContent
    {
        public ClusterPrincipalAssignmentCheckNameContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType PrincipalAssignmentType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterPrincipalRole : System.IEquatable<Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterPrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole AllDatabasesAdmin { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole AllDatabasesViewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole left, Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole left, Azure.ResourceManager.Synapse.Models.ClusterPrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CmdkeySetup : Azure.ResourceManager.Synapse.Models.CustomSetupBase
    {
        public CmdkeySetup(System.BinaryData targetName, System.BinaryData userName, Azure.ResourceManager.Synapse.Models.SecretBase password) { }
        public Azure.ResourceManager.Synapse.Models.SecretBase Password { get { throw null; } set { } }
        public System.BinaryData TargetName { get { throw null; } set { } }
        public System.BinaryData UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ColumnDataType : System.IEquatable<Azure.ResourceManager.Synapse.Models.ColumnDataType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ColumnDataType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Bigint { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Binary { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Bit { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Char { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Date { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Datetime { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Datetime2 { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Datetimeoffset { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Decimal { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Float { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Geography { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Geometry { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Hierarchyid { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Image { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Int { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Money { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Nchar { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Ntext { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Numeric { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Nvarchar { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Real { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Smalldatetime { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Smallint { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Smallmoney { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType SqlVariant { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Sysname { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Text { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Time { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Timestamp { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Tinyint { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Uniqueidentifier { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Varbinary { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Varchar { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ColumnDataType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ColumnDataType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ColumnDataType left, Azure.ResourceManager.Synapse.Models.ColumnDataType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ColumnDataType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ColumnDataType left, Azure.ResourceManager.Synapse.Models.ColumnDataType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComponentSetup : Azure.ResourceManager.Synapse.Models.CustomSetupBase
    {
        public ComponentSetup(string componentName) { }
        public string ComponentName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SecretBase LicenseKey { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Compression : System.IEquatable<Azure.ResourceManager.Synapse.Models.Compression>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Compression(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.Compression GZip { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.Compression None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.Compression other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.Compression left, Azure.ResourceManager.Synapse.Models.Compression right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.Compression (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.Compression left, Azure.ResourceManager.Synapse.Models.Compression right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationType : System.IEquatable<Azure.ResourceManager.Synapse.Models.ConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ConfigurationType Artifact { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ConfigurationType File { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ConfigurationType left, Azure.ResourceManager.Synapse.Models.ConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ConfigurationType left, Azure.ResourceManager.Synapse.Models.ConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.ConnectionPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ConnectionPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName left, Azure.ResourceManager.Synapse.Models.ConnectionPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ConnectionPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ConnectionPolicyName left, Azure.ResourceManager.Synapse.Models.ConnectionPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateMode : System.IEquatable<Azure.ResourceManager.Synapse.Models.CreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateMode(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.CreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.CreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.CreateMode Recovery { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.CreateMode Restore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.CreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.CreateMode left, Azure.ResourceManager.Synapse.Models.CreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.CreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.CreateMode left, Azure.ResourceManager.Synapse.Models.CreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateSqlPoolRestorePointDefinition
    {
        public CreateSqlPoolRestorePointDefinition(string restorePointLabel) { }
        public string RestorePointLabel { get { throw null; } }
    }
    public partial class CustomerManagedKeyDetails
    {
        public CustomerManagedKeyDetails() { }
        public Azure.ResourceManager.Synapse.Models.KekIdentityProperties KekIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.WorkspaceKeyDetails Key { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public abstract partial class CustomSetupBase
    {
        protected CustomSetupBase() { }
    }
    public partial class DatabaseCheckNameContent
    {
        public DatabaseCheckNameContent(string name, Azure.ResourceManager.Synapse.Models.KustoDatabaseResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.KustoDatabaseResourceType ResourceType { get { throw null; } }
    }
    public partial class DatabasePrincipalAssignmentCheckNameContent
    {
        public DatabasePrincipalAssignmentCheckNameContent(string name) { }
        public Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType AssignmentType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabasePrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabasePrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType MicrosoftSynapseWorkspacesKustoPoolsDatabasesPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.DatabasePrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabasePrincipalRole : System.IEquatable<Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabasePrincipalRole(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole Admin { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole Ingestor { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole Monitor { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole UnrestrictedViewer { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole User { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole Viewer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole left, Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole left, Azure.ResourceManager.Synapse.Models.DatabasePrincipalRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataConnectionCheckNameContent
    {
        public DataConnectionCheckNameContent(string name) { }
        public Azure.ResourceManager.Synapse.Models.DataConnectionType ConnectionType { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataConnectionType : System.IEquatable<Azure.ResourceManager.Synapse.Models.DataConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataConnectionType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DataConnectionType MicrosoftSynapseWorkspacesKustoPoolsDatabasesDataConnections { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DataConnectionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DataConnectionType left, Azure.ResourceManager.Synapse.Models.DataConnectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DataConnectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DataConnectionType left, Azure.ResourceManager.Synapse.Models.DataConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataConnectionValidation
    {
        public DataConnectionValidation() { }
        public string DataConnectionName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.DataConnectionData Properties { get { throw null; } set { } }
    }
    public partial class DataConnectionValidationListResult
    {
        internal DataConnectionValidationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.DataConnectionValidationResult> Value { get { throw null; } }
    }
    public partial class DataConnectionValidationResult
    {
        internal DataConnectionValidationResult() { }
        public string ErrorMessage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataFlowComputeType : System.IEquatable<Azure.ResourceManager.Synapse.Models.DataFlowComputeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataFlowComputeType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DataFlowComputeType ComputeOptimized { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DataFlowComputeType General { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DataFlowComputeType MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DataFlowComputeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DataFlowComputeType left, Azure.ResourceManager.Synapse.Models.DataFlowComputeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DataFlowComputeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DataFlowComputeType left, Azure.ResourceManager.Synapse.Models.DataFlowComputeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataLakeStorageAccountDetails
    {
        public DataLakeStorageAccountDetails() { }
        public System.Uri AccountUri { get { throw null; } set { } }
        public bool? CreateManagedPrivateEndpoint { get { throw null; } set { } }
        public string Filesystem { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public enum DataMaskingFunction
    {
        Default = 0,
        CCN = 1,
        Email = 2,
        Number = 3,
        SSN = 4,
        Text = 5,
    }
    public enum DataMaskingRuleState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum DataMaskingState
    {
        Disabled = 0,
        Enabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataWarehouseUserActivityName : System.IEquatable<Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataWarehouseUserActivityName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName left, Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName left, Azure.ResourceManager.Synapse.Models.DataWarehouseUserActivityName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DayOfWeek : System.IEquatable<Azure.ResourceManager.Synapse.Models.DayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DayOfWeek left, Azure.ResourceManager.Synapse.Models.DayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DayOfWeek left, Azure.ResourceManager.Synapse.Models.DayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DedicatedSQLMinimalTlsSettingsName : System.IEquatable<Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DedicatedSQLMinimalTlsSettingsName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName left, Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName left, Azure.ResourceManager.Synapse.Models.DedicatedSQLMinimalTlsSettingsName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultPrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultPrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.DefaultPrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum DesiredState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DynamicExecutorAllocation
    {
        public DynamicExecutorAllocation() { }
        public bool? Enabled { get { throw null; } set { } }
        public int? MaxExecutors { get { throw null; } set { } }
        public int? MinExecutors { get { throw null; } set { } }
    }
    public partial class EncryptionDetails
    {
        public EncryptionDetails() { }
        public Azure.ResourceManager.Synapse.Models.CustomerManagedKeyDetails Cmk { get { throw null; } set { } }
        public bool? DoubleEncryptionEnabled { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionProtectorName : System.IEquatable<Azure.ResourceManager.Synapse.Models.EncryptionProtectorName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionProtectorName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.EncryptionProtectorName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName left, Azure.ResourceManager.Synapse.Models.EncryptionProtectorName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.EncryptionProtectorName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.EncryptionProtectorName left, Azure.ResourceManager.Synapse.Models.EncryptionProtectorName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityReference
    {
        public EntityReference() { }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType? IntegrationRuntimeEntityReferenceType { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
    }
    public partial class EnvironmentVariableSetup : Azure.ResourceManager.Synapse.Models.CustomSetupBase
    {
        public EnvironmentVariableSetup(string variableName, string variableValue) { }
        public string VariableName { get { throw null; } set { } }
        public string VariableValue { get { throw null; } set { } }
    }
    public partial class EventGridDataConnection : Azure.ResourceManager.Synapse.DataConnectionData
    {
        public EventGridDataConnection() { }
        public Azure.ResourceManager.Synapse.Models.BlobStorageEventType? BlobStorageEventType { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.EventGridDataFormat? DataFormat { get { throw null; } set { } }
        public string EventHubResourceId { get { throw null; } set { } }
        public bool? IgnoreFirstRecord { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string StorageAccountResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridDataFormat : System.IEquatable<Azure.ResourceManager.Synapse.Models.EventGridDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Apacheavro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Multijson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat ORC { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat PSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat RAW { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Singlejson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat TSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat TXT { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventGridDataFormat W3Clogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.EventGridDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.EventGridDataFormat left, Azure.ResourceManager.Synapse.Models.EventGridDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.EventGridDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.EventGridDataFormat left, Azure.ResourceManager.Synapse.Models.EventGridDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubDataConnection : Azure.ResourceManager.Synapse.DataConnectionData
    {
        public EventHubDataConnection() { }
        public Azure.ResourceManager.Synapse.Models.Compression? Compression { get { throw null; } set { } }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.EventHubDataFormat? DataFormat { get { throw null; } set { } }
        public string EventHubResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public string ManagedIdentityResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventHubDataFormat : System.IEquatable<Azure.ResourceManager.Synapse.Models.EventHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Apacheavro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Multijson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat ORC { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat PSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat RAW { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Singlejson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat TSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat TXT { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.EventHubDataFormat W3Clogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.EventHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.EventHubDataFormat left, Azure.ResourceManager.Synapse.Models.EventHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.EventHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.EventHubDataFormat left, Azure.ResourceManager.Synapse.Models.EventHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FollowerDatabaseDefinition
    {
        public FollowerDatabaseDefinition(string kustoPoolResourceId, string attachedDatabaseConfigurationName) { }
        public string AttachedDatabaseConfigurationName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } }
        public string KustoPoolResourceId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoBackupPolicyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoBackupPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName left, Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName left, Azure.ResourceManager.Synapse.Models.GeoBackupPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum GeoBackupPolicyState
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class GetSsisObjectMetadataContent
    {
        public GetSsisObjectMetadataContent() { }
        public string MetadataPath { get { throw null; } set { } }
    }
    public partial class IntegrationRuntime
    {
        public IntegrationRuntime() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Description { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeAuthKeyName : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAuthKeyName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName AuthKey1 { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName AuthKey2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeAuthKeys
    {
        internal IntegrationRuntimeAuthKeys() { }
        public string AuthKey1 { get { throw null; } }
        public string AuthKey2 { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeAutoUpdate : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeAutoUpdate(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate Off { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate On { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeComputeProperties
    {
        public IntegrationRuntimeComputeProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeDataFlowProperties DataFlowProperties { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public int? MaxParallelExecutionsPerNode { get { throw null; } set { } }
        public string NodeSize { get { throw null; } set { } }
        public int? NumberOfNodes { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeVNetProperties VNetProperties { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeConnectionInfo
    {
        internal IntegrationRuntimeConnectionInfo() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public string IdentityCertThumbprint { get { throw null; } }
        public bool? IsIdentityCertExprired { get { throw null; } }
        public string PublicKey { get { throw null; } }
        public string ServiceToken { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class IntegrationRuntimeCustomSetupScriptProperties
    {
        public IntegrationRuntimeCustomSetupScriptProperties() { }
        public System.Uri BlobContainerUri { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SecureString SasToken { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataFlowProperties
    {
        public IntegrationRuntimeDataFlowProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public bool? Cleanup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.DataFlowComputeType? ComputeType { get { throw null; } set { } }
        public int? CoreCount { get { throw null; } set { } }
        public int? TimeToLive { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeDataProxyProperties
    {
        public IntegrationRuntimeDataProxyProperties() { }
        public Azure.ResourceManager.Synapse.Models.EntityReference ConnectVia { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.EntityReference StagingLinkedService { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEdition : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEdition(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition Enterprise { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeEntityReferenceType : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeEntityReferenceType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType IntegrationRuntimeReference { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType LinkedServiceReference { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEntityReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeInternalChannelEncryptionMode : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeInternalChannelEncryptionMode(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode NotEncrypted { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode NotSet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode SslEncrypted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeLicenseType : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType BasePrice { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType LicenseIncluded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeMonitoringData
    {
        internal IntegrationRuntimeMonitoringData() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeNodeMonitoringData> Nodes { get { throw null; } }
    }
    public partial class IntegrationRuntimeNodeIPAddress
    {
        internal IntegrationRuntimeNodeIPAddress() { }
        public string IPAddress { get { throw null; } }
    }
    public partial class IntegrationRuntimeNodeMonitoringData
    {
        internal IntegrationRuntimeNodeMonitoringData() { }
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
    public partial class IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeOutboundNetworkDependenciesEndpoint> Endpoints { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesEndpoint
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesEndpoint() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails> EndpointDetails { get { throw null; } }
    }
    public partial class IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails
    {
        internal IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails() { }
        public int? Port { get { throw null; } }
    }
    public partial class IntegrationRuntimeRegenerateKeyContent
    {
        public IntegrationRuntimeRegenerateKeyContent() { }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAuthKeyName? KeyName { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeResourcePatch
    {
        public IntegrationRuntimeResourcePatch() { }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } set { } }
        public string UpdateDelayOffset { get { throw null; } set { } }
    }
    public partial class IntegrationRuntimeSsisCatalogInfo
    {
        public IntegrationRuntimeSsisCatalogInfo() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SecureString CatalogAdminPassword { get { throw null; } set { } }
        public string CatalogAdminUserName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier? CatalogPricingTier { get { throw null; } set { } }
        public string CatalogServerEndpoint { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeSsisCatalogPricingTier : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeSsisCatalogPricingTier(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier PremiumRS { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogPricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeSsisProperties
    {
        public IntegrationRuntimeSsisProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisCatalogInfo CatalogInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeCustomSetupScriptProperties CustomSetupScriptProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeDataProxyProperties DataProxyProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeEdition? Edition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.CustomSetupBase> ExpressCustomSetupProperties { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeLicenseType? LicenseType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeState : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState AccessDenied { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Initial { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Limited { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Offline { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Online { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Started { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Starting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Stopped { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeStatus
    {
        internal IntegrationRuntimeStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState? State { get { throw null; } }
    }
    public partial class IntegrationRuntimeStatusResponse
    {
        internal IntegrationRuntimeStatusResponse() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatus Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationRuntimeUpdateResult : System.IEquatable<Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationRuntimeUpdateResult(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult Fail { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult Succeed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult left, Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationRuntimeVNetProperties
    {
        public IntegrationRuntimeVNetProperties() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> PublicIPs { get { throw null; } }
        public string Subnet { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string VNetId { get { throw null; } set { } }
    }
    public partial class IotHubDataConnection : Azure.ResourceManager.Synapse.DataConnectionData
    {
        public IotHubDataConnection() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IotHubDataFormat? DataFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EventSystemProperties { get { throw null; } }
        public string IotHubResourceId { get { throw null; } set { } }
        public string MappingRuleName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string SharedAccessPolicyName { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotHubDataFormat : System.IEquatable<Azure.ResourceManager.Synapse.Models.IotHubDataFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotHubDataFormat(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Apacheavro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Avro { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat CSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Json { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Multijson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat ORC { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Parquet { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat PSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat RAW { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Scsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Singlejson { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Sohsv { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat TSV { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat Tsve { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat TXT { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.IotHubDataFormat W3Clogfile { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.IotHubDataFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.IotHubDataFormat left, Azure.ResourceManager.Synapse.Models.IotHubDataFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.IotHubDataFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.IotHubDataFormat left, Azure.ResourceManager.Synapse.Models.IotHubDataFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPFirewallRuleProperties
    {
        public IPFirewallRuleProperties() { }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class KekIdentityProperties
    {
        public KekIdentityProperties() { }
        public string UserAssignedIdentity { get { throw null; } set { } }
        public System.BinaryData UseSystemAssignedIdentity { get { throw null; } set { } }
    }
    public enum KustoDatabaseResourceType
    {
        MicrosoftSynapseWorkspacesKustoPoolsDatabases = 0,
        MicrosoftSynapseWorkspacesKustoPoolsAttachedDatabaseConfigurations = 1,
    }
    public partial class KustoPoolCheckNameContent
    {
        public KustoPoolCheckNameContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.KustoPoolType PoolType { get { throw null; } }
    }
    public partial class KustoPoolPatch : Azure.ResourceManager.Models.ResourceData
    {
        public KustoPoolPatch() { }
        public System.Uri DataIngestionUri { get { throw null; } }
        public bool? EnablePurge { get { throw null; } set { } }
        public bool? EnableStreamingIngest { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.LanguageExtension> LanguageExtensionsValue { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.OptimizedAutoscale OptimizedAutoscale { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.AzureSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.State? State { get { throw null; } }
        public string StateReason { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        public string WorkspaceUID { get { throw null; } set { } }
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
    public partial class LanguageExtension
    {
        public LanguageExtension() { }
        public Azure.ResourceManager.Synapse.Models.LanguageExtensionName? LanguageExtensionName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LanguageExtensionName : System.IEquatable<Azure.ResourceManager.Synapse.Models.LanguageExtensionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LanguageExtensionName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.LanguageExtensionName Python { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.LanguageExtensionName R { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.LanguageExtensionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.LanguageExtensionName left, Azure.ResourceManager.Synapse.Models.LanguageExtensionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.LanguageExtensionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.LanguageExtensionName left, Azure.ResourceManager.Synapse.Models.LanguageExtensionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LanguageExtensionsList
    {
        public LanguageExtensionsList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.LanguageExtension> Value { get { throw null; } }
    }
    public partial class LibraryInfo
    {
        public LibraryInfo() { }
        public string ContainerName { get { throw null; } set { } }
        public string CreatorId { get { throw null; } }
        public string LibraryInfoType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningStatus { get { throw null; } }
        public System.DateTimeOffset? UploadedTimestamp { get { throw null; } set { } }
    }
    public partial class LibraryRequirements
    {
        public LibraryRequirements() { }
        public string Content { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class LinkedIntegrationRuntime
    {
        internal LinkedIntegrationRuntime() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public string DataFactoryLocation { get { throw null; } }
        public string DataFactoryName { get { throw null; } }
        public string Name { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
    }
    public partial class LinkedIntegrationRuntimeKeyAuthorization : Azure.ResourceManager.Synapse.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeKeyAuthorization(Azure.ResourceManager.Synapse.Models.SecureString key) { }
        public Azure.ResourceManager.Synapse.Models.SecureString Key { get { throw null; } set { } }
    }
    public partial class LinkedIntegrationRuntimeRbacAuthorization : Azure.ResourceManager.Synapse.Models.LinkedIntegrationRuntimeType
    {
        public LinkedIntegrationRuntimeRbacAuthorization(string resourceId) { }
        public string ResourceId { get { throw null; } set { } }
    }
    public abstract partial class LinkedIntegrationRuntimeType
    {
        protected LinkedIntegrationRuntimeType() { }
    }
    public partial class MaintenanceWindowTimeRange
    {
        public MaintenanceWindowTimeRange() { }
        public Azure.ResourceManager.Synapse.Models.DayOfWeek? DayOfWeek { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
    }
    public partial class ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity
    {
        public ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity() { }
        public Azure.ResourceManager.Synapse.Models.ActualState? ActualState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.DesiredState? DesiredState { get { throw null; } set { } }
    }
    public partial class ManagedIntegrationRuntime : Azure.ResourceManager.Synapse.Models.IntegrationRuntime
    {
        public ManagedIntegrationRuntime() { }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeComputeProperties ComputeProperties { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string ReferenceName { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeSsisProperties SsisProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeState? State { get { throw null; } }
        public string TypeManagedVirtualNetworkType { get { throw null; } set { } }
    }
    public partial class ManagedIntegrationRuntimeError
    {
        internal ManagedIntegrationRuntimeError() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeNode
    {
        internal ManagedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeError> Errors { get { throw null; } }
        public string NodeId { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus Available { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus Recycling { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIntegrationRuntimeOperationResult
    {
        internal ManagedIntegrationRuntimeOperationResult() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ManagedIntegrationRuntimeOperationResultType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Parameters { get { throw null; } }
        public string Result { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
    }
    public partial class ManagedIntegrationRuntimeStatus : Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatus
    {
        internal ManagedIntegrationRuntimeStatus() { }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeOperationResult LastOperation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.ManagedIntegrationRuntimeError> OtherErrors { get { throw null; } }
    }
    public partial class ManagedVirtualNetworkSettings
    {
        public ManagedVirtualNetworkSettings() { }
        public System.Collections.Generic.IList<string> AllowedAadTenantIdsForLinking { get { throw null; } }
        public bool? LinkedAccessCheckOnTargetResource { get { throw null; } set { } }
        public bool? PreventDataExfiltration { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagementOperationState : System.IEquatable<Azure.ResourceManager.Synapse.Models.ManagementOperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagementOperationState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ManagementOperationState CancelInProgress { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagementOperationState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagementOperationState Failed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagementOperationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagementOperationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ManagementOperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ManagementOperationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ManagementOperationState left, Azure.ResourceManager.Synapse.Models.ManagementOperationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ManagementOperationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ManagementOperationState left, Azure.ResourceManager.Synapse.Models.ManagementOperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeSize : System.IEquatable<Azure.ResourceManager.Synapse.Models.NodeSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeSize(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.NodeSize Large { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSize Medium { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSize None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSize Small { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSize XLarge { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSize XXLarge { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSize XXXLarge { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.NodeSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.NodeSize left, Azure.ResourceManager.Synapse.Models.NodeSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.NodeSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.NodeSize left, Azure.ResourceManager.Synapse.Models.NodeSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeSizeFamily : System.IEquatable<Azure.ResourceManager.Synapse.Models.NodeSizeFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeSizeFamily(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.NodeSizeFamily HardwareAcceleratedFpga { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSizeFamily HardwareAcceleratedGPU { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSizeFamily MemoryOptimized { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.NodeSizeFamily None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.NodeSizeFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.NodeSizeFamily left, Azure.ResourceManager.Synapse.Models.NodeSizeFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.NodeSizeFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.NodeSizeFamily left, Azure.ResourceManager.Synapse.Models.NodeSizeFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.Synapse.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OptimizedAutoscale
    {
        public OptimizedAutoscale(int version, bool isEnabled, int minimum, int maximum) { }
        public bool IsEnabled { get { throw null; } set { } }
        public int Maximum { get { throw null; } set { } }
        public int Minimum { get { throw null; } set { } }
        public int Version { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalAssignmentType : System.IEquatable<Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType MicrosoftSynapseWorkspacesKustoPoolsPrincipalAssignments { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType left, Azure.ResourceManager.Synapse.Models.PrincipalAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalsModificationKind : System.IEquatable<Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalsModificationKind(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind None { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind Replace { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind Union { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind left, Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrincipalType : System.IEquatable<Azure.ResourceManager.Synapse.Models.PrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.PrincipalType App { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.PrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.PrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.PrincipalType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.PrincipalType left, Azure.ResourceManager.Synapse.Models.PrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.PrincipalType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.PrincipalType left, Azure.ResourceManager.Synapse.Models.PrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionForPrivateLinkHubBasic
    {
        internal PrivateEndpointConnectionForPrivateLinkHubBasic() { }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        internal PrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Synapse.Models.SynapsePrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class PrivateLinkHubPatch
    {
        public PrivateLinkHubPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Synapse.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ProvisioningState DeleteError { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ProvisioningState left, Azure.ResourceManager.Synapse.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ProvisioningState left, Azure.ResourceManager.Synapse.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReadOnlyFollowingDatabase : Azure.ResourceManager.Synapse.DatabaseData
    {
        public ReadOnlyFollowingDatabase() { }
        public string AttachedDatabaseConfigurationName { get { throw null; } }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public string LeaderClusterResourceId { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.PrincipalsModificationKind? PrincipalsModificationKind { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } }
        public float? StatisticsSize { get { throw null; } }
    }
    public partial class ReadWriteDatabase : Azure.ResourceManager.Synapse.DatabaseData
    {
        public ReadWriteDatabase() { }
        public System.TimeSpan? HotCachePeriod { get { throw null; } set { } }
        public bool? IsFollowed { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan? SoftDeletePeriod { get { throw null; } set { } }
        public float? StatisticsSize { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Reason : System.IEquatable<Azure.ResourceManager.Synapse.Models.Reason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Reason(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.Reason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.Reason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.Reason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.Reason left, Azure.ResourceManager.Synapse.Models.Reason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.Reason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.Reason left, Azure.ResourceManager.Synapse.Models.Reason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendedSensitivityLabelUpdate : Azure.ResourceManager.Models.ResourceData
    {
        public RecommendedSensitivityLabelUpdate() { }
        public string Column { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.RecommendedSensitivityLabelUpdateKind? Op { get { throw null; } set { } }
        public string Schema { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public enum RecommendedSensitivityLabelUpdateKind
    {
        Enable = 0,
        Disable = 1,
    }
    public partial class RecommendedSensitivityLabelUpdateList
    {
        public RecommendedSensitivityLabelUpdateList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.RecommendedSensitivityLabelUpdate> Operations { get { throw null; } }
    }
    public partial class ReplaceAllFirewallRulesOperationResponse
    {
        internal ReplaceAllFirewallRulesOperationResponse() { }
        public string OperationId { get { throw null; } }
    }
    public partial class ReplaceAllIPFirewallRulesContent
    {
        public ReplaceAllIPFirewallRulesContent() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Synapse.Models.IPFirewallRuleProperties> IPFirewallRules { get { throw null; } }
    }
    public enum ReplicationRole
    {
        Primary = 0,
        Secondary = 1,
        NonReadableSecondary = 2,
        Source = 3,
        Copy = 4,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationState : System.IEquatable<Azure.ResourceManager.Synapse.Models.ReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ReplicationState CatchUP { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ReplicationState Pending { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ReplicationState Seeding { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ReplicationState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ReplicationState left, Azure.ResourceManager.Synapse.Models.ReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ReplicationState left, Azure.ResourceManager.Synapse.Models.ReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMoveDefinition
    {
        public ResourceMoveDefinition(string id) { }
        public string Id { get { throw null; } }
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
    public enum RestorePointType
    {
        Continuous = 0,
        Discrete = 1,
    }
    public abstract partial class SecretBase
    {
        protected SecretBase() { }
    }
    public partial class SecureString : Azure.ResourceManager.Synapse.Models.SecretBase
    {
        public SecureString(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public enum SecurityAlertPolicyState
    {
        New = 0,
        Enabled = 1,
        Disabled = 2,
    }
    public partial class SelfHostedIntegrationRuntime : Azure.ResourceManager.Synapse.Models.IntegrationRuntime
    {
        public SelfHostedIntegrationRuntime() { }
        public Azure.ResourceManager.Synapse.Models.LinkedIntegrationRuntimeType LinkedInfo { get { throw null; } set { } }
    }
    public partial class SelfHostedIntegrationRuntimeNode
    {
        internal SelfHostedIntegrationRuntimeNode() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public int? ConcurrentJobsLimit { get { throw null; } }
        public System.DateTimeOffset? ExpiryOn { get { throw null; } }
        public System.Uri HostServiceUri { get { throw null; } }
        public bool? IsActiveDispatcher { get { throw null; } }
        public System.DateTimeOffset? LastConnectOn { get { throw null; } }
        public System.DateTimeOffset? LastEndUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStartOn { get { throw null; } }
        public System.DateTimeOffset? LastStartUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastStopOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeUpdateResult? LastUpdateResult { get { throw null; } }
        public string MachineName { get { throw null; } }
        public int? MaxConcurrentJobs { get { throw null; } }
        public string NodeName { get { throw null; } }
        public System.DateTimeOffset? RegisterOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SelfHostedIntegrationRuntimeNodeStatus : System.IEquatable<Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SelfHostedIntegrationRuntimeNodeStatus(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus InitializeFailed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus Initializing { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus Limited { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus NeedRegistration { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus Offline { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus Online { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus left, Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNodeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SelfHostedIntegrationRuntimeStatus : Azure.ResourceManager.Synapse.Models.IntegrationRuntimeStatus
    {
        internal SelfHostedIntegrationRuntimeStatus() { }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeAutoUpdate? AutoUpdate { get { throw null; } }
        public System.DateTimeOffset? AutoUpdateETA { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public System.DateTimeOffset? CreateOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.IntegrationRuntimeInternalChannelEncryptionMode? InternalChannelEncryption { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.LinkedIntegrationRuntime> Links { get { throw null; } }
        public string LocalTimeZoneOffset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> NewerVersions { get { throw null; } }
        public string NodeCommunicationChannelEncryptionMode { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SelfHostedIntegrationRuntimeNode> Nodes { get { throw null; } }
        public string PushedVersion { get { throw null; } }
        public System.DateTimeOffset? ScheduledUpdateOn { get { throw null; } }
        public string ServiceRegion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceUrls { get { throw null; } }
        public string TaskQueueId { get { throw null; } }
        public string UpdateDelayOffset { get { throw null; } }
        public string Version { get { throw null; } }
        public string VersionStatus { get { throw null; } }
    }
    public enum SensitivityLabelRank
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Critical = 4,
    }
    public enum SensitivityLabelSource
    {
        Current = 0,
        Recommended = 1,
    }
    public partial class SensitivityLabelUpdate : Azure.ResourceManager.Models.ResourceData
    {
        public SensitivityLabelUpdate() { }
        public string Column { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SensitivityLabelUpdateKind? Op { get { throw null; } set { } }
        public string Schema { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.SensitivityLabelData SensitivityLabel { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
    }
    public enum SensitivityLabelUpdateKind
    {
        Set = 0,
        Remove = 1,
    }
    public partial class SensitivityLabelUpdateList
    {
        public SensitivityLabelUpdateList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Synapse.Models.SensitivityLabelUpdate> Operations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerKeyType : System.IEquatable<Azure.ResourceManager.Synapse.Models.ServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.ServerKeyType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.ServerKeyType ServiceManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.ServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.ServerKeyType left, Azure.ResourceManager.Synapse.Models.ServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.ServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.ServerKeyType left, Azure.ResourceManager.Synapse.Models.ServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServerUsage
    {
        internal ServerUsage() { }
        public double? CurrentValue { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? Limit { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class SkuDescription
    {
        internal SkuDescription() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SkuLocationInfoItem> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
    }
    public partial class SkuLocationInfoItem
    {
        internal SkuLocationInfoItem() { }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuSize : System.IEquatable<Azure.ResourceManager.Synapse.Models.SkuSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuSize(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.SkuSize ExtraSmall { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SkuSize Large { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SkuSize Medium { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.SkuSize Small { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.SkuSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.SkuSize left, Azure.ResourceManager.Synapse.Models.SkuSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.SkuSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.SkuSize left, Azure.ResourceManager.Synapse.Models.SkuSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SparkConfigProperties
    {
        public SparkConfigProperties() { }
        public Azure.ResourceManager.Synapse.Models.ConfigurationType? ConfigurationType { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class SqlPoolOperation : Azure.ResourceManager.Models.ResourceData
    {
        public SqlPoolOperation() { }
        public string DatabaseName { get { throw null; } }
        public string Description { get { throw null; } }
        public int? ErrorCode { get { throw null; } }
        public string ErrorDescription { get { throw null; } }
        public int? ErrorSeverity { get { throw null; } }
        public System.DateTimeOffset? EstimatedCompletionOn { get { throw null; } }
        public bool? IsCancellable { get { throw null; } }
        public bool? IsUserError { get { throw null; } }
        public string Operation { get { throw null; } }
        public string OperationFriendlyName { get { throw null; } }
        public int? PercentComplete { get { throw null; } }
        public string ServerName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.ManagementOperationState? State { get { throw null; } }
    }
    public partial class SqlPoolPatch
    {
        public SqlPoolPatch() { }
        public string Collation { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public long? MaxSizeBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } set { } }
        public string RecoverableDatabaseId { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.SynapseSku Sku { get { throw null; } set { } }
        public System.DateTimeOffset? SourceDatabaseDeletionOn { get { throw null; } set { } }
        public string SourceDatabaseId { get { throw null; } set { } }
        public string Status { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class SsisEnvironment : Azure.ResourceManager.Synapse.Models.SsisObjectMetadata
    {
        internal SsisEnvironment() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SsisVariable> Variables { get { throw null; } }
    }
    public partial class SsisEnvironmentReference
    {
        internal SsisEnvironmentReference() { }
        public string EnvironmentFolderName { get { throw null; } }
        public string EnvironmentName { get { throw null; } }
        public long? Id { get { throw null; } }
        public string ReferenceType { get { throw null; } }
    }
    public partial class SsisFolder : Azure.ResourceManager.Synapse.Models.SsisObjectMetadata
    {
        internal SsisFolder() { }
    }
    public abstract partial class SsisObjectMetadata
    {
        protected SsisObjectMetadata() { }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class SsisObjectMetadataStatusResponse
    {
        internal SsisObjectMetadataStatusResponse() { }
        public string Error { get { throw null; } }
        public string Name { get { throw null; } }
        public string Properties { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class SsisPackage : Azure.ResourceManager.Synapse.Models.SsisObjectMetadata
    {
        internal SsisPackage() { }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SsisParameter> Parameters { get { throw null; } }
        public long? ProjectId { get { throw null; } }
        public long? ProjectVersion { get { throw null; } }
    }
    public partial class SsisParameter
    {
        internal SsisParameter() { }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DesignDefaultValue { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Required { get { throw null; } }
        public bool? Sensitive { get { throw null; } }
        public string SensitiveDefaultValue { get { throw null; } }
        public bool? ValueSet { get { throw null; } }
        public string ValueType { get { throw null; } }
        public string Variable { get { throw null; } }
    }
    public partial class SsisProject : Azure.ResourceManager.Synapse.Models.SsisObjectMetadata
    {
        internal SsisProject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SsisEnvironmentReference> EnvironmentRefs { get { throw null; } }
        public long? FolderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Synapse.Models.SsisParameter> Parameters { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class SsisVariable
    {
        internal SsisVariable() { }
        public string DataType { get { throw null; } }
        public string Description { get { throw null; } }
        public long? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? Sensitive { get { throw null; } }
        public string SensitiveValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.Synapse.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.State Creating { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Deleted { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Deleting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Running { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Starting { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Stopped { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Stopping { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Unavailable { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.State Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.State left, Azure.ResourceManager.Synapse.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.State left, Azure.ResourceManager.Synapse.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StateValue : System.IEquatable<Azure.ResourceManager.Synapse.Models.StateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StateValue(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.StateValue Consistent { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.StateValue InConsistent { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.StateValue Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.StateValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.StateValue left, Azure.ResourceManager.Synapse.Models.StateValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.StateValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.StateValue left, Azure.ResourceManager.Synapse.Models.StateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAccountType : System.IEquatable<Azure.ResourceManager.Synapse.Models.StorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.StorageAccountType GRS { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.StorageAccountType LRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.StorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.StorageAccountType left, Azure.ResourceManager.Synapse.Models.StorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.StorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.StorageAccountType left, Azure.ResourceManager.Synapse.Models.StorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransparentDataEncryptionName : System.IEquatable<Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransparentDataEncryptionName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName Current { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName left, Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName left, Azure.ResourceManager.Synapse.Models.TransparentDataEncryptionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TransparentDataEncryptionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class UpdateIntegrationRuntimeNodeContent
    {
        public UpdateIntegrationRuntimeNodeContent() { }
        public int? ConcurrentJobsLimit { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentName : System.IEquatable<Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentName(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName left, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName left, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum VulnerabilityAssessmentPolicyBaselineName
    {
        Master = 0,
        Default = 1,
    }
    public partial class VulnerabilityAssessmentRecurringScansProperties
    {
        public VulnerabilityAssessmentRecurringScansProperties() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public bool? EmailSubscriptionAdmins { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
    }
    public partial class VulnerabilityAssessmentScanError
    {
        internal VulnerabilityAssessmentScanError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentScanState : System.IEquatable<Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentScanState(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState Failed { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState FailedToRun { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState left, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState left, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VulnerabilityAssessmentScanTriggerType : System.IEquatable<Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VulnerabilityAssessmentScanTriggerType(string value) { throw null; }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType OnDemand { get { throw null; } }
        public static Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType Recurring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType left, Azure.ResourceManager.Synapse.Models.VulnerabilityAssessmentScanTriggerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceKeyDetails
    {
        public WorkspaceKeyDetails() { }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class WorkspacePatch
    {
        public WorkspacePatch() { }
        public Azure.ResourceManager.Synapse.Models.EncryptionDetails Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Synapse.Models.ManagedVirtualNetworkSettings ManagedVirtualNetworkSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.WorkspacePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string PurviewResourceId { get { throw null; } set { } }
        public string SqlAdministratorLoginPassword { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Synapse.Models.WorkspaceRepositoryConfiguration WorkspaceRepositoryConfiguration { get { throw null; } set { } }
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
    public partial class WorkspaceRepositoryConfiguration
    {
        public WorkspaceRepositoryConfiguration() { }
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
}
