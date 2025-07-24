namespace Azure.ResourceManager.EventGrid
{
    public partial class AzureResourceManagerEventGridContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEventGridContext() { }
        public static Azure.ResourceManager.EventGrid.AzureResourceManagerEventGridContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CaCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.CaCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.CaCertificateResource>, System.Collections.IEnumerable
    {
        protected CaCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.CaCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string caCertificateName, Azure.ResourceManager.EventGrid.CaCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.CaCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string caCertificateName, Azure.ResourceManager.EventGrid.CaCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.CaCertificateResource> Get(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.CaCertificateResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.CaCertificateResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.CaCertificateResource>> GetAsync(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.CaCertificateResource> GetIfExists(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.CaCertificateResource>> GetIfExistsAsync(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.CaCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.CaCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.CaCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.CaCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CaCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.CaCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>
    {
        public CaCertificateData() { }
        public string Description { get { throw null; } set { } }
        public string EncodedCertificate { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiryTimeInUtc { get { throw null; } }
        public System.DateTimeOffset? IssueTimeInUtc { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.CaCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.CaCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaCertificateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.CaCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CaCertificateResource() { }
        public virtual Azure.ResourceManager.EventGrid.CaCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string caCertificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.CaCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.CaCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.CaCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.CaCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.CaCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.CaCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.CaCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.CaCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.CaCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected DomainEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainEventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainNetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.Collections.IEnumerable
    {
        protected DomainNetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource> Get(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource>> GetAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource> GetIfExists(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainNetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainNetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource> Reconcile(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>, System.Collections.IEnumerable
    {
        protected DomainTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> Get(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainTopicResource> GetIfExists(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetIfExistsAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainTopicData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.DomainTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>
    {
        public DomainTopicData() { }
        public Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.DomainTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.DomainTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DomainTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected DomainTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DomainTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DomainTopicResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.DomainTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DomainTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName, string domainTopicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource> GetDomainTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource>> GetDomainTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionCollection GetDomainTopicEventSubscriptions() { throw null; }
        Azure.ResourceManager.EventGrid.DomainTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.DomainTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.DomainTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.DomainTopicResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>, System.Collections.IEnumerable
    {
        protected EventGridDomainCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.EventGrid.EventGridDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string domainName, Azure.ResourceManager.EventGrid.EventGridDomainData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> Get(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetIfExists(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetIfExistsAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridDomainData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>
    {
        public EventGridDomainData(Azure.Core.AzureLocation location) { }
        public bool? AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public bool? AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridSku? SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridDomainPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventGridDomainPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridDomainPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridDomainPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainPrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridDomainPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected EventGridDomainPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridDomainResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridDomainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridDomainResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string domainName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource> GetDomainEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource>> GetDomainEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainEventSubscriptionCollection GetDomainEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource> GetDomainNetworkSecurityPerimeterConfiguration(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource>> GetDomainNetworkSecurityPerimeterConfigurationAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationCollection GetDomainNetworkSecurityPerimeterConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource> GetDomainTopic(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.DomainTopicResource>> GetDomainTopicAsync(string domainTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicCollection GetDomainTopics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource> GetEventGridDomainPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource>> GetEventGridDomainPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionCollection GetEventGridDomainPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource> GetEventGridDomainPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource>> GetEventGridDomainPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResourceCollection GetEventGridDomainPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys> RegenerateKey(Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridDomainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridDomainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridDomainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EventGridExtensions
    {
        public static Azure.ResourceManager.EventGrid.CaCertificateResource GetCaCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource GetDomainEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource GetDomainNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource GetDomainTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicResource GetDomainTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomain(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetEventGridDomainAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource GetEventGridDomainPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainResource GetEventGridDomainResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainCollection GetEventGridDomains(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomains(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomainsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetEventGridNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> GetEventGridNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource GetEventGridNamespaceClientGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource GetEventGridNamespaceClientResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource GetEventGridNamespacePermissionBindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceResource GetEventGridNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceCollection GetEventGridNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetEventGridNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetEventGridNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource GetEventGridPartnerNamespacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetEventGridTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource GetEventGridTopicPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicResource GetEventGridTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicCollection GetEventGridTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetEventSubscription(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetEventSubscriptionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventSubscriptionResource GetEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventSubscriptionCollection GetEventSubscriptions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypes(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypesAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopic(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource GetNamespaceTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.NamespaceTopicResource GetNamespaceTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetPartnerDestination(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> GetPartnerDestinationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerDestinationResource GetPartnerDestinationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerDestinationCollection GetPartnerDestinations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetPartnerDestinations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetPartnerDestinationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetPartnerNamespaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource GetPartnerNamespaceChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceResource GetPartnerNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceCollection GetPartnerNamespaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetPartnerRegistrationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerRegistrationResource GetPartnerRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerRegistrationCollection GetPartnerRegistrations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistrations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistrationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetPartnerTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource GetPartnerTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicResource GetPartnerTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicCollection GetPartnerTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsData(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetSystemTopicAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource GetSystemTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicResource GetSystemTopicResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicCollection GetSystemTopics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopicsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource GetTopicEventSubscriptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource GetTopicNetworkSecurityPerimeterConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicSpaceResource GetTopicSpaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> GetTopicType(this Azure.ResourceManager.Resources.TenantResource tenantResource, string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetTopicTypeAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeResource GetTopicTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeCollection GetTopicTypes(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetVerifiedPartner(this Azure.ResourceManager.Resources.TenantResource tenantResource, string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetVerifiedPartnerAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerResource GetVerifiedPartnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerCollection GetVerifiedPartners(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
    }
    public partial class EventGridNamespaceClientCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>, System.Collections.IEnumerable
    {
        protected EventGridNamespaceClientCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clientName, Azure.ResourceManager.EventGrid.EventGridNamespaceClientData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clientName, Azure.ResourceManager.EventGrid.EventGridNamespaceClientData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> Get(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>> GetAsync(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> GetIfExists(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>> GetIfExistsAsync(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridNamespaceClientData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>
    {
        public EventGridNamespaceClientData() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Attributes { get { throw null; } }
        public string AuthenticationName { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication ClientCertificateAuthentication { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridNamespaceClientGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>, System.Collections.IEnumerable
    {
        protected EventGridNamespaceClientGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clientGroupName, Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clientGroupName, Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> Get(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>> GetAsync(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> GetIfExists(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>> GetIfExistsAsync(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridNamespaceClientGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>
    {
        public EventGridNamespaceClientGroupData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState? ProvisioningState { get { throw null; } }
        public string Query { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridNamespaceClientGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridNamespaceClientGroupResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string clientGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridNamespaceClientResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridNamespaceClientResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceClientData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string clientName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceClientData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceClientData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridNamespaceClientData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridNamespaceClientData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>, System.Collections.IEnumerable
    {
        protected EventGridNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.EventGrid.EventGridNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string namespaceName, Azure.ResourceManager.EventGrid.EventGridNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> Get(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> GetAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetIfExists(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> GetIfExistsAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>
    {
        public EventGridNamespaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsZoneRedundant { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.NamespaceSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicsConfiguration TopicsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration TopicSpacesConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridNamespacePermissionBindingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>, System.Collections.IEnumerable
    {
        protected EventGridNamespacePermissionBindingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string permissionBindingName, Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string permissionBindingName, Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> Get(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>> GetAsync(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> GetIfExists(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>> GetIfExistsAsync(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridNamespacePermissionBindingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>
    {
        public EventGridNamespacePermissionBindingData() { }
        public string ClientGroupName { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PermissionType? Permission { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState? ProvisioningState { get { throw null; } }
        public string TopicSpaceName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridNamespacePermissionBindingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridNamespacePermissionBindingResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string permissionBindingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridNamespaceResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.CaCertificateResource> GetCaCertificate(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.CaCertificateResource>> GetCaCertificateAsync(string caCertificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.CaCertificateCollection GetCaCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource> GetEventGridNamespaceClient(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource>> GetEventGridNamespaceClientAsync(string clientName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource> GetEventGridNamespaceClientGroup(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource>> GetEventGridNamespaceClientGroupAsync(string clientGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupCollection GetEventGridNamespaceClientGroups() { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceClientCollection GetEventGridNamespaceClients() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource> GetEventGridNamespacePermissionBinding(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource>> GetEventGridNamespacePermissionBindingAsync(string permissionBindingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingCollection GetEventGridNamespacePermissionBindings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicResource> GetNamespaceTopic(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicResource>> GetNamespaceTopicAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.NamespaceTopicCollection GetNamespaceTopics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicSpaceResource> GetTopicSpace(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicSpaceResource>> GetTopicSpaceAsync(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicSpaceCollection GetTopicSpaces() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult> ValidateCustomDomainOwnership(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>> ValidateCustomDomainOwnershipAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventGridPartnerNamespacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridPartnerNamespacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridPartnerNamespacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>
    {
        public EventGridPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>
    {
        internal EventGridPrivateLinkResourceData() { }
        public string DisplayName { get { throw null; } }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public EventGridSubscriptionData() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        public string Topic { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>, System.Collections.IEnumerable
    {
        protected EventGridTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.EventGridTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.EventGridTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> Get(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetIfExists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetIfExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridTopicData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>
    {
        public EventGridTopicData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping InputSchemaMapping { get { throw null; } set { } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ResourceKind? Kind { get { throw null; } set { } }
        public string MetricResourceId { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridSku? SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridTopicPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected EventGridTopicPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridTopicPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridTopicPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicPrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridTopicPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected EventGridTopicPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventGridTopicResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventGridTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource> GetEventGridTopicPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource>> GetEventGridTopicPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionCollection GetEventGridTopicPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource> GetEventGridTopicPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource>> GetEventGridTopicPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResourceCollection GetEventGridTopicPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicEventSubscriptionCollection GetTopicEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource> GetTopicNetworkSecurityPerimeterConfiguration(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource>> GetTopicNetworkSecurityPerimeterConfigurationAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationCollection GetTopicNetworkSecurityPerimeterConfigurations() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected EventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.EventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.EventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExtensionTopicData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>
    {
        public ExtensionTopicData() { }
        public string Description { get { throw null; } set { } }
        public string SystemTopic { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.ExtensionTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.ExtensionTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTopicResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.ExtensionTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.ExtensionTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.ExtensionTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.ExtensionTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.ExtensionTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.ExtensionTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicResource>, System.Collections.IEnumerable
    {
        protected NamespaceTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.NamespaceTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topicName, Azure.ResourceManager.EventGrid.NamespaceTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicResource> Get(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.NamespaceTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.NamespaceTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicResource>> GetAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.NamespaceTopicResource> GetIfExists(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.NamespaceTopicResource>> GetIfExistsAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.NamespaceTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.NamespaceTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceTopicData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>
    {
        public NamespaceTopicData() { }
        public int? EventRetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventInputSchema? InputSchema { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PublisherType? PublisherType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NamespaceTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NamespaceTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected NamespaceTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NamespaceTopicEventSubscriptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>
    {
        public NamespaceTopicEventSubscriptionData() { }
        public Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration DeliveryConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.FiltersConfiguration FiltersConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NamespaceTopicResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NamespaceTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.NamespaceTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource> GetNamespaceTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource>> GetNamespaceTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionCollection GetNamespaceTopicEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys> RegenerateKey(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>> RegenerateKeyAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.NamespaceTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NamespaceTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NamespaceTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.NamespaceTopicResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>
    {
        public NetworkSecurityPerimeterConfigurationData() { }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo NetworkSecurityPerimeter { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile Profile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues> ProvisioningIssues { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.ResourceAssociation ResourceAssociation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerConfigurationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>
    {
        public PartnerConfigurationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EventGrid.Models.PartnerAuthorization PartnerAuthorization { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerConfigurationResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> AuthorizePartner(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> AuthorizePartnerAsync(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.PartnerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.PartnerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.PartnerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> UnauthorizePartner(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> UnauthorizePartnerAsync(Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerDestinationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerDestinationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerDestinationResource>, System.Collections.IEnumerable
    {
        protected PartnerDestinationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerDestinationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerDestinationName, Azure.ResourceManager.EventGrid.PartnerDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerDestinationName, Azure.ResourceManager.EventGrid.PartnerDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> Get(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> GetAsync(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetIfExists(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> GetIfExistsAsync(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerDestinationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerDestinationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerDestinationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerDestinationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerDestinationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>
    {
        public PartnerDestinationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState? ActivationState { get { throw null; } set { } }
        public System.Uri EndpointBaseUri { get { throw null; } set { } }
        public string EndpointServiceContext { get { throw null; } set { } }
        public System.DateTimeOffset? ExpirationTimeIfNotActivatedUtc { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerDestinationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerDestinationResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerDestinationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> Activate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> ActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerDestinationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.PartnerDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerDestinationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespaceChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>, System.Collections.IEnumerable
    {
        protected PartnerNamespaceChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string channelName, Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string channelName, Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> Get(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetIfExists(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetIfExistsAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerNamespaceChannelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>
    {
        public PartnerNamespaceChannelData() { }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType? ChannelType { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOnIfNotActivated { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo PartnerDestinationInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo PartnerTopicInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState? ReadinessState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerNamespaceChannelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespaceChannelResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerNamespaceName, string channelName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response Update(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>, System.Collections.IEnumerable
    {
        protected PartnerNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerNamespaceName, Azure.ResourceManager.EventGrid.PartnerNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerNamespaceName, Azure.ResourceManager.EventGrid.PartnerNamespaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> Get(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetAsync(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetIfExists(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetIfExistsAsync(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>
    {
        public PartnerNamespaceData(Azure.Core.AzureLocation location) { }
        public System.Uri Endpoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PartnerRegistrationFullyQualifiedId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode? PartnerTopicRoutingMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerNamespacePrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parentName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerNamespacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PartnerNamespacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerNamespaceResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerNamespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource> GetEventGridPartnerNamespacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource>> GetEventGridPartnerNamespacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionCollection GetEventGridPartnerNamespacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource> GetPartnerNamespaceChannel(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource>> GetPartnerNamespaceChannelAsync(string channelName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceChannelCollection GetPartnerNamespaceChannels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource> GetPartnerNamespacePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource>> GetPartnerNamespacePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResourceCollection GetPartnerNamespacePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys> GetSharedAccessKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>> GetSharedAccessKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys> RegenerateKey(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>> RegenerateKeyAsync(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.PartnerNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>, System.Collections.IEnumerable
    {
        protected PartnerRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerRegistrationName, Azure.ResourceManager.EventGrid.PartnerRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerRegistrationName, Azure.ResourceManager.EventGrid.PartnerRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> Get(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetAsync(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetIfExists(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetIfExistsAsync(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerRegistrationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>
    {
        public PartnerRegistrationData(Azure.Core.AzureLocation location) { }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerRegistrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerRegistrationResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerRegistrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.PartnerRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>, System.Collections.IEnumerable
    {
        protected PartnerTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerTopicName, Azure.ResourceManager.EventGrid.PartnerTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerTopicName, Azure.ResourceManager.EventGrid.PartnerTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Get(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetAsync(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetIfExists(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetIfExistsAsync(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerTopicData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>
    {
        public PartnerTopicData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState? ActivationState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string MessageForActivation { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public string PartnerTopicFriendlyDescription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected PartnerTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PartnerTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerTopicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PartnerTopicResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PartnerTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Activate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> ActivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string partnerTopicName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Deactivate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> DeactivateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource> GetPartnerTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource>> GetPartnerTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionCollection GetPartnerTopicEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.PartnerTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.PartnerTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.PartnerTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> Update(Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> UpdateAsync(Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SystemTopicCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>, System.Collections.IEnumerable
    {
        protected SystemTopicCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string systemTopicName, Azure.ResourceManager.EventGrid.SystemTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string systemTopicName, Azure.ResourceManager.EventGrid.SystemTopicData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> Get(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetAsync(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.SystemTopicResource> GetIfExists(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetIfExistsAsync(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.SystemTopicResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.SystemTopicResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SystemTopicData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.SystemTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>
    {
        public SystemTopicData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Guid? MetricResourceId { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier Source { get { throw null; } set { } }
        public string TopicType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.SystemTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.SystemTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemTopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected SystemTopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SystemTopicEventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemTopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string systemTopicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SystemTopicResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.SystemTopicData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemTopicResource() { }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string systemTopicName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource> GetSystemTopicEventSubscription(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource>> GetSystemTopicEventSubscriptionAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionCollection GetSystemTopicEventSubscriptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.SystemTopicData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.SystemTopicData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.SystemTopicData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.SystemTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.SystemTopicResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.SystemTopicPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicEventSubscriptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>, System.Collections.IEnumerable
    {
        protected TopicEventSubscriptionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string eventSubscriptionName, Azure.ResourceManager.EventGrid.EventGridSubscriptionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Get(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> GetIfExists(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetIfExistsAsync(string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicEventSubscriptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicEventSubscriptionResource() { }
        public virtual Azure.ResourceManager.EventGrid.EventGridSubscriptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topicName, string eventSubscriptionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> GetDeliveryAttributesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri> GetFullUri(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>> GetFullUriAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.EventGridSubscriptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.EventGridSubscriptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicNetworkSecurityPerimeterConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.Collections.IEnumerable
    {
        protected TopicNetworkSecurityPerimeterConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource> Get(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource> GetIfExists(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource>> GetIfExistsAsync(string perimeterGuid, string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicNetworkSecurityPerimeterConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicNetworkSecurityPerimeterConfigurationResource() { }
        public virtual Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string perimeterGuid, string associationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource> Reconcile(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource>> ReconcileAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicSpaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicSpaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicSpaceResource>, System.Collections.IEnumerable
    {
        protected TopicSpaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicSpaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topicSpaceName, Azure.ResourceManager.EventGrid.TopicSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicSpaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topicSpaceName, Azure.ResourceManager.EventGrid.TopicSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicSpaceResource> Get(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicSpaceResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicSpaceResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicSpaceResource>> GetAsync(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicSpaceResource> GetIfExists(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicSpaceResource>> GetIfExistsAsync(string topicSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicSpaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicSpaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicSpaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicSpaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicSpaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>
    {
        public TopicSpaceData() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> TopicTemplates { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.TopicSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.TopicSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicSpaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicSpaceResource() { }
        public virtual Azure.ResourceManager.EventGrid.TopicSpaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string namespaceName, string topicSpaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicSpaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicSpaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.TopicSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.TopicSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicSpaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicSpaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.TopicSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EventGrid.TopicSpaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EventGrid.TopicSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopicTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>, System.Collections.IEnumerable
    {
        protected TopicTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> Get(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.TopicTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.TopicTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicTypeResource> GetIfExists(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetIfExistsAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.TopicTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.TopicTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.TopicTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopicTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>
    {
        public TopicTypeData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission> AdditionalEnforcedPermissions { get { throw null; } }
        public bool? AreRegionalAndGlobalSourcesSupported { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType? ResourceRegionType { get { throw null; } set { } }
        public string SourceResourceFormat { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope> SupportedScopesForSource { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.TopicTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.TopicTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopicTypeResource() { }
        public virtual Azure.ResourceManager.EventGrid.TopicTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string topicTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.TopicTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.TopicTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.TopicTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VerifiedPartnerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>, System.Collections.IEnumerable
    {
        protected VerifiedPartnerCollection() { }
        public virtual Azure.Response<bool> Exists(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> Get(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetAll(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetAllAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetAsync(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetIfExists(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetIfExistsAsync(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VerifiedPartnerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>
    {
        public VerifiedPartnerData() { }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerDetails PartnerDestinationDetails { get { throw null; } set { } }
        public string PartnerDisplayName { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerDetails PartnerTopicDetails { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.VerifiedPartnerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.VerifiedPartnerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VerifiedPartnerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VerifiedPartnerResource() { }
        public virtual Azure.ResourceManager.EventGrid.VerifiedPartnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string verifiedPartnerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EventGrid.VerifiedPartnerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.VerifiedPartnerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.VerifiedPartnerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.EventGrid.Mocking
{
    public partial class MockableEventGridArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEventGridArmClient() { }
        public virtual Azure.ResourceManager.EventGrid.CaCertificateResource GetCaCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainEventSubscriptionResource GetDomainEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainNetworkSecurityPerimeterConfigurationResource GetDomainNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicEventSubscriptionResource GetDomainTopicEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.DomainTopicResource GetDomainTopicResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainPrivateEndpointConnectionResource GetEventGridDomainPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainPrivateLinkResource GetEventGridDomainPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainResource GetEventGridDomainResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupResource GetEventGridNamespaceClientGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceClientResource GetEventGridNamespaceClientResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingResource GetEventGridNamespacePermissionBindingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceResource GetEventGridNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridPartnerNamespacePrivateEndpointConnectionResource GetEventGridPartnerNamespacePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicPrivateEndpointConnectionResource GetEventGridTopicPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicPrivateLinkResource GetEventGridTopicPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicResource GetEventGridTopicResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource> GetEventSubscription(Azure.Core.ResourceIdentifier scope, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventSubscriptionResource>> GetEventSubscriptionAsync(Azure.Core.ResourceIdentifier scope, string eventSubscriptionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionResource GetEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventSubscriptionCollection GetEventSubscriptions(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypes(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic> GetEventTypesAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopic(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.ExtensionTopicResource GetExtensionTopicResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionResource GetNamespaceTopicEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.NamespaceTopicResource GetNamespaceTopicResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerDestinationResource GetPartnerDestinationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceChannelResource GetPartnerNamespaceChannelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespacePrivateLinkResource GetPartnerNamespacePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceResource GetPartnerNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerRegistrationResource GetPartnerRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicEventSubscriptionResource GetPartnerTopicEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicResource GetPartnerTopicResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicEventSubscriptionResource GetSystemTopicEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicResource GetSystemTopicResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicEventSubscriptionResource GetTopicEventSubscriptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicNetworkSecurityPerimeterConfigurationResource GetTopicNetworkSecurityPerimeterConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicSpaceResource GetTopicSpaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicTypeResource GetTopicTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.VerifiedPartnerResource GetVerifiedPartnerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEventGridResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEventGridResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomain(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridDomainResource>> GetEventGridDomainAsync(string domainName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridDomainCollection GetEventGridDomains() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetEventGridNamespace(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridNamespaceResource>> GetEventGridNamespaceAsync(string namespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridNamespaceCollection GetEventGridNamespaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopic(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.EventGridTopicResource>> GetEventGridTopicAsync(string topicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.EventGridTopicCollection GetEventGridTopics() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerConfigurationResource GetPartnerConfiguration() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetPartnerDestination(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerDestinationResource>> GetPartnerDestinationAsync(string partnerDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerDestinationCollection GetPartnerDestinations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespace(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerNamespaceResource>> GetPartnerNamespaceAsync(string partnerNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerNamespaceCollection GetPartnerNamespaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistration(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerRegistrationResource>> GetPartnerRegistrationAsync(string partnerRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerRegistrationCollection GetPartnerRegistrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopic(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.PartnerTopicResource>> GetPartnerTopicAsync(string partnerTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.PartnerTopicCollection GetPartnerTopics() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsData(Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopic(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.SystemTopicResource>> GetSystemTopicAsync(string systemTopicName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.SystemTopicCollection GetSystemTopics() { throw null; }
    }
    public partial class MockableEventGridSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEventGridSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomains(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridDomainResource> GetEventGridDomainsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetEventGridNamespaces(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridNamespaceResource> GetEventGridNamespacesAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopics(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridTopicResource> GetEventGridTopicsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicType(string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetGlobalEventSubscriptionsDataForTopicTypeAsync(string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurations(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerConfigurationResource> GetPartnerConfigurationsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetPartnerDestinations(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerDestinationResource> GetPartnerDestinationsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespaces(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerNamespaceResource> GetPartnerNamespacesAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistrations(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerRegistrationResource> GetPartnerRegistrationsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopics(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.PartnerTopicResource> GetPartnerTopicsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsData(Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataAsync(Azure.Core.AzureLocation location, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicType(Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.EventGridSubscriptionData> GetRegionalEventSubscriptionsDataForTopicTypeAsync(Azure.Core.AzureLocation location, string topicTypeName, string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopics(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EventGrid.SystemTopicResource> GetSystemTopicsAsync(string filter = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableEventGridTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEventGridTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource> GetTopicType(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.TopicTypeResource>> GetTopicTypeAsync(string topicTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.TopicTypeCollection GetTopicTypes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource> GetVerifiedPartner(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EventGrid.VerifiedPartnerResource>> GetVerifiedPartnerAsync(string verifiedPartnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EventGrid.VerifiedPartnerCollection GetVerifiedPartners() { throw null; }
    }
}
namespace Azure.ResourceManager.EventGrid.Models
{
    public abstract partial class AdvancedFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>
    {
        protected AdvancedFilter() { }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.AdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.AdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlternativeAuthenticationNameSource : System.IEquatable<Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlternativeAuthenticationNameSource(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource ClientCertificateDns { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource ClientCertificateEmail { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource ClientCertificateIP { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource ClientCertificateSubject { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource ClientCertificateUri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource left, Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource left, Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmEventGridModelFactory
    {
        public static Azure.ResourceManager.EventGrid.CaCertificateData CaCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string encodedCertificate = null, System.DateTimeOffset? issueTimeInUtc = default(System.DateTimeOffset?), System.DateTimeOffset? expiryTimeInUtc = default(System.DateTimeOffset?), Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult CustomDomainOwnershipValidationResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> customDomainsForTopicsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> customDomainsForTopicSpacesConfiguration = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.DomainTopicData DomainTopicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.EventGrid.EventGridDomainData EventGridDomainData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState? provisioningState, Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed, System.Uri endpoint, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? inputSchema, Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo eventTypeInfo, Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping inputSchemaMapping, string metricResourceId, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? publicNetworkAccess, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> inboundIPRules, bool? isLocalAuthDisabled, bool? autoCreateTopicWithFirstSubscription, bool? autoDeleteTopicWithLastSubscription, Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? dataResidencyBoundary) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridDomainData EventGridDomainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EventGrid.Models.EventGridSku? skuName = default(Azure.ResourceManager.EventGrid.Models.EventGridSku?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState?), Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed = default(Azure.ResourceManager.EventGrid.Models.TlsVersion?), System.Uri endpoint = null, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? inputSchema = default(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema?), Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo eventTypeInfo = null, Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping inputSchemaMapping = null, string metricResourceId = null, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> inboundIPRules = null, bool? isLocalAuthDisabled = default(bool?), bool? autoCreateTopicWithFirstSubscription = default(bool?), bool? autoDeleteTopicWithLastSubscription = default(bool?), Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? dataResidencyBoundary = default(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys EventGridDomainSharedAccessKeys(string key1 = null, string key2 = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceClientData EventGridNamespaceClientData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string authenticationName = null, Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication clientCertificateAuthentication = null, Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState? state = default(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState?), System.Collections.Generic.IDictionary<string, System.BinaryData> attributes = null, Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceClientGroupData EventGridNamespaceClientGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string query = null, Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespaceData EventGridNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EventGrid.Models.NamespaceSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState?), Azure.ResourceManager.EventGrid.Models.TopicsConfiguration topicsConfiguration = null, Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration topicSpacesConfiguration = null, bool? isZoneRedundant = default(bool?), Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> inboundIPRules = null, Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed = default(Azure.ResourceManager.EventGrid.Models.TlsVersion?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridNamespacePermissionBindingData EventGridNamespacePermissionBindingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string topicSpaceName = null, Azure.ResourceManager.EventGrid.Models.PermissionType? permission = default(Azure.ResourceManager.EventGrid.Models.PermissionType?), string clientGroupName = null, Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData EventGridPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState connectionState = null, Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridPrivateLinkResourceData EventGridPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, string displayName = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridSubscriptionData EventGridSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string topic = null, Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState?), Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination destination = null, Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity deliveryWithResourceIdentity = null, Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter filter = null, System.Collections.Generic.IEnumerable<string> labels = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? eventDeliverySchema = default(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema?), Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy retryPolicy = null, Azure.ResourceManager.EventGrid.Models.DeadLetterDestination deadLetterDestination = null, Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity deadLetterWithResourceIdentity = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.EventGrid.EventGridTopicData EventGridTopicData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState? provisioningState, System.Uri endpoint, Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo eventTypeInfo, Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? inputSchema, Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping inputSchemaMapping, string metricResourceId, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? publicNetworkAccess, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> inboundIPRules, bool? isLocalAuthDisabled, Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? dataResidencyBoundary) { throw null; }
        public static Azure.ResourceManager.EventGrid.EventGridTopicData EventGridTopicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EventGrid.Models.EventGridSku? skuName = default(Azure.ResourceManager.EventGrid.Models.EventGridSku?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.EventGrid.Models.ResourceKind? kind = default(Azure.ResourceManager.EventGrid.Models.ResourceKind?), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState?), System.Uri endpoint = null, Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo eventTypeInfo = null, Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed = default(Azure.ResourceManager.EventGrid.Models.TlsVersion?), Azure.ResourceManager.EventGrid.Models.EventGridInputSchema? inputSchema = default(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema?), Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping inputSchemaMapping = null, string metricResourceId = null, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> inboundIPRules = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? dataResidencyBoundary = default(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri EventSubscriptionFullUri(System.Uri endpoint = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic EventTypeUnderTopic(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string displayName = null, string description = null, System.Uri schemaUri = null, bool? isInDefaultSet = default(bool?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.ExtensionTopicData ExtensionTopicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, string systemTopic = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys NamespaceSharedAccessKeys(string key1 = null, string key2 = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.NamespaceTopicData NamespaceTopicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState?), Azure.ResourceManager.EventGrid.Models.PublisherType? publisherType = default(Azure.ResourceManager.EventGrid.Models.PublisherType?), Azure.ResourceManager.EventGrid.Models.EventInputSchema? inputSchema = default(Azure.ResourceManager.EventGrid.Models.EventInputSchema?), int? eventRetentionInDays = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData NamespaceTopicEventSubscriptionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState? provisioningState, Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration deliveryConfiguration, Azure.ResourceManager.EventGrid.Models.DeliverySchema? eventDeliverySchema, Azure.ResourceManager.EventGrid.Models.FiltersConfiguration filtersConfiguration, System.DateTimeOffset? expireOn) { throw null; }
        public static Azure.ResourceManager.EventGrid.NamespaceTopicEventSubscriptionData NamespaceTopicEventSubscriptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState?), Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration deliveryConfiguration = null, Azure.ResourceManager.EventGrid.Models.DeliverySchema? eventDeliverySchema = default(Azure.ResourceManager.EventGrid.Models.DeliverySchema?), Azure.ResourceManager.EventGrid.Models.FiltersConfiguration filtersConfiguration = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.NetworkSecurityPerimeterConfigurationData NetworkSecurityPerimeterConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues> provisioningIssues = null, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo networkSecurityPerimeter = null, Azure.ResourceManager.EventGrid.Models.ResourceAssociation resourceAssociation = null, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile profile = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerConfigurationData PartnerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EventGrid.Models.PartnerAuthorization partnerAuthorization = null, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerDestinationData PartnerDestinationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Guid? partnerRegistrationImmutableId = default(System.Guid?), string endpointServiceContext = null, System.DateTimeOffset? expirationTimeIfNotActivatedUtc = default(System.DateTimeOffset?), Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState?), Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState? activationState = default(Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState?), System.Uri endpointBaseUri = null, string messageForActivation = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData PartnerNamespaceChannelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType? channelType = default(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType?), Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo partnerTopicInfo = null, Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo partnerDestinationInfo = null, string messageForActivation = null, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState?), Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState? readinessState = default(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState?), System.DateTimeOffset? expireOnIfNotActivated = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceChannelData PartnerNamespaceChannelData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType? channelType, Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo partnerTopicInfo, string messageForActivation, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState? provisioningState, Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState? readinessState, System.DateTimeOffset? expireOnIfNotActivated) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerNamespaceData PartnerNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.EventGridPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState?), Azure.Core.ResourceIdentifier partnerRegistrationFullyQualifiedId = null, Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed = default(Azure.ResourceManager.EventGrid.Models.TlsVersion?), System.Uri endpoint = null, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> inboundIPRules = null, bool? isLocalAuthDisabled = default(bool?), Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode? partnerTopicRoutingMode = default(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys PartnerNamespaceSharedAccessKeys(string key1 = null, string key2 = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerRegistrationData PartnerRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState?), System.Guid? partnerRegistrationImmutableId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.PartnerTopicData PartnerTopicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Guid? partnerRegistrationImmutableId = default(System.Guid?), string source = null, Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo eventTypeInfo = null, System.DateTimeOffset? expireOnIfNotActivated = default(System.DateTimeOffset?), Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState?), Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState? activationState = default(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState?), string partnerTopicFriendlyDescription = null, string messageForActivation = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri SubscriptionFullUri(System.Uri endpointUri = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.SystemTopicData SystemTopicData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState?), Azure.Core.ResourceIdentifier source = null, string topicType = null, System.Guid? metricResourceId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicsConfiguration TopicsConfiguration(string hostname = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> customDomains = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys TopicSharedAccessKeys(string key1 = null, string key2 = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicSpaceData TopicSpaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string description = null, System.Collections.Generic.IEnumerable<string> topicTemplates = null, Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration TopicSpacesConfiguration(Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState? state = default(Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState?), string routeTopicResourceId = null, string hostname = null, Azure.ResourceManager.EventGrid.Models.RoutingEnrichments routingEnrichments = null, Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings clientAuthentication = null, int? maximumSessionExpiryInHours = default(int?), int? maximumClientSessionsPerAuthenticationName = default(int?), Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo routingIdentityInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> customDomains = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration TopicSpacesConfiguration(Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState? state, string routeTopicResourceId, string hostname, Azure.ResourceManager.EventGrid.Models.RoutingEnrichments routingEnrichments, int? maximumSessionExpiryInHours, int? maximumClientSessionsPerAuthenticationName, Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo routingIdentityInfo, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> customDomains) { throw null; }
        public static Azure.ResourceManager.EventGrid.TopicTypeData TopicTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provider = null, string displayName = null, string description = null, Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType? resourceRegionType = default(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType?), Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState?), System.Collections.Generic.IEnumerable<string> supportedLocations = null, string sourceResourceFormat = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope> supportedScopesForSource = null, bool? areRegionalAndGlobalSourcesSupported = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission> additionalEnforcedPermissions = null) { throw null; }
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerData VerifiedPartnerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? partnerRegistrationImmutableId = default(System.Guid?), string organizationName = null, string partnerDisplayName = null, Azure.ResourceManager.EventGrid.Models.PartnerDetails partnerTopicDetails = null, Azure.ResourceManager.EventGrid.Models.PartnerDetails partnerDestinationDetails = null, Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState? provisioningState = default(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.EventGrid.VerifiedPartnerData VerifiedPartnerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Guid? partnerRegistrationImmutableId, string organizationName, string partnerDisplayName, Azure.ResourceManager.EventGrid.Models.PartnerDetails partnerTopicDetails, Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination WebHookEventSubscriptionDestination(System.Uri endpoint = null, System.Uri baseEndpoint = null, int? maxEventsPerBatch = default(int?), int? preferredBatchSizeInKilobytes = default(int?), System.Guid? azureActiveDirectoryTenantId = default(System.Guid?), string uriOrAzureActiveDirectoryApplicationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> deliveryAttributeMappings = null, Azure.ResourceManager.EventGrid.Models.TlsVersion? minimumTlsVersionAllowed = default(Azure.ResourceManager.EventGrid.Models.TlsVersion?)) { throw null; }
    }
    public partial class AzureADPartnerClientAuthentication : Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>
    {
        public AzureADPartnerClientAuthentication() { }
        public System.Uri AzureActiveDirectoryApplicationIdOrUri { get { throw null; } set { } }
        public string AzureActiveDirectoryTenantId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>
    {
        public AzureFunctionEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public int? MaxEventsPerBatch { get { throw null; } set { } }
        public int? PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.AzureFunctionEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BoolEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>
    {
        public BoolEqualsAdvancedFilter() { }
        public bool? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BoolEqualsFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>
    {
        public BoolEqualsFilter() { }
        public bool? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.BoolEqualsFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CaCertificateProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CaCertificateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState left, Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState left, Azure.ResourceManager.EventGrid.Models.CaCertificateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClientAuthenticationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>
    {
        public ClientAuthenticationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.AlternativeAuthenticationNameSource> AlternativeAuthenticationNameSources { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings CustomJwtAuthentication { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings WebhookAuthentication { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClientCertificateAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>
    {
        public ClientCertificateAuthentication() { }
        public System.Collections.Generic.IList<string> AllowedThumbprints { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme? ValidationScheme { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ClientCertificateAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientCertificateValidationScheme : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientCertificateValidationScheme(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme DnsMatchesAuthenticationName { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme EmailMatchesAuthenticationName { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme IPMatchesAuthenticationName { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme SubjectMatchesAuthenticationName { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme ThumbprintMatch { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme UriMatchesAuthenticationName { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme left, Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme left, Azure.ResourceManager.EventGrid.Models.ClientCertificateValidationScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClientGroupProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClientGroupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState left, Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState left, Azure.ResourceManager.EventGrid.Models.ClientGroupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomDomainConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>
    {
        public CustomDomainConfiguration(string fullyQualifiedDomainName) { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public string ExpectedTxtRecordName { get { throw null; } set { } }
        public string ExpectedTxtRecordValue { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState? ValidationState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomDomainIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>
    {
        public CustomDomainIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType? IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomDomainIdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomDomainIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType left, Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType left, Azure.ResourceManager.EventGrid.Models.CustomDomainIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomDomainOwnershipValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>
    {
        internal CustomDomainOwnershipValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> CustomDomainsForTopicsConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> CustomDomainsForTopicSpacesConfiguration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomDomainOwnershipValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomDomainValidationState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomDomainValidationState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState Approved { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState ErrorRetrievingDnsRecord { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState left, Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState left, Azure.ResourceManager.EventGrid.Models.CustomDomainValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomJwtAuthenticationManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>
    {
        public CustomJwtAuthenticationManagedIdentity(Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType identityType) { }
        public Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomJwtAuthenticationManagedIdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomJwtAuthenticationManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType left, Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType left, Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomJwtAuthenticationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>
    {
        public CustomJwtAuthenticationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo> EncodedIssuerCertificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo> IssuerCertificates { get { throw null; } }
        public string TokenIssuer { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomWebhookAuthenticationManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>
    {
        public CustomWebhookAuthenticationManagedIdentity(Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType identityType) { }
        public Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomWebhookAuthenticationManagedIdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomWebhookAuthenticationManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType left, Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType left, Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataResidencyBoundary : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataResidencyBoundary(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary WithinGeopair { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary WithinRegion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary left, Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary left, Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DeadLetterDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>
    {
        protected DeadLetterDestination() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeadLetterDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeadLetterDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeadLetterWithResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>
    {
        public DeadLetterWithResourceIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DeliveryAttributeMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>
    {
        protected DeliveryAttributeMapping() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeliveryConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>
    {
        public DeliveryConfiguration() { }
        public Azure.ResourceManager.EventGrid.Models.DeliveryMode? DeliveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PushInfo Push { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.QueueInfo Queue { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeliveryMode : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DeliveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeliveryMode(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DeliveryMode Push { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DeliveryMode Queue { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DeliveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DeliveryMode left, Azure.ResourceManager.EventGrid.Models.DeliveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DeliveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DeliveryMode left, Azure.ResourceManager.EventGrid.Models.DeliveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeliverySchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DeliverySchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeliverySchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DeliverySchema CloudEventSchemaV10 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DeliverySchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DeliverySchema left, Azure.ResourceManager.EventGrid.Models.DeliverySchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DeliverySchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DeliverySchema left, Azure.ResourceManager.EventGrid.Models.DeliverySchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeliveryWithResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>
    {
        public DeliveryWithResourceIdentity() { }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DomainTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DomainTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.DomainTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DynamicDeliveryAttributeMapping : Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>
    {
        public DynamicDeliveryAttributeMapping() { }
        public string SourceField { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicDeliveryAttributeMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicRoutingEnrichment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>
    {
        public DynamicRoutingEnrichment() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncodedIssuerCertificateInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>
    {
        public EncodedIssuerCertificateInfo(string kid, string encodedCertificate) { }
        public string EncodedCertificate { get { throw null; } set { } }
        public string Kid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EncodedIssuerCertificateInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventDefinitionKind : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventDefinitionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventDefinitionKind(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventDefinitionKind Inline { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventDefinitionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventDefinitionKind left, Azure.ResourceManager.EventGrid.Models.EventDefinitionKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventDefinitionKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventDefinitionKind left, Azure.ResourceManager.EventGrid.Models.EventDefinitionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventDeliverySchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventDeliverySchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventDeliverySchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema CloudEventSchemaV1_0 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema CustomInputSchema { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventDeliverySchema EventGridSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema left, Azure.ResourceManager.EventGrid.Models.EventDeliverySchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventDeliverySchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventDeliverySchema left, Azure.ResourceManager.EventGrid.Models.EventDeliverySchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridDomainPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>
    {
        public EventGridDomainPatch() { }
        public bool? AutoCreateTopicWithFirstSubscription { get { throw null; } set { } }
        public bool? AutoDeleteTopicWithLastSubscription { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridSku? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridDomainProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridDomainProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridDomainProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridDomainRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>
    {
        public EventGridDomainRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridDomainSharedAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>
    {
        internal EventGridDomainSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridDomainSharedAccessKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventGridFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>
    {
        protected EventGridFilter() { }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridInboundIPRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>
    {
        public EventGridInboundIPRule() { }
        public Azure.ResourceManager.EventGrid.Models.EventGridIPActionType? Action { get { throw null; } set { } }
        public string IPMask { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridInputSchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridInputSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridInputSchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridInputSchema CloudEventSchemaV1_0 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridInputSchema CustomEventSchema { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridInputSchema EventGridSchema { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema left, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridInputSchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridInputSchema left, Azure.ResourceManager.EventGrid.Models.EventGridInputSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EventGridInputSchemaMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>
    {
        protected EventGridInputSchemaMapping() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridIPActionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridIPActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridIPActionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridIPActionType Allow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridIPActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridIPActionType left, Azure.ResourceManager.EventGrid.Models.EventGridIPActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridIPActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridIPActionType left, Azure.ResourceManager.EventGrid.Models.EventGridIPActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridJsonInputSchemaMapping : Azure.ResourceManager.EventGrid.Models.EventGridInputSchemaMapping, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>
    {
        public EventGridJsonInputSchemaMapping() { }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault DataVersion { get { throw null; } set { } }
        public string EventTimeSourceField { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault EventType { get { throw null; } set { } }
        public string IdSourceField { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault Subject { get { throw null; } set { } }
        public string TopicSourceField { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridJsonInputSchemaMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridNamespaceClientProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridNamespaceClientProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridNamespaceClientState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridNamespaceClientState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState left, Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState left, Azure.ResourceManager.EventGrid.Models.EventGridNamespaceClientState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridNamespacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>
    {
        public EventGridNamespacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.NamespaceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> TopicsCustomDomains { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo TopicSpacesConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridPartnerContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>
    {
        public EventGridPartnerContent() { }
        public System.DateTimeOffset? AuthorizationExpireOn { get { throw null; } set { } }
        public string PartnerName { get { throw null; } set { } }
        public System.Guid? PartnerRegistrationImmutableId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridPrivateEndpointConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>
    {
        public EventGridPrivateEndpointConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridPrivateEndpointPersistedConnectionStatus : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridPrivateEndpointPersistedConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus left, Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus left, Azure.ResourceManager.EventGrid.Models.EventGridPrivateEndpointPersistedConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess SecuredByPerimeter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess left, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess left, Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridResourceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridResourceRegionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridResourceRegionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType GlobalResource { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType RegionalResource { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType left, Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType left, Azure.ResourceManager.EventGrid.Models.EventGridResourceRegionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridSku : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridSku(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridSku Basic { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridSku Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridSku left, Azure.ResourceManager.EventGrid.Models.EventGridSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridSku left, Azure.ResourceManager.EventGrid.Models.EventGridSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridSkuName : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridSkuName(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridSkuName left, Azure.ResourceManager.EventGrid.Models.EventGridSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridSkuName left, Azure.ResourceManager.EventGrid.Models.EventGridSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventGridSubscriptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>
    {
        public EventGridSubscriptionPatch() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterDestination DeadLetterDestination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventDeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter Filter { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy RetryPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridSubscriptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventGridTopicPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>
    {
        public EventGridTopicPatch() { }
        public Azure.ResourceManager.EventGrid.Models.DataResidencyBoundary? DataResidencyBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridSku? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventGridTopicPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventGridTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventGridTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventGridTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventHubEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>
    {
        public EventHubEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventHubEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventInputSchema : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventInputSchema>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventInputSchema(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventInputSchema CloudEventSchemaV10 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventInputSchema other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventInputSchema left, Azure.ResourceManager.EventGrid.Models.EventInputSchema right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventInputSchema (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventInputSchema left, Azure.ResourceManager.EventGrid.Models.EventInputSchema right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EventSubscriptionDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>
    {
        protected EventSubscriptionDestination() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventSubscriptionFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>
    {
        public EventSubscriptionFilter() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.AdvancedFilter> AdvancedFilters { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedEventTypes { get { throw null; } }
        public bool? IsAdvancedFilteringOnArraysEnabled { get { throw null; } set { } }
        public bool? IsSubjectCaseSensitive { get { throw null; } set { } }
        public string SubjectBeginsWith { get { throw null; } set { } }
        public string SubjectEndsWith { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventSubscriptionFullUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>
    {
        internal EventSubscriptionFullUri() { }
        public System.Uri Endpoint { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionFullUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventSubscriptionIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>
    {
        public EventSubscriptionIdentity() { }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType? IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionIdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EventSubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EventSubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState AwaitingManualAction { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState left, Azure.ResourceManager.EventGrid.Models.EventSubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EventSubscriptionRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>
    {
        public EventSubscriptionRetryPolicy() { }
        public int? EventTimeToLiveInMinutes { get { throw null; } set { } }
        public int? MaxDeliveryAttempts { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventSubscriptionRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventTypeUnderTopic : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>
    {
        public EventTypeUnderTopic() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsInDefaultSet { get { throw null; } set { } }
        public System.Uri SchemaUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.EventTypeUnderTopic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FiltersConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>
    {
        public FiltersConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridFilter> Filters { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludedEventTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.FiltersConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.FiltersConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.FiltersConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectionEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>
    {
        public HybridConnectionEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.HybridConnectionEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>
    {
        public InlineEventProperties() { }
        public System.Uri DataSchemaUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.InlineEventProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.InlineEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.InlineEventProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IsNotNullAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>
    {
        public IsNotNullAdvancedFilter() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IsNotNullFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>
    {
        public IsNotNullFilter() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNotNullFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNotNullFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNotNullFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IsNullOrUndefinedAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>
    {
        public IsNullOrUndefinedAdvancedFilter() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IsNullOrUndefinedFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>
    {
        public IsNullOrUndefinedFilter() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IsNullOrUndefinedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IssuerCertificateInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>
    {
        public IssuerCertificateInfo(System.Uri certificateUri) { }
        public System.Uri CertificateUri { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.CustomJwtAuthenticationManagedIdentity Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.IssuerCertificateInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JsonFieldWithDefault : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>
    {
        public JsonFieldWithDefault() { }
        public string DefaultValue { get { throw null; } set { } }
        public string SourceField { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.JsonFieldWithDefault>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorAlertEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>
    {
        public MonitorAlertEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ActionGroups { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity? Severity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.MonitorAlertEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MonitorAlertSeverity : System.IEquatable<Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MonitorAlertSeverity(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity Sev0 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity Sev1 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity Sev2 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity Sev3 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity Sev4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity left, Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity left, Azure.ResourceManager.EventGrid.Models.MonitorAlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NamespaceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NamespaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState UpdatedFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.NamespaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NamespaceRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>
    {
        public NamespaceRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceSharedAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>
    {
        internal NamespaceSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSharedAccessKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>
    {
        public NamespaceSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridSkuName? Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceTopicEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>
    {
        public NamespaceTopicEventSubscriptionDestination() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceTopicEventSubscriptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>
    {
        public NamespaceTopicEventSubscriptionPatch() { }
        public Azure.ResourceManager.EventGrid.Models.DeliveryConfiguration DeliveryConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliverySchema? EventDeliverySchema { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.FiltersConfiguration FiltersConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicEventSubscriptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamespaceTopicPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>
    {
        public NamespaceTopicPatch() { }
        public int? EventRetentionInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NamespaceTopicPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NamespaceTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NamespaceTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState UpdatedFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.NamespaceTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterAssociationAccessMode : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterAssociationAccessMode(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode Audit { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode Enforced { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode Learning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterConfigProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterConfigProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationIssues : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>
    {
        public NetworkSecurityPerimeterConfigurationIssues() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType? IssueType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity? Severity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SuggestedAccessRules { get { throw null; } }
        public System.Collections.Generic.IList<string> SuggestedResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssues>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterConfigurationIssueSeverity : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterConfigurationIssueSeverity(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity Error { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterConfigurationIssueType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterConfigurationIssueType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType ConfigurationPropagationFailure { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType MissingIdentityConfiguration { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType MissingPerimeterConfiguration { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType Other { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationIssueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkSecurityPerimeterConfigurationProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>
    {
        public NetworkSecurityPerimeterConfigurationProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule> AccessRules { get { throw null; } }
        public string AccessRulesVersion { get { throw null; } set { } }
        public string DiagnosticSettingsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EnabledLogCategories { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterConfigurationProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>
    {
        public NetworkSecurityPerimeterInfo() { }
        public string Id { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string PerimeterGuid { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPerimeterProfileAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>
    {
        public NetworkSecurityPerimeterProfileAccessRule() { }
        public System.Collections.Generic.IList<string> AddressPrefixes { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection? Direction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public string FullyQualifiedArmId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FullyQualifiedDomainNames { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string NetworkSecurityPerimeterProfileAccessRuleType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterInfo> NetworkSecurityPerimeters { get { throw null; } }
        public System.Collections.Generic.IList<string> PhoneNumbers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> Subscriptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPerimeterProfileAccessRuleDirection : System.IEquatable<Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPerimeterProfileAccessRuleDirection(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection left, Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterProfileAccessRuleDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberGreaterThanAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>
    {
        public NumberGreaterThanAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberGreaterThanFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>
    {
        public NumberGreaterThanFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberGreaterThanOrEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>
    {
        public NumberGreaterThanOrEqualsAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberGreaterThanOrEqualsFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>
    {
        public NumberGreaterThanOrEqualsFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberGreaterThanOrEqualsFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>
    {
        public NumberInAdvancedFilter() { }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberInFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>
    {
        public NumberInFilter() { }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberInRangeAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>
    {
        public NumberInRangeAdvancedFilter() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberInRangeFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>
    {
        public NumberInRangeFilter() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberInRangeFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberLessThanAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>
    {
        public NumberLessThanAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberLessThanFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>
    {
        public NumberLessThanFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberLessThanOrEqualsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>
    {
        public NumberLessThanOrEqualsAdvancedFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberLessThanOrEqualsFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>
    {
        public NumberLessThanOrEqualsFilter() { }
        public double? Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberLessThanOrEqualsFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberNotInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>
    {
        public NumberNotInAdvancedFilter() { }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberNotInFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>
    {
        public NumberNotInFilter() { }
        public System.Collections.Generic.IList<double> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberNotInRangeAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>
    {
        public NumberNotInRangeAdvancedFilter() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NumberNotInRangeFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>
    {
        public NumberNotInRangeFilter() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<double>> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.NumberNotInRangeFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>
    {
        public PartnerAuthorization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridPartnerContent> AuthorizedPartnersList { get { throw null; } }
        public int? DefaultMaximumExpirationTimeInDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PartnerClientAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>
    {
        protected PartnerClientAuthentication() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>
    {
        public PartnerConfigurationPatch() { }
        public int? DefaultMaximumExpirationTimeInDays { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerDestinationActivationState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerDestinationActivationState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState Activated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState NeverActivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState left, Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState left, Azure.ResourceManager.EventGrid.Models.PartnerDestinationActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PartnerDestinationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>
    {
        protected PartnerDestinationInfo() { }
        public string AzureSubscriptionId { get { throw null; } set { } }
        public string EndpointServiceContext { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory> ResourceMoveChangeHistory { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerDestinationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>
    {
        public PartnerDestinationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDestinationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerDestinationProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerDestinationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState IdleDueToMirroredChannelResourceDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerDestinationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>
    {
        public PartnerDetails() { }
        public string Description { get { throw null; } set { } }
        public string LongDescription { get { throw null; } set { } }
        public System.Uri SetupUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>
    {
        public PartnerEventSubscriptionDestination() { }
        public string ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerNamespaceChannelPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>
    {
        public PartnerNamespaceChannelPatch() { }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOnIfNotActivated { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo PartnerDestinationInfo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerNamespaceChannelProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerNamespaceChannelProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState IdleDueToMirroredPartnerDestinationDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState IdleDueToMirroredPartnerTopicDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerNamespaceChannelType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerNamespaceChannelType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType PartnerDestination { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType PartnerTopic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceChannelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerNamespacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>
    {
        public PartnerNamespacePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.EventGridInboundIPRule> InboundIPRules { get { throw null; } }
        public bool? IsLocalAuthDisabled { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventGridPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerNamespaceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerNamespaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerNamespaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerNamespaceRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>
    {
        public PartnerNamespaceRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerNamespaceSharedAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>
    {
        internal PartnerNamespaceSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerNamespaceSharedAccessKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerRegistrationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>
    {
        public PartnerRegistrationPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerRegistrationProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerRegistrationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerRegistrationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicActivationState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicActivationState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState Activated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState Deactivated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState NeverActivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerTopicEventTypeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>
    {
        public PartnerTopicEventTypeInfo() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.EventGrid.Models.InlineEventProperties> InlineEventTypes { get { throw null; } }
        public Azure.ResourceManager.EventGrid.Models.EventDefinitionKind? Kind { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerTopicInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>
    {
        public PartnerTopicInfo() { }
        public System.Guid? AzureSubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.PartnerTopicEventTypeInfo EventTypeInfo { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerTopicPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>
    {
        public PartnerTopicPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerTopicPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState IdleDueToMirroredChannelResourceDeletion { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicReadinessState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicReadinessState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState Activated { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState NeverActivated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState left, Azure.ResourceManager.EventGrid.Models.PartnerTopicReadinessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerTopicRoutingMode : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerTopicRoutingMode(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode ChannelNameHeader { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode SourceEventAttribute { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode left, Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode left, Azure.ResourceManager.EventGrid.Models.PartnerTopicRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class PartnerUpdateDestinationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>
    {
        protected PartnerUpdateDestinationInfo() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionBindingProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionBindingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState left, Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState left, Azure.ResourceManager.EventGrid.Models.PermissionBindingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PermissionType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PermissionType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PermissionType Publisher { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.PermissionType Subscriber { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PermissionType left, Azure.ResourceManager.EventGrid.Models.PermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PermissionType left, Azure.ResourceManager.EventGrid.Models.PermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublisherType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.PublisherType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublisherType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.PublisherType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.PublisherType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.PublisherType left, Azure.ResourceManager.EventGrid.Models.PublisherType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.PublisherType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.PublisherType left, Azure.ResourceManager.EventGrid.Models.PublisherType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PushInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PushInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PushInfo>
    {
        public PushInfo() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterDestinationWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.DeliveryWithResourceIdentity DeliveryWithResourceIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination Destination { get { throw null; } set { } }
        public string EventTimeToLive { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PushInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PushInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.PushInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.PushInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PushInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PushInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.PushInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueueInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>
    {
        public QueueInfo() { }
        public Azure.ResourceManager.EventGrid.Models.DeadLetterWithResourceIdentity DeadLetterDestinationWithResourceIdentity { get { throw null; } set { } }
        public System.TimeSpan? EventTimeToLive { get { throw null; } set { } }
        public int? MaxDeliveryCount { get { throw null; } set { } }
        public int? ReceiveLockDurationInSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.QueueInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.QueueInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.QueueInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceAssociation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>
    {
        public ResourceAssociation() { }
        public Azure.ResourceManager.EventGrid.Models.NetworkSecurityPerimeterAssociationAccessMode? AccessMode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ResourceAssociation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ResourceAssociation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceAssociation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceKind : System.IEquatable<Azure.ResourceManager.EventGrid.Models.ResourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceKind(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.ResourceKind Azure { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.ResourceKind AzureArc { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.ResourceKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.ResourceKind left, Azure.ResourceManager.EventGrid.Models.ResourceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.ResourceKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.ResourceKind left, Azure.ResourceManager.EventGrid.Models.ResourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMoveChangeHistory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>
    {
        public ResourceMoveChangeHistory() { }
        public string AzureSubscriptionId { get { throw null; } set { } }
        public System.DateTimeOffset? ChangedTimeUtc { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ResourceMoveChangeHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingEnrichments : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>
    {
        public RoutingEnrichments() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DynamicRoutingEnrichment> Dynamic { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment> Static { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.RoutingEnrichments System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.RoutingEnrichments System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingEnrichments>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutingIdentityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>
    {
        public RoutingIdentityInfo() { }
        public Azure.ResourceManager.EventGrid.Models.RoutingIdentityType? IdentityType { get { throw null; } set { } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingIdentityType : System.IEquatable<Azure.ResourceManager.EventGrid.Models.RoutingIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.RoutingIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.RoutingIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.RoutingIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.RoutingIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.RoutingIdentityType left, Azure.ResourceManager.EventGrid.Models.RoutingIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.RoutingIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.RoutingIdentityType left, Azure.ResourceManager.EventGrid.Models.RoutingIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceBusQueueEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>
    {
        public ServiceBusQueueEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusQueueEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceBusTopicEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>
    {
        public ServiceBusTopicEventSubscriptionDestination() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.ServiceBusTopicEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StaticDeliveryAttributeMapping : Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>
    {
        public StaticDeliveryAttributeMapping() { }
        public bool? IsSecret { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticDeliveryAttributeMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StaticRoutingEnrichment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>
    {
        protected StaticRoutingEnrichment() { }
        public string Key { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StaticStringRoutingEnrichment : Azure.ResourceManager.EventGrid.Models.StaticRoutingEnrichment, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>
    {
        public StaticStringRoutingEnrichment() { }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StaticStringRoutingEnrichment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBlobDeadLetterDestination : Azure.ResourceManager.EventGrid.Models.DeadLetterDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>
    {
        public StorageBlobDeadLetterDestination() { }
        public string BlobContainerName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageBlobDeadLetterDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageQueueEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>
    {
        public StorageQueueEventSubscriptionDestination() { }
        public long? QueueMessageTimeToLiveInSeconds { get { throw null; } set { } }
        public string QueueName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StorageQueueEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringBeginsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>
    {
        public StringBeginsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringBeginsWithFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>
    {
        public StringBeginsWithFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringBeginsWithFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringContainsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>
    {
        public StringContainsAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringContainsFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>
    {
        public StringContainsFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringContainsFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringContainsFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringContainsFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringEndsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>
    {
        public StringEndsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringEndsWithFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>
    {
        public StringEndsWithFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringEndsWithFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>
    {
        public StringInAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringInFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>
    {
        public StringInFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringInFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringInFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringInFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotBeginsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>
    {
        public StringNotBeginsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotBeginsWithFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>
    {
        public StringNotBeginsWithFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotBeginsWithFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotContainsAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>
    {
        public StringNotContainsAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotContainsFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>
    {
        public StringNotContainsFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotContainsFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotEndsWithAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>
    {
        public StringNotEndsWithAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotEndsWithFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>
    {
        public StringNotEndsWithFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotEndsWithFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotInAdvancedFilter : Azure.ResourceManager.EventGrid.Models.AdvancedFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>
    {
        public StringNotInAdvancedFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInAdvancedFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StringNotInFilter : Azure.ResourceManager.EventGrid.Models.EventGridFilter, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>
    {
        public StringNotInFilter() { }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotInFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.StringNotInFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.StringNotInFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionFullUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>
    {
        internal SubscriptionFullUri() { }
        public System.Uri EndpointUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SubscriptionFullUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState AwaitingManualAction { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState CreateFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState UpdatedFailed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState left, Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState left, Azure.ResourceManager.EventGrid.Models.SubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SystemTopicPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>
    {
        public SystemTopicPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.SystemTopicPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.SystemTopicPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.SystemTopicPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsVersion : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TlsVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsVersion(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TlsVersion One0 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TlsVersion One1 { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TlsVersion One2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TlsVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TlsVersion left, Azure.ResourceManager.EventGrid.Models.TlsVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TlsVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TlsVersion left, Azure.ResourceManager.EventGrid.Models.TlsVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TopicRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>
    {
        public TopicRegenerateKeyContent(string keyName) { }
        public string KeyName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>
    {
        public TopicsConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> CustomDomains { get { throw null; } }
        public string Hostname { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopicSharedAccessKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>
    {
        internal TopicSharedAccessKeys() { }
        public string Key1 { get { throw null; } }
        public string Key2 { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSharedAccessKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicSpaceProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicSpaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicSpaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TopicSpacesConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>
    {
        public TopicSpacesConfiguration() { }
        public Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings ClientAuthentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> CustomDomains { get { throw null; } }
        public string Hostname { get { throw null; } }
        public int? MaximumClientSessionsPerAuthenticationName { get { throw null; } set { } }
        public int? MaximumSessionExpiryInHours { get { throw null; } set { } }
        public string RouteTopicResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.RoutingEnrichments RoutingEnrichments { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo RoutingIdentityInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicSpacesConfigurationState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicSpacesConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState left, Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState left, Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TopicTypeAdditionalEnforcedPermission : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>
    {
        public TopicTypeAdditionalEnforcedPermission() { }
        public bool? IsDataAction { get { throw null; } set { } }
        public string PermissionName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.TopicTypeAdditionalEnforcedPermission>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicTypeProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicTypeProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState left, Azure.ResourceManager.EventGrid.Models.TopicTypeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TopicTypeSourceScope : System.IEquatable<Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TopicTypeSourceScope(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope AzureSubscription { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope ManagementGroup { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope Resource { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope ResourceGroup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope left, Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope left, Azure.ResourceManager.EventGrid.Models.TopicTypeSourceScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateTopicSpacesConfigurationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>
    {
        public UpdateTopicSpacesConfigurationInfo() { }
        public Azure.ResourceManager.EventGrid.Models.ClientAuthenticationSettings ClientAuthentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.CustomDomainConfiguration> CustomDomains { get { throw null; } }
        public int? MaximumClientSessionsPerAuthenticationName { get { throw null; } set { } }
        public int? MaximumSessionExpiryInHours { get { throw null; } set { } }
        public string RouteTopicResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.RoutingEnrichments RoutingEnrichments { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.RoutingIdentityInfo RoutingIdentityInfo { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TopicSpacesConfigurationState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.UpdateTopicSpacesConfigurationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VerifiedPartnerProvisioningState : System.IEquatable<Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VerifiedPartnerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState left, Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState left, Azure.ResourceManager.EventGrid.Models.VerifiedPartnerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WebhookAuthenticationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>
    {
        public WebhookAuthenticationSettings(Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity identity, System.Uri endpointUri, System.Uri azureActiveDirectoryApplicationIdOrUri, string azureActiveDirectoryTenantId) { }
        public System.Uri AzureActiveDirectoryApplicationIdOrUri { get { throw null; } set { } }
        public string AzureActiveDirectoryTenantId { get { throw null; } set { } }
        public System.Uri EndpointBaseUri { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.CustomWebhookAuthenticationManagedIdentity Identity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookAuthenticationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebHookEventSubscriptionDestination : Azure.ResourceManager.EventGrid.Models.EventSubscriptionDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>
    {
        public WebHookEventSubscriptionDestination() { }
        public System.Guid? AzureActiveDirectoryTenantId { get { throw null; } set { } }
        public System.Uri BaseEndpoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.EventGrid.Models.DeliveryAttributeMapping> DeliveryAttributeMappings { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public int? MaxEventsPerBatch { get { throw null; } set { } }
        public Azure.ResourceManager.EventGrid.Models.TlsVersion? MinimumTlsVersionAllowed { get { throw null; } set { } }
        public int? PreferredBatchSizeInKilobytes { get { throw null; } set { } }
        public string UriOrAzureActiveDirectoryApplicationId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebHookEventSubscriptionDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookPartnerDestinationInfo : Azure.ResourceManager.EventGrid.Models.PartnerDestinationInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>
    {
        public WebhookPartnerDestinationInfo() { }
        public Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication ClientAuthentication { get { throw null; } set { } }
        public System.Uri EndpointBaseUri { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookPartnerDestinationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookUpdatePartnerDestinationInfo : Azure.ResourceManager.EventGrid.Models.PartnerUpdateDestinationInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>
    {
        public WebhookUpdatePartnerDestinationInfo() { }
        public Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication ClientAuthentication { get { throw null; } set { } }
        public System.Uri EndpointBaseUri { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EventGrid.Models.WebhookUpdatePartnerDestinationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
