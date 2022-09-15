namespace Azure.ResourceManager.DataLake.Store
{
    public partial class DataLakeStoreAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic>, System.Collections.IEnumerable
    {
        protected DataLakeStoreAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataLakeStoreAccountData : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreAccountData() { }
        public System.Guid? AccountId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.TierType? CurrentTier { get { throw null; } }
        public string DefaultGroup { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.EncryptionConfig EncryptionConfig { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.EncryptionProvisioningState? EncryptionProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.EncryptionState? EncryptionState { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.FirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLake.Store.FirewallRuleData> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.FirewallState? FirewallState { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.TierType? NewTier { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLake.Store.TrustedIdProviderData> TrustedIdProviders { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderState? TrustedIdProviderState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleData> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DataLakeStoreAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataLakeStoreAccountResource() { }
        public virtual Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response EnableKeyVault(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableKeyVaultAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> GetFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>> GetFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLake.Store.FirewallRuleCollection GetFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> GetTrustedIdProvider(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>> GetTrustedIdProviderAsync(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLake.Store.TrustedIdProviderCollection GetTrustedIdProviders() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> GetVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>> GetVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleCollection GetVirtualNetworkRules() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>, System.Collections.IEnumerable
    {
        protected FirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLake.Store.Models.FirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.DataLake.Store.Models.FirewallRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>.GetEnumerator() { throw null; }
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
        public virtual Azure.ResourceManager.DataLake.Store.FirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource> Update(Azure.ResourceManager.DataLake.Store.Models.FirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.FirewallRuleResource>> UpdateAsync(Azure.ResourceManager.DataLake.Store.Models.FirewallRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class StoreExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataLake.Store.Models.NameAvailabilityInformation> CheckNameAvailabilityAccount(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.Models.NameAvailabilityInformation>> CheckNameAvailabilityAccountAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountBasic> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), int? skip = default(int?), string select = null, string orderby = null, bool? count = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLake.Store.Models.CapabilityInformation> GetCapabilityLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.Models.CapabilityInformation>> GetCapabilityLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource> GetDataLakeStoreAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource>> GetDataLakeStoreAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountResource GetDataLakeStoreAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.DataLakeStoreAccountCollection GetDataLakeStoreAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.FirewallRuleResource GetFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource GetTrustedIdProviderResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataLake.Store.Models.StoreUsage> GetUsageLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataLake.Store.Models.StoreUsage> GetUsageLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource GetVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class TrustedIdProviderCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>, System.Collections.IEnumerable
    {
        protected TrustedIdProviderCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trustedIdProviderName, Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trustedIdProviderName, Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> Get(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>> GetAsync(string trustedIdProviderName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrustedIdProviderData : Azure.ResourceManager.Models.ResourceData
    {
        internal TrustedIdProviderData() { }
        public string IdProvider { get { throw null; } }
    }
    public partial class TrustedIdProviderResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrustedIdProviderResource() { }
        public virtual Azure.ResourceManager.DataLake.Store.TrustedIdProviderData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string trustedIdProviderName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource> Update(Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.TrustedIdProviderResource>> UpdateAsync(Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.DataLake.Store.Models.VirtualNetworkRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.DataLake.Store.Models.VirtualNetworkRuleCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData
    {
        internal VirtualNetworkRuleData() { }
        public string SubnetId { get { throw null; } }
    }
    public partial class VirtualNetworkRuleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource> Update(Azure.ResourceManager.DataLake.Store.Models.VirtualNetworkRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataLake.Store.VirtualNetworkRuleResource>> UpdateAsync(Azure.ResourceManager.DataLake.Store.Models.VirtualNetworkRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataLake.Store.Models
{
    public partial class CapabilityInformation
    {
        internal CapabilityInformation() { }
        public int? AccountCount { get { throw null; } }
        public int? MaxAccountCount { get { throw null; } }
        public bool? MigrationState { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.SubscriptionState? State { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
    }
    public partial class CheckNameAvailabilityContent
    {
        public CheckNameAvailabilityContent(string name, Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType ResourceType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityParametersType : System.IEquatable<Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityParametersType(string value) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType MicrosoftDataLakeStoreAccounts { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType left, Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType left, Azure.ResourceManager.DataLake.Store.Models.CheckNameAvailabilityParametersType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreateFirewallRuleWithAccountParameters
    {
        public CreateFirewallRuleWithAccountParameters(string name, string startIPAddress, string endIPAddress) { }
        public string EndIPAddress { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartIPAddress { get { throw null; } }
    }
    public partial class CreateTrustedIdProviderWithAccountParameters
    {
        public CreateTrustedIdProviderWithAccountParameters(string name, string idProvider) { }
        public string IdProvider { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class CreateVirtualNetworkRuleWithAccountParameters
    {
        public CreateVirtualNetworkRuleWithAccountParameters(string name, string subnetId) { }
        public string Name { get { throw null; } }
        public string SubnetId { get { throw null; } }
    }
    public partial class DataLakeStoreAccountBasic : Azure.ResourceManager.Models.ResourceData
    {
        internal DataLakeStoreAccountBasic() { }
        public System.Guid? AccountId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Endpoint { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountStatus? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.DataLakeStoreAccountState? State { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DataLakeStoreAccountCreateOrUpdateContent
    {
        public DataLakeStoreAccountCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public string DefaultGroup { get { throw null; } set { } }
        public Azure.ResourceManager.DataLake.Store.Models.EncryptionConfig EncryptionConfig { get { throw null; } set { } }
        public Azure.ResourceManager.DataLake.Store.Models.EncryptionState? EncryptionState { get { throw null; } set { } }
        public Azure.ResourceManager.DataLake.Store.Models.FirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLake.Store.Models.CreateFirewallRuleWithAccountParameters> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.FirewallState? FirewallState { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.TierType? NewTier { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLake.Store.Models.CreateTrustedIdProviderWithAccountParameters> TrustedIdProviders { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderState? TrustedIdProviderState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLake.Store.Models.CreateVirtualNetworkRuleWithAccountParameters> VirtualNetworkRules { get { throw null; } }
    }
    public partial class DataLakeStoreAccountPatch
    {
        public DataLakeStoreAccountPatch() { }
        public string DefaultGroup { get { throw null; } set { } }
        public string EncryptionKeyVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DataLake.Store.Models.FirewallAllowAzureIPsState? FirewallAllowAzureIPs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLake.Store.Models.UpdateFirewallRuleWithAccountParameters> FirewallRules { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.FirewallState? FirewallState { get { throw null; } set { } }
        public Azure.ResourceManager.DataLake.Store.Models.TierType? NewTier { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLake.Store.Models.UpdateTrustedIdProviderWithAccountParameters> TrustedIdProviders { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.TrustedIdProviderState? TrustedIdProviderState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DataLake.Store.Models.UpdateVirtualNetworkRuleWithAccountParameters> VirtualNetworkRules { get { throw null; } }
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
    public partial class EncryptionConfig
    {
        public EncryptionConfig(Azure.ResourceManager.DataLake.Store.Models.EncryptionConfigType configType) { }
        public Azure.ResourceManager.DataLake.Store.Models.EncryptionConfigType ConfigType { get { throw null; } set { } }
        public Azure.ResourceManager.DataLake.Store.Models.KeyVaultMetaInfo KeyVaultMetaInfo { get { throw null; } set { } }
    }
    public enum EncryptionConfigType
    {
        UserManaged = 0,
        ServiceManaged = 1,
    }
    public enum EncryptionProvisioningState
    {
        Creating = 0,
        Succeeded = 1,
    }
    public enum EncryptionState
    {
        Enabled = 0,
        Disabled = 1,
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
    public partial class KeyVaultMetaInfo
    {
        public KeyVaultMetaInfo(string keyVaultResourceId, string encryptionKeyName, string encryptionKeyVersion) { }
        public string EncryptionKeyName { get { throw null; } set { } }
        public string EncryptionKeyVersion { get { throw null; } set { } }
        public string KeyVaultResourceId { get { throw null; } set { } }
    }
    public partial class NameAvailabilityInformation
    {
        internal NameAvailabilityInformation() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class StoreUsage
    {
        internal StoreUsage() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.UsageName Name { get { throw null; } }
        public Azure.ResourceManager.DataLake.Store.Models.UsageUnit? Unit { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionState : System.IEquatable<Azure.ResourceManager.DataLake.Store.Models.SubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.DataLake.Store.Models.SubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DataLake.Store.Models.SubscriptionState Registered { get { throw null; } }
        public static Azure.ResourceManager.DataLake.Store.Models.SubscriptionState Suspended { get { throw null; } }
        public static Azure.ResourceManager.DataLake.Store.Models.SubscriptionState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.DataLake.Store.Models.SubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataLake.Store.Models.SubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataLake.Store.Models.SubscriptionState left, Azure.ResourceManager.DataLake.Store.Models.SubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataLake.Store.Models.SubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataLake.Store.Models.SubscriptionState left, Azure.ResourceManager.DataLake.Store.Models.SubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum TierType
    {
        Consumption = 0,
        Commitment1TB = 1,
        Commitment10TB = 2,
        Commitment100TB = 3,
        Commitment500TB = 4,
        Commitment1PB = 5,
        Commitment5PB = 6,
    }
    public partial class TrustedIdProviderCreateOrUpdateContent
    {
        public TrustedIdProviderCreateOrUpdateContent(string idProvider) { }
        public string IdProvider { get { throw null; } }
    }
    public partial class TrustedIdProviderPatch
    {
        public TrustedIdProviderPatch() { }
        public string IdProvider { get { throw null; } set { } }
    }
    public enum TrustedIdProviderState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class UpdateFirewallRuleWithAccountParameters
    {
        public UpdateFirewallRuleWithAccountParameters(string name) { }
        public string EndIPAddress { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
    }
    public partial class UpdateTrustedIdProviderWithAccountParameters
    {
        public UpdateTrustedIdProviderWithAccountParameters(string name) { }
        public string IdProvider { get { throw null; } set { } }
        public string Name { get { throw null; } }
    }
    public partial class UpdateVirtualNetworkRuleWithAccountParameters
    {
        public UpdateVirtualNetworkRuleWithAccountParameters(string name) { }
        public string Name { get { throw null; } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum UsageUnit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        Percent = 3,
        CountsPerSecond = 4,
        BytesPerSecond = 5,
    }
    public partial class VirtualNetworkRuleCreateOrUpdateContent
    {
        public VirtualNetworkRuleCreateOrUpdateContent(string subnetId) { }
        public string SubnetId { get { throw null; } }
    }
    public partial class VirtualNetworkRulePatch
    {
        public VirtualNetworkRulePatch() { }
        public string SubnetId { get { throw null; } set { } }
    }
}
