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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsAccountData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>
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
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> GetIfExists(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>> GetIfExistsAsync(string computePolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsComputePolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>
    {
        internal DataLakeAnalyticsComputePolicyData() { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } }
        public int? MinPriorityPerJob { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? ObjectType { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionResourceGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionResourceGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>
    {
        internal DataLakeAnalyticsFirewallRuleData() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> GetIfExists(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>> GetIfExistsAsync(string storageAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>
    {
        internal DataLakeAnalyticsStorageAccountInformationData() { }
        public string Suffix { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> GetIfExists(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>> GetIfExistsAsync(string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeAnalyticsStorageContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>
    {
        internal DataLakeAnalyticsStorageContainerData() { }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> GetIfExists(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>> GetIfExistsAsync(string dataLakeStoreAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreAccountInformationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>
    {
        internal DataLakeStoreAccountInformationData() { }
        public string Suffix { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
namespace Azure.ResourceManager.DataLakeAnalytics.Mocking
{
    public partial class MockableDataLakeAnalyticsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDataLakeAnalyticsArmClient() { }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource GetDataLakeAnalyticsAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyResource GetDataLakeAnalyticsComputePolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleResource GetDataLakeAnalyticsFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationResource GetDataLakeAnalyticsStorageAccountInformationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerResource GetDataLakeAnalyticsStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationResource GetDataLakeStoreAccountInformationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDataLakeAnalyticsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataLakeAnalyticsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource> GetDataLakeAnalyticsAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountResource>> GetDataLakeAnalyticsAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountCollection GetDataLakeAnalyticsAccounts() { throw null; }
    }
    public partial class MockableDataLakeAnalyticsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDataLakeAnalyticsSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult> CheckDataLakeAnalyticsAccountNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>> CheckDataLakeAnalyticsAccountNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionResourceGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccounts(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccountsAsync(Azure.ResourceManager.DataLakeAnalytics.Models.SubscriptionResourceGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic> GetAccountsAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation> GetCapabilityLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>> GetCapabilityLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmDataLakeAnalyticsModelFactory
    {
        public static Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent(string name = null, System.Guid objectId = default(System.Guid), Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType objectType = default(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType), int? maxDegreeOfParallelismPerJob = default(int?), int? minPriorityPerJob = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent ComputePolicyForDataLakeAnalyticsAccountUpdateContent(string name = null, System.Guid? objectId = default(System.Guid?), Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? objectType = default(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType?), int? maxDegreeOfParallelismPerJob = default(int?), int? minPriorityPerJob = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic DataLakeAnalyticsAccountBasic(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? accountId = default(System.Guid?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus? provisioningState = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState? state = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string endpoint = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent DataLakeAnalyticsAccountCreateOrUpdateContent(Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null, string defaultDataLakeStoreAccount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent> dataLakeStoreAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent> storageAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent> computePolicies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent> firewallRules = null, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState? firewallState = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState? firewallAllowAzureIPs = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? newTier = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType?), int? maxJobCount = default(int?), int? maxDegreeOfParallelism = default(int?), int? maxDegreeOfParallelismPerJob = default(int?), int? minPriorityPerJob = default(int?), int? queryStoreRetention = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsAccountData DataLakeAnalyticsAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? accountId = default(System.Guid?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus? provisioningState = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountStatus?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState? state = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string endpoint = null, string defaultDataLakeStoreAccount = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData> dataLakeStoreAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData> publicDataLakeStoreAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData> storageAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData> computePolicies = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore> hiveMetastores = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule> virtualNetworkRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData> firewallRules = null, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState? firewallState = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallState?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState? firewallAllowAzureIPs = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallAllowAzureIPsState?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? newTier = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType? currentTier = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCommitmentTierType?), int? maxJobCount = default(int?), int? maxActiveJobCountPerUser = default(int?), int? maxQueuedJobCountPerUser = default(int?), int? maxJobRunningTimeInMin = default(int?), int? systemMaxJobCount = default(int?), int? maxDegreeOfParallelism = default(int?), int? systemMaxDegreeOfParallelism = default(int?), int? maxDegreeOfParallelismPerJob = default(int?), int? minPriorityPerJob = default(int?), int? queryStoreRetention = default(int?), Azure.ResourceManager.DataLakeAnalytics.Models.DebugDataAccessLevel? debugDataAccessLevel = default(Azure.ResourceManager.DataLakeAnalytics.Models.DebugDataAccessLevel?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult DataLakeAnalyticsAccountNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation DataLakeAnalyticsCapabilityInformation(System.Guid? subscriptionId = default(System.Guid?), Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState? state = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState?), int? maxAccountCount = default(int?), int? accountCount = default(int?), bool? isUnderMigrationState = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent DataLakeAnalyticsComputePolicyCreateOrUpdateContent(System.Guid objectId = default(System.Guid), Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType objectType = default(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType), int? maxDegreeOfParallelismPerJob = default(int?), int? minPriorityPerJob = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsComputePolicyData DataLakeAnalyticsComputePolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? objectId = default(System.Guid?), Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? objectType = default(Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType?), int? maxDegreeOfParallelismPerJob = default(int?), int? minPriorityPerJob = default(int?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsFirewallRuleData DataLakeAnalyticsFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore DataLakeAnalyticsHiveMetastore(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Uri serverUri = null, string databaseName = null, string runtimeVersion = null, string userName = null, string password = null, Azure.ResourceManager.DataLakeAnalytics.Models.NestedResourceProvisioningState? nestedResourceProvisioningState = default(Azure.ResourceManager.DataLakeAnalytics.Models.NestedResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation DataLakeAnalyticsSasTokenInformation(string accessToken = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent(string accessKey = null, string suffix = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageAccountInformationData DataLakeAnalyticsStorageAccountInformationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string suffix = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeAnalyticsStorageContainerData DataLakeAnalyticsStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule DataLakeAnalyticsVirtualNetworkRule(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRuleState? virtualNetworkRuleState = default(Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRuleState?)) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.DataLakeStoreAccountInformationData DataLakeStoreAccountInformationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string suffix = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent(string name = null, string suffix = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent DataLakeStoreForDataLakeAnalyticsAccountUpdateContent(string name = null, string suffix = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent FirewallRuleForDataLakeAnalyticsAccountUpdateContent(string name = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent(string name = null, string accessKey = null, string suffix = null) { throw null; }
        public static Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent StorageAccountForDataLakeAnalyticsAccountUpdateContent(string name = null, string accessKey = null, string suffix = null) { throw null; }
    }
    public partial class ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>
    {
        public ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent(string name, System.Guid objectId, Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType objectType) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType ObjectType { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputePolicyForDataLakeAnalyticsAccountUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>
    {
        public ComputePolicyForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? ObjectType { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.ComputePolicyForDataLakeAnalyticsAccountUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsAccountBasic : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>
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
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountBasic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeAnalyticsAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>
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
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsAccountNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>
    {
        public DataLakeAnalyticsAccountNameAvailabilityContent(string name, Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsResourceType ResourceType { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsAccountNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>
    {
        internal DataLakeAnalyticsAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>
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
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeAnalyticsCapabilityInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>
    {
        internal DataLakeAnalyticsCapabilityInformation() { }
        public int? AccountCount { get { throw null; } }
        public bool? IsUnderMigrationState { get { throw null; } }
        public int? MaxAccountCount { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSubscriptionState? State { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsCapabilityInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeAnalyticsComputePolicyCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>
    {
        public DataLakeAnalyticsComputePolicyCreateOrUpdateContent(System.Guid objectId, Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType objectType) { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public System.Guid ObjectId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType ObjectType { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsComputePolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>
    {
        public DataLakeAnalyticsComputePolicyPatch() { }
        public int? MaxDegreeOfParallelismPerJob { get { throw null; } set { } }
        public int? MinPriorityPerJob { get { throw null; } set { } }
        public System.Guid? ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.AadObjectIdentifierType? ObjectType { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsComputePolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataLakeAnalyticsFirewallAllowAzureIPsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataLakeAnalyticsFirewallRuleCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>
    {
        public DataLakeAnalyticsFirewallRuleCreateOrUpdateContent(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRuleCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsFirewallRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>
    {
        public DataLakeAnalyticsFirewallRulePatch() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsFirewallRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DataLakeAnalyticsFirewallState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataLakeAnalyticsHiveMetastore : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>
    {
        internal DataLakeAnalyticsHiveMetastore() { }
        public string DatabaseName { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.NestedResourceProvisioningState? NestedResourceProvisioningState { get { throw null; } }
        public string Password { get { throw null; } }
        public string RuntimeVersion { get { throw null; } }
        public System.Uri ServerUri { get { throw null; } }
        public string UserName { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsHiveMetastore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeAnalyticsSasTokenInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>
    {
        internal DataLakeAnalyticsSasTokenInformation() { }
        public string AccessToken { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsSasTokenInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>
    {
        public DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent(string accessKey) { }
        public string AccessKey { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeAnalyticsStorageAccountInformationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>
    {
        public DataLakeAnalyticsStorageAccountInformationPatch() { }
        public string AccessKey { get { throw null; } set { } }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsStorageAccountInformationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeAnalyticsVirtualNetworkRule : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>
    {
        internal DataLakeAnalyticsVirtualNetworkRule() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        public Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRuleState? VirtualNetworkRuleState { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeAnalyticsVirtualNetworkRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DataLakeStoreAccountInformationCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>
    {
        public DataLakeStoreAccountInformationCreateOrUpdateContent() { }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreAccountInformationCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>
    {
        public DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataLakeStoreForDataLakeAnalyticsAccountUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>
    {
        public DataLakeStoreForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.DataLakeStoreForDataLakeAnalyticsAccountUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DebugDataAccessLevel
    {
        None = 0,
        All = 1,
        Customer = 2,
    }
    public partial class FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>
    {
        public FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent(string name, System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
        Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FirewallRuleForDataLakeAnalyticsAccountUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>
    {
        public FirewallRuleForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.FirewallRuleForDataLakeAnalyticsAccountUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum NestedResourceProvisioningState
    {
        Succeeded = 0,
        Canceled = 1,
        Failed = 2,
    }
    public partial class StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>
    {
        public StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent(string name, string accessKey) { }
        public string AccessKey { get { throw null; } }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAccountForDataLakeAnalyticsAccountUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>
    {
        public StorageAccountForDataLakeAnalyticsAccountUpdateContent(string name) { }
        public string AccessKey { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Suffix { get { throw null; } set { } }
        Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DataLakeAnalytics.Models.StorageAccountForDataLakeAnalyticsAccountUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionResourceGetAccountsOptions
    {
        public SubscriptionResourceGetAccountsOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Orderby { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
}
