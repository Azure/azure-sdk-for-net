namespace Azure.ResourceManager.Relationships
{
    public partial class AzureResourceManagerRelationshipsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRelationshipsContext() { }
        public static Azure.ResourceManager.Relationships.AzureResourceManagerRelationshipsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DependencyOfRelationshipCollection : Azure.ResourceManager.ArmCollection
    {
        protected DependencyOfRelationshipCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Relationships.DependencyOfRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Relationships.DependencyOfRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DependencyOfRelationshipData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>
    {
        public DependencyOfRelationshipData() { }
        public Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relationships.DependencyOfRelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.DependencyOfRelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DependencyOfRelationshipResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DependencyOfRelationshipResource() { }
        public virtual Azure.ResourceManager.Relationships.DependencyOfRelationshipData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relationships.DependencyOfRelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.DependencyOfRelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.DependencyOfRelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relationships.DependencyOfRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relationships.DependencyOfRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RelationshipsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> GetDependencyOfRelationship(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> GetDependencyOfRelationshipAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relationships.DependencyOfRelationshipResource GetDependencyOfRelationshipResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relationships.DependencyOfRelationshipCollection GetDependencyOfRelationships(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> GetServiceGroupMemberRelationship(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> GetServiceGroupMemberRelationshipAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource GetServiceGroupMemberRelationshipResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipCollection GetServiceGroupMemberRelationships(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
    public partial class ServiceGroupMemberRelationshipCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServiceGroupMemberRelationshipCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceGroupMemberRelationshipData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>
    {
        public ServiceGroupMemberRelationshipData() { }
        public Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceGroupMemberRelationshipResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceGroupMemberRelationshipResource() { }
        public virtual Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Relationships.Mocking
{
    public partial class MockableRelationshipsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRelationshipsArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource> GetDependencyOfRelationship(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.DependencyOfRelationshipResource>> GetDependencyOfRelationshipAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relationships.DependencyOfRelationshipResource GetDependencyOfRelationshipResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relationships.DependencyOfRelationshipCollection GetDependencyOfRelationships(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource> GetServiceGroupMemberRelationship(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource>> GetServiceGroupMemberRelationshipAsync(Azure.Core.ResourceIdentifier scope, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipResource GetServiceGroupMemberRelationshipResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipCollection GetServiceGroupMemberRelationships(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.Relationships.Models
{
    public static partial class ArmRelationshipsModelFactory
    {
        public static Azure.ResourceManager.Relationships.DependencyOfRelationshipData DependencyOfRelationshipData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties DependencyOfRelationshipProperties(Azure.Core.ResourceIdentifier sourceId = null, Azure.Core.ResourceIdentifier targetId = null, string targetTenant = null, Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation originInformation = null, Azure.ResourceManager.Relationships.Models.RelationshipMetadata metadata = null, Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState? provisioningState = default(Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Relationships.Models.RelationshipMetadata RelationshipMetadata(Azure.Core.ResourceType sourceType = default(Azure.Core.ResourceType), Azure.Core.ResourceType targetType = default(Azure.Core.ResourceType)) { throw null; }
        public static Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation RelationshipOriginInformation(Azure.ResourceManager.Relationships.Models.RelationshipOriginType relationshipOriginType = default(Azure.ResourceManager.Relationships.Models.RelationshipOriginType), string discoveryEngine = null) { throw null; }
        public static Azure.ResourceManager.Relationships.ServiceGroupMemberRelationshipData ServiceGroupMemberRelationshipData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties ServiceGroupMemberRelationshipProperties(Azure.Core.ResourceIdentifier sourceId = null, Azure.Core.ResourceIdentifier targetId = null, string targetTenant = null, Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation originInformation = null, Azure.ResourceManager.Relationships.Models.RelationshipMetadata metadata = null, Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState? provisioningState = default(Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState?)) { throw null; }
    }
    public partial class DependencyOfRelationshipProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>
    {
        public DependencyOfRelationshipProperties(Azure.Core.ResourceIdentifier targetId) { }
        public Azure.ResourceManager.Relationships.Models.RelationshipMetadata Metadata { get { throw null; } }
        public Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation OriginInformation { get { throw null; } }
        public Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        public string TargetTenant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.DependencyOfRelationshipProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>
    {
        internal RelationshipMetadata() { }
        public Azure.Core.ResourceType SourceType { get { throw null; } }
        public Azure.Core.ResourceType TargetType { get { throw null; } }
        protected virtual Azure.ResourceManager.Relationships.Models.RelationshipMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relationships.Models.RelationshipMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relationships.Models.RelationshipMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.Models.RelationshipMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipOriginInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>
    {
        internal RelationshipOriginInformation() { }
        public string DiscoveryEngine { get { throw null; } }
        public Azure.ResourceManager.Relationships.Models.RelationshipOriginType RelationshipOriginType { get { throw null; } }
        protected virtual Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelationshipOriginType : System.IEquatable<Azure.ResourceManager.Relationships.Models.RelationshipOriginType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelationshipOriginType(string value) { throw null; }
        public static Azure.ResourceManager.Relationships.Models.RelationshipOriginType ServiceExplicitlyCreated { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipOriginType SystemDiscoveredByRule { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipOriginType UserDiscoveredByRule { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipOriginType UserExplicitlyCreated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relationships.Models.RelationshipOriginType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relationships.Models.RelationshipOriginType left, Azure.ResourceManager.Relationships.Models.RelationshipOriginType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relationships.Models.RelationshipOriginType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relationships.Models.RelationshipOriginType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relationships.Models.RelationshipOriginType left, Azure.ResourceManager.Relationships.Models.RelationshipOriginType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelationshipProvisioningState : System.IEquatable<Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelationshipProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState left, Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState left, Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceGroupMemberRelationshipProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>
    {
        public ServiceGroupMemberRelationshipProperties(Azure.Core.ResourceIdentifier targetId) { }
        public Azure.ResourceManager.Relationships.Models.RelationshipMetadata Metadata { get { throw null; } }
        public Azure.ResourceManager.Relationships.Models.RelationshipOriginInformation OriginInformation { get { throw null; } }
        public Azure.ResourceManager.Relationships.Models.RelationshipProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        public string TargetTenant { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Relationships.Models.ServiceGroupMemberRelationshipProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
