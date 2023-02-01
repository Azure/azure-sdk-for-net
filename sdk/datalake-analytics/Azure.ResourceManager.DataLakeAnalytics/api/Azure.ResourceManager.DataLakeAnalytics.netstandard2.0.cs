namespace Azure.ResourceManager.DataLakeAnalytics
{
    public partial class DataLakeAnalyticsAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>, System.Collections.IEnumerable
    {
        protected DataLakeAnalyticsAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAll(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAllAsync(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData> ComputePolicies { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? CurrentTier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData> DataLakeStoreAccounts { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DebugDataAccessLevel? DebugDataAccessLevel { get { throw null; } }
        public string DefaultDataLakeStoreAccount { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState? FirewallState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore> HiveMetastores { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public int? MaxActiveJobCountPerUser { get { throw null; } }
        public int? MaxDegreeOfParallelism { get { throw null; } }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } }
        public int? MaxJobCount { get { throw null; } }
        public int? MaxJobRunningTimeInMin { get { throw null; } }
        public int? MaxQueuedJobCountPerUser { get { throw null; } }
        public int? MinPriorityPerJob { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? NewTier { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData> PublicDataLakeStoreAccounts { get { throw null; } }
        public int? QueryStoreRetention { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData> StorageAccounts { get { throw null; } }
        public int? SystemMaxDegreeOfParallelism { get { throw null; } }
        public int? SystemMaxJobCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
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
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationCollection GetAllDataLakeAnalyticsStorageAccountInformation() { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationCollection GetAllDataLakeStoreAccountInformation() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyCollection GetDataLakeAnalyticsComputePolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> GetDataLakeAnalyticsComputePolicy(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>> GetDataLakeAnalyticsComputePolicyAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> GetDataLakeAnalyticsFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>> GetDataLakeAnalyticsFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleCollection GetDataLakeAnalyticsFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> GetDataLakeAnalyticsStorageAccountInformation(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>> GetDataLakeAnalyticsStorageAccountInformationAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetDataLakeStoreAccountInformation(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>> GetDataLakeStoreAccountInformationAsync(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeAnalyticsComputePolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>, System.Collections.IEnumerable
    {
        protected DataLakeAnalyticsComputePolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string computePolicyName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string computePolicyName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> Get(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>> GetAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsComputePolicyData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsComputePolicyData() { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } }
        public int? MinPriorityPerJob { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? ObjectType { get { throw null; } }
    }
    public partial class DataLakeAnalyticsComputePolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeAnalyticsComputePolicyResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string computePolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> Update(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>> UpdateAsync(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataLakeAnalyticsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult> CheckDataLakeAnalyticsAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>> CheckDataLakeAnalyticsAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation> GetCapabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>> GetCapabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> GetDataLakeAnalyticsAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetDataLakeAnalyticsAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource GetDataLakeAnalyticsAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountCollection GetDataLakeAnalyticsAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource GetDataLakeAnalyticsComputePolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource GetDataLakeAnalyticsFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource GetDataLakeAnalyticsStorageAccountInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource GetDataLakeAnalyticsStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource GetDataLakeStoreAccountInformationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DataLakeAnalyticsFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected DataLakeAnalyticsFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsFirewallRuleData() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
    }
    public partial class DataLakeAnalyticsFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeAnalyticsFirewallRuleResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> Update(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>> UpdateAsync(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>, System.Collections.IEnumerable
    {
        protected DataLakeAnalyticsStorageAccountInformationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> Get(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> GetAll(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> GetAllAsync(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>> GetAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsStorageAccountInformationData() { }
        public string Suffix { get { throw null; } }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeAnalyticsStorageAccountInformationResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string storageAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> GetDataLakeAnalyticsStorageContainer(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>> GetDataLakeAnalyticsStorageContainerAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerCollection GetDataLakeAnalyticsStorageContainers() { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeAnalyticsStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>, System.Collections.IEnumerable
    {
        protected DataLakeAnalyticsStorageContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> Get(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>> GetAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsStorageContainerData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsStorageContainerData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
    }
    public partial class DataLakeAnalyticsStorageContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeAnalyticsStorageContainerResource() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string storageAccountName, string containerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation> GetSasTokens(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation> GetSasTokensAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeStoreAccountInformationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>, System.Collections.IEnumerable
    {
        protected DataLakeStoreAccountInformationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string dataLakeStoreAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataLakeStoreAccountName, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> Get(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetAll(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetAllAsync(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
}
namespace Azure.ResourceManager.DataLakeAnalytics.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AadObjectIdentifierType : System.IEquatable<Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AadObjectIdentifierType(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType Group { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType left, Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType left, Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent
    {
        public ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent(string name, System.Guid objectId, Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType objectType) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType ObjectType { get { throw null; } }
    }
    public partial class ComputePolicyForDataLakeAnalyticsAccountUpdateContent
    {
        public ComputePolicyForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? ObjectType { get { throw null; } set { } }
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
    public partial class DataLakeAnalyticsAccountCollectionGetAllOptions
    {
        public DataLakeAnalyticsAccountCollectionGetAllOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsAccountCreateOrUpdateContent
    {
        public DataLakeAnalyticsAccountCreateOrUpdateContent(Azure.Core.AzureLocation location, string defaultDataLakeStoreAccount, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent> dataLakeStoreAccounts) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent> ComputePolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent> DataLakeStoreAccounts { get { throw null; } }
        public string DefaultDataLakeStoreAccount { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState? FirewallState { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public int? MaxDegreeOfParallelism { get { throw null; } set { } }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MaxJobCount { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? NewTier { get { throw null; } set { } }
        public int? QueryStoreRetention { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent> StorageAccounts { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountNameAvailabilityContent
    {
        public DataLakeAnalyticsAccountNameAvailabilityContent(string name, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType ResourceType { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountNameAvailabilityResult
    {
        internal DataLakeAnalyticsAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class DataLakeAnalyticsAccountPatch
    {
        public DataLakeAnalyticsAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent> ComputePolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent> DataLakeStoreAccounts { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState? FirewallState { get { throw null; } set { } }
        public int? MaxDegreeOfParallelism { get { throw null; } set { } }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MaxJobCount { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? NewTier { get { throw null; } set { } }
        public int? QueryStoreRetention { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent> StorageAccounts { get { throw null; } }
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
    public partial class DataLakeAnalyticsCapabilityInformation
    {
        internal DataLakeAnalyticsCapabilityInformation() { }
        public int? AccountCount { get { throw null; } }
        public bool? IsUnderMigrationState { get { throw null; } }
        public int? MaxAccountCount { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState? State { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
    }
    public enum DataLakeAnalyticsCommitmentTierType
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
    public partial class DataLakeAnalyticsComputePolicyCreateOrUpdateContent
    {
        public DataLakeAnalyticsComputePolicyCreateOrUpdateContent(System.Guid objectId, Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType objectType) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType ObjectType { get { throw null; } }
    }
    public partial class DataLakeAnalyticsComputePolicyPatch
    {
        public DataLakeAnalyticsComputePolicyPatch() { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? ObjectType { get { throw null; } set { } }
    }
    public enum DataLakeAnalyticsFirewallAllowAzureIPsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataLakeAnalyticsFirewallRuleCreateOrUpdateContent
    {
        public DataLakeAnalyticsFirewallRuleCreateOrUpdateContent(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
    }
    public partial class DataLakeAnalyticsFirewallRulePatch
    {
        public DataLakeAnalyticsFirewallRulePatch() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public enum DataLakeAnalyticsFirewallState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataLakeAnalyticsHiveMetastore : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsHiveMetastore() { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.NestedResourceProvisioningState? NestedResourceProvisioningState { get { throw null; } }
        public string Password { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public System.Uri ServerUri { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataLakeAnalyticsResourceType : System.IEquatable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataLakeAnalyticsResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType MicrosoftDataLakeAnalyticsAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType left, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType left, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataLakeAnalyticsSasTokenInformation
    {
        internal DataLakeAnalyticsSasTokenInformation() { }
        public string AccessToken { get { throw null; } }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions
    {
        public DataLakeAnalyticsStorageAccountInformationCollectionGetAllOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent
    {
        public DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent(string accessKey) { }
        public string AccessKey { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationPatch
    {
        public DataLakeAnalyticsStorageAccountInformationPatch() { }
        public string AccessKey { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataLakeAnalyticsSubscriptionState : System.IEquatable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataLakeAnalyticsSubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState Registered { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState left, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState left, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataLakeAnalyticsVirtualNetworkRule : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeAnalyticsVirtualNetworkRule() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRuleState? VirtualNetworkRuleState { get { throw null; } }
    }
    public enum DataLakeAnalyticsVirtualNetworkRuleState
    {
        Active = 0,
        NetworkSourceDeleted = 1,
        Failed = 2,
    }
    public partial class DataLakeStoreAccountInformationCollectionGetAllOptions
    {
        public DataLakeStoreAccountInformationCollectionGetAllOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class DataLakeStoreAccountInformationCreateOrUpdateContent
    {
        public DataLakeStoreAccountInformationCreateOrUpdateContent() { }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent
    {
        public DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class DataLakeStoreForDataLakeAnalyticsAccountUpdateContent
    {
        public DataLakeStoreForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public enum DebugDataAccessLevel
    {
        None = 0,
        All = 1,
        Customer = 2,
    }
    public partial class FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent
    {
        public FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent(string name, System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
    }
    public partial class FirewallRuleForDataLakeAnalyticsAccountUpdateContent
    {
        public FirewallRuleForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public enum NestedResourceProvisioningState
    {
        Succeeded = 0,
        Canceled = 1,
        Failed = 2,
    }
    public partial class StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent
    {
        public StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent(string name, string accessKey) { }
        public string AccessKey { get { throw null; } }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class StorageAccountForDataLakeAnalyticsAccountUpdateContent
    {
        public StorageAccountForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public string AccessKey { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
    }
    public partial class SubscriptionGetAccountsOptions
    {
        public SubscriptionGetAccountsOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
}
