namespace Azure.ResourceManager.Communication
{
    public static partial class CommunicationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Communication.Models.CheckNameAvailabilityResponse> CheckNameAvailabilityCommunicationService(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Communication.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityCommunicationServiceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Communication.Models.NameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationServiceResource GetCommunicationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> GetCommunicationServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationServiceResourceCollection GetCommunicationServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.DomainResource GetDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Communication.EmailServiceResource GetEmailServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> GetEmailServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.EmailServiceResourceCollection GetEmailServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<string> GetVerifiedExchangeOnlineDomainsEmailServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<string> GetVerifiedExchangeOnlineDomainsEmailServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunicationServiceResource() { }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string communicationServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.LinkedNotificationHub> LinkNotificationHub(Azure.ResourceManager.Communication.Models.LinkNotificationHubContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>> LinkNotificationHubAsync(Azure.ResourceManager.Communication.Models.LinkNotificationHubContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.CommunicationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.CommunicationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationServiceResource>, System.Collections.IEnumerable
    {
        protected CommunicationServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string communicationServiceName, Azure.ResourceManager.Communication.CommunicationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string communicationServiceName, Azure.ResourceManager.Communication.CommunicationServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> Get(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> GetAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.CommunicationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.CommunicationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunicationServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CommunicationServiceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DataLocation { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public string ImmutableResourceId { get { throw null; } }
        public System.Collections.Generic.IList<string> LinkedDomains { get { throw null; } }
        public string NotificationHubId { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class DomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainResource() { }
        public virtual Azure.ResourceManager.Communication.DomainResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Communication.DomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.DomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CancelVerification(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.VerificationParameter verificationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelVerificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.VerificationParameter verificationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string emailServiceName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.DomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.DomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateVerification(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.VerificationParameter verificationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateVerificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.VerificationParameter verificationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.DomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.DomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.DomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.DomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.DomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.DomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.DomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.DomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.DomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.DomainResource>, System.Collections.IEnumerable
    {
        protected DomainResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.DomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.Communication.DomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.DomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.Communication.DomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.DomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.DomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.DomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.DomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.DomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.DomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.DomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.DomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DomainResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DataLocation { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainManagement? DomainManagement { get { throw null; } set { } }
        public string FromSenderDomain { get { throw null; } }
        public string MailFromSenderDomain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.UserEngagementTracking? UserEngagementTracking { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ValidSenderUsernames { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords VerificationRecords { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates VerificationStates { get { throw null; } }
    }
    public partial class EmailServiceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EmailServiceResource() { }
        public virtual Azure.ResourceManager.Communication.EmailServiceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string emailServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.DomainResource> GetDomainResource(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.DomainResource>> GetDomainResourceAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.DomainResourceCollection GetDomainResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.EmailServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.EmailServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.EmailServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.EmailServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailServiceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.EmailServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.EmailServiceResource>, System.Collections.IEnumerable
    {
        protected EmailServiceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.EmailServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string emailServiceName, Azure.ResourceManager.Communication.EmailServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.EmailServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string emailServiceName, Azure.ResourceManager.Communication.EmailServiceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> Get(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.EmailServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.EmailServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> GetAsync(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.EmailServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.EmailServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.EmailServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.EmailServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmailServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EmailServiceResourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string DataLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState? ProvisioningState { get { throw null; } }
    }
}
namespace Azure.ResourceManager.Communication.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityRequest
    {
        public CheckNameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResponse
    {
        internal CheckNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class CommunicationServiceKeys
    {
        internal CommunicationServiceKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationServicesProvisioningState : System.IEquatable<Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationServicesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState left, Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState left, Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsRecord
    {
        internal DnsRecord() { }
        public string DnsRecordType { get { throw null; } }
        public string Name { get { throw null; } }
        public int? Ttl { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainManagement : System.IEquatable<Azure.ResourceManager.Communication.Models.DomainManagement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainManagement(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainManagement AzureManaged { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainManagement CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainManagement CustomerManagedInExchangeOnline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.DomainManagement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.DomainManagement left, Azure.ResourceManager.Communication.Models.DomainManagement right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.DomainManagement (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.DomainManagement left, Azure.ResourceManager.Communication.Models.DomainManagement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainPropertiesVerificationRecords
    {
        internal DomainPropertiesVerificationRecords() { }
        public Azure.ResourceManager.Communication.Models.DnsRecord Dkim { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DnsRecord Dkim2 { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DnsRecord Dmarc { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DnsRecord Domain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DnsRecord SPF { get { throw null; } }
    }
    public partial class DomainPropertiesVerificationStates
    {
        internal DomainPropertiesVerificationStates() { }
        public Azure.ResourceManager.Communication.Models.VerificationStatusRecord Dkim { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationStatusRecord Dkim2 { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationStatusRecord Dmarc { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationStatusRecord Domain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationStatusRecord SPF { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainsProvisioningState : System.IEquatable<Azure.ResourceManager.Communication.Models.DomainsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainsProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.DomainsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.DomainsProvisioningState left, Azure.ResourceManager.Communication.Models.DomainsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.DomainsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.DomainsProvisioningState left, Azure.ResourceManager.Communication.Models.DomainsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EmailServicesProvisioningState : System.IEquatable<Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EmailServicesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState left, Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState left, Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum KeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class LinkedNotificationHub
    {
        internal LinkedNotificationHub() { }
        public string ResourceId { get { throw null; } }
    }
    public partial class LinkNotificationHubContent
    {
        public LinkNotificationHubContent(string resourceId, string connectionString) { }
        public string ConnectionString { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class NameAvailabilityContent : Azure.ResourceManager.Communication.Models.CheckNameAvailabilityRequest
    {
        public NameAvailabilityContent() { }
    }
    public partial class RegenerateKeyContent
    {
        public RegenerateKeyContent() { }
        public Azure.ResourceManager.Communication.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserEngagementTracking : System.IEquatable<Azure.ResourceManager.Communication.Models.UserEngagementTracking>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserEngagementTracking(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.UserEngagementTracking Disabled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.UserEngagementTracking Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.UserEngagementTracking other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.UserEngagementTracking left, Azure.ResourceManager.Communication.Models.UserEngagementTracking right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.UserEngagementTracking (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.UserEngagementTracking left, Azure.ResourceManager.Communication.Models.UserEngagementTracking right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VerificationParameter
    {
        public VerificationParameter(Azure.ResourceManager.Communication.Models.VerificationType verificationType) { }
        public Azure.ResourceManager.Communication.Models.VerificationType VerificationType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VerificationStatus : System.IEquatable<Azure.ResourceManager.Communication.Models.VerificationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VerificationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.VerificationStatus CancellationRequested { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationStatus VerificationFailed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationStatus VerificationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationStatus VerificationRequested { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationStatus Verified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.VerificationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.VerificationStatus left, Azure.ResourceManager.Communication.Models.VerificationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.VerificationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.VerificationStatus left, Azure.ResourceManager.Communication.Models.VerificationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VerificationStatusRecord
    {
        internal VerificationStatusRecord() { }
        public string ErrorCode { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VerificationType : System.IEquatable<Azure.ResourceManager.Communication.Models.VerificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VerificationType(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.VerificationType Dkim { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationType Dkim2 { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationType Dmarc { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationType Domain { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.VerificationType SPF { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.VerificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.VerificationType left, Azure.ResourceManager.Communication.Models.VerificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.VerificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.VerificationType left, Azure.ResourceManager.Communication.Models.VerificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
