namespace Azure.ResourceManager.PrivateTrafficManager
{
    public partial class AzureResourceManagerPrivateTrafficManagerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPrivateTrafficManagerContext() { }
        public static Azure.ResourceManager.PrivateTrafficManager.AzureResourceManagerPrivateTrafficManagerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
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
    public partial class PrivateTrafficManagerEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>, System.Collections.IEnumerable
    {
        protected PrivateTrafficManagerEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateTrafficManagerEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>
    {
        public PrivateTrafficManagerEndpointData() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateTrafficManagerEndpointResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string privateTrafficManagerProfileName, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PrivateTrafficManagerExtensions
    {
        public static Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource GetHealthPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource GetPrivateTrafficManagerEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource>> GetPrivateTrafficManagerProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string privateTrafficManagerProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource GetPrivateTrafficManagerProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileCollection GetPrivateTrafficManagerProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource> GetPrivateTrafficManagerProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource GetProfileProbingGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMap(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource>> GetTopologyMapAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string topologyMapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource GetTopologyMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapCollection GetTopologyMaps(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMaps(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource> GetTopologyMapsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource GetTopologyMapSiteResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.PrivateTrafficManager.HealthPolicyCollection GetHealthPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource> GetHealthPolicy(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource>> GetHealthPolicyAsync(string healthPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource> GetPrivateTrafficManagerEndpoint(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource>> GetPrivateTrafficManagerEndpointAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointCollection GetPrivateTrafficManagerEndpoints() { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> GetTopologyMapSite(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>> GetTopologyMapSiteAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteCollection GetTopologyMapSites() { throw null; }
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
    public partial class TopologyMapSiteCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>, System.Collections.IEnumerable
    {
        protected TopologyMapSiteCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteName, Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> Get(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>> GetAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> GetIfExists(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>> GetIfExistsAsync(string siteName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TopologyMapSiteData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>
    {
        public TopologyMapSiteData() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapSiteResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TopologyMapSiteResource() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string topologyMapName, string siteName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PrivateTrafficManager.Mocking
{
    public partial class MockablePrivateTrafficManagerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePrivateTrafficManagerArmClient() { }
        public virtual Azure.ResourceManager.PrivateTrafficManager.HealthPolicyResource GetHealthPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointResource GetPrivateTrafficManagerEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileResource GetPrivateTrafficManagerProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayResource GetProfileProbingGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapResource GetTopologyMapResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteResource GetTopologyMapSiteResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    public static partial class ArmPrivateTrafficManagerModelFactory
    {
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange ExpectedStatusCodeRange(int? min = default(int?), int? max = default(int?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.HealthPolicyData HealthPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties properties = null, string kind = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties HealthPolicyProperties(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig probeConfig = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig PrivateTrafficManagerDnsConfig(Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType? recordType = default(Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType?), long? timeToLiveInSeconds = default(long?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerEndpointData PrivateTrafficManagerEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch PrivateTrafficManagerEndpointPatch(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties PrivateTrafficManagerEndpointPatchProperties(string target = null, string monitoringTarget = null, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? endpointStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus?), long? weight = default(long?), long? priority = default(long?), Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? alwaysServe = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe?), Azure.Core.ResourceIdentifier healthPolicyId = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties PrivateTrafficManagerEndpointProperties(string target = null, string monitoringTarget = null, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? endpointStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind? kind = default(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind?), long? weight = default(long?), long? priority = default(long?), Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? alwaysServe = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe?), Azure.Core.ResourceIdentifier healthPolicyId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.PrivateTrafficManagerProfileData PrivateTrafficManagerProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch PrivateTrafficManagerProfilePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties PrivateTrafficManagerProfilePatchProperties(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? customTopologyMapMode = default(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode?), Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig dnsConfig = null, Azure.Core.ResourceIdentifier topologyMapId = null, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus? profileStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? trafficRoutingMethod = default(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> endpoints = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties PrivateTrafficManagerProfileProperties(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? customTopologyMapMode = default(Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode?), Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig dnsConfig = null, Azure.Core.ResourceIdentifier topologyMapId = null, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus? profileStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? trafficRoutingMethod = default(Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> endpoints = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig ProbeConfig(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol? protocol = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol?), long? port = default(long?), string path = null, long? intervalInSeconds = default(long?), long? timeoutInSeconds = default(long?), long? toleratedNumberOfFailures = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader> customHeaders = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange> expectedStatusCodeRanges = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader ProbeCustomHeader(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeHealthPolicy ProbeHealthPolicy(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.HealthPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint ProfileEndpoint(string name = null, string target = null, string monitoringTarget = null, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? endpointStatus = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus?), Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind? kind = default(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind?), long? weight = default(long?), long? priority = default(long?), Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? alwaysServe = default(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe?), Azure.Core.ResourceIdentifier healthPolicyId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.ProfileProbingGatewayData ProfileProbingGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayPatch ProfileProbingGatewayPatch(Azure.Core.ResourceIdentifier probingGatewayId = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProfileProbingGatewayProperties ProfileProbingGatewayProperties(Azure.Core.ResourceIdentifier probingGatewayId = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapData TopologyMapData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite TopologyMapInlineSite(string name = null, Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapPatch TopologyMapPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string catchAllSiteName = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapProperties TopologyMapProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite> sites = null, string catchAllSiteName = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.TopologyMapSiteData TopologyMapSiteData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch TopologyMapSitePatch(Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties TopologyMapSitePatchProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> probingGatewayIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualNetworkIds = null) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties TopologyMapSiteProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> probingGatewayIds = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> virtualNetworkIds = null, Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState?)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DnsRecordType : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DnsRecordType(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType A { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType AAAA { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType CNAME { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType left, Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType left, Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointAdministrativeStatus : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointAdministrativeStatus(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointAlwaysServe : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointAlwaysServe(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe left, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe left, Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class PrivateTrafficManagerDnsConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>
    {
        public PrivateTrafficManagerDnsConfig() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.DnsRecordType? RecordType { get { throw null; } set { } }
        public long? TimeToLiveInSeconds { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateTrafficManagerEndpointKind : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateTrafficManagerEndpointKind(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind Endpoint { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind left, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind left, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateTrafficManagerEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>
    {
        public PrivateTrafficManagerEndpointPatch() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerEndpointPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>
    {
        public PrivateTrafficManagerEndpointPatchProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? AlwaysServe { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? EndpointStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HealthPolicyId { get { throw null; } set { } }
        public string MonitoringTarget { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>
    {
        public PrivateTrafficManagerEndpointProperties(string target) { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? AlwaysServe { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? EndpointStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HealthPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind? Kind { get { throw null; } set { } }
        public string MonitoringTarget { get { throw null; } set { } }
        public long? Priority { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Target { get { throw null; } set { } }
        public long? Weight { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerProfilePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatch>
    {
        public PrivateTrafficManagerProfilePatch() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties Properties { get { throw null; } set { } }
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
    public partial class PrivateTrafficManagerProfilePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>
    {
        public PrivateTrafficManagerProfilePatchProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? CustomTopologyMapMode { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> Endpoints { get { throw null; } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TopologyMapId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfilePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateTrafficManagerProfileProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>
    {
        public PrivateTrafficManagerProfileProperties() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.CustomTopologyMapMode? CustomTopologyMapMode { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerDnsConfig DnsConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint> Endpoints { get { throw null; } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus? ProfileStatus { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier TopologyMapId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TrafficRoutingMethod? TrafficRoutingMethod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateTrafficManagerProfileStatus : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateTrafficManagerProfileStatus(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus left, Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerProfileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProbeConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeConfig>
    {
        public ProbeConfig() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader> CustomHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PrivateTrafficManager.Models.ExpectedStatusCodeRange> ExpectedStatusCodeRanges { get { throw null; } }
        public long? IntervalInSeconds { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol? Protocol { get { throw null; } set { } }
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
    public partial class ProbeCustomHeader : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>
    {
        public ProbeCustomHeader() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeCustomHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProbeProtocol : System.IEquatable<Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProbeProtocol(string value) { throw null; }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol Tcp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol left, Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol left, Azure.ResourceManager.PrivateTrafficManager.Models.ProbeProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProfileEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.ProfileEndpoint>
    {
        public ProfileEndpoint(string name, string target) { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAlwaysServe? AlwaysServe { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.EndpointAdministrativeStatus? EndpointStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HealthPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.PrivateTrafficManagerEndpointKind? Kind { get { throw null; } set { } }
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
    public partial class TopologyMapInlineSite : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapInlineSite>
    {
        public TopologyMapInlineSite(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties Properties { get { throw null; } set { } }
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
        public string CatchAllSiteName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
    public partial class TopologyMapSitePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>
    {
        public TopologyMapSitePatch() { }
        public Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapSitePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>
    {
        public TopologyMapSitePatchProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ProbingGatewayIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VirtualNetworkIds { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSitePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TopologyMapSiteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>
    {
        public TopologyMapSiteProperties() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ProbingGatewayIds { get { throw null; } }
        public Azure.ResourceManager.PrivateTrafficManager.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> VirtualNetworkIds { get { throw null; } }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PrivateTrafficManager.Models.TopologyMapSiteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
