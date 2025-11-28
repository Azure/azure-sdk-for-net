namespace Azure.ResourceManager.ContainerServiceNodeCustomization
{
    public partial class AzureResourceManagerContainerServiceNodeCustomizationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerServiceNodeCustomizationContext() { }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.AzureResourceManagerContainerServiceNodeCustomizationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerServiceNodeCustomizationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetNodeCustomization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> GetNodeCustomizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource GetNodeCustomizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationCollection GetNodeCustomizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetNodeCustomizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetNodeCustomizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource GetNodeCustomizationVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NodeCustomizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>, System.Collections.IEnumerable
    {
        protected NodeCustomizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodeCustomizationName, Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodeCustomizationName, Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> Get(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> GetAsync(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetIfExists(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> GetIfExistsAsync(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NodeCustomizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>
    {
        public NodeCustomizationData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeCustomizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NodeCustomizationResource() { }
        public virtual Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string nodeCustomizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> GetNodeCustomizationVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>> GetNodeCustomizationVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionCollection GetNodeCustomizationVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NodeCustomizationVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>, System.Collections.IEnumerable
    {
        protected NodeCustomizationVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NodeCustomizationVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>
    {
        internal NodeCustomizationVersionData() { }
        public Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeCustomizationVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NodeCustomizationVersionResource() { }
        public virtual Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string nodeCustomizationName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceNodeCustomization.Mocking
{
    public partial class MockableContainerServiceNodeCustomizationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceNodeCustomizationArmClient() { }
        public virtual Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource GetNodeCustomizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionResource GetNodeCustomizationVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerServiceNodeCustomizationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceNodeCustomizationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetNodeCustomization(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource>> GetNodeCustomizationAsync(string nodeCustomizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationCollection GetNodeCustomizations() { throw null; }
    }
    public partial class MockableContainerServiceNodeCustomizationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceNodeCustomizationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetNodeCustomizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationResource> GetNodeCustomizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceNodeCustomization.Models
{
    public static partial class ArmContainerServiceNodeCustomizationModelFactory
    {
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationData NodeCustomizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties NodeCustomizationProperties(System.Collections.Generic.IEnumerable<string> containerImages = null, Azure.ResourceManager.Models.UserAssignedIdentity identityProfile = null, string version = null, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript> customizationScripts = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.NodeCustomizationVersionData NodeCustomizationVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties properties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExecutionPoint : System.IEquatable<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExecutionPoint(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint NodeImageBuildTime { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint NodeProvisionTime { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint left, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint left, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeCustomizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>
    {
        public NodeCustomizationPatch() { }
        public Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeCustomizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>
    {
        public NodeCustomizationProperties() { }
        public System.Collections.Generic.IList<string> ContainerImages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript> CustomizationScripts { get { throw null; } }
        public Azure.ResourceManager.Models.UserAssignedIdentity IdentityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeCustomizationScript : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>
    {
        public NodeCustomizationScript(string name, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint executionPoint, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType scriptType) { }
        public Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ExecutionPoint ExecutionPoint { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? RebootAfter { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType ScriptType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeCustomizationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>
    {
        public NodeCustomizationUpdateProperties() { }
        public System.Collections.Generic.IList<string> ContainerImages { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationScript> CustomizationScripts { get { throw null; } }
        public Azure.ResourceManager.Models.UserAssignedIdentity IdentityProfile { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.NodeCustomizationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState left, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState left, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScriptType : System.IEquatable<Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScriptType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType Bash { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType PowerShell { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType left, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType left, Azure.ResourceManager.ContainerServiceNodeCustomization.Models.ScriptType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
