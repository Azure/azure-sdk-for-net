namespace Azure.ResourceManager.DataLakeAnalytics
{
    public partial class ComputePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>, System.Collections.IEnumerable
    {
        protected ComputePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string computePolicyName, Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string computePolicyName, Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> Get(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>> GetAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ComputePolicyData : Azure.ResourceManager.Models.ResourceData
    {
        internal ComputePolicyData() { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } }
        public int? MinPriorityPerJob { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType? ObjectType { get { throw null; } }
    }
    public partial class ComputePolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputePolicyResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.ComputePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string computePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> Update(Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>> UpdateAsync(Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeAnalyticsAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>, System.Collections.IEnumerable
    {
        protected DataLakeAnalyticsAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsAccountData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsAccountData() { }
        public System.Guid? AccountId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyData> ComputePolicies { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.TierType? CurrentTier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData> DataLakeStoreAccounts { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DebugDataAccessLevel? DebugDataAccessLevel { get { throw null; } }
        public string DefaultDataLakeStoreAccount { get { throw null; } }
        public string DefaultDataLakeStoreAccountType { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.FirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleData> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.FirewallState? FirewallState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.Models.HiveMetastore> HiveMetastores { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public int? MaxActiveJobCountPerUser { get { throw null; } }
        public int? MaxDegreeOfParallelism { get { throw null; } }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } }
        public int? MaxJobCount { get { throw null; } }
        public int? MaxJobRunningTimeInMin { get { throw null; } }
        public int? MaxQueuedJobCountPerUser { get { throw null; } }
        public int? MinPriorityPerJob { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.TierType? NewTier { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData> PublicDataLakeStoreAccounts { get { throw null; } }
        public int? QueryStoreRetention { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationData> StorageAccounts { get { throw null; } }
        public int? SystemMaxDegreeOfParallelism { get { throw null; } }
        public int? SystemMaxJobCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeAnalyticsAccountResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationCollection GetAllDataLakeStoreAccountInformation() { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationCollection GetAllStorageAccountInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.ComputePolicyCollection GetComputePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource> GetComputePolicy(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource>> GetComputePolicyAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetDataLakeStoreAccountInformation(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>> GetDataLakeStoreAccountInformationAsync(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> GetStorageAccountInformation(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>> GetStorageAccountInformationAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataLakeAnalyticsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.NameAvailabilityInformation> CheckNameAvailabilityAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.NameAvailabilityInformation>> CheckNameAvailabilityAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.CapabilityInformation> GetCapabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.CapabilityInformation>> GetCapabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.ComputePolicyResource GetComputePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> GetDataLakeAnalyticsAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetDataLakeAnalyticsAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource GetDataLakeAnalyticsAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountCollection GetDataLakeAnalyticsAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource GetDataLakeStoreAccountInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource GetStorageAccountInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource GetStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DataLakeStoreAccountInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>, System.Collections.IEnumerable
    {
        protected DataLakeStoreAccountInformationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string dataLakeStoreAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataLakeStoreAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> Get(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>> GetAsync(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreAccountInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreAccountInformationData() { }
        public string Suffix { get { throw null; } }
    }
    public partial class DataLakeStoreAccountInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeStoreAccountInformationResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string dataLakeStoreAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        internal FirewallRuleData() { }
        public string EndIPAddress { get { throw null; } }
        public string StartIPAddress { get { throw null; } }
    }
    public partial class FirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FirewallRuleResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource> Update(Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.FirewallRuleResource>> UpdateAsync(Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>, System.Collections.IEnumerable
    {
        protected StorageAccountInformationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> Get(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>> GetAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAccountInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal StorageAccountInformationData() { }
        public string Suffix { get { throw null; } }
    }
    public partial class StorageAccountInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAccountInformationResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string storageAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageAccountInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> GetStorageContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>> GetStorageContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.StorageContainerCollection GetStorageContainers() { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountInformationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountInformationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>, System.Collections.IEnumerable
    {
        protected StorageContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageContainerData : Azure.ResourceManager.Models.ResourceData
    {
        internal StorageContainerData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class StorageContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageContainerResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.StorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string storageAccountName, string containerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.StorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.SasTokenInformation> GetSasTokens(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.SasTokenInformation> GetSasTokensAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataLakeAnalytics.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AADObjectType : System.IEquatable<Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AADObjectType(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType Group { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType left, Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType left, Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddDataLakeStoreWithAccountParameters
    {
        public AddDataLakeStoreWithAccountParameters(string name) { }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class AddStorageAccountWithAccountParameters
    {
        public AddStorageAccountWithAccountParameters(string name, string accessKey) { }
        public string AccessKey { get { throw null; } }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class CapabilityInformation
    {
        internal CapabilityInformation() { }
        public int? AccountCount { get { throw null; } }
        public int? MaxAccountCount { get { throw null; } }
        public bool? MigrationState { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState? State { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name, Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityParametersType : System.IEquatable<Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityParametersType(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType MicrosoftDataLakeAnalyticsAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType left, Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType left, Azure.ResourceManager.DataLakeAnalytics.Models.CheckNameAvailabilityParametersType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputePolicyCreateOrUpdateContent
    {
        public ComputePolicyCreateOrUpdateContent(System.Guid objectId, Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType objectType) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType ObjectType { get { throw null; } }
    }
    public partial class ComputePolicyPatch
    {
        public ComputePolicyPatch() { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType? ObjectType { get { throw null; } set { } }
    }
    public partial class CreateComputePolicyWithAccountParameters
    {
        public CreateComputePolicyWithAccountParameters(string name, System.Guid objectId, Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType objectType) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType ObjectType { get { throw null; } }
    }
    public partial class CreateFirewallRuleWithAccountParameters
    {
        public CreateFirewallRuleWithAccountParameters(string name, string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartIPAddress { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountBasic : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsAccountBasic() { }
        public System.Guid? AccountId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountCreateOrUpdateContent
    {
        public DataLakeAnalyticsAccountCreateOrUpdateContent(Azure.Core.AzureLocation location, string defaultDataLakeStoreAccount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.AddDataLakeStoreWithAccountParameters> dataLakeStoreAccounts) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.CreateComputePolicyWithAccountParameters> ComputePolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.AddDataLakeStoreWithAccountParameters> DataLakeStoreAccounts { get { throw null; } }
        public string DefaultDataLakeStoreAccount { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.FirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.CreateFirewallRuleWithAccountParameters> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.FirewallState? FirewallState { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public int? MaxDegreeOfParallelism { get { throw null; } set { } }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MaxJobCount { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.TierType? NewTier { get { throw null; } set { } }
        public int? QueryStoreRetention { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.AddStorageAccountWithAccountParameters> StorageAccounts { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountPatch
    {
        public DataLakeAnalyticsAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.UpdateComputePolicyWithAccountParameters> ComputePolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.UpdateDataLakeStoreWithAccountParameters> DataLakeStoreAccounts { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.FirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.UpdateFirewallRuleWithAccountParameters> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.FirewallState? FirewallState { get { throw null; } set { } }
        public int? MaxDegreeOfParallelism { get { throw null; } set { } }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MaxJobCount { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.TierType? NewTier { get { throw null; } set { } }
        public int? QueryStoreRetention { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.UpdateStorageAccountWithAccountParameters> StorageAccounts { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public enum DataLakeAnalyticsAccountState
    {
        Active = 0,
        Suspended = 1,
    }
    public enum DataLakeAnalyticsAccountStatus
    {
        Failed = 0,
        Creating = 1,
        Running = 2,
        Succeeded = 3,
        Patching = 4,
        Suspending = 5,
        Resuming = 6,
        Deleting = 7,
        Deleted = 8,
        Undeleting = 9,
        Canceled = 10,
    }
    public partial class DataLakeStoreAccountInformationCreateOrUpdateContent
    {
        public DataLakeStoreAccountInformationCreateOrUpdateContent() { }
        public string Suffix { get { throw null; } set { } }
    }
    public enum DebugDataAccessLevel
    {
        None = 0,
        All = 1,
        Customer = 2,
    }
    public enum FirewallAllowAzureIPsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class FirewallRuleCreateOrUpdateContent
    {
        public FirewallRuleCreateOrUpdateContent(string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } }
        public string StartIPAddress { get { throw null; } }
    }
    public partial class FirewallRulePatch
    {
        public FirewallRulePatch() { }
        public string EndIPAddress { get { throw null; } set { } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public enum FirewallState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class HiveMetastore : Azure.ResourceManager.Models.ResourceData
    {
        internal HiveMetastore() { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.NestedResourceProvisioningState? NestedResourceProvisioningState { get { throw null; } }
        public string Password { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public System.Uri ServerUri { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class NameAvailabilityInformation
    {
        internal NameAvailabilityInformation() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public enum NestedResourceProvisioningState
    {
        Succeeded = 0,
        Canceled = 1,
        Failed = 2,
    }
    public partial class SasTokenInformation
    {
        internal SasTokenInformation() { }
        public string AccessToken { get { throw null; } }
    }
    public partial class StorageAccountInformationCreateOrUpdateContent
    {
        public StorageAccountInformationCreateOrUpdateContent(string accessKey) { }
        public string AccessKey { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class StorageAccountInformationPatch
    {
        public StorageAccountInformationPatch() { }
        public string AccessKey { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionState : System.IEquatable<Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState Registered { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState left, Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState left, Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TierType
    {
        Consumption = 0,
        Commitment100AUHours = 1,
        Commitment500AUHours = 2,
        Commitment1000AUHours = 3,
        Commitment5000AUHours = 4,
        Commitment10000AUHours = 5,
        Commitment50000AUHours = 6,
        Commitment100000AUHours = 7,
        Commitment500000AUHours = 8,
    }
    public partial class UpdateComputePolicyWithAccountParameters
    {
        public UpdateComputePolicyWithAccountParameters(string name) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AADObjectType? ObjectType { get { throw null; } set { } }
    }
    public partial class UpdateDataLakeStoreWithAccountParameters
    {
        public UpdateDataLakeStoreWithAccountParameters(string name) { }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class UpdateFirewallRuleWithAccountParameters
    {
        public UpdateFirewallRuleWithAccountParameters(string name) { }
        public string EndIPAddress { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class UpdateStorageAccountWithAccountParameters
    {
        public UpdateStorageAccountWithAccountParameters(string name) { }
        public string AccessKey { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class VirtualNetworkRule : Azure.ResourceManager.Models.ResourceData
    {
        internal VirtualNetworkRule() { }
        public string SubnetId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.VirtualNetworkRuleState? VirtualNetworkRuleState { get { throw null; } }
    }
    public enum VirtualNetworkRuleState
    {
        Active = 0,
        NetworkSourceDeleted = 1,
        Failed = 2,
    }
}
