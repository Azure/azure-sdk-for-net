namespace Azure.ResourceManager.Communication
{
    public partial class CommunicationDomainResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CommunicationDomainResource() { }
        public virtual Azure.ResourceManager.Communication.CommunicationDomainResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CancelVerification(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CancelVerificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string emailServiceName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SenderUsernameResource> GetSenderUsernameResource(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SenderUsernameResource>> GetSenderUsernameResourceAsync(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.SenderUsernameResourceCollection GetSenderUsernameResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SuppressionListResource> GetSuppressionListResource(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SuppressionListResource>> GetSuppressionListResourceAsync(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.SuppressionListResourceCollection GetSuppressionListResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InitiateVerification(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateVerificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationDomainResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationDomainResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationDomainResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationDomainResource>, System.Collections.IEnumerable
    {
        protected CommunicationDomainResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.Communication.CommunicationDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.CommunicationDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.Communication.CommunicationDomainResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.CommunicationDomainResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationDomainResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Communication.CommunicationDomainResource> GetIfExists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Communication.CommunicationDomainResource>> GetIfExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.CommunicationDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.CommunicationDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunicationDomainResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CommunicationDomainResourceData(Azure.Core.AzureLocation location) { }
        public string DataLocation { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainManagement? DomainManagement { get { throw null; } set { } }
        public string FromSenderDomain { get { throw null; } }
        public string MailFromSenderDomain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.UserEngagementTracking? UserEngagementTracking { get { throw null; } set { } }
        public Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords VerificationRecords { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates VerificationStates { get { throw null; } }
    }
    public static partial class CommunicationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult> CheckCommunicationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>> CheckCommunicationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationDomainResource GetCommunicationDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationServiceResource GetCommunicationServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> GetCommunicationServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationServiceResourceCollection GetCommunicationServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.EmailServiceResource GetEmailServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> GetEmailServiceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.EmailServiceResourceCollection GetEmailServiceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Communication.SenderUsernameResource GetSenderUsernameResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Communication.SuppressionListAddressResource GetSuppressionListAddressResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Communication.SuppressionListResource GetSuppressionListResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys> RegenerateKey(Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>> RegenerateKeyAsync(Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> Update(Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> UpdateAsync(Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Communication.CommunicationServiceResource> GetIfExists(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Communication.CommunicationServiceResource>> GetIfExistsAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.CommunicationServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.CommunicationServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.CommunicationServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.CommunicationServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CommunicationServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CommunicationServiceResourceData(Azure.Core.AzureLocation location) { }
        public string DataLocation { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? ImmutableResourceId { get { throw null; } }
        public System.Collections.Generic.IList<string> LinkedDomains { get { throw null; } }
        public Azure.Core.ResourceIdentifier NotificationHubId { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> GetCommunicationDomainResource(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> GetCommunicationDomainResourceAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.CommunicationDomainResourceCollection GetCommunicationDomainResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.EmailServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.EmailServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.NullableResponse<Azure.ResourceManager.Communication.EmailServiceResource> GetIfExists(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Communication.EmailServiceResource>> GetIfExistsAsync(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.EmailServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.EmailServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.EmailServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.EmailServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmailServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public EmailServiceResourceData(Azure.Core.AzureLocation location) { }
        public string DataLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class SenderUsernameResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SenderUsernameResource() { }
        public virtual Azure.ResourceManager.Communication.SenderUsernameResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string emailServiceName, string domainName, string senderUsername) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SenderUsernameResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SenderUsernameResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SenderUsernameResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.SenderUsernameResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SenderUsernameResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.SenderUsernameResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SenderUsernameResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.SenderUsernameResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.SenderUsernameResource>, System.Collections.IEnumerable
    {
        protected SenderUsernameResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SenderUsernameResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string senderUsername, Azure.ResourceManager.Communication.SenderUsernameResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SenderUsernameResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string senderUsername, Azure.ResourceManager.Communication.SenderUsernameResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SenderUsernameResource> Get(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.SenderUsernameResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.SenderUsernameResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SenderUsernameResource>> GetAsync(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Communication.SenderUsernameResource> GetIfExists(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Communication.SenderUsernameResource>> GetIfExistsAsync(string senderUsername, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.SenderUsernameResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.SenderUsernameResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.SenderUsernameResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.SenderUsernameResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SenderUsernameResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SenderUsernameResourceData() { }
        public string DataLocation { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string Username { get { throw null; } set { } }
    }
    public partial class SuppressionListAddressResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SuppressionListAddressResource() { }
        public virtual Azure.ResourceManager.Communication.SuppressionListAddressResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string emailServiceName, string domainName, string suppressionListName, string addressId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SuppressionListAddressResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SuppressionListAddressResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListAddressResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.SuppressionListAddressResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListAddressResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.SuppressionListAddressResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SuppressionListAddressResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.SuppressionListAddressResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.SuppressionListAddressResource>, System.Collections.IEnumerable
    {
        protected SuppressionListAddressResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListAddressResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string addressId, Azure.ResourceManager.Communication.SuppressionListAddressResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListAddressResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string addressId, Azure.ResourceManager.Communication.SuppressionListAddressResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SuppressionListAddressResource> Get(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.SuppressionListAddressResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.SuppressionListAddressResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SuppressionListAddressResource>> GetAsync(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Communication.SuppressionListAddressResource> GetIfExists(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Communication.SuppressionListAddressResource>> GetIfExistsAsync(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.SuppressionListAddressResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.SuppressionListAddressResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.SuppressionListAddressResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.SuppressionListAddressResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SuppressionListAddressResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SuppressionListAddressResourceData() { }
        public string DataLocation { get { throw null; } }
        public string Email { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string LastName { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
    }
    public partial class SuppressionListResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SuppressionListResource() { }
        public virtual Azure.ResourceManager.Communication.SuppressionListResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string emailServiceName, string domainName, string suppressionListName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SuppressionListResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SuppressionListResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SuppressionListAddressResource> GetSuppressionListAddressResource(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SuppressionListAddressResource>> GetSuppressionListAddressResourceAsync(string addressId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.SuppressionListAddressResourceCollection GetSuppressionListAddressResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.SuppressionListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.SuppressionListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SuppressionListResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.SuppressionListResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.SuppressionListResource>, System.Collections.IEnumerable
    {
        protected SuppressionListResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string suppressionListName, Azure.ResourceManager.Communication.SuppressionListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Communication.SuppressionListResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string suppressionListName, Azure.ResourceManager.Communication.SuppressionListResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.SuppressionListResource> Get(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.SuppressionListResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.SuppressionListResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.SuppressionListResource>> GetAsync(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Communication.SuppressionListResource> GetIfExists(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Communication.SuppressionListResource>> GetIfExistsAsync(string suppressionListName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Communication.SuppressionListResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Communication.SuppressionListResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Communication.SuppressionListResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Communication.SuppressionListResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SuppressionListResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SuppressionListResourceData() { }
        public System.DateTimeOffset? CreatedTimeStamp { get { throw null; } }
        public string DataLocation { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedTimeStamp { get { throw null; } }
        public string ListName { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.Communication.Mocking
{
    public partial class MockableCommunicationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCommunicationArmClient() { }
        public virtual Azure.ResourceManager.Communication.CommunicationDomainResource GetCommunicationDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceResource GetCommunicationServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Communication.EmailServiceResource GetEmailServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Communication.SenderUsernameResource GetSenderUsernameResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Communication.SuppressionListAddressResource GetSuppressionListAddressResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Communication.SuppressionListResource GetSuppressionListResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCommunicationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommunicationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResource(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationServiceResource>> GetCommunicationServiceResourceAsync(string communicationServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.CommunicationServiceResourceCollection GetCommunicationServiceResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResource(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.EmailServiceResource>> GetEmailServiceResourceAsync(string emailServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Communication.EmailServiceResourceCollection GetEmailServiceResources() { throw null; }
    }
    public partial class MockableCommunicationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommunicationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult> CheckCommunicationNameAvailability(Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>> CheckCommunicationNameAvailabilityAsync(Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.CommunicationServiceResource> GetCommunicationServiceResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Communication.EmailServiceResource> GetEmailServiceResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetVerifiedExchangeOnlineDomainsEmailServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetVerifiedExchangeOnlineDomainsEmailServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Communication.Models
{
    public static partial class ArmCommunicationModelFactory
    {
        public static Azure.ResourceManager.Communication.CommunicationDomainResourceData CommunicationDomainResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Communication.Models.DomainProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.DomainProvisioningState?), string dataLocation = null, string fromSenderDomain = null, string mailFromSenderDomain = null, Azure.ResourceManager.Communication.Models.DomainManagement? domainManagement = default(Azure.ResourceManager.Communication.Models.DomainManagement?), Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates verificationStates = null, Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords verificationRecords = null, Azure.ResourceManager.Communication.Models.UserEngagementTracking? userEngagementTracking = default(Azure.ResourceManager.Communication.Models.UserEngagementTracking?)) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult CommunicationNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason? reason = default(Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceKeys CommunicationServiceKeys(string primaryKey = null, string secondaryKey = null, string primaryConnectionString = null, string secondaryConnectionString = null) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationServiceResourceData CommunicationServiceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState?), string hostName = null, string dataLocation = null, Azure.Core.ResourceIdentifier notificationHubId = null, string version = null, System.Guid? immutableResourceId = default(System.Guid?), System.Collections.Generic.IEnumerable<string> linkedDomains = null) { throw null; }
        public static Azure.ResourceManager.Communication.CommunicationServiceResourceData CommunicationServiceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState?), string hostName = null, string dataLocation = null, Azure.Core.ResourceIdentifier notificationHubId = null, string version = null, System.Guid? immutableResourceId = default(System.Guid?), System.Collections.Generic.IEnumerable<string> linkedDomains = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords DomainPropertiesVerificationRecords(Azure.ResourceManager.Communication.Models.VerificationDnsRecord domain = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord spf = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord dkim = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord dkim2 = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord dmarc = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates DomainPropertiesVerificationStates(Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord domain = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord spf = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord dkim = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord dkim2 = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord dmarc = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord DomainVerificationStatusRecord(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus? status = default(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus?), string errorCode = null) { throw null; }
        public static Azure.ResourceManager.Communication.EmailServiceResourceData EmailServiceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState?), string dataLocation = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.LinkedNotificationHub LinkedNotificationHub(Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Communication.SenderUsernameResourceData SenderUsernameResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string dataLocation = null, string username = null, string displayName = null, Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Communication.SuppressionListAddressResourceData SuppressionListAddressResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string email = null, string firstName = null, string lastName = null, string notes = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), string dataLocation = null) { throw null; }
        public static Azure.ResourceManager.Communication.SuppressionListResourceData SuppressionListResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string listName = null, System.DateTimeOffset? lastUpdatedTimeStamp = default(System.DateTimeOffset?), System.DateTimeOffset? createdTimeStamp = default(System.DateTimeOffset?), string dataLocation = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.VerificationDnsRecord VerificationDnsRecord(string dnsRecordType = null, string name = null, string value = null, int? timeToLiveInSeconds = default(int?)) { throw null; }
    }
    public partial class CommunicationAcceptTags
    {
        public CommunicationAcceptTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class CommunicationDomainResourcePatch : Azure.ResourceManager.Communication.Models.CommunicationAcceptTags
    {
        public CommunicationDomainResourcePatch() { }
        public Azure.ResourceManager.Communication.Models.UserEngagementTracking? UserEngagementTracking { get { throw null; } set { } }
    }
    public partial class CommunicationNameAvailabilityContent
    {
        public CommunicationNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason left, Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason left, Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunicationNameAvailabilityResult
    {
        internal CommunicationNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class CommunicationServiceKeys
    {
        internal CommunicationServiceKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
    }
    public enum CommunicationServiceKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class CommunicationServiceNameAvailabilityContent : Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent
    {
        public CommunicationServiceNameAvailabilityContent() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationServiceProvisioningState : System.IEquatable<Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationServiceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState left, Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState left, Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunicationServiceResourcePatch : Azure.ResourceManager.Communication.Models.CommunicationAcceptTags
    {
        public CommunicationServiceResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LinkedDomains { get { throw null; } }
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
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Dkim { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Dkim2 { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Dmarc { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Domain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Spf { get { throw null; } }
    }
    public partial class DomainPropertiesVerificationStates
    {
        internal DomainPropertiesVerificationStates() { }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Dkim { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Dkim2 { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Dmarc { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Domain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Spf { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainProvisioningState : System.IEquatable<Azure.ResourceManager.Communication.Models.DomainProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.DomainProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.DomainProvisioningState left, Azure.ResourceManager.Communication.Models.DomainProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.DomainProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.DomainProvisioningState left, Azure.ResourceManager.Communication.Models.DomainProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainRecordVerificationStatus : System.IEquatable<Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainRecordVerificationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus CancellationRequested { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus VerificationFailed { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus VerificationInProgress { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus VerificationRequested { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus Verified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus left, Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus left, Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainRecordVerificationType : System.IEquatable<Azure.ResourceManager.Communication.Models.DomainRecordVerificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainRecordVerificationType(string value) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationType Dkim { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationType Dkim2 { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationType Dmarc { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationType Domain { get { throw null; } }
        public static Azure.ResourceManager.Communication.Models.DomainRecordVerificationType Spf { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Communication.Models.DomainRecordVerificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Communication.Models.DomainRecordVerificationType left, Azure.ResourceManager.Communication.Models.DomainRecordVerificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Communication.Models.DomainRecordVerificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Communication.Models.DomainRecordVerificationType left, Azure.ResourceManager.Communication.Models.DomainRecordVerificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DomainsRecordVerificationContent
    {
        public DomainsRecordVerificationContent(Azure.ResourceManager.Communication.Models.DomainRecordVerificationType verificationType) { }
        public Azure.ResourceManager.Communication.Models.DomainRecordVerificationType VerificationType { get { throw null; } }
    }
    public partial class DomainVerificationStatusRecord
    {
        internal DomainVerificationStatusRecord() { }
        public string ErrorCode { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus? Status { get { throw null; } }
    }
    public partial class EmailServiceResourcePatch : Azure.ResourceManager.Communication.Models.CommunicationAcceptTags
    {
        public EmailServiceResourcePatch() { }
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
    public partial class LinkedNotificationHub
    {
        internal LinkedNotificationHub() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
    }
    public partial class LinkNotificationHubContent
    {
        public LinkNotificationHubContent(Azure.Core.ResourceIdentifier resourceId, string connectionString) { }
        public string ConnectionString { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
    }
    public partial class RegenerateCommunicationServiceKeyContent
    {
        public RegenerateCommunicationServiceKeyContent() { }
        public Azure.ResourceManager.Communication.Models.CommunicationServiceKeyType? KeyType { get { throw null; } set { } }
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
    public partial class VerificationDnsRecord
    {
        internal VerificationDnsRecord() { }
        public string DnsRecordType { get { throw null; } }
        public string Name { get { throw null; } }
        public int? TimeToLiveInSeconds { get { throw null; } }
        public string Value { get { throw null; } }
    }
}
