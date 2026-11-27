namespace Azure.ResourceManager.NetworkSecurity
{
    public partial class AgentFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>, System.Collections.IEnumerable
    {
        protected AgentFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentFabricName, Azure.ResourceManager.NetworkSecurity.AgentFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentFabricName, Azure.ResourceManager.NetworkSecurity.AgentFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> Get(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> GetAsync(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetIfExists(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> GetIfExistsAsync(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentFabricData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>
    {
        public AgentFabricData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.AgentFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.AgentFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>, System.Collections.IEnumerable
    {
        protected AgentFabricMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string memberName, Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string memberName, Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> Get(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> GetAsync(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> GetIfExists(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> GetIfExistsAsync(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentFabricMemberData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>
    {
        public AgentFabricMemberData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricMemberResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentFabricMemberResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentFabricName, string memberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentFabricResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentFabricResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.AgentFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentFabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource> GetAgentFabricMember(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource>> GetAgentFabricMemberAsync(string memberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.AgentFabricMemberCollection GetAgentFabricMembers() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> GetClusterAssociation(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> GetClusterAssociationAsync(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.ClusterAssociationCollection GetClusterAssociations() { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.EgressTrustBundleResource GetEgressTrustBundle() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.AgentFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.AgentFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.AgentFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerNetworkSecurityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNetworkSecurityContext() { }
        public static Azure.ResourceManager.NetworkSecurity.AzureResourceManagerNetworkSecurityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ClusterAssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>, System.Collections.IEnumerable
    {
        protected ClusterAssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string clusterAssociationName, Azure.ResourceManager.NetworkSecurity.ClusterAssociationData data, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string clusterAssociationName, Azure.ResourceManager.NetworkSecurity.ClusterAssociationData data, Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> Get(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> GetAsync(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> GetIfExists(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> GetIfExistsAsync(string clusterAssociationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ClusterAssociationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>
    {
        public ClusterAssociationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.ClusterAssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.ClusterAssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAssociationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ClusterAssociationResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.ClusterAssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentFabricName, string clusterAssociationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.ClusterAssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.ClusterAssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.ClusterAssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EgressTrustBundleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>
    {
        internal EgressTrustBundleData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressTrustBundleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EgressTrustBundleResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentFabricName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class NetworkSecurityExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAgentFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> GetAgentFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource GetAgentFabricMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.AgentFabricResource GetAgentFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.AgentFabricCollection GetAgentFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAgentFabrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAgentFabricsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource GetClusterAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.EgressTrustBundleResource GetEgressTrustBundleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetNetworkSecurityPolicyGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> GetNetworkSecurityPolicyGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource GetNetworkSecurityPolicyGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupCollection GetNetworkSecurityPolicyGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetNetworkSecurityPolicyGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetNetworkSecurityPolicyGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShield(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetNeuroShieldAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource GetNeuroShieldFindingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource GetNeuroShieldMitigationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetNeuroShieldOperationStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetNeuroShieldOperationStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource GetNeuroShieldProtectedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldResource GetNeuroShieldResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldCollection GetNeuroShields(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShields(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShieldsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource GetNeuroShieldSummaryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class NetworkSecurityPolicyGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>, System.Collections.IEnumerable
    {
        protected NetworkSecurityPolicyGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyGroupName, Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyGroupName, Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> Get(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> GetAsync(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetIfExists(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> GetIfExistsAsync(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetworkSecurityPolicyGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>
    {
        public NetworkSecurityPolicyGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPolicyGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetworkSecurityPolicyGroupResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string policyGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeuroShieldCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string neuroShieldName, Azure.ResourceManager.NetworkSecurity.NeuroShieldData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string neuroShieldName, Azure.ResourceManager.NetworkSecurity.NeuroShieldData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> Get(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetIfExists(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetIfExistsAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>
    {
        public NeuroShieldData(Azure.Core.AzureLocation location, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldFindingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldFindingCollection() { }
        public virtual Azure.Response<bool> Exists(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> Get(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetIfExists(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetIfExistsAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldFindingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>
    {
        internal NeuroShieldFindingData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldFindingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldFindingResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName, string protectedResourceName, string findingId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult> Mitigate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>> MitigateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult> Rollback(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>> RollbackAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldMitigationCollection() { }
        public virtual Azure.Response<bool> Exists(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Get(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetIfExists(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetIfExistsAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldMitigationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>
    {
        internal NeuroShieldMitigationData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldMitigationResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName, string protectedResourceName, string mitigationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Execute(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> ExecuteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> Rollback(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> RollbackAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldProtectedResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName, string protectedResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetNeuroShieldFinding(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource>> GetNeuroShieldFindingAsync(string findingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingCollection GetNeuroShieldFindings() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetNeuroShieldMitigation(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource>> GetNeuroShieldMitigationAsync(string mitigationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationCollection GetNeuroShieldMitigations() { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult> TriggerInventoryUpload(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>> TriggerInventoryUploadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>, System.Collections.IEnumerable
    {
        protected NeuroShieldProtectedResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedResourceName, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedResourceName, Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData data, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> Get(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetAll(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetAllAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetIfExists(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetIfExistsAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeuroShieldProtectedResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>
    {
        public NeuroShieldProtectedResourceData(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties properties) { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetNeuroShieldFindings(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource> GetNeuroShieldFindingsAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetNeuroShieldMitigations(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource> GetNeuroShieldMitigationsAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource> GetNeuroShieldProtectedResource(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource>> GetNeuroShieldProtectedResourceAsync(string protectedResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceCollection GetNeuroShieldProtectedResources() { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource GetNeuroShieldSummary() { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> Update(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> UpdateAsync(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeuroShieldSummaryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>
    {
        internal NeuroShieldSummaryData() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldSummaryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeuroShieldSummaryResource() { }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string neuroShieldName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkSecurity.Mocking
{
    public partial class MockableNetworkSecurityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkSecurityArmClient() { }
        public virtual Azure.ResourceManager.NetworkSecurity.AgentFabricMemberResource GetAgentFabricMemberResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.AgentFabricResource GetAgentFabricResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.ClusterAssociationResource GetClusterAssociationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.EgressTrustBundleResource GetEgressTrustBundleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource GetNetworkSecurityPolicyGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingResource GetNeuroShieldFindingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationResource GetNeuroShieldMitigationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResource GetNeuroShieldProtectedResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldResource GetNeuroShieldResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryResource GetNeuroShieldSummaryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetworkSecurityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkSecurityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAgentFabric(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.AgentFabricResource>> GetAgentFabricAsync(string agentFabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.AgentFabricCollection GetAgentFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetNetworkSecurityPolicyGroup(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource>> GetNetworkSecurityPolicyGroupAsync(string policyGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupCollection GetNetworkSecurityPolicyGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShield(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource>> GetNeuroShieldAsync(string neuroShieldName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetworkSecurity.NeuroShieldCollection GetNeuroShields() { throw null; }
    }
    public partial class MockableNetworkSecuritySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetworkSecuritySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> Get(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAgentFabrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.AgentFabricResource> GetAgentFabricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetAsync(string location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetNetworkSecurityPolicyGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupResource> GetNetworkSecurityPolicyGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Models.OperationStatusResult> GetNeuroShieldOperationStatus(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Models.OperationStatusResult>> GetNeuroShieldOperationStatusAsync(Azure.Core.AzureLocation location, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShields(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetworkSecurity.NeuroShieldResource> GetNeuroShieldsAsync(int? maxCount = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetworkSecurity.Models
{
    public partial class AciWorkload : Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>
    {
        public AciWorkload(Azure.Core.ResourceIdentifier resourceId, string workloadId) { }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity AgentIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string WorkloadId { get { throw null; } set { } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AciWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AciWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AciWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricMemberPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>
    {
        public AgentFabricMemberPatch() { }
        public string Fqdn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricMemberProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>
    {
        public AgentFabricMemberProperties() { }
        public string Fqdn { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? ProvisioningState { get { throw null; } }
        public string SpiffeId { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload Workload { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>
    {
        public AgentFabricPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>
    {
        public AgentFabricProperties() { }
        public Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile ContentInspectionProfile { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> DefaultPolicyGroups { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        public string TrustDomain { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentFabricProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentFabricProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState left, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState left, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentFabricSandboxEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>
    {
        public AgentFabricSandboxEndpoint(string name, int servicePort, string protocol, int targetPort) { }
        public string Name { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public int ServicePort { get { throw null; } set { } }
        public int TargetPort { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricSandboxImage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>
    {
        public AgentFabricSandboxImage(string uri) { }
        public string Digest { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy? PullPolicy { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentFabricSandboxImagePullPolicy : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentFabricSandboxImagePullPolicy(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy IfNotPresent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy left, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy left, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentFabricSandboxResources : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>
    {
        public AgentFabricSandboxResources(string cpu, string memory) { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFabricSandboxWorkload : Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>
    {
        public AgentFabricSandboxWorkload(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage image, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources resources, string domain) { }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity AgentIdentity { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint> Endpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage Image { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources Resources { get { throw null; } set { } }
        public string WorkloadId { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentFabricWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>
    {
        internal AgentFabricWorkload() { }
        public System.Guid? MemberGuid { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>
    {
        public AgentIdentity(System.Guid tenantId, string agentId) { }
        public string AgentId { get { throw null; } set { } }
        public string BlueprintId { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AksWorkload : Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>
    {
        public AksWorkload(Azure.Core.ResourceIdentifier clusterAssociationId, Azure.Core.ResourceIdentifier clusterResourceId, Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference workload) { }
        public Azure.Core.ResourceIdentifier ClusterAssociationId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping> Endpoints { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference Workload { get { throw null; } set { } }
        public string WorkloadId { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AksWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AksWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AksWorkloadPortMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>
    {
        public AksWorkloadPortMapping(string name, int servicePort, string protocol, int targetPort) { }
        public string Name { get { throw null; } set { } }
        public string Protocol { get { throw null; } set { } }
        public int ServicePort { get { throw null; } set { } }
        public int TargetPort { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AksWorkloadReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>
    {
        public AksWorkloadReference(string apiVersion, string kind, string @namespace, string name) { }
        public string ApiVersion { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmNetworkSecurityModelFactory
    {
        public static Azure.ResourceManager.NetworkSecurity.Models.AciWorkload AciWorkload(System.Guid? memberGuid = default(System.Guid?), Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity agentIdentity = null, string workloadId = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.AgentFabricData AgentFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.AgentFabricMemberData AgentFabricMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberPatch AgentFabricMemberPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string fqdn = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricMemberProperties AgentFabricMemberProperties(string fqdn = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload workload = null, string spiffeId = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricPatch AgentFabricPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProperties AgentFabricProperties(System.Guid? resourceGuid = default(System.Guid?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> defaultPolicyGroups = null, Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile contentInspectionProfile = null, string trustDomain = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint AgentFabricSandboxEndpoint(string name = null, int servicePort = 0, string protocol = null, int targetPort = 0) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage AgentFabricSandboxImage(string uri = null, string digest = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy? pullPolicy = default(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImagePullPolicy?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources AgentFabricSandboxResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxWorkload AgentFabricSandboxWorkload(System.Guid? memberGuid = default(System.Guid?), Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxImage image = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxResources resources = null, Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.AgentFabricSandboxEndpoint> endpoints = null, string domain = null, string workloadId = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentFabricWorkload AgentFabricWorkload(string type = null, System.Guid? memberGuid = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AgentIdentity AgentIdentity(System.Guid tenantId = default(System.Guid), string agentId = null, string blueprintId = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AksWorkload AksWorkload(System.Guid? memberGuid = default(System.Guid?), Azure.Core.ResourceIdentifier clusterAssociationId = null, Azure.Core.ResourceIdentifier clusterResourceId = null, Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference workload = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping> endpoints = null, string workloadId = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadPortMapping AksWorkloadPortMapping(string name = null, int servicePort = 0, string protocol = null, int targetPort = 0) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AksWorkloadReference AksWorkloadReference(string apiVersion = null, string kind = null, string @namespace = null, string name = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate AzureManagedCaCertificate() { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.ClusterAssociationData ClusterAssociationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch ClusterAssociationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties ClusterAssociationProperties(Azure.Core.ResourceIdentifier clusterResourceId = null, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName? sku = default(Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName?), string workloadClusterGatewayIP = null, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus status = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus ClusterAssociationStatus(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties ClusterAssociationUpdateProperties(Azure.Core.ResourceIdentifier clusterResourceId = null, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName? sku = default(Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName?), string workloadClusterGatewayIP = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy ContentInspectionPolicy(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource source = null, Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection promptInjectionProtection = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource ContentInspectionPolicyAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource ContentInspectionPolicySource(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource ContentInspectionPolicyWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile ContentInspectionProfile(System.Uri endpoint = null, string apiKey = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate EgressTrustBundleCertificate(string certificateId = null, string pem = null, string thumbprintSha256 = null, System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.EgressTrustBundleData EgressTrustBundleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties EgressTrustBundleProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate> certificates = null, string bundleVersion = null, int cacheValiditySeconds = 0, System.DateTimeOffset cacheExpiresOn = default(System.DateTimeOffset), Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource FqdnFilteringAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination FqdnFilteringDestination(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination FqdnFilteringFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy FqdnFilteringPolicy(string name = null, int? priority = default(int?), Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection? direction = default(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection?), System.Collections.Generic.IEnumerable<int> ports = null, Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource source = null, Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination destination = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource FqdnFilteringSource(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource FqdnFilteringWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching McpArgumentMatching(System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.NetworkSecurity.Models.McpMatchType matchType = default(Azure.ResourceManager.NetworkSecurity.Models.McpMatchType), Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase? matchCase = default(Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase?), string path = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicy McpPolicy(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction defaultAction = default(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction), Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource source = null, Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination destination = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.McpRule> rules = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination McpPolicyAddressPrefixesDestination(System.Collections.Generic.IEnumerable<string> prefixes = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource McpPolicyAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination McpPolicyDestination(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination McpPolicyFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource McpPolicySource(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination McpPolicyWorkloadIdPatternsDestination(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource McpPolicyWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching McpPromptMatching(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod> methods = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching names = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching titles = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching descriptions = null, Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching arguments = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching responseContents = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpRule McpRule(string name = null, int? priority = default(int?), Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction? action = default(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction?), System.Collections.Generic.IEnumerable<string> tools = null, Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching matchingConditionsDestinations = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching McpRuleDestinationMatching(System.Collections.Generic.IEnumerable<string> serverFqdns = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching protocolVersions = null, Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching toolMatching = null, Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching promptMatching = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching McpStringMatching(System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.NetworkSecurity.Models.McpMatchType matchType = default(Azure.ResourceManager.NetworkSecurity.Models.McpMatchType), Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase? matchCase = default(Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching McpToolMatching(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod> methods = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching names = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching titles = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching descriptions = null, Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching callArguments = null, Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching responseContents = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase NetworkSecurityPolicyBase(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NetworkSecurityPolicyGroupData NetworkSecurityPolicyGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch NetworkSecurityPolicyGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties NetworkSecurityPolicyGroupProperties(string displayName = null, string description = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase> networkSecurityPolicies = null, Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldData NeuroShieldData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldFindingData NeuroShieldFindingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties NeuroShieldFindingProperties(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState?), string cveId = null, Azure.Core.ResourceIdentifier virtualMachineArmId = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold severity = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold), string description = null, string reason = null, System.DateTimeOffset? detectedOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus status = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata NeuroShieldInventoryUploadRequestMetadata(System.Guid requestId = default(System.Guid), System.DateTimeOffset requestedOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult NeuroShieldInventoryUploadRequestResult(System.Guid requestId = default(System.Guid), System.DateTimeOffset requestedOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset), bool deduplicated = false) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult NeuroShieldMitigationActionResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData> value = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData NeuroShieldMitigationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties NeuroShieldMitigationProperties(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState?), Azure.Core.ResourceIdentifier findingId = null, string cveId = null, Azure.Core.ResourceIdentifier virtualMachineArmId = null, int rank = 0, string commandsSummary = null, bool isRollbackable = false, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus status = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus), string statusDetails = null, System.DateTimeOffset? appliedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch NeuroShieldPatch(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags tags = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties NeuroShieldPatchProperties(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode? responseMode = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? severityThreshold = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold?), string description = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags NeuroShieldPatchTags(System.Collections.Generic.IDictionary<string, string> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties NeuroShieldProperties(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield?), System.Guid? resourceGuid = default(System.Guid?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode responseMode = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? severityThreshold = default(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold?), string description = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldProtectedResourceData NeuroShieldProtectedResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity NeuroShieldProtectedResourceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties NeuroShieldProtectedResourceProperties(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield?), Azure.Core.ResourceIdentifier targetResourceId = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity targetIdentity = null, System.DateTimeOffset? agentHealthLastSeenOn = default(System.DateTimeOffset?), Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata inventoryUploadRequest = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity NeuroShieldProtectedResourceUserAssignedIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.NeuroShieldSummaryData NeuroShieldSummaryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties NeuroShieldSummaryProperties(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState?), int protectedCount = 0, int scannedProtectedCount = 0, int activeFindings = 0, int criticalFindings = 0, int highFindings = 0, int mediumFindings = 0, int lowFindings = 0, int unreachableFindings = 0, int awaitingApprovalMitigations = 0, int queuedMitigations = 0, int inProgressMitigations = 0, int succeededMitigations = 0, int failedMitigations = 0, int rollbackInProgressMitigations = 0) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection PromptInjectionProtection(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity? sensitivity = default(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity?), System.Collections.Generic.IEnumerable<string> promptLocations = null, System.Collections.Generic.IEnumerable<string> responseLocations = null, Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection onDetection = default(Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase TlsInspectionCertificateBase(string mode = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy TlsInspectionPolicy(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource source = null, Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase certificate = null, Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction? defaultAction = default(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule> rules = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource TlsInspectionPolicySource(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource TlsInspectionPolicyWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule TlsInspectionRule(string name = null, int priority = 0, Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction? action = default(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination> destinations = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination TlsInspectionRuleDestination(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination TlsInspectionRuleFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination UrlFilteringAddressPrefixesDestination(System.Collections.Generic.IEnumerable<string> prefixes = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource UrlFilteringAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination UrlFilteringDestination(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination UrlFilteringFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy UrlFilteringPolicy(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction defaultAction = default(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction), Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource source = null, Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination destination = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule> rules = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule UrlFilteringRule(string name = null, int priority = 0, string hostname = null, Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod? method = default(Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod?), System.Collections.Generic.IEnumerable<string> paths = null, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction? action = default(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction?)) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource UrlFilteringSource(string type = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination UrlFilteringWorkloadIdPatternsDestination(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource UrlFilteringWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
    }
    public partial class AzureManagedCaCertificate : Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>
    {
        public AzureManagedCaCertificate() { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.AzureManagedCaCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAssociationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>
    {
        public ClusterAssociationPatch(Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties properties) { }
        public Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAssociationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>
    {
        public ClusterAssociationProperties(Azure.Core.ResourceIdentifier clusterResourceId) { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName? Sku { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus Status { get { throw null; } }
        public string WorkloadClusterGatewayIP { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterAssociationSkuName : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterAssociationSkuName(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName left, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName left, Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterAssociationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>
    {
        internal ClusterAssociationStatus() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterAssociationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>
    {
        public ClusterAssociationUpdateProperties() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationSkuName? Sku { get { throw null; } set { } }
        public string WorkloadClusterGatewayIP { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ClusterAssociationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentInspectionPolicy : Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>
    {
        public ContentInspectionPolicy(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource source) { }
        public Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection PromptInjectionProtection { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource Source { get { throw null; } set { } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentInspectionPolicyAddressPrefixesSource : Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>
    {
        public ContentInspectionPolicyAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes) { }
        public System.Collections.Generic.IList<string> Prefixes { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyAddressPrefixesSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ContentInspectionPolicySource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>
    {
        internal ContentInspectionPolicySource() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentInspectionPolicyWorkloadIdPatternsSource : Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>
    {
        public ContentInspectionPolicyWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionPolicyWorkloadIdPatternsSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentInspectionProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>
    {
        public ContentInspectionProfile() { }
        public string ApiKey { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentInspectionSensitivity : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentInspectionSensitivity(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity High { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity Low { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity left, Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity left, Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressTrustBundleCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>
    {
        internal EgressTrustBundleCertificate() { }
        public string CertificateId { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public string Pem { get { throw null; } }
        public System.DateTimeOffset StartsOn { get { throw null; } }
        public string ThumbprintSha256 { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressTrustBundleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>
    {
        internal EgressTrustBundleProperties() { }
        public string BundleVersion { get { throw null; } }
        public System.DateTimeOffset CacheExpiresOn { get { throw null; } }
        public int CacheValiditySeconds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleCertificate> Certificates { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.EgressTrustBundleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FqdnFilteringAddressPrefixesSource : Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>
    {
        public FqdnFilteringAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes) { }
        public System.Collections.Generic.IList<string> Prefixes { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringAddressPrefixesSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FqdnFilteringDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>
    {
        internal FqdnFilteringDestination() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FqdnFilteringFqdnsDestination : Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>
    {
        public FqdnFilteringFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns) { }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringFqdnsDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FqdnFilteringPolicy : Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>
    {
        public FqdnFilteringPolicy(Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource source) { }
        public Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringDestination Destination { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection? Direction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Ports { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource Source { get { throw null; } set { } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FqdnFilteringSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>
    {
        internal FqdnFilteringSource() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FqdnFilteringWorkloadIdPatternsSource : Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>
    {
        public FqdnFilteringWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.FqdnFilteringWorkloadIdPatternsSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpArgumentMatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>
    {
        public McpArgumentMatching(System.Collections.Generic.IEnumerable<string> values, Azure.ResourceManager.NetworkSecurity.Models.McpMatchType matchType) { }
        public Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase? MatchCase { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpMatchType MatchType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct McpMatchCase : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public McpMatchCase(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase CaseInsensitive { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase CaseSensitive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase left, Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase left, Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct McpMatchType : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.McpMatchType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public McpMatchType(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpMatchType Contains { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpMatchType ExactMatch { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpMatchType NotContains { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpMatchType NotExactMatch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.McpMatchType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.McpMatchType left, Azure.ResourceManager.NetworkSecurity.Models.McpMatchType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpMatchType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpMatchType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.McpMatchType left, Azure.ResourceManager.NetworkSecurity.Models.McpMatchType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McpPolicy : Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>
    {
        public McpPolicy(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction defaultAction, Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource source, Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination destination, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.McpRule> rules) { }
        public Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction DefaultAction { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination Destination { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.McpRule> Rules { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource Source { get { throw null; } set { } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpPolicyAddressPrefixesDestination : Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>
    {
        public McpPolicyAddressPrefixesDestination(System.Collections.Generic.IEnumerable<string> prefixes) { }
        public System.Collections.Generic.IList<string> Prefixes { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpPolicyAddressPrefixesSource : Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>
    {
        public McpPolicyAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes) { }
        public System.Collections.Generic.IList<string> Prefixes { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyAddressPrefixesSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class McpPolicyDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>
    {
        internal McpPolicyDestination() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpPolicyFqdnsDestination : Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>
    {
        public McpPolicyFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns) { }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyFqdnsDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class McpPolicySource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>
    {
        internal McpPolicySource() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpPolicyWorkloadIdPatternsDestination : Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>
    {
        public McpPolicyWorkloadIdPatternsDestination(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicyDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpPolicyWorkloadIdPatternsSource : Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>
    {
        public McpPolicyWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.McpPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPolicyWorkloadIdPatternsSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpPromptMatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>
    {
        public McpPromptMatching() { }
        public Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching Arguments { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching Descriptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod> Methods { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching Names { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching ResponseContents { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching Titles { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct McpPromptMethod : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public McpPromptMethod(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod Get { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod List { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod left, Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod left, Azure.ResourceManager.NetworkSecurity.Models.McpPromptMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McpRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>
    {
        public McpRule() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction? Action { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching MatchingConditionsDestinations { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tools { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpRuleDestinationMatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>
    {
        public McpRuleDestinationMatching() { }
        public Azure.ResourceManager.NetworkSecurity.Models.McpPromptMatching PromptMatching { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching ProtocolVersions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ServerFqdns { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching ToolMatching { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpRuleDestinationMatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpStringMatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>
    {
        public McpStringMatching(System.Collections.Generic.IEnumerable<string> values, Azure.ResourceManager.NetworkSecurity.Models.McpMatchType matchType) { }
        public Azure.ResourceManager.NetworkSecurity.Models.McpMatchCase? MatchCase { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpMatchType MatchType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpToolMatching : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>
    {
        public McpToolMatching() { }
        public Azure.ResourceManager.NetworkSecurity.Models.McpArgumentMatching CallArguments { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching Descriptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod> Methods { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching Names { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching ResponseContents { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.McpStringMatching Titles { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.McpToolMatching>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct McpToolMethod : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public McpToolMethod(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod Call { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod List { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod left, Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod left, Azure.ResourceManager.NetworkSecurity.Models.McpToolMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPolicyAction : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPolicyAction(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction Allow { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction left, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction left, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class NetworkSecurityPolicyBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>
    {
        internal NetworkSecurityPolicyBase() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSecurityPolicyDirection : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSecurityPolicyDirection(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection Both { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection Inbound { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection Outbound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection left, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection left, Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkSecurityPolicyGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>
    {
        public NetworkSecurityPolicyGroupPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkSecurityPolicyGroupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>
    {
        public NetworkSecurityPolicyGroupProperties() { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase> NetworkSecurityPolicies { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.AgentFabricProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyGroupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldFindingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>
    {
        internal NeuroShieldFindingProperties() { }
        public string CveId { get { throw null; } }
        public string Description { get { throw null; } }
        public System.DateTimeOffset? DetectedOn { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Severity { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Status { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineArmId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldFindingStatus : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldFindingStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus AwaitingApproval { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Mitigated { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus MitigationInProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus MitigationsExhausted { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus Unreachable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldFindingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeuroShieldInventoryUploadRequestMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>
    {
        internal NeuroShieldInventoryUploadRequestMetadata() { }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.DateTimeOffset RequestedOn { get { throw null; } }
        public System.Guid RequestId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldInventoryUploadRequestResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>
    {
        internal NeuroShieldInventoryUploadRequestResult() { }
        public bool Deduplicated { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.DateTimeOffset RequestedOn { get { throw null; } }
        public System.Guid RequestId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationActionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>
    {
        internal NeuroShieldMitigationActionResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.NeuroShieldMitigationData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationActionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldMitigationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>
    {
        internal NeuroShieldMitigationProperties() { }
        public System.DateTimeOffset? AppliedOn { get { throw null; } }
        public string CommandsSummary { get { throw null; } }
        public string CveId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FindingId { get { throw null; } }
        public bool IsRollbackable { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int Rank { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualMachineArmId { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldMitigationStatus : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldMitigationStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus AwaitingApproval { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Queued { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus RollbackFailed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus RollbackInProgress { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus RolledBack { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldMitigationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeuroShieldPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>
    {
        public NeuroShieldPatch() { }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>
    {
        public NeuroShieldPatchProperties() { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode? ResponseMode { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? SeverityThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldPatchTags : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>
    {
        public NeuroShieldPatchTags() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldPatchTags>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>
    {
        public NeuroShieldProperties(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode responseMode) { }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? ProvisioningState { get { throw null; } }
        public System.Guid? ResourceGuid { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode ResponseMode { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? SeverityThreshold { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>
    {
        public NeuroShieldProtectedResourceIdentity(Azure.ResourceManager.Models.ManagedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>
    {
        public NeuroShieldProtectedResourceProperties(Azure.Core.ResourceIdentifier targetResourceId) { }
        public System.DateTimeOffset? AgentHealthLastSeenOn { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldInventoryUploadRequestMetadata InventoryUploadRequest { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceIdentity TargetIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeuroShieldProtectedResourceUserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>
    {
        public NeuroShieldProtectedResourceUserAssignedIdentity() { }
        public System.Guid? ClientId { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldProtectedResourceUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldResponseMode : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldResponseMode(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode Auto { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldResponseMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeuroShieldSeverityThreshold : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeuroShieldSeverityThreshold(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Critical { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold High { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Low { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold left, Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSeverityThreshold right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeuroShieldSummaryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>
    {
        internal NeuroShieldSummaryProperties() { }
        public int ActiveFindings { get { throw null; } }
        public int AwaitingApprovalMitigations { get { throw null; } }
        public int CriticalFindings { get { throw null; } }
        public int FailedMitigations { get { throw null; } }
        public int HighFindings { get { throw null; } }
        public int InProgressMitigations { get { throw null; } }
        public int LowFindings { get { throw null; } }
        public int MediumFindings { get { throw null; } }
        public int ProtectedCount { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public int QueuedMitigations { get { throw null; } }
        public int RollbackInProgressMitigations { get { throw null; } }
        public int ScannedProtectedCount { get { throw null; } }
        public int SucceededMitigations { get { throw null; } }
        public int UnreachableFindings { get { throw null; } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.NeuroShieldSummaryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PromptInjectionOnDetection : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PromptInjectionOnDetection(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection Alert { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection BlockAndAlert { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection Sanitize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection left, Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection left, Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PromptInjectionProtection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>
    {
        public PromptInjectionProtection(Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection onDetection) { }
        public Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionOnDetection OnDetection { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PromptLocations { get { throw null; } }
        public System.Collections.Generic.IList<string> ResponseLocations { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.ContentInspectionSensitivity? Sensitivity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.PromptInjectionProtection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateNeuroShield : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateNeuroShield(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Creating { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Deleting { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield left, Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield left, Azure.ResourceManager.NetworkSecurity.Models.ProvisioningStateNeuroShield right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState left, Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState left, Azure.ResourceManager.NetworkSecurity.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TlsInspectionAction : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TlsInspectionAction(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction Bypass { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction Inspect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction left, Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction left, Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TlsInspectionCertificateBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>
    {
        internal TlsInspectionCertificateBase() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsInspectionPolicy : Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>
    {
        public TlsInspectionPolicy(Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource source, Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase certificate) { }
        public Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionCertificateBase Certificate { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule> Rules { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource Source { get { throw null; } set { } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TlsInspectionPolicySource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>
    {
        internal TlsInspectionPolicySource() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsInspectionPolicyWorkloadIdPatternsSource : Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>
    {
        public TlsInspectionPolicyWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionPolicyWorkloadIdPatternsSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsInspectionRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>
    {
        public TlsInspectionRule(string name, int priority, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination> destinations) { }
        public Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionAction? Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination> Destinations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TlsInspectionRuleDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>
    {
        internal TlsInspectionRuleDestination() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TlsInspectionRuleFqdnsDestination : Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>
    {
        public TlsInspectionRuleFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns) { }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.TlsInspectionRuleFqdnsDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlFilteringAddressPrefixesDestination : Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>
    {
        public UrlFilteringAddressPrefixesDestination(System.Collections.Generic.IEnumerable<string> prefixes) { }
        public System.Collections.Generic.IList<string> Prefixes { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlFilteringAddressPrefixesSource : Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>
    {
        public UrlFilteringAddressPrefixesSource(System.Collections.Generic.IEnumerable<string> prefixes) { }
        public System.Collections.Generic.IList<string> Prefixes { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringAddressPrefixesSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class UrlFilteringDestination : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>
    {
        internal UrlFilteringDestination() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlFilteringFqdnsDestination : Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>
    {
        public UrlFilteringFqdnsDestination(System.Collections.Generic.IEnumerable<string> fqdns) { }
        public System.Collections.Generic.IList<string> Fqdns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringFqdnsDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UrlFilteringHttpMethod : System.IEquatable<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UrlFilteringHttpMethod(string value) { throw null; }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Delete { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Get { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Head { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Options { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Patch { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Post { get { throw null; } }
        public static Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod Put { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod left, Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod left, Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UrlFilteringPolicy : Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>
    {
        public UrlFilteringPolicy(Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction defaultAction, Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource source, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule> rules) { }
        public Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction DefaultAction { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination Destination { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule> Rules { get { throw null; } }
        public Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource Source { get { throw null; } set { } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlFilteringRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>
    {
        public UrlFilteringRule(string name, int priority) { }
        public Azure.ResourceManager.NetworkSecurity.Models.NetworkSecurityPolicyAction? Action { get { throw null; } set { } }
        public string Hostname { get { throw null; } set { } }
        public Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringHttpMethod? Method { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Paths { get { throw null; } }
        public int Priority { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class UrlFilteringSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>
    {
        internal UrlFilteringSource() { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlFilteringWorkloadIdPatternsDestination : Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>
    {
        public UrlFilteringWorkloadIdPatternsDestination(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlFilteringWorkloadIdPatternsSource : Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>
    {
        public UrlFilteringWorkloadIdPatternsSource(System.Collections.Generic.IEnumerable<string> patterns) { }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetworkSecurity.Models.UrlFilteringWorkloadIdPatternsSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
