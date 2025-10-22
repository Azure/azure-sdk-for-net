namespace Azure.ResourceManager.ServiceNetworking
{
    public partial class ApplicationGatewayForContainersSecurityPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>, System.Collections.IEnumerable
    {
        protected ApplicationGatewayForContainersSecurityPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string securityPolicyName, Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string securityPolicyName, Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> Get(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> GetAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> GetIfExists(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> GetIfExistsAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ApplicationGatewayForContainersSecurityPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>
    {
        public ApplicationGatewayForContainersSecurityPolicyData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType? PolicyType { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule> Rules { get { throw null; } }
        public Azure.Core.ResourceIdentifier WafPolicyId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationGatewayForContainersSecurityPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ApplicationGatewayForContainersSecurityPolicyResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string securityPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> Update(Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerAssociationCollection` moving forward.")]
    public partial class AssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>, System.Collections.IEnumerable
    {
        protected AssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.AssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.AssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.AssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.AssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetIfExists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetIfExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.AssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.AssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.AssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerAssociationData` moving forward.")]
    public partial class AssociationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>
    {
        public AssociationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ServiceNetworking.Models.AssociationType? AssociationType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.AssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.AssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerAssociationResource` moving forward.")]
    public partial class AssociationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssociationResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.AssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string associationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceNetworking.AssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.AssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.AssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> Update(Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerServiceNetworkingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerServiceNetworkingContext() { }
        public static Azure.ResourceManager.ServiceNetworking.AzureResourceManagerServiceNetworkingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerFrontendCollection` moving forward.")]
    public partial class FrontendCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>, System.Collections.IEnumerable
    {
        protected FrontendCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.FrontendResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.FrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.FrontendResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.FrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> Get(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetIfExists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetIfExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.FrontendResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.FrontendResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.FrontendResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerFrontendData` moving forward.")]
    public partial class FrontendData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>
    {
        public FrontendData(Azure.Core.AzureLocation location) { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.FrontendData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.FrontendData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerFrontendResource` moving forward.")]
    public partial class FrontendResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FrontendResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.FrontendData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string frontendName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceNetworking.FrontendData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.FrontendData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.FrontendData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> Update(Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ServiceNetworkingExtensions
    {
        public static Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource GetApplicationGatewayForContainersSecurityPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerAssociationResource` moving forward.")]
        public static Azure.ResourceManager.ServiceNetworking.AssociationResource GetAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerFrontendResource` moving forward.")]
        public static Azure.ResourceManager.ServiceNetworking.FrontendResource GetFrontendResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficController(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource GetTrafficControllerAssociationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetTrafficControllerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource GetTrafficControllerFrontendResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerResource GetTrafficControllerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerCollection GetTrafficControllers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficControllerAssociationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>, System.Collections.IEnumerable
    {
        protected TrafficControllerAssociationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string associationName, Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> Get(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> GetAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> GetIfExists(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> GetIfExistsAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficControllerAssociationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>
    {
        public TrafficControllerAssociationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType? AssociationType { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficControllerAssociationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficControllerAssociationResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string associationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> Update(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficControllerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>, System.Collections.IEnumerable
    {
        protected TrafficControllerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string trafficControllerName, Azure.ResourceManager.ServiceNetworking.TrafficControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string trafficControllerName, Azure.ResourceManager.ServiceNetworking.TrafficControllerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> Get(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetIfExists(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetIfExistsAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficControllerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>
    {
        public TrafficControllerData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Associations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ConfigurationEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> Frontends { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property is now deprecated. Please use `TrafficControllerProvisioningState` moving forward.")]
        public Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> SecurityPolicies { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations SecurityPolicyConfigurations { get { throw null; } set { } }
        public Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? TrafficControllerProvisioningState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier WafSecurityPolicyId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficControllerFrontendCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>, System.Collections.IEnumerable
    {
        protected TrafficControllerFrontendCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string frontendName, Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> Get(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> GetAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> GetIfExists(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> GetIfExistsAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TrafficControllerFrontendData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>
    {
        public TrafficControllerFrontendData(Azure.Core.AzureLocation location) { }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations SecurityPolicyConfigurations { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficControllerFrontendResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficControllerFrontendResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName, string frontendName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> Update(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TrafficControllerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TrafficControllerResource() { }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string trafficControllerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyCollection GetApplicationGatewayForContainersSecurityPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource> GetApplicationGatewayForContainersSecurityPolicy(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource>> GetApplicationGatewayForContainersSecurityPolicyAsync(string securityPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerAssociation` moving forward.")]
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource> GetAssociation(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerAssociationAsync` moving forward.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.AssociationResource>> GetAssociationAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerAssociations` moving forward.")]
        public virtual Azure.ResourceManager.ServiceNetworking.AssociationCollection GetAssociations() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerFrontend` moving forward.")]
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource> GetFrontend(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerFrontendAsync` moving forward.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.FrontendResource>> GetFrontendAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerFrontends` moving forward.")]
        public virtual Azure.ResourceManager.ServiceNetworking.FrontendCollection GetFrontends() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource> GetTrafficControllerAssociation(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource>> GetTrafficControllerAssociationAsync(string associationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationCollection GetTrafficControllerAssociations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource> GetTrafficControllerFrontend(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource>> GetTrafficControllerFrontendAsync(string frontendName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendCollection GetTrafficControllerFrontends() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.TrafficControllerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.TrafficControllerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> Update(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> UpdateAsync(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceNetworking.Mocking
{
    public partial class MockableServiceNetworkingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceNetworkingArmClient() { }
        public virtual Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyResource GetApplicationGatewayForContainersSecurityPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerAssociationResource` moving forward.")]
        public virtual Azure.ResourceManager.ServiceNetworking.AssociationResource GetAssociationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `GetTrafficControllerFrontendResource` moving forward.")]
        public virtual Azure.ResourceManager.ServiceNetworking.FrontendResource GetFrontendResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationResource GetTrafficControllerAssociationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendResource GetTrafficControllerFrontendResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerResource GetTrafficControllerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableServiceNetworkingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceNetworkingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficController(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource>> GetTrafficControllerAsync(string trafficControllerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ServiceNetworking.TrafficControllerCollection GetTrafficControllers() { throw null; }
    }
    public partial class MockableServiceNetworkingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableServiceNetworkingSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ServiceNetworking.TrafficControllerResource> GetTrafficControllersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ServiceNetworking.Models
{
    public partial class ApplicationGatewayForContainersSecurityPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>
    {
        public ApplicationGatewayForContainersSecurityPolicyPatch() { }
        public Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier WafPolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationGatewayForContainersSecurityPolicyType : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationGatewayForContainersSecurityPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType IPAccessRules { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType WAF { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType left, Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType left, Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmServiceNetworkingModelFactory
    {
        public static Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData ApplicationGatewayForContainersSecurityPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType? policyType = default(Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType?), Azure.Core.ResourceIdentifier wafPolicyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule> rules = null, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ServiceNetworking.ApplicationGatewayForContainersSecurityPolicyData ApplicationGatewayForContainersSecurityPolicyData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceNetworking.Models.ApplicationGatewayForContainersSecurityPolicyType? policyType, Azure.Core.ResourceIdentifier wafPolicyId, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? provisioningState) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `TrafficControllerAssociationData` moving forward.")]
        public static Azure.ResourceManager.ServiceNetworking.AssociationData AssociationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.ServiceNetworking.Models.AssociationType? associationType, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? provisioningState) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is now deprecated. Please use `TrafficControllerFrontedData` moving forward.")]
        public static Azure.ResourceManager.ServiceNetworking.FrontendData FrontendData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string fqdn, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerAssociationData TrafficControllerAssociationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType? associationType = default(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType?), Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerData TrafficControllerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> configurationEndpoints, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> frontends, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> associations, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> securityPolicies, Azure.Core.ResourceIdentifier wafSecurityPolicyId, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? trafficControllerProvisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerData TrafficControllerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<string> configurationEndpoints = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> frontends = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> associations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> securityPolicies = null, Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations securityPolicyConfigurations = null, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? trafficControllerProvisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerData TrafficControllerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, System.Collections.Generic.IEnumerable<string> configurationEndpoints, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> frontends, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> associations, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData TrafficControllerFrontendData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string fqdn = null, Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations securityPolicyConfigurations = null, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? provisioningState = default(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ServiceNetworking.TrafficControllerFrontendData TrafficControllerFrontendData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string fqdn, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState? provisioningState) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerAssociationPatch` moving forward.")]
    public partial class AssociationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>
    {
        public AssociationPatch() { }
        public Azure.ResourceManager.ServiceNetworking.Models.AssociationType? AssociationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.AssociationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerAssociationType` moving forward.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssociationType : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.AssociationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssociationType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.AssociationType Subnets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.AssociationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.AssociationType left, Azure.ResourceManager.ServiceNetworking.Models.AssociationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.AssociationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.AssociationType left, Azure.ResourceManager.ServiceNetworking.Models.AssociationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `TrafficControllerFrontendPatch` moving forward.")]
    public partial class FrontendPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>
    {
        public FrontendPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.FrontendPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.ObsoleteAttribute("This class is now deprecated. Please use the new class `ServiceNetworkingProvisioningState` moving forward.")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState left, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState left, Azure.ResourceManager.ServiceNetworking.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPolicyConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>
    {
        public SecurityPolicyConfigurations() { }
        public Azure.Core.ResourceIdentifier IPAccessRulesSecurityPolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WafSecurityPolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecurityPolicyUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>
    {
        public SecurityPolicyUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule> Rules { get { throw null; } }
        public Azure.Core.ResourceIdentifier WafPolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceNetworkingIPAccessRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>
    {
        public ServiceNetworkingIPAccessRule(string name, int priority, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction action) { }
        public Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceNetworkingIPAccessRuleAction : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceNetworkingIPAccessRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction left, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction left, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingIPAccessRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceNetworkingProvisioningState : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceNetworkingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState left, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState left, Azure.ResourceManager.ServiceNetworking.Models.ServiceNetworkingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficControllerAssociationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>
    {
        public TrafficControllerAssociationPatch() { }
        public Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType? AssociationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficControllerAssociationType : System.IEquatable<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficControllerAssociationType(string value) { throw null; }
        public static Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType Subnets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType left, Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType left, Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerAssociationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficControllerFrontendPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>
    {
        public TrafficControllerFrontendPatch() { }
        public Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations FrontendUpdateSecurityPolicyConfigurations { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerFrontendPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficControllerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>
    {
        public TrafficControllerPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.ServiceNetworking.Models.SecurityPolicyConfigurations TrafficControllerUpdateSecurityPolicyConfigurations { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier WafSecurityPolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ServiceNetworking.Models.TrafficControllerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
