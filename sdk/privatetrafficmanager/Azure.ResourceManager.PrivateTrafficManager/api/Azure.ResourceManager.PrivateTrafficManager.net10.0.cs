namespace Azure.ResourceManager.PrivateTrafficManager
{
    public partial class AzureResourceManagerPrivateTrafficManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPrivateTrafficManagerContext() { }
        public static Azure.ResourceManager.PrivateTrafficManager.AzureResourceManagerPrivateTrafficManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>, System.Collections.IEnumerable
    {
        protected EndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.PrivateTrafficManager.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.PrivateTrafficManager.EndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>
    {
        public EndpointData() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.EndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.EndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.EndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateTrafficManagerProfileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.EndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.EndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.EndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>, System.Collections.IEnumerable
    {
        protected HealthPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string healthPolicyName, Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string healthPolicyName, Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> Get(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> GetAsync(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> GetIfExists(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> GetIfExistsAsync(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class HealthPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>
    {
        internal HealthPolicyData() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthPolicyResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateTrafficManagerProfileName, string healthPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PrivateTrafficManagerExtensions
    {
        public static Azure.ResourceManager.PrivateTrafficManager.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource GetHealthPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> GetPrivateTrafficManagerProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource GetPrivateTrafficManagerProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileCollection GetPrivateTrafficManagerProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource GetProfileProbingGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.SiteResource GetSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMap(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> GetTopologyMapAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource GetTopologyMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapCollection GetTopologyMaps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMaps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMapsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateTrafficManagerProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>, System.Collections.IEnumerable
    {
        protected PrivateTrafficManagerProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateTrafficManagerProfileName, Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateTrafficManagerProfileName, Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> Get(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> GetAsync(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetIfExists(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> GetIfExistsAsync(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateTrafficManagerProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>
    {
        public PrivateTrafficManagerProfileData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateTrafficManagerProfileResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateTrafficManagerProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.EndpointResource> GetEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.EndpointResource>> GetEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.EndpointCollection GetEndpoints() { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.HealthPolicyCollection GetHealthPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> GetHealthPolicy(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> GetHealthPolicyAsync(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> GetProfileProbingGateway(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>> GetProfileProbingGatewayAsync(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayCollection GetProfileProbingGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfileProbingGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>, System.Collections.IEnumerable
    {
        protected ProfileProbingGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileProbingGatewayName, Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileProbingGatewayName, Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> Get(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>> GetAsync(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> GetIfExists(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>> GetIfExistsAsync(string profileProbingGatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfileProbingGatewayData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>
    {
        public ProfileProbingGatewayData() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileProbingGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfileProbingGatewayResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateTrafficManagerProfileName, string profileProbingGatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.SiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.SiteResource>, System.Collections.IEnumerable
    {
        protected SiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.SiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.PrivateTrafficManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.SiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.PrivateTrafficManager.SiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.SiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.SiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.SiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.SiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.SiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.SiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.SiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.SiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.SiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.SiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>
    {
        public SiteData() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.SiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.SiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.SiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topologyMapName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.SiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.SiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.SiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.SiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.SiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.SiteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.SiteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TopologyMapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>, System.Collections.IEnumerable
    {
        protected TopologyMapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string topologyMapName, Azure.ResourceManager.PrivateTrafficManager.TopologyMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string topologyMapName, Azure.ResourceManager.PrivateTrafficManager.TopologyMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> Get(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> GetAsync(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetIfExists(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> GetIfExistsAsync(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopologyMapData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>
    {
        public TopologyMapData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopologyMapResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topologyMapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.SiteResource> GetSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.SiteResource>> GetSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.SiteCollection GetSites() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrivateTrafficManager.Mocking
{
    public partial class MockablePrivateTrafficManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateTrafficManagerArmClient() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.EndpointResource GetEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource GetHealthPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource GetPrivateTrafficManagerProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource GetProfileProbingGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.SiteResource GetSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource GetTopologyMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePrivateTrafficManagerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateTrafficManagerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfile(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> GetPrivateTrafficManagerProfileAsync(string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileCollection GetPrivateTrafficManagerProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMap(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> GetTopologyMapAsync(string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapCollection GetTopologyMaps() { throw null; }
    }
    public partial class MockablePrivateTrafficManagerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateTrafficManagerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMaps(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMapsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrivateTrafficManager.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdministrativeStatus : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdministrativeStatus(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlwaysServe : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlwaysServe(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe left, Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe left, Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmPrivateTrafficManagerModelFactory
    {
        public static Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader CustomHeader(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig DnsConfig(Azure.ResourceManager.PrivateTrafficManager.Models.RecordType? recordType = default(Azure.ResourceManager.PrivateTrafficManager.Models.RecordType?), long? ttl = default(long?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.EndpointData EndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch EndpointPatch(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties EndpointProperties(string target = null, string monitoringTarget = null, Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? endpointStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind? kind = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind?), long? weight = default(long?), long? priority = default(long?), Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? alwaysServe = default(Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe?), Azure.Core.ResourceIdentifier healthPolicyId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties EndpointUpdateProperties(string target = null, string monitoringTarget = null, Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? endpointStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus?), long? weight = default(long?), long? priority = default(long?), Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? alwaysServe = default(Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe?), Azure.Core.ResourceIdentifier healthPolicyId = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange ExpectedStatusCodeRange(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData HealthPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties properties = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties HealthPolicyProperties(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig probeConfig = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData PrivateTrafficManagerProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch PrivateTrafficManagerProfilePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties PrivateTrafficManagerProfileUpdateProperties(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? customTopologyMapMode = default(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode?), Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig dnsConfig = null, Azure.Core.ResourceIdentifier topologyMapId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus? profileStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? trafficRoutingMethod = default(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> endpoints = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig ProbeConfig(Azure.ResourceManager.PrivateTrafficManager.Models.Protocol? protocol = default(Azure.ResourceManager.PrivateTrafficManager.Models.Protocol?), long? port = default(long?), string path = null, long? intervalInSeconds = default(long?), long? timeoutInSeconds = default(long?), long? toleratedNumberOfFailures = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader> customHeaders = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange> expectedStatusCodeRanges = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy ProbeHealthPolicy(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint ProfileEndpoint(string name = null, string target = null, string monitoringTarget = null, Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? endpointStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind? kind = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind?), long? weight = default(long?), long? priority = default(long?), Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? alwaysServe = default(Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe?), Azure.Core.ResourceIdentifier healthPolicyId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData ProfileProbingGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch ProfileProbingGatewayPatch(Azure.Core.ResourceIdentifier probingGatewayId = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties ProfileProbingGatewayProperties(Azure.Core.ResourceIdentifier probingGatewayId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties ProfileProperties(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? customTopologyMapMode = default(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode?), Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig dnsConfig = null, Azure.Core.ResourceIdentifier topologyMapId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus? profileStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? trafficRoutingMethod = default(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> endpoints = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.SiteData SiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch SitePatch(Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties SiteProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> probingGatewayIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualNetworkIds = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties SiteUpdateProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> probingGatewayIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualNetworkIds = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapData TopologyMapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite TopologyMapInlineSite(string name = null, Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch TopologyMapPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string topologyMapPatchCatchAllSiteName = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties TopologyMapProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite> sites = null, string catchAllSiteName = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
    }
    public partial class CustomHeader : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>
    {
        public CustomHeader() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomTopologyMapMode : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomTopologyMapMode(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode left, Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode left, Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DnsConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>
    {
        public DnsConfig() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.RecordType? RecordType { get { throw null; } set { } }
        public long? Ttl { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>
    {
        public EndpointPatch() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>
    {
        public EndpointProperties(string target) { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? AlwaysServe { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? EndpointStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HealthPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind? Kind { get { throw null; } set { } }
        public string MonitoringTarget { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointsKind : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointsKind(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind Endpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind left, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind left, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>
    {
        public EndpointUpdateProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? AlwaysServe { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? EndpointStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HealthPolicyId { get { throw null; } set { } }
        public string MonitoringTarget { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExpectedStatusCodeRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>
    {
        public ExpectedStatusCodeRange() { }
        public int? Max { get { throw null; } set { } }
        public int? Min { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>
    {
        public HealthPolicyProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig ProbeConfig { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>
    {
        public PrivateTrafficManagerProfilePatch() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerProfileUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>
    {
        public PrivateTrafficManagerProfileUpdateProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? CustomTopologyMapMode { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> Endpoints { get { throw null; } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TopologyMapId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>
    {
        public ProbeConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.CustomHeader> CustomHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange> ExpectedStatusCodeRanges { get { throw null; } }
        public long? IntervalInSeconds { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.Protocol? Protocol { get { throw null; } set { } }
        public long? TimeoutInSeconds { get { throw null; } set { } }
        public long? ToleratedNumberOfFailures { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHealthPolicy : Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>
    {
        public ProbeHealthPolicy() { }
        protected override Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>
    {
        public ProfileEndpoint(string name, string target) { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.AlwaysServe? AlwaysServe { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.AdministrativeStatus? EndpointStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HealthPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointsKind? Kind { get { throw null; } set { } }
        public string MonitoringTarget { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileProbingGatewayPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>
    {
        public ProfileProbingGatewayPatch() { }
        public Azure.Core.ResourceIdentifier ProbingGatewayId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileProbingGatewayProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>
    {
        public ProfileProbingGatewayProperties(Azure.Core.ResourceIdentifier probingGatewayId) { }
        public Azure.Core.ResourceIdentifier ProbingGatewayId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>
    {
        public ProfileProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? CustomTopologyMapMode { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.DnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> Endpoints { get { throw null; } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TopologyMapId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProfileStatus : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.Protocol HTTP { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.Protocol HTTPS { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.Protocol TCP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.Protocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.Protocol left, Azure.ResourceManager.PrivateTrafficManager.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.Protocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.Protocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.Protocol left, Azure.ResourceManager.PrivateTrafficManager.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState left, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState left, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecordType : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.RecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecordType(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.RecordType A { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.RecordType AAAA { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.RecordType CNAME { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.RecordType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.RecordType left, Azure.ResourceManager.PrivateTrafficManager.Models.RecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.RecordType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.RecordType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.RecordType left, Azure.ResourceManager.PrivateTrafficManager.Models.RecordType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SitePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>
    {
        public SitePatch() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SitePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>
    {
        public SiteProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ProbingGatewayIds { get { throw null; } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VirtualNetworkIds { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>
    {
        public SiteUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ProbingGatewayIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VirtualNetworkIds { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.SiteUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapInlineSite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>
    {
        public TopologyMapInlineSite(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.SiteProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>
    {
        public TopologyMapPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TopologyMapPatchCatchAllSiteName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>
    {
        public TopologyMapProperties() { }
        public string CatchAllSiteName { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite> Sites { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficRoutingMethod : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficRoutingMethod(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod Priority { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod Weighted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod left, Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod left, Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
}
