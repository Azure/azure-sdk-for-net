namespace Azure.ResourceManager.HealthcareApis
{
    public partial class AzureResourceManagerHealthcareApisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHealthcareApisContext() { }
        public static Azure.ResourceManager.HealthcareApis.AzureResourceManagerHealthcareApisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DicomServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>, System.Collections.IEnumerable
    {
        protected DicomServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dicomServiceName, Azure.ResourceManager.HealthcareApis.DicomServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dicomServiceName, Azure.ResourceManager.HealthcareApis.DicomServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> Get(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetIfExists(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetIfExistsAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.DicomServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.DicomServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.DicomServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DicomServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>
    {
        public DicomServiceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? EventState { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsDataPartitionsEnabled { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Uri ServiceUri { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration StorageConfiguration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.DicomServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.DicomServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DicomServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DicomServiceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.DicomServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string dicomServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.DicomServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.DicomServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.DicomServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FhirServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>, System.Collections.IEnumerable
    {
        protected FhirServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fhirServiceName, Azure.ResourceManager.HealthcareApis.FhirServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fhirServiceName, Azure.ResourceManager.HealthcareApis.FhirServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> Get(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetIfExists(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetIfExistsAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.FhirServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.FhirServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.FhirServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FhirServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>
    {
        public FhirServiceData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration AcrConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? EventState { get { throw null; } }
        public string ExportStorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration ImportConfiguration { get { throw null; } set { } }
        public bool? IsUsCoreMissingDataEnabled { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration ResourceVersionPolicyConfiguration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.FhirServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.FhirServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FhirServiceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.FhirServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string fhirServiceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.FhirServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.FhirServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.FhirServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HealthcareApisExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult> CheckHealthcareApisNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>> CheckHealthcareApisNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthcareApis.Models.OperationDetail> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.Models.OperationDetail> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locationName, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.DicomServiceResource GetDicomServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.FhirServiceResource GetFhirServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource GetHealthcareApisIotConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource GetHealthcareApisIotFhirDestinationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetHealthcareApisService(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> GetHealthcareApisServiceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource GetHealthcareApisServicePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource GetHealthcareApisServicePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource GetHealthcareApisServiceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisServiceCollection GetHealthcareApisServices(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetHealthcareApisServices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetHealthcareApisServicesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetHealthcareApisWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> GetHealthcareApisWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource GetHealthcareApisWorkspacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource GetHealthcareApisWorkspacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource GetHealthcareApisWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceCollection GetHealthcareApisWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetHealthcareApisWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetHealthcareApisWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareApisIotConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisIotConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string iotConnectorName, Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string iotConnectorName, Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> Get(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> GetAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> GetIfExists(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> GetIfExistsAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisIotConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>
    {
        public HealthcareApisIotConnectorData(Azure.Core.AzureLocation location) { }
        public System.BinaryData DeviceMappingContent { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration IngestionEndpointConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisIotConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisIotConnectorResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string iotConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> GetHealthcareApisIotFhirDestination(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>> GetHealthcareApisIotFhirDestinationAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationCollection GetHealthcareApisIotFhirDestinations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareApisIotFhirDestinationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisIotFhirDestinationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fhirDestinationName, Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fhirDestinationName, Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> Get(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>> GetAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> GetIfExists(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>> GetIfExistsAsync(string fhirDestinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisIotFhirDestinationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>
    {
        public HealthcareApisIotFhirDestinationData(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType resourceIdentityResolutionType, Azure.Core.ResourceIdentifier fhirServiceResourceId) { }
        public HealthcareApisIotFhirDestinationData(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType resourceIdentityResolutionType, Azure.Core.ResourceIdentifier fhirServiceResourceId, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties fhirMapping) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.BinaryData FhirMappingContent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FhirServiceResourceId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType ResourceIdentityResolutionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisIotFhirDestinationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisIotFhirDestinationResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string iotConnectorName, string fhirDestinationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareApisPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>
    {
        public HealthcareApisPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>
    {
        public HealthcareApisPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisServiceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisServiceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>
    {
        public HealthcareApisServiceData(Azure.Core.AzureLocation location, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisKind kind) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisKind Kind { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServicePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisServicePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisServicePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisServicePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareApisServicePrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisServicePrivateLinkResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServicePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisServicePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisServiceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisServiceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource> GetHealthcareApisServicePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource>> GetHealthcareApisServicePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionCollection GetHealthcareApisServicePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource> GetHealthcareApisServicePrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource>> GetHealthcareApisServicePrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResourceCollection GetHealthcareApisServicePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareApisWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>
    {
        public HealthcareApisWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisWorkspacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisWorkspacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisWorkspacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisWorkspacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthcareApisWorkspacePrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisWorkspacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisWorkspacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HealthcareApisWorkspacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthcareApisWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthcareApisWorkspaceResource() { }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource> GetDicomService(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.DicomServiceResource>> GetDicomServiceAsync(string dicomServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.DicomServiceCollection GetDicomServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource> GetFhirService(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.FhirServiceResource>> GetFhirServiceAsync(string fhirServiceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.FhirServiceCollection GetFhirServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource> GetHealthcareApisIotConnector(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource>> GetHealthcareApisIotConnectorAsync(string iotConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorCollection GetHealthcareApisIotConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource> GetHealthcareApisWorkspacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource>> GetHealthcareApisWorkspacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionCollection GetHealthcareApisWorkspacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource> GetHealthcareApisWorkspacePrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource>> GetHealthcareApisWorkspacePrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResourceCollection GetHealthcareApisWorkspacePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HealthcareApis.Mocking
{
    public partial class MockableHealthcareApisArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthcareApisArmClient() { }
        public virtual Azure.ResourceManager.HealthcareApis.DicomServiceResource GetDicomServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.FhirServiceResource GetFhirServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorResource GetHealthcareApisIotConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationResource GetHealthcareApisIotFhirDestinationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateEndpointConnectionResource GetHealthcareApisServicePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServicePrivateLinkResource GetHealthcareApisServicePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource GetHealthcareApisServiceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateEndpointConnectionResource GetHealthcareApisWorkspacePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspacePrivateLinkResource GetHealthcareApisWorkspacePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource GetHealthcareApisWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHealthcareApisResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthcareApisResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetHealthcareApisService(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource>> GetHealthcareApisServiceAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisServiceCollection GetHealthcareApisServices() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetHealthcareApisWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource>> GetHealthcareApisWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceCollection GetHealthcareApisWorkspaces() { throw null; }
    }
    public partial class MockableHealthcareApisSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthcareApisSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult> CheckHealthcareApisNameAvailability(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>> CheckHealthcareApisNameAvailabilityAsync(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription> Get(string locationName, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>> GetAsync(string locationName, string operationResultId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetHealthcareApisServices(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisServiceResource> GetHealthcareApisServicesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetHealthcareApisWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceResource> GetHealthcareApisWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableHealthcareApisTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHealthcareApisTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthcareApis.Models.OperationDetail> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthcareApis.Models.OperationDetail> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HealthcareApis.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.ActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.ActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.ActionType left, Azure.ResourceManager.HealthcareApis.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.ActionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.ActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.ActionType left, Azure.ResourceManager.HealthcareApis.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHealthcareApisModelFactory
    {
        public static Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration DicomServiceAuthenticationConfiguration(string authority = null, System.Collections.Generic.IEnumerable<string> audiences = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration DicomServiceCorsConfiguration(System.Collections.Generic.IEnumerable<string> origins = null, System.Collections.Generic.IEnumerable<string> headers = null, System.Collections.Generic.IEnumerable<string> methods = null, int? maxAge = default(int?), bool? allowCredentials = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.DicomServiceData DicomServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState, Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration authenticationConfiguration, Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration corsConfiguration, System.Uri serviceUri, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.DicomServiceData DicomServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration authenticationConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration corsConfiguration = null, System.Uri serviceUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? eventState = default(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration storageConfiguration = null, bool? isDataPartitionsEnabled = default(bool?), System.Uri keyEncryptionKeyUri = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.DicomServiceData DicomServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration authenticationConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration corsConfiguration = null, System.Uri serviceUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? eventState = default(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState?), System.Uri keyEncryptionKeyUri = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration storageConfiguration = null, bool? isDataPartitionsEnabled = default(bool?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.DicomServiceData DicomServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState, Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration authenticationConfiguration, Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration corsConfiguration, System.Uri serviceUri, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? eventState, System.Uri keyEncryptionKeyUri, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch DicomServicePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration FhirServiceAcrConfiguration(System.Collections.Generic.IEnumerable<string> loginServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry> ociArtifacts = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration FhirServiceAuthenticationConfiguration(string authority = null, string audience = null, bool? isSmartProxyEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration> smartIdentityProviders = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration FhirServiceCorsConfiguration(System.Collections.Generic.IEnumerable<string> origins = null, System.Collections.Generic.IEnumerable<string> headers = null, System.Collections.Generic.IEnumerable<string> methods = null, int? maxAge = default(int?), bool? allowCredentials = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.FhirServiceData FhirServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind? kind = default(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration acrConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration authenticationConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration corsConfiguration = null, string exportStorageAccountName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? eventState = default(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration resourceVersionPolicyConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration importConfiguration = null, bool? isUsCoreMissingDataEnabled = default(bool?), System.Uri keyEncryptionKeyUri = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.FhirServiceData FhirServiceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind? kind, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry> accessPolicies, Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration acrConfiguration, Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration authenticationConfiguration, Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration corsConfiguration, string exportStorageAccountName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? eventState, Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration resourceVersionPolicyConfiguration, Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration importConfiguration, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ETag? etag) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.FhirServiceData FhirServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration acrConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration authenticationConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration corsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? eventState = default(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState?), Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration resourceVersionPolicyConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration importConfiguration = null, string exportStorageAccountName = null, bool? isUsCoreMissingDataEnabled = default(bool?), System.Uri keyEncryptionKeyUri = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind? kind = default(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration FhirServiceImportConfiguration(string integrationDataStore = null, bool? isInitialImportMode = default(bool?), bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch FhirServicePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration FhirServiceResourceVersionPolicyConfiguration(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy? @default = default(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy> resourceTypeOverrides = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData HealthcareApisIotConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration ingestionEndpointConfiguration = null, System.BinaryData deviceMappingContent = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisIotConnectorData HealthcareApisIotConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration ingestionEndpointConfiguration = null, System.BinaryData deviceMappingContent = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration HealthcareApisIotConnectorEventHubIngestionConfiguration(string eventHubName = null, string consumerGroup = null, string fullyQualifiedEventHubNamespace = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch HealthcareApisIotConnectorPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData HealthcareApisIotFhirDestinationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType resourceIdentityResolutionType = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType), Azure.Core.ResourceIdentifier fhirServiceResourceId = null, System.BinaryData fhirMappingContent = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisIotFhirDestinationData HealthcareApisIotFhirDestinationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType resourceIdentityResolutionType = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType), Azure.Core.ResourceIdentifier fhirServiceResourceId = null, System.BinaryData fhirMappingContent = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties HealthcareApisIotMappingProperties(System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent HealthcareApisNameAvailabilityContent(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult HealthcareApisNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameUnavailableReason? reason = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData HealthcareApisPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData HealthcareApisPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateLinkResourceData HealthcareApisPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState HealthcareApisPrivateLinkServiceConnectionState(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags HealthcareApisResourceTags(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry HealthcareApisServiceAccessPolicyEntry(string objectId = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration HealthcareApisServiceAcrConfiguration(System.Collections.Generic.IEnumerable<string> loginServers = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry> ociArtifacts = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration HealthcareApisServiceAuthenticationConfiguration(string authority = null, string audience = null, bool? isSmartProxyEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration HealthcareApisServiceCorsConfiguration(System.Collections.Generic.IEnumerable<string> origins = null, System.Collections.Generic.IEnumerable<string> headers = null, System.Collections.Generic.IEnumerable<string> methods = null, int? maxAge = default(int?), bool? allowCredentials = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration HealthcareApisServiceCosmosDbConfiguration(int? offerThroughput = default(int?), System.Uri keyVaultKeyUri = null, System.Guid? crossTenantCmkApplicationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisServiceData HealthcareApisServiceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties properties = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisKind kind = Azure.ResourceManager.HealthcareApis.Models.HealthcareApisKind.Fhir, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration HealthcareApisServiceImportConfiguration(string integrationDataStore = null, bool? isInitialImportMode = default(bool?), bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry HealthcareApisServiceOciArtifactEntry(string loginServer = null, string imageName = null, string digest = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch HealthcareApisServicePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties HealthcareApisServiceProperties(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry> accessPolicies = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration cosmosDbConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration authenticationConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration corsConfiguration = null, string exportStorageAccountName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration acrConfiguration = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration importConfiguration = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration HealthcareApisServiceStorageConfiguration(Azure.Core.ResourceIdentifier storageResourceId = null, string fileSystemName = null, string storageEventQueueName = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.HealthcareApisWorkspaceData HealthcareApisWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch HealthcareApisWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties HealthcareApisWorkspaceProperties(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.LogSpecification LogSpecification(string name = null, string displayName = null, string blobDuration = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.MetricDimension MetricDimension(string name = null, string displayName = null, bool? toBeExportedForShoebox = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.MetricSpecification MetricSpecification(string name = null, string displayName = null, string displayDescription = null, string unit = null, string category = null, string aggregationType = null, System.Collections.Generic.IEnumerable<string> supportedAggregationTypes = null, System.Collections.Generic.IEnumerable<string> supportedTimeGrainTypes = null, bool? fillGapWithZero = default(bool?), string metricFilterPattern = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.MetricDimension> dimensions = null, bool? isInternal = default(bool?), string sourceMdmAccount = null, string sourceMdmNamespace = null, bool? enableRegionalMdmAccount = default(bool?), string resourceIdDimensionNameOverride = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationDetail OperationDetail(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.HealthcareApis.Models.OperationDisplay display = null, string origin = null, Azure.ResourceManager.HealthcareApis.Models.ActionType? actionType = default(Azure.ResourceManager.HealthcareApis.Models.ActionType?), Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification operationServiceSpecification = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationDisplay OperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription OperationResultsDescription(string id = null, string name = null, Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus? status = default(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus?), string startTime = null, string endTime = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification ServiceSpecification(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.LogSpecification> logSpecifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification> metricSpecifications = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication SmartIdentityProviderApplication(string clientId = null, string audience = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.SmartDataAction> allowedDataActions = null) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration SmartIdentityProviderConfiguration(string authority = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication> applications = null) { throw null; }
    }
    public partial class DicomServiceAuthenticationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>
    {
        public DicomServiceAuthenticationConfiguration() { }
        public System.Collections.Generic.IReadOnlyList<string> Audiences { get { throw null; } }
        public string Authority { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceAuthenticationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DicomServiceCorsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>
    {
        public DicomServiceCorsConfiguration() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public System.Collections.Generic.IList<string> Origins { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServiceCorsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DicomServicePatch : Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>
    {
        public DicomServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.DicomServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirResourceVersionPolicy : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirResourceVersionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy NoVersion { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy Versioned { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy VersionedUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy left, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy left, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirServiceAccessPolicyEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>
    {
        public FhirServiceAccessPolicyEntry(string objectId) { }
        public FhirServiceAccessPolicyEntry(string objectId, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalBinaryDataProperties) { }
        public string ObjectId { get { throw null; } set { } }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAccessPolicyEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirServiceAcrConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>
    {
        public FhirServiceAcrConfiguration() { }
        public System.Collections.Generic.IList<string> LoginServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry> OciArtifacts { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAcrConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirServiceAuthenticationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>
    {
        public FhirServiceAuthenticationConfiguration() { }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public bool? IsSmartProxyEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration> SmartIdentityProviders { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceAuthenticationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirServiceCorsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>
    {
        public FhirServiceCorsConfiguration() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public System.Collections.Generic.IList<string> Origins { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceCorsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirServiceEventState : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirServiceEventState(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState Enabled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState left, Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState left, Azure.ResourceManager.HealthcareApis.Models.FhirServiceEventState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirServiceImportConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>
    {
        public FhirServiceImportConfiguration() { }
        public string IntegrationDataStore { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsInitialImportMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceImportConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FhirServiceKind : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FhirServiceKind(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind FhirR4 { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind FhirStu3 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind left, Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind left, Azure.ResourceManager.HealthcareApis.Models.FhirServiceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FhirServicePatch : Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>
    {
        public FhirServicePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FhirServiceResourceVersionPolicyConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>
    {
        public FhirServiceResourceVersionPolicyConfiguration() { }
        public Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy? Default { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.HealthcareApis.Models.FhirResourceVersionPolicy> ResourceTypeOverrides { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.FhirServiceResourceVersionPolicyConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisIotConnectorEventHubIngestionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>
    {
        public HealthcareApisIotConnectorEventHubIngestionConfiguration() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public string EventHubName { get { throw null; } set { } }
        public string FullyQualifiedEventHubNamespace { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorEventHubIngestionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisIotConnectorPatch : Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>
    {
        public HealthcareApisIotConnectorPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisIotIdentityResolutionType : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisIotIdentityResolutionType(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType Create { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType Lookup { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotIdentityResolutionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareApisIotMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>
    {
        public HealthcareApisIotMappingProperties() { }
        public System.BinaryData Content { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisIotMappingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum HealthcareApisKind
    {
        Fhir = 0,
        FhirStu3 = 1,
        FhirR4 = 2,
    }
    public partial class HealthcareApisNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>
    {
        public HealthcareApisNameAvailabilityContent(string name, Azure.Core.ResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>
    {
        internal HealthcareApisNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum HealthcareApisNameUnavailableReason
    {
        Invalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareApisPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>
    {
        public HealthcareApisPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisProvisioningState : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Deprovisioned { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState SystemMaintenance { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Verifying { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthcareApisPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthcareApisPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess left, Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HealthcareApisResourceTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>
    {
        public HealthcareApisResourceTags() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceAccessPolicyEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>
    {
        public HealthcareApisServiceAccessPolicyEntry(string objectId) { }
        public string ObjectId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceAcrConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>
    {
        public HealthcareApisServiceAcrConfiguration() { }
        public System.Collections.Generic.IList<string> LoginServers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry> OciArtifacts { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceAuthenticationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>
    {
        public HealthcareApisServiceAuthenticationConfiguration() { }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public bool? IsSmartProxyEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceCorsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>
    {
        public HealthcareApisServiceCorsConfiguration() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Headers { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public System.Collections.Generic.IList<string> Origins { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceCosmosDbConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>
    {
        public HealthcareApisServiceCosmosDbConfiguration() { }
        public System.Guid? CrossTenantCmkApplicationId { get { throw null; } set { } }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public int? OfferThroughput { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceImportConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>
    {
        public HealthcareApisServiceImportConfiguration() { }
        public string IntegrationDataStore { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsInitialImportMode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceOciArtifactEntry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>
    {
        public HealthcareApisServiceOciArtifactEntry() { }
        public string Digest { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public string LoginServer { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceOciArtifactEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServicePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>
    {
        public HealthcareApisServicePatch() { }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServicePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>
    {
        public HealthcareApisServiceProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAcrConfiguration AcrConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceAuthenticationConfiguration AuthenticationConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCorsConfiguration CorsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceCosmosDbConfiguration CosmosDbConfiguration { get { throw null; } set { } }
        public string ExportStorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceImportConfiguration ImportConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisServiceStorageConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>
    {
        public HealthcareApisServiceStorageConfiguration() { }
        public string FileSystemName { get { throw null; } set { } }
        public string StorageEventQueueName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisServiceStorageConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisWorkspacePatch : Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>
    {
        public HealthcareApisWorkspacePatch() { }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HealthcareApis.Models.HealthcareApisResourceTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthcareApisWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>
    {
        public HealthcareApisWorkspaceProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HealthcareApis.HealthcareApisPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.HealthcareApisWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>
    {
        internal LogSpecification() { }
        public string BlobDuration { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.LogSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.LogSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.LogSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.LogSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.LogSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>
    {
        internal MetricDimension() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public bool? ToBeExportedForShoebox { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.MetricDimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.MetricDimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.MetricDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.MetricDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MetricSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.MetricDimension> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? EnableRegionalMdmAccount { get { throw null; } }
        public bool? FillGapWithZero { get { throw null; } }
        public bool? IsInternal { get { throw null; } }
        public string MetricFilterPattern { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceIdDimensionNameOverride { get { throw null; } }
        public string SourceMdmAccount { get { throw null; } }
        public string SourceMdmNamespace { get { throw null; } }
        public System.Collections.Generic.IList<string> SupportedAggregationTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> SupportedTimeGrainTypes { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.MetricSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.MetricSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.MetricSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.MetricSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>
    {
        internal OperationDetail() { }
        public Azure.ResourceManager.HealthcareApis.Models.ActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification OperationServiceSpecification { get { throw null; } }
        public string Origin { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.OperationDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.OperationDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.OperationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.OperationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.OperationDisplay JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.OperationDisplay PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.OperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.OperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationResultsDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>
    {
        internal OperationResultsDescription() { }
        public string EndTime { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
        public string StartTime { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.OperationResultsDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationResultStatus : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationResultStatus(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Requested { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Running { get { throw null; } }
        public static Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus left, Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus left, Azure.ResourceManager.HealthcareApis.Models.OperationResultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.HealthcareApis.Models.HealthcareApisPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>
    {
        internal ServiceSpecification() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.LogSpecification> LogSpecifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.MetricSpecification> MetricSpecifications { get { throw null; } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.ServiceSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SmartDataAction : System.IEquatable<Azure.ResourceManager.HealthcareApis.Models.SmartDataAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmartDataAction(string value) { throw null; }
        public static Azure.ResourceManager.HealthcareApis.Models.SmartDataAction Read { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HealthcareApis.Models.SmartDataAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HealthcareApis.Models.SmartDataAction left, Azure.ResourceManager.HealthcareApis.Models.SmartDataAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.SmartDataAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HealthcareApis.Models.SmartDataAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HealthcareApis.Models.SmartDataAction left, Azure.ResourceManager.HealthcareApis.Models.SmartDataAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SmartIdentityProviderApplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>
    {
        public SmartIdentityProviderApplication() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.SmartDataAction> AllowedDataActions { get { throw null; } }
        public string Audience { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SmartIdentityProviderConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>
    {
        public SmartIdentityProviderConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderApplication> Applications { get { throw null; } }
        public string Authority { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HealthcareApis.Models.SmartIdentityProviderConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
