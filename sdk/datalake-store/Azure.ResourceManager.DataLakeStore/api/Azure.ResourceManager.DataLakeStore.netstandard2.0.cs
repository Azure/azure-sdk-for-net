namespace Azure.ResourceManager.DataLakeStore
{
    public partial class DataLakeStoreAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData>, System.Collections.IEnumerable
    {
        protected DataLakeStoreAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAll(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderBy = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAllAsync(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountCollectionGetAllOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderBy = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreAccountData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreAccountData() { }
        public System.Guid? AccountId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType? CurrentTier { get { throw null; } }
        public string DefaultGroup { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountEncryptionConfig EncryptionConfig { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionProvisioningState? EncryptionProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionState? EncryptionState { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleData> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallState? FirewallState { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType? NewTier { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderData> TrustedIdProviders { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderState? TrustedIdProviderState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleData> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DataLakeStoreAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeStoreAccountResource() { }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableKeyVault(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableKeyVaultAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> GetDataLakeStoreFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>> GetDataLakeStoreFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleCollection GetDataLakeStoreFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> GetDataLakeStoreTrustedIdProvider(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>> GetDataLakeStoreTrustedIdProviderAsync(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderCollection GetDataLakeStoreTrustedIdProviders() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> GetDataLakeStoreVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>> GetDataLakeStoreVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleCollection GetDataLakeStoreVirtualNetworkRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataLakeStoreExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountNameAvailabilityResult> CheckDataLakeStoreAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountNameAvailabilityResult>> CheckDataLakeStoreAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DataLakeStore.Models.SubscriptionGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderBy = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DataLakeStore.Models.SubscriptionGetAccountsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderBy = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCapabilityInformation> GetCapabilityByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCapabilityInformation>> GetCapabilityByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource> GetDataLakeStoreAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource>> GetDataLakeStoreAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountResource GetDataLakeStoreAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountCollection GetDataLakeStoreAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource GetDataLakeStoreFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource GetDataLakeStoreTrustedIdProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource GetDataLakeStoreVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsage> GetUsagesByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsage> GetUsagesByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeStoreFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected DataLakeStoreFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreFirewallRuleData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreFirewallRuleData() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
    }
    public partial class DataLakeStoreFirewallRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeStoreFirewallRuleResource() { }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource> Update(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleResource>> UpdateAsync(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeStoreTrustedIdProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>, System.Collections.IEnumerable
    {
        protected DataLakeStoreTrustedIdProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trustedIdProviderName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trustedIdProviderName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> Get(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>> GetAsync(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreTrustedIdProviderData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreTrustedIdProviderData() { }
        public System.Uri IdProvider { get { throw null; } }
    }
    public partial class DataLakeStoreTrustedIdProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeStoreTrustedIdProviderResource() { }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string trustedIdProviderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource> Update(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderResource>> UpdateAsync(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataLakeStoreVirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected DataLakeStoreVirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreVirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreVirtualNetworkRuleData() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
    }
    public partial class DataLakeStoreVirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeStoreVirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource> Update(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreVirtualNetworkRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleResource>> UpdateAsync(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreVirtualNetworkRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataLakeStore.Models
{
    public partial class DataLakeStoreAccountBasicData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreAccountBasicData() { }
        public System.Guid? AccountId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataLakeStoreAccountCollectionGetAllOptions
    {
        public DataLakeStoreAccountCollectionGetAllOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class DataLakeStoreAccountCreateOrUpdateContent
    {
        public DataLakeStoreAccountCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public string DefaultGroup { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountEncryptionConfig EncryptionConfig { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionState? EncryptionState { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeStore.Models.FirewallRuleForDataLakeStoreAccountCreateOrUpdateContent> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallState? FirewallState { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType? NewTier { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeStore.Models.TrustedIdProviderForDataLakeStoreAccountCreateOrUpdateContent> TrustedIdProviders { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderState? TrustedIdProviderState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeStore.Models.VirtualNetworkRuleForDataLakeStoreAccountCreateOrUpdateContent> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DataLakeStoreAccountEncryptionConfig
    {
        public DataLakeStoreAccountEncryptionConfig(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountEncryptionConfigType configType) { }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountEncryptionConfigType ConfigType { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountKeyVaultMetaInfo KeyVaultMetaInfo { get { throw null; } set { } }
    }
    public enum DataLakeStoreAccountEncryptionConfigType
    {
        UserManaged = 0,
        ServiceManaged = 1,
    }
    public partial class DataLakeStoreAccountKeyVaultMetaInfo
    {
        public DataLakeStoreAccountKeyVaultMetaInfo(string keyVaultResourceId, string encryptionKeyName, string encryptionKeyVersion) { }
        public string EncryptionKeyName { get { throw null; } set { } }
        public string EncryptionKeyVersion { get { throw null; } set { } }
        public string KeyVaultResourceId { get { throw null; } set { } }
    }
    public partial class DataLakeStoreAccountNameAvailabilityContent
    {
        public DataLakeStoreAccountNameAvailabilityContent(string name, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType ResourceType { get { throw null; } }
    }
    public partial class DataLakeStoreAccountNameAvailabilityResult
    {
        internal DataLakeStoreAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class DataLakeStoreAccountPatch
    {
        public DataLakeStoreAccountPatch() { }
        public string DefaultGroup { get { throw null; } set { } }
        public string EncryptionKeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeStore.Models.FirewallRuleForDataLakeStoreAccountUpdateContent> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallState? FirewallState { get { throw null; } set { } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType? NewTier { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeStore.Models.TrustedIdProviderForDataLakeStoreAccountUpdateContent> TrustedIdProviders { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderState? TrustedIdProviderState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLakeStore.Models.VirtualNetworkRuleForDataLakeStoreAccountUpdateContent> VirtualNetworkRules { get { throw null; } }
    }
    public enum DataLakeStoreAccountState
    {
        Active = 0,
        Suspended = 1,
    }
    public enum DataLakeStoreAccountStatus
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
    public partial class DataLakeStoreCapabilityInformation
    {
        internal DataLakeStoreCapabilityInformation() { }
        public int? AccountCount { get { throw null; } }
        public bool? IsUnderMigrationState { get { throw null; } }
        public int? MaxAccountCount { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState? State { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
    }
    public enum DataLakeStoreCommitmentTierType
    {
        Consumption = 0,
        Commitment1TB = 1,
        Commitment10TB = 2,
        Commitment100TB = 3,
        Commitment500TB = 4,
        Commitment1PB = 5,
        Commitment5PB = 6,
    }
    public enum DataLakeStoreEncryptionProvisioningState
    {
        Creating = 0,
        Succeeded = 1,
    }
    public enum DataLakeStoreEncryptionState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum DataLakeStoreFirewallAllowAzureIPsState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataLakeStoreFirewallRuleCreateOrUpdateContent
    {
        public DataLakeStoreFirewallRuleCreateOrUpdateContent(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
    }
    public partial class DataLakeStoreFirewallRulePatch
    {
        public DataLakeStoreFirewallRulePatch() { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public enum DataLakeStoreFirewallState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public static partial class DataLakeStoreModelFactory
    {
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountBasicData DataLakeStoreAccountBasicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? accountId = default(System.Guid?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountStatus? provisioningState = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountStatus?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountState? state = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string endpoint = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreAccountData DataLakeStoreAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Guid? accountId = default(System.Guid?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountStatus? provisioningState = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountStatus?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountState? state = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string endpoint = null, string defaultGroup = null, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountEncryptionConfig encryptionConfig = null, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionState? encryptionState = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionState?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionProvisioningState? encryptionProvisioningState = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreEncryptionProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleData> firewallRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleData> virtualNetworkRules = null, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallState? firewallState = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallState?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallAllowAzureIPsState? firewallAllowAzureIPs = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreFirewallAllowAzureIPsState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderData> trustedIdProviders = null, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderState? trustedIdProviderState = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreTrustedIdProviderState?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType? newTier = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType? currentTier = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCommitmentTierType?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreAccountNameAvailabilityResult DataLakeStoreAccountNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreCapabilityInformation DataLakeStoreCapabilityInformation(System.Guid? subscriptionId = default(System.Guid?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState? state = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState?), int? maxAccountCount = default(int?), int? accountCount = default(int?), bool? isUnderMigrationState = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreFirewallRuleData DataLakeStoreFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreTrustedIdProviderData DataLakeStoreTrustedIdProviderData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Uri idProvider = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsage DataLakeStoreUsage(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsageUnit? unit = default(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsageUnit?), Azure.Core.ResourceIdentifier id = null, int? currentValue = default(int?), int? limit = default(int?), Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsageName name = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsageName DataLakeStoreUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.DataLakeStoreVirtualNetworkRuleData DataLakeStoreVirtualNetworkRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier subnetId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataLakeStoreResourceType : System.IEquatable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataLakeStoreResourceType(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType MicrosoftDataLakeStoreAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType left, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType left, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataLakeStoreSubscriptionState : System.IEquatable<Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataLakeStoreSubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState Registered { get { throw null; } }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState left, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState left, Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreSubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataLakeStoreTrustedIdProviderCreateOrUpdateContent
    {
        public DataLakeStoreTrustedIdProviderCreateOrUpdateContent(System.Uri idProvider) { }
        public System.Uri IdProvider { get { throw null; } }
    }
    public partial class DataLakeStoreTrustedIdProviderPatch
    {
        public DataLakeStoreTrustedIdProviderPatch() { }
        public System.Uri IdProvider { get { throw null; } set { } }
    }
    public enum DataLakeStoreTrustedIdProviderState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataLakeStoreUsage
    {
        internal DataLakeStoreUsage() { }
        public int? CurrentValue { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsageName Name { get { throw null; } }
        public Azure.ResourceManager.DataLakeStore.Models.DataLakeStoreUsageUnit? Unit { get { throw null; } }
    }
    public partial class DataLakeStoreUsageName
    {
        internal DataLakeStoreUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum DataLakeStoreUsageUnit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        Percent = 3,
        CountsPerSecond = 4,
        BytesPerSecond = 5,
    }
    public partial class DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent
    {
        public DataLakeStoreVirtualNetworkRuleCreateOrUpdateContent(Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
    }
    public partial class DataLakeStoreVirtualNetworkRulePatch
    {
        public DataLakeStoreVirtualNetworkRulePatch() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
    public partial class FirewallRuleForDataLakeStoreAccountCreateOrUpdateContent
    {
        public FirewallRuleForDataLakeStoreAccountCreateOrUpdateContent(string name, System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } }
    }
    public partial class FirewallRuleForDataLakeStoreAccountUpdateContent
    {
        public FirewallRuleForDataLakeStoreAccountUpdateContent(string name) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
    }
    public partial class SubscriptionGetAccountsOptions
    {
        public SubscriptionGetAccountsOptions() { }
        public bool? Count { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string OrderBy { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
    }
    public partial class TrustedIdProviderForDataLakeStoreAccountCreateOrUpdateContent
    {
        public TrustedIdProviderForDataLakeStoreAccountCreateOrUpdateContent(string name, System.Uri idProvider) { }
        public System.Uri IdProvider { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class TrustedIdProviderForDataLakeStoreAccountUpdateContent
    {
        public TrustedIdProviderForDataLakeStoreAccountUpdateContent(string name) { }
        public System.Uri IdProvider { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class VirtualNetworkRuleForDataLakeStoreAccountCreateOrUpdateContent
    {
        public VirtualNetworkRuleForDataLakeStoreAccountCreateOrUpdateContent(string name, Azure.Core.ResourceIdentifier subnetId) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
    }
    public partial class VirtualNetworkRuleForDataLakeStoreAccountUpdateContent
    {
        public VirtualNetworkRuleForDataLakeStoreAccountUpdateContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
    }
}
