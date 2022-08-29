namespace Azure.ResourceManager.DataShare
{
    public partial class AccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.AccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.AccountResource>, System.Collections.IEnumerable
    {
        protected AccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.AccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataShare.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.AccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DataShare.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.AccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.AccountResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.AccountResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.AccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.AccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.AccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.AccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AccountData(Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class AccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountResource() { }
        public virtual Azure.ResourceManager.DataShare.AccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.AccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.AccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareResource> GetShare(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareResource>> GetShareAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareCollection GetShares() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetShareSubscription(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetShareSubscriptionAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ShareSubscriptionCollection GetShareSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.AccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.AccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.AccountResource> Update(Azure.ResourceManager.DataShare.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> UpdateAsync(Azure.ResourceManager.DataShare.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsumerInvitationCollection : Azure.ResourceManager.ArmCollection
    {
        protected ConsumerInvitationCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource> Get(Azure.Core.AzureLocation location, string invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource>> GetAsync(Azure.Core.AzureLocation location, string invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConsumerInvitationData : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumerInvitationData(string invitationId) { }
        public int? DataSetCount { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string InvitationId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.InvitationStatus? InvitationStatus { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProviderEmail { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ProviderTenantName { get { throw null; } }
        public System.DateTimeOffset? RespondedOn { get { throw null; } }
        public System.DateTimeOffset? SentOn { get { throw null; } }
        public string ShareName { get { throw null; } }
        public string TermsOfUse { get { throw null; } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class ConsumerInvitationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConsumerInvitationResource() { }
        public virtual Azure.ResourceManager.DataShare.ConsumerInvitationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(Azure.Core.AzureLocation location, string invitationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataSetResource>, System.Collections.IEnumerable
    {
        protected DataSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataSetName, Azure.ResourceManager.DataShare.DataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataSetName, Azure.ResourceManager.DataShare.DataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataSetResource> Get(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataSetResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataSetResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataSetResource>> GetAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataSetData : Azure.ResourceManager.Models.ResourceData
    {
        public DataSetData() { }
    }
    public partial class DataSetMappingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataSetMappingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataSetMappingResource>, System.Collections.IEnumerable
    {
        protected DataSetMappingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetMappingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataSetMappingName, Azure.ResourceManager.DataShare.DataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetMappingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataSetMappingName, Azure.ResourceManager.DataShare.DataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataSetMappingResource> Get(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.DataSetMappingResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.DataSetMappingResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataSetMappingResource>> GetAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.DataSetMappingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.DataSetMappingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.DataSetMappingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.DataSetMappingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataSetMappingData : Azure.ResourceManager.Models.ResourceData
    {
        public DataSetMappingData() { }
    }
    public partial class DataSetMappingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataSetMappingResource() { }
        public virtual Azure.ResourceManager.DataShare.DataSetMappingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareSubscriptionName, string dataSetMappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataSetMappingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataSetMappingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetMappingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetMappingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataSetMappingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataSetResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataSetResource() { }
        public virtual Azure.ResourceManager.DataShare.DataSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string dataSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.DataSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.DataSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DataShareExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DataShare.Models.EmailRegistration> ActivateEmailEmailRegistration(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.Models.EmailRegistration emailRegistration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.Models.EmailRegistration>> ActivateEmailEmailRegistrationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.Models.EmailRegistration emailRegistration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.AccountResource> GetAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.AccountResource>> GetAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataShare.AccountResource GetAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.AccountCollection GetAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataShare.AccountResource> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataShare.AccountResource> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource> GetConsumerInvitation(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, string invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource>> GetConsumerInvitationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, string invitationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataShare.ConsumerInvitationResource GetConsumerInvitationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ConsumerInvitationCollection GetConsumerInvitations(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DataShare.ConsumerInvitationResource> GetConsumerInvitationsByListInvitation(this Azure.ResourceManager.Resources.TenantResource tenantResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DataShare.ConsumerInvitationResource> GetConsumerInvitationsByListInvitationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DataShare.DataSetMappingResource GetDataSetMappingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.DataSetResource GetDataSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.InvitationResource GetInvitationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource GetProviderShareSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareResource GetShareResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.ShareSubscriptionResource GetShareSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.SynchronizationSettingResource GetSynchronizationSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DataShare.TriggerResource GetTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.Models.EmailRegistration> RegisterEmailEmailRegistration(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.Models.EmailRegistration>> RegisterEmailEmailRegistrationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource> RejectInvitationConsumerInvitation(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.ConsumerInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ConsumerInvitationResource>> RejectInvitationConsumerInvitationAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DataShare.ConsumerInvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InvitationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.InvitationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.InvitationResource>, System.Collections.IEnumerable
    {
        protected InvitationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.InvitationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string invitationName, Azure.ResourceManager.DataShare.InvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.InvitationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string invitationName, Azure.ResourceManager.DataShare.InvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.InvitationResource> Get(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.InvitationResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.InvitationResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.InvitationResource>> GetAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.InvitationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.InvitationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.InvitationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.InvitationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InvitationData : Azure.ResourceManager.Models.ResourceData
    {
        public InvitationData() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string InvitationId { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.InvitationStatus? InvitationStatus { get { throw null; } }
        public System.DateTimeOffset? RespondedOn { get { throw null; } }
        public System.DateTimeOffset? SentOn { get { throw null; } }
        public string TargetActiveDirectoryId { get { throw null; } set { } }
        public string TargetEmail { get { throw null; } set { } }
        public string TargetObjectId { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class InvitationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InvitationResource() { }
        public virtual Azure.ResourceManager.DataShare.InvitationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string invitationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.InvitationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.InvitationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.InvitationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.InvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.InvitationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.InvitationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProviderShareSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ProviderShareSubscriptionCollection() { }
        public virtual Azure.Response<bool> Exists(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Get(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderShareSubscriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public ProviderShareSubscriptionData() { }
        public string ConsumerEmail { get { throw null; } }
        public string ConsumerName { get { throw null; } }
        public string ConsumerTenantName { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string ProviderEmail { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public System.DateTimeOffset? SharedOn { get { throw null; } }
        public string ShareSubscriptionObjectId { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus? ShareSubscriptionStatus { get { throw null; } }
    }
    public partial class ProviderShareSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderShareSubscriptionResource() { }
        public virtual Azure.ResourceManager.DataShare.ProviderShareSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Adjust(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> AdjustAsync(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string providerShareSubscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Reinstate(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> ReinstateAsync(Azure.ResourceManager.DataShare.ProviderShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> Revoke(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> RevokeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareResource>, System.Collections.IEnumerable
    {
        protected ShareCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.DataShare.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string shareName, Azure.ResourceManager.DataShare.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareResource> Get(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ShareResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ShareResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareResource>> GetAsync(string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ShareResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ShareResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ShareData : Azure.ResourceManager.Models.ResourceData
    {
        public ShareData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareKind? ShareKind { get { throw null; } set { } }
        public string Terms { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class ShareResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ShareResource() { }
        public virtual Azure.ResourceManager.DataShare.ShareData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataSetResource> GetDataSet(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataSetResource>> GetDataSetAsync(string dataSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataSetCollection GetDataSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.InvitationResource> GetInvitation(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.InvitationResource>> GetInvitationAsync(string invitationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.InvitationCollection GetInvitations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource> GetProviderShareSubscription(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ProviderShareSubscriptionResource>> GetProviderShareSubscriptionAsync(string providerShareSubscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.ProviderShareSubscriptionCollection GetProviderShareSubscriptions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetails(Azure.ResourceManager.DataShare.Models.ShareSynchronization shareSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetailsAsync(Azure.ResourceManager.DataShare.Models.ShareSynchronization shareSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.ShareSynchronization> GetSynchronizations(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.ShareSynchronization> GetSynchronizationsAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.SynchronizationSettingResource> GetSynchronizationSetting(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.SynchronizationSettingResource>> GetSynchronizationSettingAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.SynchronizationSettingCollection GetSynchronizationSettings() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ShareSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>, System.Collections.IEnumerable
    {
        protected ShareSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string shareSubscriptionName, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string shareSubscriptionName, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource> Get(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetAll(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.ShareSubscriptionResource> GetAllAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetAsync(string shareSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.ShareSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.ShareSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.ShareSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ShareSubscriptionData : Azure.ResourceManager.Models.ResourceData
    {
        public ShareSubscriptionData(string invitationId, string sourceShareLocation) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string InvitationId { get { throw null; } set { } }
        public string ProviderEmail { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ProviderTenantName { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ShareDescription { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareKind? ShareKind { get { throw null; } }
        public string ShareName { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus? ShareSubscriptionStatus { get { throw null; } }
        public string ShareTerms { get { throw null; } }
        public string SourceShareLocation { get { throw null; } set { } }
        public string UserEmail { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    public partial class ShareSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ShareSubscriptionResource() { }
        public virtual Azure.ResourceManager.DataShare.ShareSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> CancelSynchronization(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>> CancelSynchronizationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet> GetConsumerSourceDataSets(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.ConsumerSourceDataSet> GetConsumerSourceDataSetsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.DataSetMappingResource> GetDataSetMapping(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.DataSetMappingResource>> GetDataSetMappingAsync(string dataSetMappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.DataSetMappingCollection GetDataSetMappings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting> GetSourceShareSynchronizationSettings(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting> GetSourceShareSynchronizationSettingsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetails(Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.SynchronizationDetails> GetSynchronizationDetailsAsync(Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization shareSubscriptionSynchronization, string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> GetSynchronizations(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> GetSynchronizationsAsync(string skipToken = null, string filter = null, string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.TriggerResource> GetTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.TriggerResource>> GetTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DataShare.TriggerCollection GetTriggers() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization> Synchronize(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.Synchronize synchronize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.ShareSubscriptionSynchronization>> SynchronizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.Models.Synchronize synchronize, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.ShareSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.ShareSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SynchronizationSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.SynchronizationSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.SynchronizationSettingResource>, System.Collections.IEnumerable
    {
        protected SynchronizationSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.SynchronizationSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string synchronizationSettingName, Azure.ResourceManager.DataShare.SynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.SynchronizationSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string synchronizationSettingName, Azure.ResourceManager.DataShare.SynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.SynchronizationSettingResource> Get(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.SynchronizationSettingResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.SynchronizationSettingResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.SynchronizationSettingResource>> GetAsync(string synchronizationSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.SynchronizationSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.SynchronizationSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.SynchronizationSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.SynchronizationSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SynchronizationSettingData : Azure.ResourceManager.Models.ResourceData
    {
        public SynchronizationSettingData() { }
    }
    public partial class SynchronizationSettingResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SynchronizationSettingResource() { }
        public virtual Azure.ResourceManager.DataShare.SynchronizationSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareName, string synchronizationSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.SynchronizationSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.SynchronizationSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.SynchronizationSettingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.SynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.SynchronizationSettingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.SynchronizationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.TriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.TriggerResource>, System.Collections.IEnumerable
    {
        protected TriggerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.TriggerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataShare.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.TriggerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string triggerName, Azure.ResourceManager.DataShare.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.TriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DataShare.TriggerResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DataShare.TriggerResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.TriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DataShare.TriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DataShare.TriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DataShare.TriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DataShare.TriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TriggerData : Azure.ResourceManager.Models.ResourceData
    {
        public TriggerData() { }
    }
    public partial class TriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TriggerResource() { }
        public virtual Azure.ResourceManager.DataShare.TriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string shareSubscriptionName, string triggerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.Models.OperationResponse>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DataShare.TriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DataShare.TriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.TriggerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DataShare.TriggerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DataShare.TriggerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DataShare.Models
{
    public partial class AccountPatch
    {
        public AccountPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class AdlsGen1FileDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public AdlsGen1FileDataSet(string accountName, string fileName, string folderPath, string resourceGroup, string subscriptionId) { }
        public string AccountName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } }
        public string FileName { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen1FolderDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public AdlsGen1FolderDataSet(string accountName, string folderPath, string resourceGroup, string subscriptionId) { }
        public string AccountName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } }
        public string FolderPath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen2FileDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public AdlsGen2FileDataSet(string filePath, string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string DataSetId { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen2FileDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public AdlsGen2FileDataSetMapping(string dataSetId, string filePath, string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public string FileSystem { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.OutputType? OutputType { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen2FileSystemDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public AdlsGen2FileSystemDataSet(string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string DataSetId { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen2FileSystemDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public AdlsGen2FileSystemDataSetMapping(string dataSetId, string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen2FolderDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public AdlsGen2FolderDataSet(string fileSystem, string folderPath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string DataSetId { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class AdlsGen2FolderDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public AdlsGen2FolderDataSetMapping(string dataSetId, string fileSystem, string folderPath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FileSystem { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BlobContainerDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public BlobContainerDataSet(string containerName, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BlobContainerDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public BlobContainerDataSetMapping(string containerName, string dataSetId, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BlobDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public BlobDataSet(string containerName, string filePath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BlobDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public BlobDataSetMapping(string containerName, string dataSetId, string filePath, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string FilePath { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.OutputType? OutputType { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BlobFolderDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public BlobFolderDataSet(string containerName, string prefix, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class BlobFolderDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public BlobFolderDataSetMapping(string containerName, string dataSetId, string prefix, string resourceGroup, string storageAccountName, string subscriptionId) { }
        public string ContainerName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string Prefix { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceGroup { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
    }
    public partial class ConsumerSourceDataSet : Azure.ResourceManager.Models.ResourceData
    {
        public ConsumerSourceDataSet() { }
        public string DataSetId { get { throw null; } }
        public string DataSetLocation { get { throw null; } }
        public string DataSetName { get { throw null; } }
        public string DataSetPath { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataSetType? DataSetType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSetMappingStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataSetMappingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSetMappingStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataSetMappingStatus Broken { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetMappingStatus Ok { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus left, Azure.ResourceManager.DataShare.Models.DataSetMappingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataSetMappingStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataSetMappingStatus left, Azure.ResourceManager.DataShare.Models.DataSetMappingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSetType : System.IEquatable<Azure.ResourceManager.DataShare.Models.DataSetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSetType(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.DataSetType AdlsGen1File { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType AdlsGen1Folder { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType AdlsGen2File { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType AdlsGen2FileSystem { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType AdlsGen2Folder { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType Blob { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType BlobFolder { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType Container { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType KustoCluster { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType KustoDatabase { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType KustoTable { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType SqlDBTable { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType SqlDWTable { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.DataSetType SynapseWorkspaceSqlPoolTable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.DataSetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.DataSetType left, Azure.ResourceManager.DataShare.Models.DataSetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.DataSetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.DataSetType left, Azure.ResourceManager.DataShare.Models.DataSetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmailRegistration
    {
        public EmailRegistration() { }
        public string ActivationCode { get { throw null; } set { } }
        public System.DateTimeOffset? ActivationExpirationOn { get { throw null; } }
        public string Email { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.RegistrationStatus? RegistrationStatus { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InvitationStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.InvitationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InvitationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.InvitationStatus Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.InvitationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.InvitationStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.InvitationStatus Withdrawn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.InvitationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.InvitationStatus left, Azure.ResourceManager.DataShare.Models.InvitationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.InvitationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.InvitationStatus left, Azure.ResourceManager.DataShare.Models.InvitationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KustoClusterDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public KustoClusterDataSet(string kustoClusterResourceId) { }
        public string DataSetId { get { throw null; } }
        public string KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class KustoClusterDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public KustoClusterDataSetMapping(string dataSetId, string kustoClusterResourceId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class KustoDatabaseDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public KustoDatabaseDataSet(string kustoDatabaseResourceId) { }
        public string DataSetId { get { throw null; } }
        public string KustoDatabaseResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class KustoDatabaseDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public KustoDatabaseDataSetMapping(string dataSetId, string kustoClusterResourceId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class KustoTableDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public KustoTableDataSet(string kustoDatabaseResourceId, Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties tableLevelSharingProperties) { }
        public string DataSetId { get { throw null; } }
        public string KustoDatabaseResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.TableLevelSharingProperties TableLevelSharingProperties { get { throw null; } set { } }
    }
    public partial class KustoTableDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public KustoTableDataSetMapping(string dataSetId, string kustoClusterResourceId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string KustoClusterResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class OperationResponse
    {
        internal OperationResponse() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.Status Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OutputType : System.IEquatable<Azure.ResourceManager.DataShare.Models.OutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OutputType(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.OutputType Csv { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.OutputType Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.OutputType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.OutputType left, Azure.ResourceManager.DataShare.Models.OutputType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.OutputType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.OutputType left, Azure.ResourceManager.DataShare.Models.OutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DataShare.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.ProvisioningState left, Azure.ResourceManager.DataShare.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.ProvisioningState left, Azure.ResourceManager.DataShare.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceInterval : System.IEquatable<Azure.ResourceManager.DataShare.Models.RecurrenceInterval>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceInterval(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.RecurrenceInterval Day { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.RecurrenceInterval Hour { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.RecurrenceInterval other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.RecurrenceInterval left, Azure.ResourceManager.DataShare.Models.RecurrenceInterval right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.RecurrenceInterval (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.RecurrenceInterval left, Azure.ResourceManager.DataShare.Models.RecurrenceInterval right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegistrationStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.RegistrationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegistrationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.RegistrationStatus Activated { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.RegistrationStatus ActivationAttemptsExhausted { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.RegistrationStatus ActivationPending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.RegistrationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.RegistrationStatus left, Azure.ResourceManager.DataShare.Models.RegistrationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.RegistrationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.RegistrationStatus left, Azure.ResourceManager.DataShare.Models.RegistrationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduledSourceSynchronizationSetting : Azure.ResourceManager.DataShare.Models.SourceShareSynchronizationSetting
    {
        internal ScheduledSourceSynchronizationSetting() { }
        public Azure.ResourceManager.DataShare.Models.RecurrenceInterval? RecurrenceInterval { get { throw null; } }
        public System.DateTimeOffset? SynchronizationOn { get { throw null; } }
    }
    public partial class ScheduledSynchronizationSetting : Azure.ResourceManager.DataShare.SynchronizationSettingData
    {
        public ScheduledSynchronizationSetting(Azure.ResourceManager.DataShare.Models.RecurrenceInterval recurrenceInterval, System.DateTimeOffset synchronizationOn) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.RecurrenceInterval RecurrenceInterval { get { throw null; } set { } }
        public System.DateTimeOffset SynchronizationOn { get { throw null; } set { } }
        public string UserName { get { throw null; } }
    }
    public partial class ScheduledTrigger : Azure.ResourceManager.DataShare.TriggerData
    {
        public ScheduledTrigger(Azure.ResourceManager.DataShare.Models.RecurrenceInterval recurrenceInterval, System.DateTimeOffset synchronizationOn) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.RecurrenceInterval RecurrenceInterval { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } set { } }
        public System.DateTimeOffset SynchronizationOn { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.TriggerStatus? TriggerStatus { get { throw null; } }
        public string UserName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareKind : System.IEquatable<Azure.ResourceManager.DataShare.Models.ShareKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareKind(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ShareKind CopyBased { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareKind InPlace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.ShareKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.ShareKind left, Azure.ResourceManager.DataShare.Models.ShareKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.ShareKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.ShareKind left, Azure.ResourceManager.DataShare.Models.ShareKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareSubscriptionStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus Revoked { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus Revoking { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus SourceDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus left, Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus left, Azure.ResourceManager.DataShare.Models.ShareSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareSubscriptionSynchronization
    {
        public ShareSubscriptionSynchronization(string synchronizationId) { }
        public int? DurationMs { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public string SynchronizationId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } }
    }
    public partial class ShareSynchronization
    {
        public ShareSynchronization() { }
        public string ConsumerEmail { get { throw null; } set { } }
        public string ConsumerName { get { throw null; } set { } }
        public string ConsumerTenantName { get { throw null; } set { } }
        public int? DurationMs { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string SynchronizationId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } }
    }
    public abstract partial class SourceShareSynchronizationSetting
    {
        protected SourceShareSynchronizationSetting() { }
    }
    public partial class SqlDBTableDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public SqlDBTableDataSet() { }
        public string DatabaseName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } }
        public string SchemaName { get { throw null; } set { } }
        public string SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class SqlDBTableDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public SqlDBTableDataSetMapping(string databaseName, string dataSetId, string schemaName, string sqlServerResourceId, string tableName) { }
        public string DatabaseName { get { throw null; } set { } }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaName { get { throw null; } set { } }
        public string SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class SqlDWTableDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public SqlDWTableDataSet() { }
        public string DataSetId { get { throw null; } }
        public string DataWarehouseName { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    public partial class SqlDWTableDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public SqlDWTableDataSetMapping(string dataSetId, string dataWarehouseName, string schemaName, string sqlServerResourceId, string tableName) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public string DataWarehouseName { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaName { get { throw null; } set { } }
        public string SqlServerResourceId { get { throw null; } set { } }
        public string TableName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.DataShare.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.Status Accepted { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.Status Canceled { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.Status Failed { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.Status InProgress { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.Status Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.Status TransientFailure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.Status left, Azure.ResourceManager.DataShare.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.Status left, Azure.ResourceManager.DataShare.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SynapseWorkspaceSqlPoolTableDataSet : Azure.ResourceManager.DataShare.DataSetData
    {
        public SynapseWorkspaceSqlPoolTableDataSet(string synapseWorkspaceSqlPoolTableResourceId) { }
        public string DataSetId { get { throw null; } }
        public string SynapseWorkspaceSqlPoolTableResourceId { get { throw null; } set { } }
    }
    public partial class SynapseWorkspaceSqlPoolTableDataSetMapping : Azure.ResourceManager.DataShare.DataSetMappingData
    {
        public SynapseWorkspaceSqlPoolTableDataSetMapping(string dataSetId, string synapseWorkspaceSqlPoolTableResourceId) { }
        public string DataSetId { get { throw null; } set { } }
        public Azure.ResourceManager.DataShare.Models.DataSetMappingStatus? DataSetMappingStatus { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SynapseWorkspaceSqlPoolTableResourceId { get { throw null; } set { } }
    }
    public partial class SynchronizationDetails
    {
        internal SynchronizationDetails() { }
        public string DataSetId { get { throw null; } }
        public Azure.ResourceManager.DataShare.Models.DataSetType? DataSetType { get { throw null; } }
        public int? DurationMs { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public long? FilesRead { get { throw null; } }
        public long? FilesWritten { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public long? RowsCopied { get { throw null; } }
        public long? RowsRead { get { throw null; } }
        public long? SizeRead { get { throw null; } }
        public long? SizeWritten { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        public long? VCore { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SynchronizationMode : System.IEquatable<Azure.ResourceManager.DataShare.Models.SynchronizationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SynchronizationMode(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.SynchronizationMode FullSync { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.SynchronizationMode Incremental { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.SynchronizationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.SynchronizationMode left, Azure.ResourceManager.DataShare.Models.SynchronizationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.SynchronizationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.SynchronizationMode left, Azure.ResourceManager.DataShare.Models.SynchronizationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Synchronize
    {
        public Synchronize() { }
        public Azure.ResourceManager.DataShare.Models.SynchronizationMode? SynchronizationMode { get { throw null; } set { } }
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
    public readonly partial struct TriggerStatus : System.IEquatable<Azure.ResourceManager.DataShare.Models.TriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.DataShare.Models.TriggerStatus Active { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.TriggerStatus Inactive { get { throw null; } }
        public static Azure.ResourceManager.DataShare.Models.TriggerStatus SourceSynchronizationSettingDeleted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DataShare.Models.TriggerStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DataShare.Models.TriggerStatus left, Azure.ResourceManager.DataShare.Models.TriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DataShare.Models.TriggerStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DataShare.Models.TriggerStatus left, Azure.ResourceManager.DataShare.Models.TriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
