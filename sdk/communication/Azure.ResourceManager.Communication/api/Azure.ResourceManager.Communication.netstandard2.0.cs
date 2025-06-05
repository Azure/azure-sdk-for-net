namespace Azure.ResourceManager.Communication
{
    public partial class AzureResourceManagerCommunicationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCommunicationContext() { }
        public static Azure.ResourceManager.Communication.AzureResourceManagerCommunicationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CommunicationDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>
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
        public virtual Azure.ResourceManager.ArmOperation InitiateVerification(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InitiateVerificationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Communication.CommunicationDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Communication.CommunicationDomainResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.CommunicationDomainResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CommunicationDomainResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.CommunicationDomainResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.CommunicationDomainResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationDomainResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Pageable<string> GetVerifiedExchangeOnlineDomainsEmailServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<string> GetVerifiedExchangeOnlineDomainsEmailServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CommunicationServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>
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
        Azure.ResourceManager.Communication.CommunicationServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.CommunicationServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CommunicationServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.CommunicationServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.CommunicationServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.CommunicationServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmailServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.EmailServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>
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
        Azure.ResourceManager.Communication.EmailServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.EmailServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EmailServiceResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.EmailServiceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>
    {
        public EmailServiceResourceData(Azure.Core.AzureLocation location) { }
        public string DataLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.EmailServiceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.EmailServiceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.EmailServiceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SenderUsernameResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>
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
        Azure.ResourceManager.Communication.SenderUsernameResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.SenderUsernameResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SenderUsernameResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>
    {
        public SenderUsernameResourceData() { }
        public string DataLocation { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState? ProvisioningState { get { throw null; } }
        public string Username { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.SenderUsernameResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.SenderUsernameResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.SenderUsernameResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Communication.CommunicationServiceResourceData CommunicationServiceResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Communication.Models.CommunicationServicesProvisioningState? provisioningState, string hostName, string dataLocation, Azure.Core.ResourceIdentifier notificationHubId, string version, System.Guid? immutableResourceId, System.Collections.Generic.IEnumerable<string> linkedDomains) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords DomainPropertiesVerificationRecords(Azure.ResourceManager.Communication.Models.VerificationDnsRecord domain = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord spf = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord dkim = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord dkim2 = null, Azure.ResourceManager.Communication.Models.VerificationDnsRecord dmarc = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates DomainPropertiesVerificationStates(Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord domain = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord spf = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord dkim = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord dkim2 = null, Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord dmarc = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord DomainVerificationStatusRecord(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus? status = default(Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus?), string errorCode = null) { throw null; }
        public static Azure.ResourceManager.Communication.EmailServiceResourceData EmailServiceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.EmailServicesProvisioningState?), string dataLocation = null) { throw null; }
        public static Azure.ResourceManager.Communication.Models.LinkedNotificationHub LinkedNotificationHub(Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.Communication.SenderUsernameResourceData SenderUsernameResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string dataLocation = null, string username = null, string displayName = null, Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState? provisioningState = default(Azure.ResourceManager.Communication.Models.CommunicationServiceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Communication.Models.VerificationDnsRecord VerificationDnsRecord(string dnsRecordType = null, string name = null, string value = null, int? timeToLiveInSeconds = default(int?)) { throw null; }
    }
    public partial class CommunicationAcceptTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>
    {
        public CommunicationAcceptTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationAcceptTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationAcceptTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationAcceptTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunicationDomainResourcePatch : Azure.ResourceManager.Communication.Models.CommunicationAcceptTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>
    {
        public CommunicationDomainResourcePatch() { }
        public Azure.ResourceManager.Communication.Models.UserEngagementTracking? UserEngagementTracking { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationDomainResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunicationNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>
    {
        public CommunicationNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CommunicationNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>
    {
        internal CommunicationNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommunicationServiceKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>
    {
        internal CommunicationServiceKeys() { }
        public string PrimaryConnectionString { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryConnectionString { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationServiceKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationServiceKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CommunicationServiceKeyType
    {
        Primary = 0,
        Secondary = 1,
    }
    public partial class CommunicationServiceNameAvailabilityContent : Azure.ResourceManager.Communication.Models.CommunicationNameAvailabilityContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>
    {
        public CommunicationServiceNameAvailabilityContent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CommunicationServiceResourcePatch : Azure.ResourceManager.Communication.Models.CommunicationAcceptTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>
    {
        public CommunicationServiceResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LinkedDomains { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.CommunicationServiceResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DomainPropertiesVerificationRecords : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>
    {
        internal DomainPropertiesVerificationRecords() { }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Dkim { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Dkim2 { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Dmarc { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Domain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.VerificationDnsRecord Spf { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationRecords>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainPropertiesVerificationStates : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>
    {
        internal DomainPropertiesVerificationStates() { }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Dkim { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Dkim2 { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Dmarc { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Domain { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord Spf { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainPropertiesVerificationStates>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DomainsRecordVerificationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>
    {
        public DomainsRecordVerificationContent(Azure.ResourceManager.Communication.Models.DomainRecordVerificationType verificationType) { }
        public Azure.ResourceManager.Communication.Models.DomainRecordVerificationType VerificationType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainsRecordVerificationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainVerificationStatusRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>
    {
        internal DomainVerificationStatusRecord() { }
        public string ErrorCode { get { throw null; } }
        public Azure.ResourceManager.Communication.Models.DomainRecordVerificationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.DomainVerificationStatusRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmailServiceResourcePatch : Azure.ResourceManager.Communication.Models.CommunicationAcceptTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>
    {
        public EmailServiceResourcePatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.EmailServiceResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LinkedNotificationHub : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>
    {
        internal LinkedNotificationHub() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.LinkedNotificationHub System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.LinkedNotificationHub System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkedNotificationHub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkNotificationHubContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>
    {
        public LinkNotificationHubContent(Azure.Core.ResourceIdentifier resourceId, string connectionString) { }
        public string ConnectionString { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.LinkNotificationHubContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.LinkNotificationHubContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.LinkNotificationHubContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegenerateCommunicationServiceKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>
    {
        public RegenerateCommunicationServiceKeyContent() { }
        public Azure.ResourceManager.Communication.Models.CommunicationServiceKeyType? KeyType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.RegenerateCommunicationServiceKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VerificationDnsRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>
    {
        internal VerificationDnsRecord() { }
        public string DnsRecordType { get { throw null; } }
        public string Name { get { throw null; } }
        public int? TimeToLiveInSeconds { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.VerificationDnsRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Communication.Models.VerificationDnsRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Communication.Models.VerificationDnsRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
