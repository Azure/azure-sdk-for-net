namespace Azure.ResourceManager.IoTOperations
{
    public partial class BrokerAuthenticationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BrokerAuthenticationResource() { }
        public virtual Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName, string authenticationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BrokerAuthenticationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>, System.Collections.IEnumerable
    {
        protected BrokerAuthenticationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authenticationName, Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authenticationName, Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> Get(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>> GetAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> GetIfExists(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>> GetIfExistsAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BrokerAuthenticationResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>
    {
        public BrokerAuthenticationResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthorizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BrokerAuthorizationResource() { }
        public virtual Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName, string authorizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BrokerAuthorizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>, System.Collections.IEnumerable
    {
        protected BrokerAuthorizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationName, Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> Get(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>> GetAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> GetIfExists(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>> GetIfExistsAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BrokerAuthorizationResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>
    {
        public BrokerAuthorizationResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerListenerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BrokerListenerResource() { }
        public virtual Azure.ResourceManager.IoTOperations.BrokerListenerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName, string listenerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerListenerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerListenerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IoTOperations.BrokerListenerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerListenerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerListenerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerListenerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerListenerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerListenerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BrokerListenerResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerListenerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerListenerResource>, System.Collections.IEnumerable
    {
        protected BrokerListenerResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerListenerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string listenerName, Azure.ResourceManager.IoTOperations.BrokerListenerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerListenerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string listenerName, Azure.ResourceManager.IoTOperations.BrokerListenerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerListenerResource> Get(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.BrokerListenerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.BrokerListenerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerListenerResource>> GetAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerListenerResource> GetIfExists(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerListenerResource>> GetIfExistsAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.BrokerListenerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerListenerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.BrokerListenerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerListenerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BrokerListenerResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>
    {
        public BrokerListenerResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.BrokerListenerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerListenerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerListenerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BrokerResource() { }
        public virtual Azure.ResourceManager.IoTOperations.BrokerResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string brokerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource> GetBrokerAuthenticationResource(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource>> GetBrokerAuthenticationResourceAsync(string authenticationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceCollection GetBrokerAuthenticationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource> GetBrokerAuthorizationResource(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource>> GetBrokerAuthorizationResourceAsync(string authorizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceCollection GetBrokerAuthorizationResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerListenerResource> GetBrokerListenerResource(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerListenerResource>> GetBrokerListenerResourceAsync(string listenerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerListenerResourceCollection GetBrokerListenerResources() { throw null; }
        Azure.ResourceManager.IoTOperations.BrokerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.BrokerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BrokerResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerResource>, System.Collections.IEnumerable
    {
        protected BrokerResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string brokerName, Azure.ResourceManager.IoTOperations.BrokerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.BrokerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string brokerName, Azure.ResourceManager.IoTOperations.BrokerResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerResource> Get(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.BrokerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.BrokerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerResource>> GetAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerResource> GetIfExists(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.BrokerResource>> GetIfExistsAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.BrokerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.BrokerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.BrokerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.BrokerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BrokerResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>
    {
        public BrokerResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.BrokerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.BrokerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.BrokerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataflowEndpointResource() { }
        public virtual Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string dataflowEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataflowEndpointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>, System.Collections.IEnumerable
    {
        protected DataflowEndpointResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataflowEndpointName, Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataflowEndpointName, Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> Get(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>> GetAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> GetIfExists(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>> GetIfExistsAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataflowEndpointResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>
    {
        public DataflowEndpointResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataflowProfileResource() { }
        public virtual Azure.ResourceManager.IoTOperations.DataflowProfileResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string dataflowProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowResource> GetDataflowResource(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowResource>> GetDataflowResourceAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.DataflowResourceCollection GetDataflowResources() { throw null; }
        Azure.ResourceManager.IoTOperations.DataflowProfileResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.DataflowProfileResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.DataflowProfileResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.DataflowProfileResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataflowProfileResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.DataflowProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.DataflowProfileResource>, System.Collections.IEnumerable
    {
        protected DataflowProfileResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataflowProfileName, Azure.ResourceManager.IoTOperations.DataflowProfileResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataflowProfileName, Azure.ResourceManager.IoTOperations.DataflowProfileResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowProfileResource> Get(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.DataflowProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.DataflowProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowProfileResource>> GetAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.DataflowProfileResource> GetIfExists(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.DataflowProfileResource>> GetIfExistsAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.DataflowProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.DataflowProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.DataflowProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.DataflowProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataflowProfileResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>
    {
        public DataflowProfileResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.DataflowProfileResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.DataflowProfileResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowProfileResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataflowResource() { }
        public virtual Azure.ResourceManager.IoTOperations.DataflowResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName, string dataflowProfileName, string dataflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IoTOperations.DataflowResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.DataflowResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.DataflowResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.IoTOperations.DataflowResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataflowResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.DataflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.DataflowResource>, System.Collections.IEnumerable
    {
        protected DataflowResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dataflowName, Azure.ResourceManager.IoTOperations.DataflowResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.DataflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dataflowName, Azure.ResourceManager.IoTOperations.DataflowResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowResource> Get(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.DataflowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.DataflowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowResource>> GetAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.DataflowResource> GetIfExists(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.DataflowResource>> GetIfExistsAsync(string dataflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.DataflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.DataflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.DataflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.DataflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataflowResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>
    {
        public DataflowResourceData(Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.DataflowResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.DataflowResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.DataflowResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceResource() { }
        public virtual Azure.ResourceManager.IoTOperations.InstanceResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.BrokerResource> GetBrokerResource(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.BrokerResource>> GetBrokerResourceAsync(string brokerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerResourceCollection GetBrokerResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowEndpointResource> GetDataflowEndpointResource(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowEndpointResource>> GetDataflowEndpointResourceAsync(string dataflowEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.DataflowEndpointResourceCollection GetDataflowEndpointResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.DataflowProfileResource> GetDataflowProfileResource(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.DataflowProfileResource>> GetDataflowProfileResourceAsync(string dataflowProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.DataflowProfileResourceCollection GetDataflowProfileResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.IoTOperations.InstanceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.InstanceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> Update(Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> UpdateAsync(Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>, System.Collections.IEnumerable
    {
        protected InstanceResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.InstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.IoTOperations.InstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.IoTOperations.InstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.IoTOperations.InstanceResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.IoTOperations.InstanceResource> GetIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.IoTOperations.InstanceResource>> GetIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.IoTOperations.InstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.IoTOperations.InstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.InstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstanceResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>
    {
        public InstanceResourceData(Azure.Core.AzureLocation location, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation) { }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.InstanceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.InstanceResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.InstanceResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.InstanceResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class IoTOperationsExtensions
    {
        public static Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource GetBrokerAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource GetBrokerAuthorizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerListenerResource GetBrokerListenerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerResource GetBrokerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.DataflowEndpointResource GetDataflowEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.DataflowProfileResource GetDataflowProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.DataflowResource GetDataflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.IoTOperations.InstanceResource GetInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstanceResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetInstanceResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.InstanceResourceCollection GetInstanceResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstanceResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstanceResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.IoTOperations.Models.Operation> GetOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.Models.Operation> GetOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTOperations.Mocking
{
    public partial class MockableIoTOperationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsArmClient() { }
        public virtual Azure.ResourceManager.IoTOperations.BrokerAuthenticationResource GetBrokerAuthenticationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerAuthorizationResource GetBrokerAuthorizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerListenerResource GetBrokerListenerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.BrokerResource GetBrokerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.DataflowEndpointResource GetDataflowEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.DataflowProfileResource GetDataflowProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.DataflowResource GetDataflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.InstanceResource GetInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableIoTOperationsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstanceResource(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.IoTOperations.InstanceResource>> GetInstanceResourceAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.IoTOperations.InstanceResourceCollection GetInstanceResources() { throw null; }
    }
    public partial class MockableIoTOperationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstanceResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.InstanceResource> GetInstanceResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableIoTOperationsTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableIoTOperationsTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.IoTOperations.Models.Operation> GetOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.IoTOperations.Models.Operation> GetOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.IoTOperations.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ActionType left, Azure.ResourceManager.IoTOperations.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ActionType left, Azure.ResourceManager.IoTOperations.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvancedSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>
    {
        public AdvancedSettings() { }
        public Azure.ResourceManager.IoTOperations.Models.ClientConfig Clients { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? EncryptInternalTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions InternalCerts { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.AdvancedSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.AdvancedSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AdvancedSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmIoTOperationsModelFactory
    {
        public static Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties BrokerAuthenticationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods> authenticationMethods = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerAuthenticationResourceData BrokerAuthenticationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties BrokerAuthorizationProperties(Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig authorizationPolicies = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerAuthorizationResourceData BrokerAuthorizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties BrokerListenerProperties(string serviceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.ListenerPort> ports = null, Azure.ResourceManager.IoTOperations.Models.ServiceType? serviceType = default(Azure.ResourceManager.IoTOperations.Models.ServiceType?), Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerListenerResourceData BrokerListenerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerProperties BrokerProperties(Azure.ResourceManager.IoTOperations.Models.AdvancedSettings advanced = null, Azure.ResourceManager.IoTOperations.Models.Cardinality cardinality = null, Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics diagnostics = null, Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer diskBackedMessageBuffer = null, Azure.ResourceManager.IoTOperations.Models.OperationalMode? generateResourceLimitsCpu = default(Azure.ResourceManager.IoTOperations.Models.OperationalMode?), Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile? memoryProfile = default(Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile?), Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.BrokerResourceData BrokerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.BrokerProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties DataflowEndpointProperties(Azure.ResourceManager.IoTOperations.Models.EndpointType endpointType = default(Azure.ResourceManager.IoTOperations.Models.EndpointType), Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer dataExplorerSettings = null, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage dataLakeStorageSettings = null, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake fabricOneLakeSettings = null, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka kafkaSettings = null, string localStoragePersistentVolumeClaimRef = null, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt mqttSettings = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.DataflowEndpointResourceData DataflowEndpointResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties DataflowProfileProperties(Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics diagnostics = null, int? instanceCount = default(int?), Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.DataflowProfileResourceData DataflowProfileResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowProperties DataflowProperties(Azure.ResourceManager.IoTOperations.Models.OperationalMode? mode = default(Azure.ResourceManager.IoTOperations.Models.OperationalMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.DataflowOperation> operations = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.DataflowResourceData DataflowResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.IoTOperations.Models.DataflowProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.InstanceProperties InstanceProperties(string description = null, Azure.ResourceManager.IoTOperations.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.IoTOperations.Models.ProvisioningState?), string version = null, string schemaRegistryNamespace = null, Azure.ResourceManager.IoTOperations.Models.Components components = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.InstanceResourceData InstanceResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.IoTOperations.Models.InstanceProperties properties = null, Azure.ResourceManager.IoTOperations.Models.ExtendedLocation extendedLocation = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.Operation Operation(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.IoTOperations.Models.OperationDisplay display = null, Azure.ResourceManager.IoTOperations.Models.Origin? origin = default(Azure.ResourceManager.IoTOperations.Models.Origin?), Azure.ResourceManager.IoTOperations.Models.ActionType? actionType = default(Azure.ResourceManager.IoTOperations.Models.ActionType?)) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.OperationDisplay OperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
    }
    public partial class AuthorizationConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>
    {
        public AuthorizationConfig() { }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Cache { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule> Rules { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>
    {
        public AuthorizationRule(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule> brokerResources, Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition principals) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule> BrokerResources { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition Principals { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule> StateStoreResources { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.AuthorizationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.AuthorizationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.AuthorizationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackendChain : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>
    {
        public BackendChain(int partitions, int redundancyFactor) { }
        public int Partitions { get { throw null; } set { } }
        public int RedundancyFactor { get { throw null; } set { } }
        public int? Workers { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BackendChain System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BackendChain System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BackendChain>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BatchingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>
    {
        public BatchingConfiguration() { }
        public int? LatencySeconds { get { throw null; } set { } }
        public int? MaxMessages { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerAuthenticationMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerAuthenticationMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod Custom { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod ServiceAccountToken { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod X509 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod left, Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod left, Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>
    {
        public BrokerAuthenticationProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods> authenticationMethods) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods> AuthenticationMethods { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethodCustom : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>
    {
        public BrokerAuthenticatorMethodCustom(System.Uri endpoint) { }
        public string CaCertConfigMap { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public string X509SecretRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethods : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>
    {
        public BrokerAuthenticatorMethods(Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod method) { }
        public Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodCustom CustomSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticationMethod Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServiceAccountTokenAudiences { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509 X509Settings { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethods>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethodX509 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>
    {
        public BrokerAuthenticatorMethodX509() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes> AuthorizationAttributes { get { throw null; } }
        public string TrustedClientCaCert { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthenticatorMethodX509Attributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>
    {
        public BrokerAuthenticatorMethodX509Attributes(System.Collections.Generic.IDictionary<string, string> attributes, string subject) { }
        public System.Collections.Generic.IDictionary<string, string> Attributes { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthenticatorMethodX509Attributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerAuthorizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>
    {
        public BrokerAuthorizationProperties(Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig authorizationPolicies) { }
        public Azure.ResourceManager.IoTOperations.Models.AuthorizationConfig AuthorizationPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerAuthorizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>
    {
        public BrokerDiagnostics() { }
        public Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs Logs { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.Metrics Metrics { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.SelfCheck SelfCheck { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.Traces Traces { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrokerListenerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>
    {
        public BrokerListenerProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.ListenerPort> ports) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.ListenerPort> Ports { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ServiceType? ServiceType { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerListenerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerMemoryProfile : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerMemoryProfile(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile High { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile Low { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile Medium { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile Tiny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile left, Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile left, Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>
    {
        public BrokerProperties() { }
        public Azure.ResourceManager.IoTOperations.Models.AdvancedSettings Advanced { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.Cardinality Cardinality { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerDiagnostics Diagnostics { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer DiskBackedMessageBuffer { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? GenerateResourceLimitsCpu { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerMemoryProfile? MemoryProfile { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.BrokerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerProtocolType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerProtocolType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType Mqtt { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType WebSockets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType left, Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType left, Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BrokerResourceDefinitionMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BrokerResourceDefinitionMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod Connect { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod Publish { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod Subscribe { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod left, Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod left, Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BrokerResourceRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>
    {
        public BrokerResourceRule(Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod method) { }
        public System.Collections.Generic.IList<string> ClientIds { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerResourceDefinitionMethod Method { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Topics { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.BrokerResourceRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Cardinality : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>
    {
        public Cardinality(Azure.ResourceManager.IoTOperations.Models.BackendChain backendChain, Azure.ResourceManager.IoTOperations.Models.Frontend frontend) { }
        public Azure.ResourceManager.IoTOperations.Models.BackendChain BackendChain { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.Frontend Frontend { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.Cardinality System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.Cardinality System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Cardinality>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertManagerCertificateSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>
    {
        public CertManagerCertificateSpec(Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef issuerRef) { }
        public string Duration { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef IssuerRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey PrivateKey { get { throw null; } set { } }
        public string RenewBefore { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.SanForCert San { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertManagerCertOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>
    {
        public CertManagerCertOptions(string duration, string renewBefore, Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey privateKey) { }
        public string Duration { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey PrivateKey { get { throw null; } set { } }
        public string RenewBefore { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerCertOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertManagerIssuerKind : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertManagerIssuerKind(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind ClusterIssuer { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind Issuer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind left, Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind left, Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CertManagerIssuerRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>
    {
        public CertManagerIssuerRef(string group, Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind kind, string name) { }
        public string Group { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerIssuerRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CertManagerPrivateKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>
    {
        public CertManagerPrivateKey(Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm algorithm, Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy rotationPolicy) { }
        public Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Algorithm { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy RotationPolicy { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.CertManagerPrivateKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClientConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>
    {
        public ClientConfig() { }
        public int? MaxKeepAliveSeconds { get { throw null; } set { } }
        public int? MaxMessageExpirySeconds { get { throw null; } set { } }
        public int? MaxPacketSizeBytes { get { throw null; } set { } }
        public int? MaxReceiveMaximum { get { throw null; } set { } }
        public int? MaxSessionExpirySeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit SubscriberQueueLimit { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.ClientConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ClientConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ClientConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudEventAttributeType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudEventAttributeType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType CreateOrRemap { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType Propagate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType left, Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType left, Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Components : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Components>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Components>
    {
        public Components() { }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? AdrState { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? AkriState { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? ConnectorsState { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? DataflowsState { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? SchemaRegistryState { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.Components System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Components>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Components>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.Components System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Components>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Components>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Components>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataExplorerAuthMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataExplorerAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod left, Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod left, Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowBuiltInTransformationDataset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>
    {
        public DataflowBuiltInTransformationDataset(string key, System.Collections.Generic.IEnumerable<string> inputs) { }
        public string Description { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Inputs { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public string SchemaRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowBuiltInTransformationFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>
    {
        public DataflowBuiltInTransformationFilter(System.Collections.Generic.IEnumerable<string> inputs, string expression) { }
        public string Description { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Inputs { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.FilterType? Type { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowBuiltInTransformationMap : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>
    {
        public DataflowBuiltInTransformationMap(System.Collections.Generic.IEnumerable<string> inputs, string output) { }
        public string Description { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Inputs { get { throw null; } }
        public string Output { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowMappingType? Type { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowBuiltInTransformationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>
    {
        public DataflowBuiltInTransformationSettings() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationDataset> Datasets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationFilter> Filter { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationMap> Map { get { throw null; } }
        public string SchemaRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat? SerializationFormat { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowDestinationOperationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>
    {
        public DataflowDestinationOperationSettings(string endpointRef, string dataDestination) { }
        public string DataDestination { get { throw null; } set { } }
        public string EndpointRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointAuthenticationSasl : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>
    {
        public DataflowEndpointAuthenticationSasl(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType saslType, string secretRef) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType SaslType { get { throw null; } set { } }
        public string SecretRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointAuthenticationSaslType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointAuthenticationSaslType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType Plain { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType ScramSha256 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType ScramSha512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSaslType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointAuthenticationUserAssignedManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>
    {
        public DataflowEndpointAuthenticationUserAssignedManagedIdentity(string clientId, string tenantId) { }
        public string ClientId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataExplorer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>
    {
        public DataflowEndpointDataExplorer(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication authentication, string database, string host) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration Batching { get { throw null; } set { } }
        public string Database { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataExplorerAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>
    {
        public DataflowEndpointDataExplorerAuthentication(Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod method) { }
        public Azure.ResourceManager.IoTOperations.Models.DataExplorerAuthMethod Method { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorerAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataLakeStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>
    {
        public DataflowEndpointDataLakeStorage(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication authentication, string host) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration Batching { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointDataLakeStorageAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>
    {
        public DataflowEndpointDataLakeStorageAuthentication(Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod method) { }
        public string AccessTokenSecretRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod Method { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorageAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointFabricOneLake : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>
    {
        public DataflowEndpointFabricOneLake(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication authentication, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames names, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType oneLakePathType, string host) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BatchingConfiguration Batching { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames Names { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType OneLakePathType { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointFabricOneLakeAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>
    {
        public DataflowEndpointFabricOneLakeAuthentication(Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod method) { }
        public Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod Method { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointFabricOneLakeNames : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>
    {
        public DataflowEndpointFabricOneLakeNames(string lakehouseName, string workspaceName) { }
        public string LakehouseName { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLakeNames>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointFabricPathType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointFabricPathType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType Files { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType Tables { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricPathType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointKafka : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>
    {
        public DataflowEndpointKafka(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication authentication, string host) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication Authentication { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching Batching { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType? CloudEventAttributes { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression? Compression { get { throw null; } set { } }
        public string ConsumerGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? CopyMqttProperties { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck? KafkaAcks { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy? PartitionStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.TlsProperties Tls { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointKafkaAck : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointKafkaAck(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck All { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck One { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck Zero { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAck right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointKafkaAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>
    {
        public DataflowEndpointKafkaAuthentication(Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod method) { }
        public Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod Method { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationSasl SaslSettings { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        public string X509CertificateSecretRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointKafkaBatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>
    {
        public DataflowEndpointKafkaBatching() { }
        public int? LatencyMs { get { throw null; } set { } }
        public int? MaxBytes { get { throw null; } set { } }
        public int? MaxMessages { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Mode { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaBatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointKafkaCompression : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointKafkaCompression(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression Gzip { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression Lz4 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression None { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression Snappy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaCompression right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowEndpointKafkaPartitionStrategy : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowEndpointKafkaPartitionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy Default { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy Property { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy Static { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy Topic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy left, Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafkaPartitionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowEndpointMqtt : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>
    {
        public DataflowEndpointMqtt(Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication authentication) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication Authentication { get { throw null; } set { } }
        public string ClientIdPrefix { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.CloudEventAttributeType? CloudEventAttributes { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public int? KeepAliveSeconds { get { throw null; } set { } }
        public int? MaxInflightMessages { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType? Protocol { get { throw null; } set { } }
        public int? Qos { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.MqttRetainType? Retain { get { throw null; } set { } }
        public int? SessionExpirySeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.TlsProperties Tls { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointMqttAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>
    {
        public DataflowEndpointMqttAuthentication(Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod method) { }
        public Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod Method { get { throw null; } set { } }
        public string ServiceAccountTokenAudience { get { throw null; } set { } }
        public string SystemAssignedManagedIdentityAudience { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointAuthenticationUserAssignedManagedIdentity UserAssignedManagedIdentitySettings { get { throw null; } set { } }
        public string X509CertificateSecretRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqttAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>
    {
        public DataflowEndpointProperties(Azure.ResourceManager.IoTOperations.Models.EndpointType endpointType) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataExplorer DataExplorerSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointDataLakeStorage DataLakeStorageSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.EndpointType EndpointType { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointFabricOneLake FabricOneLakeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointKafka KafkaSettings { get { throw null; } set { } }
        public string LocalStoragePersistentVolumeClaimRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowEndpointMqtt MqttSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataflowMappingType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataflowMappingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataflowMappingType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowMappingType BuiltInFunction { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowMappingType Compute { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowMappingType NewProperties { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowMappingType PassThrough { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataflowMappingType Rename { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataflowMappingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataflowMappingType left, Azure.ResourceManager.IoTOperations.Models.DataflowMappingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataflowMappingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataflowMappingType left, Azure.ResourceManager.IoTOperations.Models.DataflowMappingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataflowOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>
    {
        public DataflowOperation(Azure.ResourceManager.IoTOperations.Models.OperationType operationType) { }
        public Azure.ResourceManager.IoTOperations.Models.DataflowBuiltInTransformationSettings BuiltInTransformationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowDestinationOperationSettings DestinationSettings { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationType OperationType { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings SourceSettings { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>
    {
        public DataflowProfileProperties() { }
        public Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics Diagnostics { get { throw null; } set { } }
        public int? InstanceCount { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProfileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>
    {
        public DataflowProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.IoTOperations.Models.DataflowOperation> operations) { }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Mode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.DataflowOperation> Operations { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.DataflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataflowSourceOperationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>
    {
        public DataflowSourceOperationSettings(string endpointRef, System.Collections.Generic.IEnumerable<string> dataSources) { }
        public string AssetRef { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DataSources { get { throw null; } }
        public string EndpointRef { get { throw null; } set { } }
        public string SchemaRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat? SerializationFormat { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DataflowSourceOperationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataLakeStorageAuthMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataLakeStorageAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod AccessToken { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod left, Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod left, Azure.ResourceManager.IoTOperations.Models.DataLakeStorageAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticsLogs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>
    {
        public DiagnosticsLogs() { }
        public string Level { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig OpentelemetryExportConfig { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskBackedMessageBuffer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>
    {
        public DiskBackedMessageBuffer(string maxSize) { }
        public Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec EphemeralVolumeClaimSpec { get { throw null; } set { } }
        public string MaxSize { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec PersistentVolumeClaimSpec { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.DiskBackedMessageBuffer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.EndpointType DataExplorer { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.EndpointType DataLakeStorage { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.EndpointType FabricOneLake { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.EndpointType Kafka { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.EndpointType LocalStorage { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.EndpointType Mqtt { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.EndpointType left, Azure.ResourceManager.IoTOperations.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.EndpointType left, Azure.ResourceManager.IoTOperations.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>
    {
        public ExtendedLocation(string name, Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType type) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType Type { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.ExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType CustomLocation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType left, Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType left, Azure.ResourceManager.IoTOperations.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FabricOneLakeAuthMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FabricOneLakeAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod left, Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod left, Azure.ResourceManager.IoTOperations.Models.FabricOneLakeAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.FilterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.FilterType Filter { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.FilterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.FilterType left, Azure.ResourceManager.IoTOperations.Models.FilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.FilterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.FilterType left, Azure.ResourceManager.IoTOperations.Models.FilterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Frontend : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Frontend>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Frontend>
    {
        public Frontend(int replicas) { }
        public int Replicas { get { throw null; } set { } }
        public int? Workers { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.Frontend System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Frontend>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Frontend>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.Frontend System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Frontend>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Frontend>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Frontend>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>
    {
        public InstanceProperties(string schemaRegistryNamespace) { }
        public Azure.ResourceManager.IoTOperations.Models.Components Components { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaRegistryNamespace { get { throw null; } set { } }
        public string Version { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.InstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.InstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>
    {
        public InstanceResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.InstanceResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KafkaAuthMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KafkaAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod Anonymous { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod Sasl { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod X509Certificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod left, Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod left, Azure.ResourceManager.IoTOperations.Models.KafkaAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>
    {
        public KubernetesReference(string kind, string name) { }
        public string ApiGroup { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.KubernetesReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.KubernetesReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.KubernetesReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListenerPort : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>
    {
        public ListenerPort(int port) { }
        public string AuthenticationRef { get { throw null; } set { } }
        public string AuthorizationRef { get { throw null; } set { } }
        public int? NodePort { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.BrokerProtocolType? Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.TlsCertMethod Tls { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.ListenerPort System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ListenerPort System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ListenerPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalKubernetesReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>
    {
        public LocalKubernetesReference(string kind, string name) { }
        public string ApiGroup { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Metrics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Metrics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Metrics>
    {
        public Metrics() { }
        public Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig OpentelemetryExportConfig { get { throw null; } set { } }
        public int? PrometheusPort { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.Metrics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Metrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Metrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.Metrics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Metrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Metrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Metrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MqttAuthMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MqttAuthMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod Anonymous { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod ServiceAccountToken { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod UserAssignedManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod X509Certificate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod left, Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod left, Azure.ResourceManager.IoTOperations.Models.MqttAuthMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MqttRetainType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.MqttRetainType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MqttRetainType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.MqttRetainType Keep { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.MqttRetainType Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.MqttRetainType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.MqttRetainType left, Azure.ResourceManager.IoTOperations.Models.MqttRetainType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.MqttRetainType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.MqttRetainType left, Azure.ResourceManager.IoTOperations.Models.MqttRetainType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenTelemetryExportConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>
    {
        public OpenTelemetryExportConfig(string otlpGrpcEndpoint) { }
        public int? IntervalSeconds { get { throw null; } set { } }
        public string OtlpGrpcEndpoint { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenTelemetryLogExportConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>
    {
        public OpenTelemetryLogExportConfig(string otlpGrpcEndpoint) { }
        public int? IntervalSeconds { get { throw null; } set { } }
        public string Level { get { throw null; } set { } }
        public string OtlpGrpcEndpoint { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OpenTelemetryLogExportConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Operation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Operation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Operation>
    {
        internal Operation() { }
        public Azure.ResourceManager.IoTOperations.Models.ActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.Origin? Origin { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.Operation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Operation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Operation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.Operation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Operation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Operation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Operation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationalMode : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.OperationalMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationalMode(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.OperationalMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.OperationalMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.OperationalMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.OperationalMode left, Azure.ResourceManager.IoTOperations.Models.OperationalMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.OperationalMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.OperationalMode left, Azure.ResourceManager.IoTOperations.Models.OperationalMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.OperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.OperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.OperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.OperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.OperationType BuiltInTransformation { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.OperationType Destination { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.OperationType Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.OperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.OperationType left, Azure.ResourceManager.IoTOperations.Models.OperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.OperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.OperationType left, Azure.ResourceManager.IoTOperations.Models.OperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorValue : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.OperatorValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorValue(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.OperatorValue DoesNotExist { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.OperatorValue Exists { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.OperatorValue In { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.OperatorValue NotIn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.OperatorValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.OperatorValue left, Azure.ResourceManager.IoTOperations.Models.OperatorValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.OperatorValue (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.OperatorValue left, Azure.ResourceManager.IoTOperations.Models.OperatorValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Origin : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.Origin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Origin(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.Origin System { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.Origin User { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.Origin UserSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.Origin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.Origin left, Azure.ResourceManager.IoTOperations.Models.Origin right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.Origin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.Origin left, Azure.ResourceManager.IoTOperations.Models.Origin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrincipalDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>
    {
        public PrincipalDefinition() { }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, string>> Attributes { get { throw null; } }
        public System.Collections.Generic.IList<string> ClientIds { get { throw null; } }
        public System.Collections.Generic.IList<string> Usernames { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.PrincipalDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateKeyAlgorithm : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateKeyAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Ec256 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Ec384 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Ec521 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Ed25519 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Rsa2048 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Rsa4096 { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm Rsa8192 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm left, Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm left, Azure.ResourceManager.IoTOperations.Models.PrivateKeyAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateKeyRotationPolicy : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateKeyRotationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy left, Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy left, Azure.ResourceManager.IoTOperations.Models.PrivateKeyRotationPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfileDiagnostics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>
    {
        public ProfileDiagnostics() { }
        public Azure.ResourceManager.IoTOperations.Models.DiagnosticsLogs Logs { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.Metrics Metrics { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.ProfileDiagnostics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ProvisioningState left, Azure.ResourceManager.IoTOperations.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ProvisioningState left, Azure.ResourceManager.IoTOperations.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SanForCert : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>
    {
        public SanForCert(System.Collections.Generic.IEnumerable<string> dns, System.Collections.Generic.IEnumerable<string> ip) { }
        public System.Collections.Generic.IList<string> Dns { get { throw null; } }
        public System.Collections.Generic.IList<string> IP { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.SanForCert System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.SanForCert System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SanForCert>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>
    {
        public SelfCheck() { }
        public int? IntervalSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Mode { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.SelfCheck System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.SelfCheck System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SelfTracing : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>
    {
        public SelfTracing() { }
        public int? IntervalSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Mode { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.SelfTracing System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.SelfTracing System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SelfTracing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.ServiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.ServiceType ClusterIP { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ServiceType LoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.ServiceType NodePort { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.ServiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.ServiceType left, Azure.ResourceManager.IoTOperations.Models.ServiceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.ServiceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.ServiceType left, Azure.ResourceManager.IoTOperations.Models.ServiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceSerializationFormat : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceSerializationFormat(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat Json { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat left, Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat left, Azure.ResourceManager.IoTOperations.Models.SourceSerializationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StateStoreResourceDefinitionMethod : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StateStoreResourceDefinitionMethod(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod Read { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod left, Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod left, Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StateStoreResourceKeyType : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StateStoreResourceKeyType(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType Binary { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType Pattern { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType left, Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType left, Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StateStoreResourceRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>
    {
        public StateStoreResourceRule(Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType keyType, System.Collections.Generic.IEnumerable<string> keys, Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod method) { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.StateStoreResourceKeyType KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.StateStoreResourceDefinitionMethod Method { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.StateStoreResourceRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriberMessageDropStrategy : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriberMessageDropStrategy(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy DropOldest { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy left, Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy left, Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriberQueueLimit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>
    {
        public SubscriberQueueLimit() { }
        public long? Length { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.SubscriberMessageDropStrategy? Strategy { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.SubscriberQueueLimit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsCertMethod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>
    {
        public TlsCertMethod(Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode mode) { }
        public Azure.ResourceManager.IoTOperations.Models.CertManagerCertificateSpec CertManagerCertificateSpec { get { throw null; } set { } }
        public string ManualSecretRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode Mode { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.TlsCertMethod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.TlsCertMethod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsCertMethod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsCertMethodMode : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsCertMethodMode(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode left, Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode left, Azure.ResourceManager.IoTOperations.Models.TlsCertMethodMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TlsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>
    {
        public TlsProperties() { }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Mode { get { throw null; } set { } }
        public string TrustedCaCertificateConfigMapRef { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.TlsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.TlsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.TlsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Traces : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Traces>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Traces>
    {
        public Traces() { }
        public int? CacheSizeMegabytes { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperationalMode? Mode { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OpenTelemetryExportConfig OpentelemetryExportConfig { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.SelfTracing SelfTracing { get { throw null; } set { } }
        public int? SpanChannelCapacity { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.Traces System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Traces>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.Traces>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.Traces System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Traces>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Traces>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.Traces>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransformationSerializationFormat : System.IEquatable<Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransformationSerializationFormat(string value) { throw null; }
        public static Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat Delta { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat Json { get { throw null; } }
        public static Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat Parquet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat left, Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat left, Azure.ResourceManager.IoTOperations.Models.TransformationSerializationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeClaimResourceRequirements : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>
    {
        public VolumeClaimResourceRequirements() { }
        public System.Collections.Generic.IDictionary<string, string> Limits { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Requests { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeClaimSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>
    {
        public VolumeClaimSpec() { }
        public System.Collections.Generic.IList<string> AccessModes { get { throw null; } }
        public Azure.ResourceManager.IoTOperations.Models.LocalKubernetesReference DataSource { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.KubernetesReference DataSourceRef { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.VolumeClaimResourceRequirements Resources { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector Selector { get { throw null; } set { } }
        public string StorageClassName { get { throw null; } set { } }
        public string VolumeMode { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeClaimSpecSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>
    {
        public VolumeClaimSpecSelector() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions> MatchExpressions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> MatchLabels { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeClaimSpecSelectorMatchExpressions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>
    {
        public VolumeClaimSpecSelectorMatchExpressions(string key, Azure.ResourceManager.IoTOperations.Models.OperatorValue @operator) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.IoTOperations.Models.OperatorValue Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.IoTOperations.Models.VolumeClaimSpecSelectorMatchExpressions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
