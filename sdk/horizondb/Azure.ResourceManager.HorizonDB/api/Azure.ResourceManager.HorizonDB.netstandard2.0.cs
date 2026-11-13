namespace Azure.ResourceManager.HorizonDB
{
    public partial class AzureResourceManagerHorizonDBContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHorizonDBContext() { }
        public static Azure.ResourceManager.HorizonDB.AzureResourceManagerHorizonDBContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>
    {
        public ChangeDataCaptureCapabilityData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureCapabilityResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>, System.Collections.IEnumerable
    {
        protected ChangeDataCaptureConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>
    {
        public ChangeDataCaptureConfigurationData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureConfigurationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChangeDataCaptureDestinationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>, System.Collections.IEnumerable
    {
        protected ChangeDataCaptureDestinationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string destinationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string destinationName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> Get(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetIfExists(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetIfExistsAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChangeDataCaptureDestinationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>
    {
        public ChangeDataCaptureDestinationData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureDestinationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureDestinationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult> ActivateIdentity(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>> ActivateIdentityAsync(Azure.WaitUntil waitUntil, string ifMatch, Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string destinationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> GetChangeDataCaptureIdentityAssignment(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>> GetChangeDataCaptureIdentityAssignmentAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentCollection GetChangeDataCaptureIdentityAssignments() { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChangeDataCaptureIdentityAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>, System.Collections.IEnumerable
    {
        protected ChangeDataCaptureIdentityAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> Get(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>> GetAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> GetIfExists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>> GetIfExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChangeDataCaptureIdentityAssignmentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>
    {
        public ChangeDataCaptureIdentityAssignmentData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureIdentityAssignmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChangeDataCaptureIdentityAssignmentResource() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string destinationName, string assignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBCapabilityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>
    {
        internal HorizonDBCapabilityData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBCapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBCapabilityResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>, System.Collections.IEnumerable
    {
        protected HorizonDBClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDBClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterName, Azure.ResourceManager.HorizonDB.HorizonDBClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Get(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetIfExists(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetIfExistsAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>
    {
        public HorizonDBClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBClusterResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource GetChangeDataCaptureCapability() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource> GetChangeDataCaptureConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource>> GetChangeDataCaptureConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationCollection GetChangeDataCaptureConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource> GetChangeDataCaptureDestination(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource>> GetChangeDataCaptureDestinationAsync(string destinationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationCollection GetChangeDataCaptureDestinations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> GetHorizonDBEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>> GetHorizonDBEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBEndpointCollection GetHorizonDBEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> GetHorizonDBLogCaptureConfiguration(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>> GetHorizonDBLogCaptureConfigurationAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationCollection GetHorizonDBLogCaptureConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> GetHorizonDBLogFile(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>> GetHorizonDBLogFileAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBLogFileCollection GetHorizonDBLogFiles() { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource GetHorizonDBPasswordAuthentication() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetHorizonDBPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetHorizonDBPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolCollection GetHorizonDBPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetHorizonDBPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetHorizonDBPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionCollection GetHorizonDBPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetHorizonDBPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetHorizonDBPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceCollection GetHorizonDBPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetMicrosoftEntraAdministrator(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetMicrosoftEntraAdministratorAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorCollection GetMicrosoftEntraAdministrators() { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource GetMicrosoftEntraAuthentication() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBDefaultParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>, System.Collections.IEnumerable
    {
        protected HorizonDBDefaultParameterGroupCollection() { }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBDefaultParameterGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>
    {
        internal HorizonDBDefaultParameterGroupData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBDefaultParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBDefaultParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>, System.Collections.IEnumerable
    {
        protected HorizonDBEndpointCollection() { }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>
    {
        internal HorizonDBEndpointData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBEndpointResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string endpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HorizonDBExtensions
    {
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource GetChangeDataCaptureCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource GetChangeDataCaptureConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource GetChangeDataCaptureDestinationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource GetChangeDataCaptureIdentityAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource GetHorizonDBCapability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource GetHorizonDBCapability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource GetHorizonDBCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetHorizonDBClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterResource GetHorizonDBClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterCollection GetHorizonDBClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> GetHorizonDBDefaultParameterGroup(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>> GetHorizonDBDefaultParameterGroupAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource GetHorizonDBDefaultParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupCollection GetHorizonDBDefaultParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource GetHorizonDBEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource GetHorizonDBFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource GetHorizonDBLogCaptureConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource GetHorizonDBLogFileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource GetHorizonDBMaintenanceEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBNodeResource GetHorizonDBNodeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetHorizonDBParameterGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource GetHorizonDBParameterGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupCollection GetHorizonDBParameterGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource GetHorizonDBPasswordAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPoolResource GetHorizonDBPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource GetHorizonDBPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource GetHorizonDBPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource GetMicrosoftEntraAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource GetMicrosoftEntraAuthenticationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HorizonDBFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected HorizonDBFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>
    {
        public HorizonDBFirewallRuleData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBFirewallRuleResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBLogCaptureConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>, System.Collections.IEnumerable
    {
        protected HorizonDBLogCaptureConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> Get(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>> GetAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> GetIfExists(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>> GetIfExistsAsync(string logCaptureConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBLogCaptureConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>
    {
        internal HorizonDBLogCaptureConfigurationData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBLogCaptureConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBLogCaptureConfigurationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string logCaptureConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBLogFileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>, System.Collections.IEnumerable
    {
        protected HorizonDBLogFileCollection() { }
        public virtual Azure.Response<bool> Exists(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> Get(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>> GetAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> GetIfExists(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>> GetIfExistsAsync(string logFileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBLogFileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>
    {
        internal HorizonDBLogFileData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBLogFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBLogFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBLogFileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBLogFileResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBLogFileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string logFileName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri> GetDownloadUrls(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>> GetDownloadUrlsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBLogFileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBLogFileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBLogFileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBMaintenanceEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>, System.Collections.IEnumerable
    {
        protected HorizonDBMaintenanceEventCollection() { }
        public virtual Azure.Response<bool> Exists(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> Get(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>> GetAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> GetIfExists(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>> GetIfExistsAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBMaintenanceEventData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>
    {
        internal HorizonDBMaintenanceEventData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBMaintenanceEventResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBMaintenanceEventResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult> ApplyNow(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>> ApplyNowAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string maintenanceEventId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult> Reschedule(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>> RescheduleAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBNodeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>, System.Collections.IEnumerable
    {
        protected HorizonDBNodeCollection() { }
        public virtual Azure.Response<bool> Exists(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> Get(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>> GetAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> GetIfExists(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>> GetIfExistsAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBNodeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>
    {
        internal HorizonDBNodeData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBNodeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBNodeResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBNodeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName, string nodeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBNodeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBNodeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBNodeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>, System.Collections.IEnumerable
    {
        protected HorizonDBParameterGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string parameterGroupName, Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Get(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetIfExists(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetIfExistsAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBParameterGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>
    {
        public HorizonDBParameterGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBParameterGroupResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string parameterGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties> GetConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties> GetConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPasswordAuthenticationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>
    {
        public HorizonDBPasswordAuthenticationData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPasswordAuthenticationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPasswordAuthenticationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.HorizonDB.HorizonDBPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.HorizonDB.HorizonDBPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPoolData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>
    {
        public HorizonDBPoolData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPoolResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource> GetHorizonDBFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource>> GetHorizonDBFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleCollection GetHorizonDBFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource> GetHorizonDBMaintenanceEvent(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource>> GetHorizonDBMaintenanceEventAsync(string maintenanceEventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventCollection GetHorizonDBMaintenanceEvents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource> GetHorizonDBNode(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBNodeResource>> GetHorizonDBNodeAsync(string nodeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBNodeCollection GetHorizonDBNodes() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>
    {
        public HorizonDBPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HorizonDBPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HorizonDBPrivateLinkResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected HorizonDBPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>
    {
        internal HorizonDBPrivateLinkResourceData() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>, System.Collections.IEnumerable
    {
        protected MicrosoftEntraAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> Get(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> GetIfExists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetIfExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MicrosoftEntraAdministratorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>
    {
        internal MicrosoftEntraAdministratorData() { }
        public Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MicrosoftEntraAdministratorResource() { }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName, string objectId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>
    {
        public MicrosoftEntraAuthenticationData() { }
        public Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MicrosoftEntraAuthenticationResource() { }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Mocking
{
    public partial class MockableHorizonDBArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBArmClient() { }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityResource GetChangeDataCaptureCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationResource GetChangeDataCaptureConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationResource GetChangeDataCaptureDestinationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentResource GetChangeDataCaptureIdentityAssignmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource GetHorizonDBCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterResource GetHorizonDBClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource GetHorizonDBDefaultParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBEndpointResource GetHorizonDBEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleResource GetHorizonDBFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationResource GetHorizonDBLogCaptureConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBLogFileResource GetHorizonDBLogFileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventResource GetHorizonDBMaintenanceEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBNodeResource GetHorizonDBNodeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource GetHorizonDBParameterGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationResource GetHorizonDBPasswordAuthenticationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPoolResource GetHorizonDBPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionResource GetHorizonDBPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResource GetHorizonDBPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorResource GetMicrosoftEntraAdministratorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationResource GetMicrosoftEntraAuthenticationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHorizonDBResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBCluster(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource>> GetHorizonDBClusterAsync(string clusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBClusterCollection GetHorizonDBClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroup(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource>> GetHorizonDBParameterGroupAsync(string parameterGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupCollection GetHorizonDBParameterGroups() { throw null; }
    }
    public partial class MockableHorizonDBSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHorizonDBSubscriptionResource() { }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource GetHorizonDBCapability() { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBCapabilityResource GetHorizonDBCapability(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClusters(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBClusterResource> GetHorizonDBClustersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource> GetHorizonDBDefaultParameterGroup(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupResource>> GetHorizonDBDefaultParameterGroupAsync(Azure.Core.AzureLocation location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupCollection GetHorizonDBDefaultParameterGroups(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupResource> GetHorizonDBParameterGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HorizonDB.Models
{
    public partial class ActivateChangeDataCaptureIdentityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>
    {
        internal ActivateChangeDataCaptureIdentityResult() { }
        public Azure.Core.ResourceIdentifier PreviousIdentityAssignmentResourceId { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetIdentityAssignmentResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AiModelManagementStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AiModelManagementStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus left, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus left, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHorizonDBModelFactory
    {
        public static Azure.ResourceManager.HorizonDB.Models.ActivateChangeDataCaptureIdentityResult ActivateChangeDataCaptureIdentityResult(Azure.Core.ResourceIdentifier targetIdentityAssignmentResourceId = null, Azure.Core.ResourceIdentifier previousIdentityAssignmentResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureCapabilityData ChangeDataCaptureCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch ChangeDataCaptureCapabilityPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties ChangeDataCaptureCapabilityProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), bool? isAutoUpgradeExtensionEnabled = default(bool?), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture replicationArchitecture = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus extension = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus prerequisites = null, int destinationCount = 0, int configurationCount = 0, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch ChangeDataCaptureCapabilityPropertiesPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState?), bool? isAutoUpgradeExtensionEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureConfigurationData ChangeDataCaptureConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch ChangeDataCaptureConfigurationPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties ChangeDataCaptureConfigurationProperties(string databaseName = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile usageProfile = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile), Azure.Core.ResourceIdentifier destinationResourceId = null, string logicalStreamId = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus extension = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus replication = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus topology = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureDestinationData ChangeDataCaptureDestinationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails ChangeDataCaptureDestinationDetails(string destinationType = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol protocol = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch ChangeDataCaptureDestinationPatch(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties ChangeDataCaptureDestinationProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails destination = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.Core.ResourceIdentifier activeIdentityAssignmentResourceId = null, int configurationCount = 0, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus ChangeDataCaptureExtensionStatus(string name = null, string version = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.ChangeDataCaptureIdentityAssignmentData ChangeDataCaptureIdentityAssignmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties ChangeDataCaptureIdentityAssignmentProperties(Azure.Core.ResourceIdentifier identityResourceId = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState effectiveState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState activationState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState), System.Guid principalId = default(System.Guid), System.Guid tenantId = default(System.Guid), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus validation = null, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus status = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus ChangeDataCaptureIdentityValidationStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState), System.DateTimeOffset? validatedOn = default(System.DateTimeOffset?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus ChangeDataCapturePrerequisiteStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState engineConfigurationState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState), Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState readWriteEndpointState = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus ChangeDataCaptureReplicationStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState), string externalArtifactId = null, System.DateTimeOffset? lastConnectedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus ChangeDataCaptureStatus(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus ChangeDataCaptureTopologyBindingStatus(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState state = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState), long generation = (long)0, Azure.Core.ResourceIdentifier activeClusterResourceId = null, Azure.Core.ResourceIdentifier replacementConfigurationResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails FabricDestinationDetails(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol protocol = default(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol), string workspaceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent HorizonDBActivateChangeDataCaptureIdentityContent(Azure.Core.ResourceIdentifier identityAssignmentResourceId = null, bool? shouldDrainExistingSessions = default(bool?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication HorizonDBAuthentication(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties HorizonDBAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBCapabilityData HorizonDBCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties HorizonDBCapabilityProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability clusterCapabilities = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability poolCapabilities = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties HorizonDBClusterBackupProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState geoRedundancy = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState), int? retentionDays = default(int?), System.DateTimeOffset? earliestRestorePointOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability HorizonDBClusterCapability(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion recommendedPostgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability> supportedPostgreSqlVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability> supportedFeatures = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBClusterData HorizonDBClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties properties = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption HorizonDBClusterDataEncryption(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? type = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType?), System.Uri primaryKeyUri = null, Azure.Core.ResourceIdentifier primaryUserAssignedIdentityId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus? primaryEncryptionKeyStatus = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus?), string primaryEncryptionKeyCurrentVersion = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch HorizonDBClusterDataEncryptionPatch(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? type = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType?), System.Uri primaryKeyUri = null, Azure.Core.ResourceIdentifier primaryUserAssignedIdentityId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability HorizonDBClusterFeatureCapability(string name = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity HorizonDBClusterManagedServiceIdentity(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType type = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch HorizonDBClusterPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity identity = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties HorizonDBClusterPatchProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? networkPublicAccess = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState?), int? backupRetentionDays = default(int?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch dataEncryption = null, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? aiModelManagement = default(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties HorizonDBClusterProperties(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion? postgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode? creationMode = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode?), System.DateTimeOffset? pointInTimeOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier creationSourceClusterResourceId = null, string creationSourceClusterLocation = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? networkPublicAccess = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties backup = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption dataEncryption = null, Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? aiModelManagement = default(Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus?), Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState), Azure.Core.ResourceIdentifier designatedPoolResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability HorizonDBComputeGenerationCapability(int computeGeneration = 0, Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType recommendedComputeModelType = default(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability> supportedComputeModels = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability HorizonDBComputeModelCapability(string type = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability HorizonDBComputeProcessorCapability(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType name = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability> supportedGenerations = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability HorizonDBComputeSizeCapability(int vCores = 0, long memoryPerVCoreInMb = (long)0) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBDefaultParameterGroupData HorizonDBDefaultParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties HorizonDBDefaultParameterGroupProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion postgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBEndpointData HorizonDBEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties HorizonDBEndpointProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope scope = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope), Azure.Core.ResourceIdentifier associatedResourceId = null, string fullyQualifiedDomainName = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole role = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBFirewallRuleData HorizonDBFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties HorizonDBFirewallRuleProperties(string startIPAddress = null, string endIPAddress = null, string description = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBLogCaptureConfigurationData HorizonDBLogCaptureConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch HorizonDBLogCaptureConfigurationPatch(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties HorizonDBLogCaptureConfigurationPatchProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState?), int? retentionDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties HorizonDBLogCaptureConfigurationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState), int retentionDays = 0, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBLogFileData HorizonDBLogFileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties HorizonDBLogFileProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType logType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastModifiedOn = default(System.DateTimeOffset), System.DateTimeOffset retentionExpiresOn = default(System.DateTimeOffset), bool isMutable = false, long sizeInKilobytes = (long)0, string pool = null, string node = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole role = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult HorizonDBMaintenanceEventActionResult(string maintenanceEventId = null, Azure.Core.ResourceIdentifier poolResourceId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus? status = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus?), System.DateTimeOffset? plannedStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? plannedEndsOn = default(System.DateTimeOffset?), bool? isAppliedNow = default(bool?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBMaintenanceEventData HorizonDBMaintenanceEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties HorizonDBMaintenanceEventProperties(string maintenanceEventId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType maintenanceType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType), string description = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus status = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus), System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset endsOn = default(System.DateTimeOffset), System.TimeSpan? estimatedDowntime = default(System.TimeSpan?), bool isDeferrable = false, System.DateTimeOffset? deferralDeadlineOn = default(System.DateTimeOffset?), System.DateTimeOffset? rescheduledFromOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset originalStartsOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent HorizonDBMaintenanceEventRescheduleContent(System.DateTimeOffset scheduledStartsOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBNodeData HorizonDBNodeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties HorizonDBNodeProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole role = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole), string availabilityZone = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties HorizonDBParameterGroupConnectionProperties(Azure.Core.ResourceIdentifier poolResourceId = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBParameterGroupData HorizonDBParameterGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch HorizonDBParameterGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties HorizonDBParameterGroupPatchProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties HorizonDBParameterGroupProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> parameters = null, string description = null, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion postgreSqlVersion = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties HorizonDBParameterProperties(string name = null, string description = null, string value = null, string defaultValue = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource? valueSource = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource?), string dataType = null, string allowedValues = null, bool? isDynamic = default(bool?), bool? isReadOnly = default(bool?), System.Uri documentationLink = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPasswordAuthenticationData HorizonDBPasswordAuthenticationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch HorizonDBPasswordAuthenticationPatch(Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties HorizonDBPasswordAuthenticationPatchProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState?), string administratorLoginPassword = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties HorizonDBPasswordAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState), string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability HorizonDBPoolCapability(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType recommendedComputeProcessor = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability> supportedProcessors = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability> supportedFeatures = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch HorizonDBPoolComputeModelPatch(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType? type = default(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType?), Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType? computeProcessor = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType?), int? computeGeneration = default(int?), int? vCores = default(int?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPoolData HorizonDBPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability HorizonDBPoolFeatureCapability(string name = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch HorizonDBPoolPatch(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties HorizonDBPoolPatchProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch computeModel = null, int? nodeCount = default(int?), Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode? highAvailabilityMode = default(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode?), Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch parameterGroup = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType? maintenanceManagementType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties HorizonDBPoolProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState?), Azure.ResourceManager.HorizonDB.Models.PoolComputeModel computeModel = null, int nodeCount = 0, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode highAvailabilityMode = default(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode), Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference parameterGroup = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties scheduledMaintenance = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateEndpointConnectionData HorizonDBPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties HorizonDBPrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.HorizonDBPrivateLinkResourceData HorizonDBPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties HorizonDBPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState HorizonDBPrivateLinkServiceConnectionState(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability HorizonDBProvisionedComputeModelCapability(int recommendedVCoreCount = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability> supportedComputeSizes = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties HorizonDBScheduledMaintenanceProperties(string maintenanceManagementType = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties HorizonDBSystemScheduledMaintenanceProperties() { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri LogFileDownloadUri(System.Uri downloadUri = null, System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent MicrosoftEntraAdministratorContent(Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAdministratorData MicrosoftEntraAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties MicrosoftEntraAdministratorProperties(string principalName = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType principalType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType), System.Guid? objectId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd MicrosoftEntraAdministratorPropertiesForAdd(string principalName = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType principalType = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.MicrosoftEntraAuthenticationData MicrosoftEntraAuthenticationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch MicrosoftEntraAuthenticationPatch(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties MicrosoftEntraAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState), Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? provisioningState = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolComputeModel PoolComputeModel(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType type = default(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType), Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType computeProcessor = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType), int computeGeneration = 0, int vCores = 0) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference PoolParameterGroupReference(Azure.Core.ResourceIdentifier parameterGroupResourceId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod applyMethod = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod), Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus? syncStatus = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch PoolParameterGroupReferencePatch(Azure.Core.ResourceIdentifier parameterGroupResourceId = null, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod? applyMethod = default(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod?)) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability PostgreSqlVersionCapability(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion name = default(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion> supportedVersionsToUpgrade = null) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>
    {
        public ChangeDataCaptureCapabilityPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>
    {
        public ChangeDataCaptureCapabilityProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState) { }
        public int ConfigurationCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState DesiredState { get { throw null; } set { } }
        public int DestinationCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState EffectiveState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus Extension { get { throw null; } }
        public bool? IsAutoUpgradeExtensionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus Prerequisites { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture ReplicationArchitecture { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureCapabilityPropertiesPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>
    {
        public ChangeDataCaptureCapabilityPropertiesPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? DesiredState { get { throw null; } set { } }
        public bool? IsAutoUpgradeExtensionEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureCapabilityPropertiesPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>
    {
        public ChangeDataCaptureConfigurationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? DesiredState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>
    {
        public ChangeDataCaptureConfigurationProperties(string databaseName, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile usageProfile, Azure.Core.ResourceIdentifier destinationResourceId, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState) { }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState DesiredState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DestinationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState EffectiveState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus Extension { get { throw null; } }
        public string LogicalStreamId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus Replication { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus Topology { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile UsageProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureDesiredState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureDesiredState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ChangeDataCaptureDestinationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>
    {
        internal ChangeDataCaptureDestinationDetails() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureDestinationEffectiveState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureDestinationEffectiveState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Degraded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Disabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Enabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Enabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState WaitingForIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureDestinationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>
    {
        public ChangeDataCaptureDestinationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState? DesiredState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureDestinationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>
    {
        public ChangeDataCaptureDestinationProperties(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails destination, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState desiredState) { }
        public Azure.Core.ResourceIdentifier ActiveIdentityAssignmentResourceId { get { throw null; } }
        public int ConfigurationCount { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDesiredState DesiredState { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails Destination { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationEffectiveState EffectiveState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureEffectiveState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureEffectiveState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Degraded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Disabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Enabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Enabling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState Failed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEffectiveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureEngineConfigurationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureEngineConfigurationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState NotReady { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState Reconciling { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureExtensionState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureExtensionState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Installing { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState NotInstalled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Removing { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>
    {
        internal ChangeDataCaptureExtensionStatus() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionState State { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureIdentityActivationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureIdentityActivationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Activating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Active { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Deactivating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureIdentityAssignmentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>
    {
        public ChangeDataCaptureIdentityAssignmentProperties(Azure.Core.ResourceIdentifier identityResourceId) { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityActivationState ActivationState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState EffectiveState { get { throw null; } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public System.Guid PrincipalId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus Status { get { throw null; } }
        public System.Guid TenantId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus Validation { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureIdentityAssignmentState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureIdentityAssignmentState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Assigned { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Assigning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState Removing { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityAssignmentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureIdentityValidationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureIdentityValidationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState Running { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureIdentityValidationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>
    {
        internal ChangeDataCaptureIdentityValidationStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationState State { get { throw null; } }
        public System.DateTimeOffset? ValidatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureIdentityValidationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCapturePrerequisiteStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>
    {
        internal ChangeDataCapturePrerequisiteStatus() { }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureEngineConfigurationState EngineConfigurationState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState ReadWriteEndpointState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCapturePrerequisiteStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureProtocol : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureProtocol(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol Native { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureReadWriteEndpointState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureReadWriteEndpointState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReadWriteEndpointState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureReplicationArchitecture : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureReplicationArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture ComputeBased { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture Hybrid { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture StorageBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureReplicationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Connecting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Degraded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState NotConnected { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Paused { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Reconnecting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Replicating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>
    {
        internal ChangeDataCaptureReplicationStatus() { }
        public string ExternalArtifactId { get { throw null; } }
        public System.DateTimeOffset? LastConnectedOn { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChangeDataCaptureStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>
    {
        internal ChangeDataCaptureStatus() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureTopologyBindingState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureTopologyBindingState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Active { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Conflict { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState RebindRequired { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Reconciling { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState Superseded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeDataCaptureTopologyBindingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>
    {
        internal ChangeDataCaptureTopologyBindingStatus() { }
        public Azure.Core.ResourceIdentifier ActiveClusterResourceId { get { throw null; } }
        public long Generation { get { throw null; } }
        public Azure.Core.ResourceIdentifier ReplacementConfigurationResourceId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureTopologyBindingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeDataCaptureUsageProfile : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeDataCaptureUsageProfile(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile Mirroring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile left, Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureUsageProfile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FabricDestinationDetails : Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>
    {
        public FabricDestinationDetails(Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureProtocol protocol, string workspaceId) { }
        public string WorkspaceId { get { throw null; } set { } }
        protected override Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HorizonDB.Models.ChangeDataCaptureDestinationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.FabricDestinationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBActivateChangeDataCaptureIdentityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>
    {
        public HorizonDBActivateChangeDataCaptureIdentityContent(Azure.Core.ResourceIdentifier identityAssignmentResourceId) { }
        public Azure.Core.ResourceIdentifier IdentityAssignmentResourceId { get { throw null; } }
        public bool? ShouldDrainExistingSessions { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBActivateChangeDataCaptureIdentityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBAuthentication : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>
    {
        internal HorizonDBAuthentication() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>
    {
        internal HorizonDBAuthenticationProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBAuthenticationState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBAuthenticationState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBCapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>
    {
        internal HorizonDBCapabilityProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability ClusterCapabilities { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability PoolCapabilities { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBCapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterBackupGeoRedundancyState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterBackupGeoRedundancyState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBClusterBackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>
    {
        public HorizonDBClusterBackupProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState geoRedundancy) { }
        public System.DateTimeOffset? EarliestRestorePointOn { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupGeoRedundancyState GeoRedundancy { get { throw null; } set { } }
        public int? RetentionDays { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>
    {
        internal HorizonDBClusterCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion RecommendedPostgreSqlVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability> SupportedPostgreSqlVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterCreateMode : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode Create { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode PointInTimeRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBClusterDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>
    {
        public HorizonDBClusterDataEncryption() { }
        public string PrimaryEncryptionKeyCurrentVersion { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus? PrimaryEncryptionKeyStatus { get { throw null; } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterDataEncryptionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>
    {
        public HorizonDBClusterDataEncryptionPatch() { }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterDataEncryptionType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterDataEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType SystemManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterEncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterEncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterEncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBClusterFeatureCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>
    {
        internal HorizonDBClusterFeatureCapability() { }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterFeatureCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterIdentityType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBClusterManagedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>
    {
        public HorizonDBClusterManagedServiceIdentity(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType type) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>
    {
        public HorizonDBClusterPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>
    {
        public HorizonDBClusterPatchProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? AiModelManagement { get { throw null; } set { } }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryptionPatch DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? NetworkPublicAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>
    {
        public HorizonDBClusterProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.AiModelManagementStatus? AiModelManagement { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterCreateMode? CreationMode { get { throw null; } set { } }
        public string CreationSourceClusterLocation { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier CreationSourceClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DesignatedPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? NetworkPublicAccess { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeOn { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion? PostgreSqlVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBClusterState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBClusterState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBClusterState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBComputeGenerationCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>
    {
        internal HorizonDBComputeGenerationCapability() { }
        public int ComputeGeneration { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType RecommendedComputeModelType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability> SupportedComputeModels { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class HorizonDBComputeModelCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>
    {
        internal HorizonDBComputeModelCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType Type { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBComputeProcessorCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>
    {
        internal HorizonDBComputeProcessorCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeGenerationCapability> SupportedGenerations { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBComputeProcessorType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBComputeProcessorType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType AMD { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType Intel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBComputeSizeCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>
    {
        internal HorizonDBComputeSizeCapability() { }
        public long MemoryPerVCoreInMb { get { throw null; } }
        public int VCores { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBDefaultParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>
    {
        internal HorizonDBDefaultParameterGroupProperties() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion PostgreSqlVersion { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBDefaultParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>
    {
        internal HorizonDBEndpointProperties() { }
        public Azure.Core.ResourceIdentifier AssociatedResourceId { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole Role { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope Scope { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBEndpointRole : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBEndpointRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole left, Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole left, Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBEndpointScope : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBEndpointScope(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope Cluster { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope Pool { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope left, Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope left, Azure.ResourceManager.HorizonDB.Models.HorizonDBEndpointScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBFirewallRuleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>
    {
        public HorizonDBFirewallRuleProperties(string startIPAddress, string endIPAddress) { }
        public string Description { get { throw null; } set { } }
        public string EndIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public string StartIPAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBFirewallRuleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBLogCaptureConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>
    {
        public HorizonDBLogCaptureConfigurationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBLogCaptureConfigurationPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>
    {
        public HorizonDBLogCaptureConfigurationPatchProperties() { }
        public int? RetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBLogCaptureConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>
    {
        internal HorizonDBLogCaptureConfigurationProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public int RetentionDays { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBLogCaptureState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBLogCaptureState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogCaptureState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBLogFileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>
    {
        internal HorizonDBLogFileProperties() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public bool IsMutable { get { throw null; } }
        public System.DateTimeOffset LastModifiedOn { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType LogType { get { throw null; } }
        public string Node { get { throw null; } }
        public string Pool { get { throw null; } }
        public System.DateTimeOffset RetentionExpiresOn { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole Role { get { throw null; } }
        public long SizeInKilobytes { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBLogFileType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBLogFileType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType PostgreSqlServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBLogFileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBMaintenanceEventActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>
    {
        internal HorizonDBMaintenanceEventActionResult() { }
        public bool? IsAppliedNow { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string MaintenanceEventId { get { throw null; } }
        public System.DateTimeOffset? PlannedEndsOn { get { throw null; } }
        public System.DateTimeOffset? PlannedStartsOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier PoolResourceId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBMaintenanceEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>
    {
        internal HorizonDBMaintenanceEventProperties() { }
        public System.DateTimeOffset? DeferralDeadlineOn { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset EndsOn { get { throw null; } }
        public System.TimeSpan? EstimatedDowntime { get { throw null; } }
        public bool IsDeferrable { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string MaintenanceEventId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType MaintenanceType { get { throw null; } }
        public System.DateTimeOffset OriginalStartsOn { get { throw null; } }
        public System.DateTimeOffset? RescheduledFromOn { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBMaintenanceEventRescheduleContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>
    {
        public HorizonDBMaintenanceEventRescheduleContent(System.DateTimeOffset scheduledStartsOn) { }
        public System.DateTimeOffset ScheduledStartsOn { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventRescheduleContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBMaintenanceEventStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBMaintenanceEventStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus Planned { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus Rescheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceEventStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBMaintenanceType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBMaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType PlannedMaintenance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBMaintenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBNodeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>
    {
        internal HorizonDBNodeProperties() { }
        public string AvailabilityZone { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole Role { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBNodeRole : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBNodeRole(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole ReadWrite { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole Unassigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole left, Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole left, Azure.ResourceManager.HorizonDB.Models.HorizonDBNodeRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBParameterApplyMethod : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBParameterApplyMethod(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod Immediate { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod PendingReboot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod left, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod left, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBParameterGroupConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>
    {
        internal HorizonDBParameterGroupConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PoolResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>
    {
        public HorizonDBParameterGroupPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>
    {
        public HorizonDBParameterGroupPatchProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBParameterGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>
    {
        public HorizonDBParameterGroupProperties(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion postgreSqlVersion) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties> Parameters { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion PostgreSqlVersion { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBParameterGroupSyncStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBParameterGroupSyncStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus Applying { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus FailedToApply { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus InSync { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus PendingReboot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBParameterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>
    {
        public HorizonDBParameterProperties() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Uri DocumentationLink { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Unit { get { throw null; } }
        public string Value { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource? ValueSource { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBParameterValueSource : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBParameterValueSource(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource SystemDefault { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource UserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource left, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource left, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterValueSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBPasswordAuthenticationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>
    {
        public HorizonDBPasswordAuthenticationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPasswordAuthenticationPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>
    {
        public HorizonDBPasswordAuthenticationPatchProperties() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPasswordAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>
    {
        public HorizonDBPasswordAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPasswordAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>
    {
        internal HorizonDBPoolCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType RecommendedComputeProcessor { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorCapability> SupportedProcessors { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolComputeModelPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>
    {
        public HorizonDBPoolComputeModelPatch() { }
        public int? ComputeGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType? ComputeProcessor { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType? Type { get { throw null; } set { } }
        public int? VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolFeatureCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>
    {
        internal HorizonDBPoolFeatureCapability() { }
        public string Name { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolFeatureCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>
    {
        public HorizonDBPoolPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>
    {
        public HorizonDBPoolPatchProperties() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolComputeModelPatch ComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode? HighAvailabilityMode { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType? MaintenanceManagementType { get { throw null; } set { } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch ParameterGroup { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>
    {
        public HorizonDBPoolProperties(Azure.ResourceManager.HorizonDB.Models.PoolComputeModel computeModel, int nodeCount, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode highAvailabilityMode) { }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModel ComputeModel { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode HighAvailabilityMode { get { throw null; } set { } }
        public int NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference ParameterGroup { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties ScheduledMaintenance { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPoolState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPoolState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Ready { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Restarting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Starting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Stopped { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Stopping { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrincipalType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrincipalType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType Group { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType ServicePrincipal { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType Unknown { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBPrivateEndpointConnectionPatchProperties
    {
        public HorizonDBPrivateEndpointConnectionPatchProperties() { }
    }
    public partial class HorizonDBPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>
    {
        public HorizonDBPrivateEndpointConnectionProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HorizonDBPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>
    {
        internal HorizonDBPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>
    {
        public HorizonDBPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBProvisionedComputeModelCapability : Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>
    {
        internal HorizonDBProvisionedComputeModelCapability() { }
        public int RecommendedVCoreCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeSizeCapability> SupportedComputeSizes { get { throw null; } }
        protected override Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeModelCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisionedComputeModelCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBProvisioningState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBPublicNetworkAccessState : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBPublicNetworkAccessState(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState left, Azure.ResourceManager.HorizonDB.Models.HorizonDBPublicNetworkAccessState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HorizonDBScheduledMaintenanceManagementType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HorizonDBScheduledMaintenanceManagementType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType System { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType left, Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class HorizonDBScheduledMaintenanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>
    {
        internal HorizonDBScheduledMaintenanceProperties() { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HorizonDBSystemScheduledMaintenanceProperties : Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>
    {
        public HorizonDBSystemScheduledMaintenanceProperties() { }
        protected override Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.HorizonDB.Models.HorizonDBScheduledMaintenanceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.HorizonDBSystemScheduledMaintenanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogFileDownloadUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>
    {
        internal LogFileDownloadUri() { }
        public System.Uri DownloadUri { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.LogFileDownloadUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>
    {
        public MicrosoftEntraAdministratorContent(Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd properties) { }
        public Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>
    {
        internal MicrosoftEntraAdministratorProperties() { }
        public System.Guid? ObjectId { get { throw null; } }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType PrincipalType { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAdministratorPropertiesForAdd : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>
    {
        public MicrosoftEntraAdministratorPropertiesForAdd(string principalName, Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType principalType) { }
        public string PrincipalName { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBPrincipalType PrincipalType { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAdministratorPropertiesForAdd>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>
    {
        public MicrosoftEntraAuthenticationPatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState? State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftEntraAuthenticationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>
    {
        public MicrosoftEntraAuthenticationProperties(Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState state) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBAuthenticationState State { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.MicrosoftEntraAuthenticationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolComputeModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>
    {
        public PoolComputeModel(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType type, Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType computeProcessor, int computeGeneration, int vCores) { }
        public int ComputeGeneration { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBComputeProcessorType ComputeProcessor { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType Type { get { throw null; } set { } }
        public int VCores { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolComputeModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolComputeModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolComputeModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolComputeModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolComputeModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolComputeModelType : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolComputeModelType(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType Provisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType left, Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType left, Azure.ResourceManager.HorizonDB.Models.PoolComputeModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PoolHighAvailabilityMode : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PoolHighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode AnyZone { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode left, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode left, Azure.ResourceManager.HorizonDB.Models.PoolHighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PoolParameterGroupReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>
    {
        public PoolParameterGroupReference(Azure.Core.ResourceIdentifier parameterGroupResourceId, Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod applyMethod) { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod ApplyMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParameterGroupResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterGroupSyncStatus? SyncStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PoolParameterGroupReferencePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>
    {
        public PoolParameterGroupReferencePatch() { }
        public Azure.ResourceManager.HorizonDB.Models.HorizonDBParameterApplyMethod? ApplyMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ParameterGroupResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PoolParameterGroupReferencePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlCapabilityVersion : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlCapabilityVersion(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion V17 { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion V18 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlVersion : System.IEquatable<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlVersion(string value) { throw null; }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion V17 { get { throw null; } }
        public static Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion V18 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion left, Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlVersionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>
    {
        internal PostgreSqlVersionCapability() { }
        public Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HorizonDB.Models.PostgreSqlCapabilityVersion> SupportedVersionsToUpgrade { get { throw null; } }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HorizonDB.Models.PostgreSqlVersionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
