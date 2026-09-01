namespace Azure.ResourceManager.ProgrammableConnectivity
{
    public partial class AzureResourceManagerProgrammableConnectivityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerProgrammableConnectivityContext() { }
        public static Azure.ResourceManager.ProgrammableConnectivity.AzureResourceManagerProgrammableConnectivityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class OperatorApiConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>, System.Collections.IEnumerable
    {
        protected OperatorApiConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string operatorApiConnectionName, Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string operatorApiConnectionName, Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> Get(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> GetAsync(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetIfExists(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> GetIfExistsAsync(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperatorApiConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>
    {
        public OperatorApiConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperatorApiConnectionResource() { }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string operatorApiConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperatorApiPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>, System.Collections.IEnumerable
    {
        protected OperatorApiPlanCollection() { }
        public virtual Azure.Response<bool> Exists(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> Get(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetAll(string filter = null, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetAllAsync(string filter = null, int? maxCount = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>> GetAsync(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetIfExists(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>> GetIfExistsAsync(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OperatorApiPlanData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>
    {
        internal OperatorApiPlanData() { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OperatorApiPlanResource() { }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string operatorApiPlanName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ProgrammableConnectivityExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> GetOperatorApiConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource GetOperatorApiConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionCollection GetOperatorApiConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnections(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnectionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetOperatorApiPlan(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>> GetOperatorApiPlanAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource GetOperatorApiPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanCollection GetOperatorApiPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetProgrammableConnectivityGateway(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> GetProgrammableConnectivityGatewayAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource GetProgrammableConnectivityGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayCollection GetProgrammableConnectivityGateways(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetProgrammableConnectivityGateways(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetProgrammableConnectivityGatewaysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProgrammableConnectivityGatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>, System.Collections.IEnumerable
    {
        protected ProgrammableConnectivityGatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetIfExists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> GetIfExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProgrammableConnectivityGatewayData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>
    {
        public ProgrammableConnectivityGatewayData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgrammableConnectivityGatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProgrammableConnectivityGatewayResource() { }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> Update(Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> UpdateAsync(Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProgrammableConnectivity.Mocking
{
    public partial class MockableProgrammableConnectivityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableProgrammableConnectivityArmClient() { }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource GetOperatorApiConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource GetOperatorApiPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource GetProgrammableConnectivityGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableProgrammableConnectivityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProgrammableConnectivityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnection(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> GetOperatorApiConnectionAsync(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionCollection GetOperatorApiConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetProgrammableConnectivityGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource>> GetProgrammableConnectivityGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayCollection GetProgrammableConnectivityGateways() { throw null; }
    }
    public partial class MockableProgrammableConnectivitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProgrammableConnectivitySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetOperatorApiPlan(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>> GetOperatorApiPlanAsync(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanCollection GetOperatorApiPlans() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetProgrammableConnectivityGateways(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayResource> GetProgrammableConnectivityGatewaysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProgrammableConnectivity.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationCategory : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationCategory(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Agriculture { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory ArtAndDesign { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory AutoAndVehicle { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Beauty { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory BooksAndReference { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Business { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Construction { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Defense { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory DeveloperTools { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Education { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Engineering { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory EventsAndEntertainment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Finance { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory FoodAndDrink { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Games { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory HealthAndFitness { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Healthcare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Information { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Kids { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory LibrariesAndDemo { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Lifestyle { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Manufacturing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory MapsAndNavigation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Media { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Medical { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Mining { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory MusicAndAudio { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory NewsAndMagazines { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Organizations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Other { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory PhotoAndVideo { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Productivity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory PublicService { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory RealEstate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Shopping { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory SocialNetworkingAndCommunications { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Sports { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Tourism { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Trading { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Transportation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory TravelAndLocal { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Utilities { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Water { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Weather { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory left, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory left, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationContactPerson : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>
    {
        public ApplicationContactPerson(string familyName, string givenName, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string FamilyName { get { throw null; } set { } }
        public string GivenName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationGeographicAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>
    {
        public ApplicationGeographicAddress(string countryCode) { }
        public string City { get { throw null; } set { } }
        public string CountryCode { get { throw null; } set { } }
        public string Locality { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetName { get { throw null; } set { } }
        public string StreetNumber { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationLocalRepresentative : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>
    {
        public ApplicationLocalRepresentative(string countryCode, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson representative) { }
        public string CountryCode { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson Representative { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationOwnerOrganizationType : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationOwnerOrganizationType(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType AcademicScientificOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType ForProfitOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType GovernmentalOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType IndustryConsortium { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType InternationalOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType NonGovernmentalOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType NonProfitOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType OrganizationalUnit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType left, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType left, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmProgrammableConnectivityModelFactory
    {
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson ApplicationContactPerson(string familyName = null, string givenName = null, string emailAddress = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress ApplicationGeographicAddress(string streetNumber = null, string streetName = null, string locality = null, string city = null, string stateOrProvince = null, string postalCode = null, string countryCode = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative ApplicationLocalRepresentative(string countryCode = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson representative = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties GatewayApplicationOwnerProperties(string name = null, string legalName = null, string tradingName = null, string organizationDescription = null, string taxNumber = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType organizationType = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType), string organizationIdentificationId = null, string organizationIdentificationIssuer = null, string organizationIdentificationType = null, string contactEmailAddress = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson legalRepresentative = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson privacyManager = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson dataProtectionOfficer = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress registeredGeographicAddress = null, System.Uri privacyPolicyUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative> localRepresentatives = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties GatewayApplicationProperties(string name = null, string applicationDescription = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory category = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory), string commercialName = null, string privacyRightsRequestEmailAddress = null, System.Uri privacyPolicyUri = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData OperatorApiConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing OperatorApiConnectionDataProcessing(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation processingOperation = default(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext> contexts = null, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration duration = default(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration), Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency frequency = default(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion> transitRegions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion> storageRegions = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion OperatorApiConnectionDataRegion(string countryCode = null, string commercialOrganization = null, bool isCommercialActivity = false, System.Uri dataPrivacyFrameworkUri = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch OperatorApiConnectionPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties OperatorApiConnectionProperties(Azure.Core.ResourceIdentifier operatorApiPlanId = null, Azure.Core.ResourceIdentifier gatewayId = null, string operatorName = null, string camaraApiName = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState?), Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus status = null, bool isPlanTermsAndConditionsAccepted = false, System.Collections.Generic.IEnumerable<string> planTermsAndConditionsLinks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose> purposes = null, string purposeReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing> dataProcessingList = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus OperatorApiConnectionStatus(string state = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties OperatorApiConnectionUpdateProperties(Azure.Core.ResourceIdentifier operatorApiPlanId = null, bool? isPlanTermsAndConditionsAccepted = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose> purposes = null, string purposeReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing> dataProcessingList = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData OperatorApiPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties OperatorApiPlanMarketplaceProperties(string offerId = null, string publisherId = null, string planId = null, System.Collections.Generic.IEnumerable<string> planTermsAndConditionsLinks = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties OperatorApiPlanProperties(string operatorName = null, string camaraApiName = null, System.Collections.Generic.IEnumerable<string> supportedLocations = null, System.Collections.Generic.IEnumerable<string> operatorRegions = null, System.Collections.Generic.IEnumerable<string> markets = null, string limits = null, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties marketplaceProperties = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.ProgrammableConnectivityGatewayData ProgrammableConnectivityGatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch ProgrammableConnectivityGatewayPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties ProgrammableConnectivityGatewayProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> operatorApiConnections = null, string gatewayBaseUri = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState?), Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties configuredApplication = null, Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties configuredApplicationOwner = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProcessingContext : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProcessingContext(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext AlgorithmicLogic { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext AssistiveAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext AutomatedDecisionMaking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext AutomatedScoringOfIndividuals { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext AutomationLevel { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext Autonomous { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotChallengeProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotChallengeProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotChallengeProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotCorrectProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotCorrectProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotCorrectProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotObjectToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotOptInToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotOptOutFromProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotReverseProcessEffects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotReverseProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotReverseProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CannotWithdrawFromProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ChallengingProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ChallengingProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ChallengingProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CompletelyManualProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ConditionalAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ConsentControl { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CorrectingProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CorrectingProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext CorrectingProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataControllerDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataPublishedByDataSubject { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataSubject { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataSubjectDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataSubjectScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext DecisionMaking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EntityActiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EntityInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EntityNonInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EntityNonPermissiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EntityPassiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EntityPermissiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EvaluationOfIndividuals { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext EvaluationScoring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext FullAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext GeographicCoverage { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext GlobalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HighAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HugeDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HugeScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolved { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvementForControl { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvementForDecision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvementForInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvementForIntervention { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvementForOversight { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanInvolvementForVerification { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext HumanNotInvolved { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext InnovativeUseOfExistingTechnology { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext InnovativeUseOfNewTechnologies { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext InnovativeUseOfTechnology { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext LargeDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext LargeScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext LargeScaleProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext LocalEnvironmentScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext LocalityScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext MediumDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext MediumScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext MediumScaleProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext MultiNationalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext NationalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext NearlyGlobalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext NonPublicDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext NotAutomated { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ObjectingToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ObtainConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext OptingInToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext OptingOutFromProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext PartialAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ProcessingCondition { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ProcessingDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ProcessingLocation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ProcessingScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ProvideConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext PublicDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ReaffirmConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext RegionalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ReversingProcessEffects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ReversingProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ReversingProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext Scale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ScoringOfIndividuals { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SingularDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SingularScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SmallDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SmallScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SmallScaleProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SporadicDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SporadicScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext StorageCondition { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext StorageDeletion { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext StorageDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext StorageLocation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext StorageRestoration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext SystematicMonitoring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext ThirdPartyDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext WithdrawConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext WithdrawingFromProcess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProcessingDuration : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProcessingDuration(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration EndlessDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration FixedOccurrencesDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration IndeterminateDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration TemporalDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration UntilEventDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration UntilTimeDuration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProcessingFrequency : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProcessingFrequency(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency ContinuousFrequency { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency OftenFrequency { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency SingularFrequency { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency SporadicFrequency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataProcessingOperation : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataProcessingOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Access { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Acquire { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Adapt { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Aggregate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Align { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Alter { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Analyze { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Anonymize { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Assess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Collect { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Combine { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Consult { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Copy { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation CrossBorderTransfer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Derive { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Destruct { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Disclose { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation DiscloseByTransmission { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Display { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Disseminate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Download { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Erase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Export { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Filter { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Format { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Generate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Infer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation MakeAvailable { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Match { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Modify { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Monitor { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Move { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Observe { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Obtain { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Organize { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Profiling { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Pseudonymize { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Query { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Record { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Reformat { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Remove { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Restrict { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Retrieve { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Screen { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Share { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Store { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Structure { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Transfer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Transform { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Transmit { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation Use { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation left, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayApplicationOwnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>
    {
        public GatewayApplicationOwnerProperties(string name, string legalName, string tradingName, string organizationDescription, string taxNumber, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType organizationType, string organizationIdentificationId, string organizationIdentificationIssuer, string organizationIdentificationType, string contactEmailAddress, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson legalRepresentative, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson privacyManager, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson dataProtectionOfficer, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress registeredGeographicAddress, System.Uri privacyPolicyUri, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative> localRepresentatives) { }
        public string ContactEmailAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson DataProtectionOfficer { get { throw null; } set { } }
        public string LegalName { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson LegalRepresentative { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationLocalRepresentative> LocalRepresentatives { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string OrganizationDescription { get { throw null; } set { } }
        public string OrganizationIdentificationId { get { throw null; } set { } }
        public string OrganizationIdentificationIssuer { get { throw null; } set { } }
        public string OrganizationIdentificationType { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerOrganizationType OrganizationType { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationContactPerson PrivacyManager { get { throw null; } set { } }
        public System.Uri PrivacyPolicyUri { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationGeographicAddress RegisteredGeographicAddress { get { throw null; } set { } }
        public string TaxNumber { get { throw null; } set { } }
        public string TradingName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayApplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>
    {
        public GatewayApplicationProperties(string name, string applicationDescription, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory category, string commercialName, string privacyRightsRequestEmailAddress, System.Uri privacyPolicyUri) { }
        public string ApplicationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationCategory Category { get { throw null; } set { } }
        public string CommercialName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri PrivacyPolicyUri { get { throw null; } set { } }
        public string PrivacyRightsRequestEmailAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionDataProcessing : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>
    {
        public OperatorApiConnectionDataProcessing(Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation processingOperation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext> contexts, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration duration, Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency frequency, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion> transitRegions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion> storageRegions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingContext> Contexts { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingDuration Duration { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingFrequency Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessingOperation ProcessingOperation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion> StorageRegions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion> TransitRegions { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionDataRegion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>
    {
        public OperatorApiConnectionDataRegion(string countryCode, bool isCommercialActivity, System.Uri dataPrivacyFrameworkUri) { }
        public string CommercialOrganization { get { throw null; } set { } }
        public string CountryCode { get { throw null; } set { } }
        public System.Uri DataPrivacyFrameworkUri { get { throw null; } set { } }
        public bool IsCommercialActivity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataRegion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>
    {
        public OperatorApiConnectionPatch() { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>
    {
        public OperatorApiConnectionProperties(Azure.Core.ResourceIdentifier operatorApiPlanId, Azure.Core.ResourceIdentifier gatewayId, bool isPlanTermsAndConditionsAccepted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose> purposes, string purposeReason, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing> dataProcessingList) { }
        public string CamaraApiName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing> DataProcessingList { get { throw null; } }
        public Azure.Core.ResourceIdentifier GatewayId { get { throw null; } set { } }
        public bool IsPlanTermsAndConditionsAccepted { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OperatorApiPlanId { get { throw null; } set { } }
        public string OperatorName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PlanTermsAndConditionsLinks { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PurposeReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose> Purposes { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperatorApiConnectionPurpose : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperatorApiConnectionPurpose(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose AcademicResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose AccountManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose Advertising { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose AgeVerification { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CombatClimateChange { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CommercialPurpose { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CommercialResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CommunicationForCustomerCare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CommunicationManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CounterMoneyLaundering { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose Counterterrorism { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CreditChecking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CustomerCare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CustomerClaimsManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CustomerManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CustomerOrderManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CustomerRelationshipManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose CustomerSolvencyMonitoring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose DataAltruism { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose DeliveryOfGoods { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose DirectMarketing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose DisputeManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose EnforceAccessControl { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose EnforceSecurity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose EstablishContractualAgreement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose FraudPreventionAndDetection { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose FulfillmentOfContractualObligation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose FulfillmentOfObligation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose HumanResourceManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose IdentityAuthentication { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose IdentityVerification { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ImproveExistingProductsAndServices { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ImproveHealthcare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ImproveInternalCRMProcesses { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ImprovePublicServices { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ImproveTransportMobility { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose IncreaseServiceRobustness { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose InternalResourceOptimization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose LegalCompliance { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose MaintainCreditCheckingDatabase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose MaintainCreditRatingDatabase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose MaintainFraudDatabase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose Marketing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose MemberPartnerManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose MisusePreventionAndDetection { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose NonCommercialPurpose { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose NonCommercialResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose OptimizationForConsumer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose OptimizationForController { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose OptimizeUserInterface { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose OrganizationComplianceManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose OrganizationGovernance { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose OrganizationRiskManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PaymentManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose Personalization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PersonalizedAdvertising { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PersonalizedBenefits { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PersonnelHiring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PersonnelManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PersonnelPayment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProtectionOfIPR { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProtectionOfNationalSecurity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProtectionOfPublicSecurity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProvideEventRecommendations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProvideOfficialStatistics { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProvidePersonalizedRecommendations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ProvideProductRecommendations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PublicBenefit { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PublicPolicyMaking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose PublicRelations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose RecordManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose RepairImpairments { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose RequestedServiceProvision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ResearchAndDevelopment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose RightsFulfillment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ScientificResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose SearchFunctionalities { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose SellDataToThirdParties { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose SellInsightsFromData { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose SellProducts { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose SellProductsToDataSubject { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose Serviceoptimization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ServicePersonalization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ServiceProvision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ServiceRegistration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose ServiceUsageAnalytics { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose SocialMediaMarketing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose TargetedAdvertising { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose TechnicalServiceProvision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose UserInterfacePersonalization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose VendorManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose VendorPayment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose VendorRecordsManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose VendorSelectionAssessment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose Verification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose left, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose left, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperatorApiConnectionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>
    {
        internal OperatorApiConnectionStatus() { }
        public string Reason { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>
    {
        public OperatorApiConnectionUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionDataProcessing> DataProcessingList { get { throw null; } }
        public bool? IsPlanTermsAndConditionsAccepted { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OperatorApiPlanId { get { throw null; } set { } }
        public string PurposeReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPurpose> Purposes { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiPlanMarketplaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>
    {
        internal OperatorApiPlanMarketplaceProperties() { }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PlanTermsAndConditionsLinks { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiPlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>
    {
        internal OperatorApiPlanProperties() { }
        public string CamaraApiName { get { throw null; } }
        public string Limits { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanMarketplaceProperties MarketplaceProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> Markets { get { throw null; } }
        public string OperatorName { get { throw null; } }
        public System.Collections.Generic.IList<string> OperatorRegions { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> SupportedLocations { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgrammableConnectivityGatewayPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>
    {
        public ProgrammableConnectivityGatewayPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProgrammableConnectivityGatewayProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>
    {
        public ProgrammableConnectivityGatewayProperties(Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties configuredApplication, Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties configuredApplicationOwner) { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationProperties ConfiguredApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayApplicationOwnerProperties ConfiguredApplicationOwner { get { throw null; } set { } }
        public string GatewayBaseUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> OperatorApiConnections { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ProgrammableConnectivityGatewayProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState left, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState left, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
