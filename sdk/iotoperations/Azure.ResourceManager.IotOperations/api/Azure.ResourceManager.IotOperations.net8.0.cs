namespace Azure.ResourceManager.IotOperations
{
    public partial class IotOperationsBrokerAuthenticationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>, System.Collections.IEnumerable
    {
        protected IotOperationsBrokerAuthenticationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authenticationName, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authenticationName, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> Get(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>> GetAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> GetIfExists(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>> GetIfExistsAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsBrokerAuthenticationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>
    {
        public IotOperationsBrokerAuthenticationData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerAuthenticationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsBrokerAuthenticationResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName, string authenticationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsBrokerAuthorizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>, System.Collections.IEnumerable
    {
        protected IotOperationsBrokerAuthorizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> Get(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>> GetAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> GetIfExists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>> GetIfExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsBrokerAuthorizationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>
    {
        public IotOperationsBrokerAuthorizationData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerAuthorizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsBrokerAuthorizationResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName, string authorizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsBrokerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>, System.Collections.IEnumerable
    {
        protected IotOperationsBrokerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string brokerName, Azure.ResourceManager.IotOperations.IotOperationsBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string brokerName, Azure.ResourceManager.IotOperations.IotOperationsBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> Get(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>> GetAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> GetIfExists(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>> GetIfExistsAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsBrokerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>
    {
        public IotOperationsBrokerData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerListenerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>, System.Collections.IEnumerable
    {
        protected IotOperationsBrokerListenerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string listenerName, Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string listenerName, Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> Get(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>> GetAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> GetIfExists(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>> GetIfExistsAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsBrokerListenerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>
    {
        public IotOperationsBrokerListenerData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerListenerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsBrokerListenerResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName, string listenerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsBrokerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsBrokerResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource> GetIotOperationsBrokerAuthentication(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource>> GetIotOperationsBrokerAuthenticationAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationCollection GetIotOperationsBrokerAuthentications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource> GetIotOperationsBrokerAuthorization(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource>> GetIotOperationsBrokerAuthorizationAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationCollection GetIotOperationsBrokerAuthorizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource> GetIotOperationsBrokerListener(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource>> GetIotOperationsBrokerListenerAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerCollection GetIotOperationsBrokerListeners() { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsBrokerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsBrokerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsBrokerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsDataflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>, System.Collections.IEnumerable
    {
        protected IotOperationsDataflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataflowName, Azure.ResourceManager.IotOperations.IotOperationsDataflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataflowName, Azure.ResourceManager.IotOperations.IotOperationsDataflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> Get(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>> GetAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> GetIfExists(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>> GetIfExistsAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsDataflowData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>
    {
        public IotOperationsDataflowData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsDataflowEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>, System.Collections.IEnumerable
    {
        protected IotOperationsDataflowEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataflowEndpointName, Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataflowEndpointName, Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> Get(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>> GetAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> GetIfExists(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>> GetIfExistsAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsDataflowEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>
    {
        public IotOperationsDataflowEndpointData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsDataflowEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsDataflowEndpointResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string dataflowEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsDataflowProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>, System.Collections.IEnumerable
    {
        protected IotOperationsDataflowProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataflowProfileName, Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataflowProfileName, Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> Get(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>> GetAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> GetIfExists(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>> GetIfExistsAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsDataflowProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>
    {
        public IotOperationsDataflowProfileData(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsDataflowProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsDataflowProfileResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string dataflowProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> GetIotOperationsDataflow(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>> GetIotOperationsDataflowAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowCollection GetIotOperationsDataflows() { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsDataflowResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsDataflowResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string dataflowProfileName, string dataflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsDataflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsDataflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsDataflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsDataflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IotOperations.IotOperationsDataflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class IotOperationsExtensions
    {
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource GetIotOperationsBrokerAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource GetIotOperationsBrokerAuthorizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource GetIotOperationsBrokerListenerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerResource GetIotOperationsBrokerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource GetIotOperationsDataflowEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource GetIotOperationsDataflowProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsDataflowResource GetIotOperationsDataflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIotOperationsInstance(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> GetIotOperationsInstanceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsInstanceResource GetIotOperationsInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsInstanceCollection GetIotOperationsInstances(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIotOperationsInstances(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIotOperationsInstancesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IotOperationsInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>, System.Collections.IEnumerable
    {
        protected IotOperationsInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.IotOperations.IotOperationsInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.IotOperations.IotOperationsInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> GetIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IotOperationsInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>
    {
        public IotOperationsInstanceData(Azure.Core.AzureLocation location, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IotOperationsInstanceResource() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource> GetIotOperationsBroker(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsBrokerResource>> GetIotOperationsBrokerAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerCollection GetIotOperationsBrokers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource> GetIotOperationsDataflowEndpoint(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource>> GetIotOperationsDataflowEndpointAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointCollection GetIotOperationsDataflowEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource> GetIotOperationsDataflowProfile(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource>> GetIotOperationsDataflowProfileAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileCollection GetIotOperationsDataflowProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IotOperations.IotOperationsInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.IotOperationsInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.IotOperationsInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> Update(Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> UpdateAsync(Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotOperations.Mocking
{
    public partial class MockableIotOperationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIotOperationsArmClient() { }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationResource GetIotOperationsBrokerAuthenticationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationResource GetIotOperationsBrokerAuthorizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerResource GetIotOperationsBrokerListenerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsBrokerResource GetIotOperationsBrokerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointResource GetIotOperationsDataflowEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileResource GetIotOperationsDataflowProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsDataflowResource GetIotOperationsDataflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsInstanceResource GetIotOperationsInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIotOperationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotOperationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIotOperationsInstance(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource>> GetIotOperationsInstanceAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IotOperations.IotOperationsInstanceCollection GetIotOperationsInstances() { throw null; }
    }
    public partial class MockableIotOperationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIotOperationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIotOperationsInstances(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IotOperations.IotOperationsInstanceResource> GetIotOperationsInstancesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IotOperations.Models
{
    public static partial class ArmIotOperationsModelFactory
    {
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthenticationData IotOperationsBrokerAuthenticationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties IotOperationsBrokerAuthenticationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods> authenticationMethods = null, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerAuthorizationData IotOperationsBrokerAuthorizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties IotOperationsBrokerAuthorizationProperties(Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig authorizationPolicies = null, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerData IotOperationsBrokerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsBrokerListenerData IotOperationsBrokerListenerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties IotOperationsBrokerListenerProperties(string serviceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort> ports = null, Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType? serviceType = default(Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType?), Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties IotOperationsBrokerProperties(Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings advanced = null, Azure.ResourceManager.IotOperations.Models.BrokerCardinality cardinality = null, Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics diagnostics = null, Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer diskBackedMessageBuffer = null, Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? generateResourceLimitsCpu = default(Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode?), Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile? memoryProfile = default(Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile?), Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsDataflowData IotOperationsDataflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsDataflowEndpointData IotOperationsDataflowEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties IotOperationsDataflowEndpointProperties(Azure.ResourceManager.IotOperations.Models.DataflowEndpointType endpointType = default(Azure.ResourceManager.IotOperations.Models.DataflowEndpointType), Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer dataExplorerSettings = null, Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage dataLakeStorageSettings = null, Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake fabricOneLakeSettings = null, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka kafkaSettings = null, string localStoragePersistentVolumeClaimRef = null, Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt mqttSettings = null, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsDataflowProfileData IotOperationsDataflowProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties IotOperationsDataflowProfileProperties(Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics diagnostics = null, int? instanceCount = default(int?), Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties IotOperationsDataflowProperties(Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? mode = default(Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties> operations = null, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IotOperations.IotOperationsInstanceData IotOperationsInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties properties = null, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties IotOperationsInstanceProperties(string description = null, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? provisioningState = default(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState?), string version = null, Azure.Core.ResourceIdentifier schemaRegistryRefResourceId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlockerListenerServiceType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlockerListenerServiceType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType ClusterIP { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType LoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType NodePort { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType left, Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType left, Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerAdvancedSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>
    {
        public BrokerAdvancedSettings() { }
        public Azure.ResourceManager.IotOperations.Models.BrokerClientConfig Clients { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? EncryptInternalTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig InternalCerts { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerAuthenticationMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerAuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod Custom { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod ServiceAccountToken { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod X509 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod left, Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod left, Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerAuthenticatorMethodCustom : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>
    {
        public BrokerAuthenticatorMethodCustom(System.Uri endpoint) { }
        public string CaCertConfigMap { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public string X509SecretRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethods : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>
    {
        public BrokerAuthenticatorMethods(Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod method) { }
        public Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodCustom CustomSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerAuthenticationMethod Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServiceAccountTokenAudiences { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509 X509Settings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethodX509 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>
    {
        public BrokerAuthenticatorMethodX509() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes> AuthorizationAttributes { get { throw null; } }
        public string TrustedClientCaCert { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethodX509Attributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>
    {
        public BrokerAuthenticatorMethodX509Attributes(System.Collections.Generic.IDictionary<string, string> attributes, string subject) { }
        public System.Collections.Generic.IDictionary<string, string> Attributes { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthorizationConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>
    {
        public BrokerAuthorizationConfig() { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Cache { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule> Rules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthorizationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>
    {
        public BrokerAuthorizationRule(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule> brokerResources, Azure.ResourceManager.IotOperations.Models.PrincipalConfig principals) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule> BrokerResources { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.PrincipalConfig Principals { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule> StateStoreResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerBackendChain : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>
    {
        public BrokerBackendChain(int partitions, int redundancyFactor) { }
        public int Partitions { get { throw null; } set { } }
        public int RedundancyFactor { get { throw null; } set { } }
        public int? Workers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerBackendChain System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerBackendChain System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerBackendChain>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerCardinality : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>
    {
        public BrokerCardinality(Azure.ResourceManager.IotOperations.Models.BrokerBackendChain backendChain, Azure.ResourceManager.IotOperations.Models.BrokerFrontend frontend) { }
        public Azure.ResourceManager.IotOperations.Models.BrokerBackendChain BackendChain { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerFrontend Frontend { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerCardinality System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerCardinality System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerCardinality>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerClientConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>
    {
        public BrokerClientConfig() { }
        public int? MaxKeepAliveSeconds { get { throw null; } set { } }
        public int? MaxMessageExpirySeconds { get { throw null; } set { } }
        public int? MaxPacketSizeBytes { get { throw null; } set { } }
        public int? MaxReceiveMaximum { get { throw null; } set { } }
        public int? MaxSessionExpirySeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit SubscriberQueueLimit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerClientConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerClientConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerClientConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>
    {
        public BrokerDiagnostics() { }
        public string LogsLevel { get { throw null; } set { } }
        public int? MetricsPrometheusPort { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck SelfCheck { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces Traces { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerDiagnosticSelfCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>
    {
        public BrokerDiagnosticSelfCheck() { }
        public int? IntervalSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Mode { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticSelfCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerDiagnosticTraces : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>
    {
        public BrokerDiagnosticTraces() { }
        public int? CacheSizeMegabytes { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing SelfTracing { get { throw null; } set { } }
        public int? SpanChannelCapacity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerDiagnosticTraces>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerFrontend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>
    {
        public BrokerFrontend(int replicas) { }
        public int Replicas { get { throw null; } set { } }
        public int? Workers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerFrontend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerFrontend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerFrontend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerListenerPort : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>
    {
        public BrokerListenerPort(int port) { }
        public string AuthenticationRef { get { throw null; } set { } }
        public string AuthorizationRef { get { throw null; } set { } }
        public int? NodePort { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerProtocolType? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod Tls { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerListenerPort System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerListenerPort System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerMemoryProfile : System.IEquatable<Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerMemoryProfile(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile High { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile Low { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile Medium { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile Tiny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile left, Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile left, Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerOperatorValue : System.IEquatable<Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerOperatorValue(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue DoesNotExist { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue Exists { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue In { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue NotIn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue left, Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue left, Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerProtocolType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.BrokerProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.BrokerProtocolType Mqtt { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerProtocolType WebSockets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.BrokerProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.BrokerProtocolType left, Azure.ResourceManager.IotOperations.Models.BrokerProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.BrokerProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.BrokerProtocolType left, Azure.ResourceManager.IotOperations.Models.BrokerProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerResourceDefinitionMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerResourceDefinitionMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod Connect { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod Publish { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod Subscribe { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod left, Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod left, Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerResourceRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>
    {
        public BrokerResourceRule(Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod method) { }
        public System.Collections.Generic.IList<string> ClientIds { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.BrokerResourceDefinitionMethod Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Topics { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerResourceRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.BrokerResourceRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.BrokerResourceRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertManagerCertConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>
    {
        public CertManagerCertConfig(string duration, string renewBefore, Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey privateKey) { }
        public string Duration { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey PrivateKey { get { throw null; } set { } }
        public string RenewBefore { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertManagerCertificateSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>
    {
        public CertManagerCertificateSpec(Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef issuerRef) { }
        public string Duration { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef IssuerRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey PrivateKey { get { throw null; } set { } }
        public string RenewBefore { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.SanForCert San { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertManagerIssuerKind : System.IEquatable<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertManagerIssuerKind(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind ClusterIssuer { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind Issuer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind left, Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind left, Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertManagerIssuerRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>
    {
        public CertManagerIssuerRef(string group, Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind kind, string name) { }
        public string Group { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CertManagerIssuerKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerIssuerRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertManagerPrivateKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>
    {
        public CertManagerPrivateKey(Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm algorithm, Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy rotationPolicy) { }
        public Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Algorithm { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy RotationPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.CertManagerPrivateKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudEventAttributeType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudEventAttributeType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType CreateOrRemap { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType Propagate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType left, Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType left, Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataExplorerAuthMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataExplorerAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod left, Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod left, Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowBuiltInTransformationDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>
    {
        public DataflowBuiltInTransformationDataset(string key, System.Collections.Generic.IEnumerable<string> inputs) { }
        public string Description { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Inputs { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string SchemaRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowBuiltInTransformationFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>
    {
        public DataflowBuiltInTransformationFilter(System.Collections.Generic.IEnumerable<string> inputs, string expression) { }
        public string Description { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Inputs { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.DataflowFilterType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowBuiltInTransformationMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>
    {
        public DataflowBuiltInTransformationMap(System.Collections.Generic.IEnumerable<string> inputs, string output) { }
        public string Description { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Inputs { get { throw null; } }
        public string Output { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowMappingType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowBuiltInTransformationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>
    {
        public DataflowBuiltInTransformationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationDataset> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationFilter> Filter { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationMap> Map { get { throw null; } }
        public string SchemaRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat? SerializationFormat { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowDestinationOperationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>
    {
        public DataflowDestinationOperationSettings(string endpointRef, string dataDestination) { }
        public string DataDestination { get { throw null; } set { } }
        public string EndpointRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointAuthenticationSasl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>
    {
        public DataflowEndpointAuthenticationSasl(Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType saslType, string secretRef) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType SaslType { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointAuthenticationSaslType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointAuthenticationSaslType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType Plain { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType ScramSha256 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType ScramSha512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSaslType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointAuthenticationUserAssignedManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>
    {
        public DataflowEndpointAuthenticationUserAssignedManagedIdentity(string clientId, string tenantId) { }
        public string ClientId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataExplorer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>
    {
        public DataflowEndpointDataExplorer(Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication authentication, string database, string host) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig Batching { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataExplorerAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>
    {
        public DataflowEndpointDataExplorerAuthentication(Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod method) { }
        public Azure.ResourceManager.IotOperations.Models.DataExplorerAuthMethod Method { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorerAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataLakeStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>
    {
        public DataflowEndpointDataLakeStorage(Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication authentication, string host) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig Batching { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataLakeStorageAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>
    {
        public DataflowEndpointDataLakeStorageAuthentication(Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod method) { }
        public string AccessTokenSecretRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod Method { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointFabricOneLake : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>
    {
        public DataflowEndpointFabricOneLake(Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication authentication, Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames names, Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType oneLakePathType, string host) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig Batching { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames Names { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType OneLakePathType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointFabricOneLakeAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>
    {
        public DataflowEndpointFabricOneLakeAuthentication(Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod method) { }
        public Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod Method { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointFabricOneLakeNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>
    {
        public DataflowEndpointFabricOneLakeNames(string lakehouseName, string workspaceName) { }
        public string LakehouseName { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLakeNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointFabricPathType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointFabricPathType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType Files { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType Tables { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricPathType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointKafka : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>
    {
        public DataflowEndpointKafka(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication authentication, string host) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching Batching { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType? CloudEventAttributes { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression? Compression { get { throw null; } set { } }
        public string ConsumerGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? CopyMqttProperties { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck? KafkaAcks { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy? PartitionStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties Tls { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointKafkaAck : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointKafkaAck(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck All { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck One { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAck right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointKafkaAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>
    {
        public DataflowEndpointKafkaAuthentication(Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod method) { }
        public Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod Method { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationSasl SaslSettings { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        public string X509CertificateSecretRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointKafkaBatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>
    {
        public DataflowEndpointKafkaBatching() { }
        public int? LatencyMs { get { throw null; } set { } }
        public int? MaxBytes { get { throw null; } set { } }
        public int? MaxMessages { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaBatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointKafkaCompression : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointKafkaCompression(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression Gzip { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression Lz4 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression None { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression Snappy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaCompression right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointKafkaPartitionStrategy : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointKafkaPartitionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy Default { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy Property { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy Static { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy Topic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafkaPartitionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointMqtt : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>
    {
        public DataflowEndpointMqtt(Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication authentication) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication Authentication { get { throw null; } set { } }
        public string ClientIdPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.CloudEventAttributeType? CloudEventAttributes { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int? KeepAliveSeconds { get { throw null; } set { } }
        public int? MaxInflightMessages { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerProtocolType? Protocol { get { throw null; } set { } }
        public int? Qos { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.MqttRetainType? Retain { get { throw null; } set { } }
        public int? SessionExpirySeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties Tls { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointMqttAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>
    {
        public DataflowEndpointMqttAuthentication(Azure.ResourceManager.IotOperations.Models.MqttAuthMethod method) { }
        public Azure.ResourceManager.IotOperations.Models.MqttAuthMethod Method { get { throw null; } set { } }
        public string ServiceAccountTokenAudience { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        public string X509CertificateSecretRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqttAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointType DataExplorer { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointType DataLakeStorage { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointType FabricOneLake { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointType Kafka { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointType LocalStorage { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowEndpointType Mqtt { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowEndpointType left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowEndpointType left, Azure.ResourceManager.IotOperations.Models.DataflowEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowFilterType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowFilterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowFilterType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowFilterType Filter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowFilterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowFilterType left, Azure.ResourceManager.IotOperations.Models.DataflowFilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowFilterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowFilterType left, Azure.ResourceManager.IotOperations.Models.DataflowFilterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowMappingType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowMappingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowMappingType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowMappingType BuiltInFunction { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowMappingType Compute { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowMappingType NewProperties { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowMappingType PassThrough { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowMappingType Rename { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowMappingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowMappingType left, Azure.ResourceManager.IotOperations.Models.DataflowMappingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowMappingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowMappingType left, Azure.ResourceManager.IotOperations.Models.DataflowMappingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowOperationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>
    {
        public DataflowOperationProperties(Azure.ResourceManager.IotOperations.Models.DataflowOperationType operationType) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowBuiltInTransformationSettings BuiltInTransformationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowDestinationOperationSettings DestinationSettings { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowOperationType OperationType { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings SourceSettings { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowOperationType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowOperationType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowOperationType BuiltInTransformation { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowOperationType Destination { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataflowOperationType Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowOperationType left, Azure.ResourceManager.IotOperations.Models.DataflowOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowOperationType left, Azure.ResourceManager.IotOperations.Models.DataflowOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowProfileDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>
    {
        public DataflowProfileDiagnostics() { }
        public string LogsLevel { get { throw null; } set { } }
        public int? MetricsPrometheusPort { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowSourceOperationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>
    {
        public DataflowSourceOperationSettings(string endpointRef, System.Collections.Generic.IEnumerable<string> dataSources) { }
        public string AssetRef { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataSources { get { throw null; } }
        public string EndpointRef { get { throw null; } set { } }
        public string SchemaRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat? SerializationFormat { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DataflowSourceOperationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowSourceSerializationFormat : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowSourceSerializationFormat(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat left, Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat left, Azure.ResourceManager.IotOperations.Models.DataflowSourceSerializationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataLakeStorageAuthMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataLakeStorageAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod AccessToken { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod left, Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod left, Azure.ResourceManager.IotOperations.Models.DataLakeStorageAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticSelfTracing : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>
    {
        public DiagnosticSelfTracing() { }
        public int? IntervalSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiagnosticSelfTracing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskBackedMessageBuffer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>
    {
        public DiskBackedMessageBuffer(string maxSize) { }
        public Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec EphemeralVolumeClaimSpec { get { throw null; } set { } }
        public string MaxSize { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec PersistentVolumeClaimSpec { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricOneLakeAuthMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricOneLakeAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod left, Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod left, Azure.ResourceManager.IotOperations.Models.FabricOneLakeAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotOperationsBatchingConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>
    {
        public IotOperationsBatchingConfig() { }
        public int? LatencySeconds { get { throw null; } set { } }
        public int? MaxMessages { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBatchingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>
    {
        public IotOperationsBrokerAuthenticationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods> authenticationMethods) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.BrokerAuthenticatorMethods> AuthenticationMethods { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerAuthorizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>
    {
        public IotOperationsBrokerAuthorizationProperties(Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig authorizationPolicies) { }
        public Azure.ResourceManager.IotOperations.Models.BrokerAuthorizationConfig AuthorizationPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerAuthorizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerListenerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>
    {
        public IotOperationsBrokerListenerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort> ports) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.BrokerListenerPort> Ports { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BlockerListenerServiceType? ServiceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerListenerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsBrokerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>
    {
        public IotOperationsBrokerProperties() { }
        public Azure.ResourceManager.IotOperations.Models.BrokerAdvancedSettings Advanced { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerCardinality Cardinality { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerDiagnostics Diagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DiskBackedMessageBuffer DiskBackedMessageBuffer { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? GenerateResourceLimitsCpu { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerMemoryProfile? MemoryProfile { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsDataflowEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>
    {
        public IotOperationsDataflowEndpointProperties(Azure.ResourceManager.IotOperations.Models.DataflowEndpointType endpointType) { }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataExplorer DataExplorerSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointDataLakeStorage DataLakeStorageSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointType EndpointType { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointFabricOneLake FabricOneLakeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointKafka KafkaSettings { get { throw null; } set { } }
        public string LocalStoragePersistentVolumeClaimRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.DataflowEndpointMqtt MqttSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsDataflowProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>
    {
        public IotOperationsDataflowProfileProperties() { }
        public Azure.ResourceManager.IotOperations.Models.DataflowProfileDiagnostics Diagnostics { get { throw null; } set { } }
        public int? InstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProfileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsDataflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>
    {
        public IotOperationsDataflowProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties> operations) { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.DataflowOperationProperties> Operations { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>
    {
        public IotOperationsExtendedLocation(string name, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType type) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotOperationsExtendedLocationType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotOperationsExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType left, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType left, Azure.ResourceManager.IotOperations.Models.IotOperationsExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotOperationsInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>
    {
        public IotOperationsInstancePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IotOperationsInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>
    {
        public IotOperationsInstanceProperties(Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef schemaRegistryRef) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SchemaRegistryRefResourceId { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotOperationsOperationalMode : System.IEquatable<Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotOperationsOperationalMode(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode left, Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode left, Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IotOperationsProvisioningState : System.IEquatable<Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IotOperationsProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState left, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState left, Azure.ResourceManager.IotOperations.Models.IotOperationsProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotOperationsTlsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>
    {
        public IotOperationsTlsProperties() { }
        public Azure.ResourceManager.IotOperations.Models.IotOperationsOperationalMode? Mode { get { throw null; } set { } }
        public string TrustedCaCertificateConfigMapRef { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.IotOperationsTlsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KafkaAuthMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KafkaAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod Anonymous { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod Sasl { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod X509Certificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod left, Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod left, Azure.ResourceManager.IotOperations.Models.KafkaAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>
    {
        public KubernetesReference(string kind, string name) { }
        public string ApiGroup { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.KubernetesReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.KubernetesReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.KubernetesReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListenerPortTlsCertMethod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>
    {
        public ListenerPortTlsCertMethod(Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode mode) { }
        public Azure.ResourceManager.IotOperations.Models.CertManagerCertificateSpec CertManagerCertificateSpec { get { throw null; } set { } }
        public string ManualSecretRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.ListenerPortTlsCertMethod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalKubernetesReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>
    {
        public LocalKubernetesReference(string kind, string name) { }
        public string ApiGroup { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MqttAuthMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.MqttAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MqttAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.MqttAuthMethod Anonymous { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.MqttAuthMethod ServiceAccountToken { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.MqttAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.MqttAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.MqttAuthMethod X509Certificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.MqttAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.MqttAuthMethod left, Azure.ResourceManager.IotOperations.Models.MqttAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.MqttAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.MqttAuthMethod left, Azure.ResourceManager.IotOperations.Models.MqttAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MqttRetainType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.MqttRetainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MqttRetainType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.MqttRetainType Keep { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.MqttRetainType Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.MqttRetainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.MqttRetainType left, Azure.ResourceManager.IotOperations.Models.MqttRetainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.MqttRetainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.MqttRetainType left, Azure.ResourceManager.IotOperations.Models.MqttRetainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrincipalConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>
    {
        public PrincipalConfig() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, string>> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<string> ClientIds { get { throw null; } }
        public System.Collections.Generic.IList<string> Usernames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.PrincipalConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.PrincipalConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.PrincipalConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateKeyAlgorithm : System.IEquatable<Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateKeyAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Ec256 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Ec384 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Ec521 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Ed25519 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Rsa2048 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Rsa4096 { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm Rsa8192 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm left, Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm left, Azure.ResourceManager.IotOperations.Models.PrivateKeyAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateKeyRotationPolicy : System.IEquatable<Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateKeyRotationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy left, Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy left, Azure.ResourceManager.IotOperations.Models.PrivateKeyRotationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SanForCert : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SanForCert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SanForCert>
    {
        public SanForCert(System.Collections.Generic.IEnumerable<string> dns, System.Collections.Generic.IEnumerable<string> ip) { }
        public System.Collections.Generic.IList<string> Dns { get { throw null; } }
        public System.Collections.Generic.IList<string> IP { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.SanForCert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SanForCert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SanForCert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.SanForCert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SanForCert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SanForCert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SanForCert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaRegistryRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>
    {
        public SchemaRegistryRef(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SchemaRegistryRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StateStoreResourceDefinitionMethod : System.IEquatable<Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StateStoreResourceDefinitionMethod(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod Read { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod left, Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod left, Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StateStoreResourceKeyType : System.IEquatable<Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StateStoreResourceKeyType(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType Binary { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType Pattern { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType left, Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType left, Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StateStoreResourceRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>
    {
        public StateStoreResourceRule(Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType keyType, System.Collections.Generic.IEnumerable<string> keys, Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod method) { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.StateStoreResourceKeyType KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.StateStoreResourceDefinitionMethod Method { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.StateStoreResourceRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriberMessageDropStrategy : System.IEquatable<Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriberMessageDropStrategy(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy DropOldest { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy left, Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy left, Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriberQueueLimit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>
    {
        public SubscriberQueueLimit() { }
        public long? Length { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.SubscriberMessageDropStrategy? Strategy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.SubscriberQueueLimit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsCertMethodMode : System.IEquatable<Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsCertMethodMode(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode left, Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode left, Azure.ResourceManager.IotOperations.Models.TlsCertMethodMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransformationSerializationFormat : System.IEquatable<Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransformationSerializationFormat(string value) { throw null; }
        public static Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat Delta { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat Json { get { throw null; } }
        public static Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat left, Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat left, Azure.ResourceManager.IotOperations.Models.TransformationSerializationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeClaimResourceRequirements : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>
    {
        public VolumeClaimResourceRequirements() { }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeClaimSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>
    {
        public VolumeClaimSpec() { }
        public System.Collections.Generic.IList<string> AccessModes { get { throw null; } }
        public Azure.ResourceManager.IotOperations.Models.LocalKubernetesReference DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.KubernetesReference DataSourceRef { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.VolumeClaimResourceRequirements Resources { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector Selector { get { throw null; } set { } }
        public string StorageClassName { get { throw null; } set { } }
        public string VolumeMode { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeClaimSpecSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>
    {
        public VolumeClaimSpecSelector() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions> MatchExpressions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> MatchLabels { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeClaimSpecSelectorMatchExpressions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>
    {
        public VolumeClaimSpecSelectorMatchExpressions(string key, Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue @operator) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.IotOperations.Models.BrokerOperatorValue Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IotOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
