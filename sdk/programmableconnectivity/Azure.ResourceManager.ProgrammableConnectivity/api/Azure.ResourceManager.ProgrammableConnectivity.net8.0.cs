namespace Azure.ResourceManager.ProgrammableConnectivity
{
    public partial class AzureResourceManagerProgrammableConnectivityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerProgrammableConnectivityContext() { }
        public static Azure.ResourceManager.ProgrammableConnectivity.AzureResourceManagerProgrammableConnectivityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class GatewayCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>, System.Collections.IEnumerable
    {
        protected GatewayCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.ProgrammableConnectivity.GatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gatewayName, Azure.ResourceManager.ProgrammableConnectivity.GatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> Get(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> GetAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetIfExists(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> GetIfExistsAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GatewayData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>
    {
        public GatewayData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.GatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.GatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GatewayResource() { }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.GatewayData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gatewayName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProgrammableConnectivity.GatewayData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.GatewayData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.GatewayData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> Update(Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> UpdateAsync(Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetAll(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetAllAsync(string filter = null, int? top = default(int?), int? skip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetGateway(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> GetGatewayAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.GatewayResource GetGatewayResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.GatewayCollection GetGateways(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetGateways(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetGatewaysAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    }
}
namespace Azure.ResourceManager.ProgrammableConnectivity.Mocking
{
    public partial class MockableProgrammableConnectivityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableProgrammableConnectivityArmClient() { }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.GatewayResource GetGatewayResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource GetOperatorApiConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource GetOperatorApiPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableProgrammableConnectivityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProgrammableConnectivityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetGateway(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource>> GetGatewayAsync(string gatewayName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.GatewayCollection GetGateways() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnection(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource>> GetOperatorApiConnectionAsync(string operatorApiConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionCollection GetOperatorApiConnections() { throw null; }
    }
    public partial class MockableProgrammableConnectivitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProgrammableConnectivitySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetGateways(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.GatewayResource> GetGatewaysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionResource> GetOperatorApiConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource> GetOperatorApiPlan(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanResource>> GetOperatorApiPlanAsync(string operatorApiPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanCollection GetOperatorApiPlans() { throw null; }
    }
}
namespace Azure.ResourceManager.ProgrammableConnectivity.Models
{
    public partial class ApplicationOwnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>
    {
        public ApplicationOwnerProperties(string name, string legalName, string tradingName, string organizationDescription, string taxNumber, Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType organizationType, string organizationIdentificationId, string organizationIdentificationIssuer, string organizationIdentificationType, string contactEmailAddress, Azure.ResourceManager.ProgrammableConnectivity.Models.Person legalRepresentative, Azure.ResourceManager.ProgrammableConnectivity.Models.Person privacyManager, Azure.ResourceManager.ProgrammableConnectivity.Models.Person dataProtectionOfficer, Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress registeredGeographicAddress, System.Uri privacyPolicyUri, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative> localRepresentatives) { }
        public string ContactEmailAddress { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Person DataProtectionOfficer { get { throw null; } set { } }
        public string LegalName { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Person LegalRepresentative { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative> LocalRepresentatives { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string OrganizationDescription { get { throw null; } set { } }
        public string OrganizationIdentificationId { get { throw null; } set { } }
        public string OrganizationIdentificationIssuer { get { throw null; } set { } }
        public string OrganizationIdentificationType { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType OrganizationType { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Person PrivacyManager { get { throw null; } set { } }
        public System.Uri PrivacyPolicyUri { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress RegisteredGeographicAddress { get { throw null; } set { } }
        public string TaxNumber { get { throw null; } set { } }
        public string TradingName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>
    {
        public ApplicationProperties(string name, string applicationDescription, Azure.ResourceManager.ProgrammableConnectivity.Models.Category category, string commercialName, string privacyRightsRequestEmailAddress, System.Uri privacyPolicyUri) { }
        public string ApplicationDescription { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Category Category { get { throw null; } set { } }
        public string CommercialName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Uri PrivacyPolicyUri { get { throw null; } set { } }
        public string PrivacyRightsRequestEmailAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmProgrammableConnectivityModelFactory
    {
        public static Azure.ResourceManager.ProgrammableConnectivity.GatewayData GatewayData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties GatewayProperties(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> operatorApiConnections = null, string gatewayBaseUri = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState?), Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties configuredApplication = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties configuredApplicationOwner = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties MarketplaceProperties(string offerId = null, string publisherId = null, string planId = null, System.Collections.Generic.IEnumerable<string> planTermsAndConditionsLinks = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiConnectionData OperatorApiConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties OperatorApiConnectionProperties(Azure.Core.ResourceIdentifier operatorApiPlanId = null, Azure.Core.ResourceIdentifier gatewayId = null, string operatorName = null, string camaraApiName = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState?), Azure.ResourceManager.ProgrammableConnectivity.Models.Status status = null, bool planTermsAndConditionsAccepted = false, System.Collections.Generic.IEnumerable<string> planTermsAndConditionsLinks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose> purposes = null, string purposeReason = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing> dataProcessingList = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.OperatorApiPlanData OperatorApiPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties OperatorApiPlanProperties(string operatorName = null, string camaraApiName = null, System.Collections.Generic.IEnumerable<string> supportedLocations = null, System.Collections.Generic.IEnumerable<string> operatorRegions = null, System.Collections.Generic.IEnumerable<string> markets = null, string limits = null, Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties marketplaceProperties = null, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Status Status(string state = null, string reason = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Category : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.Category>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Category(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Agriculture { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category ArtAndDesign { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category AutoAndVehicle { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Beauty { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category BooksAndReference { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Business { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Construction { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Defense { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category DeveloperTools { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Education { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Engineering { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category EventsAndEntertainment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Finance { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category FoodAndDrink { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Games { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category HealthAndFitness { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Healthcare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Information { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Kids { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category LibrariesAndDemo { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Lifestyle { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Manufacturing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category MapsAndNavigation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Media { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Medical { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Mining { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category MusicAndAudio { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category NewsAndMagazines { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Organizations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Other { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category PhotoAndVideo { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Productivity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category PublicService { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category RealEstate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Shopping { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category SocialNetworkingAndCommunications { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Sports { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Tourism { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Trading { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Transportation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category TravelAndLocal { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Utilities { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Water { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Category Weather { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.Category other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.Category left, Azure.ResourceManager.ProgrammableConnectivity.Models.Category right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.Category (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.Category left, Azure.ResourceManager.ProgrammableConnectivity.Models.Category right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Context : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.Context>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Context(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context AlgorithmicLogic { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context AssistiveAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context AutomatedDecisionMaking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context AutomatedScoringOfIndividuals { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context AutomationLevel { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context Autonomous { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotChallengeProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotChallengeProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotChallengeProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotCorrectProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotCorrectProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotCorrectProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotObjectToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotOptInToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotOptOutFromProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotReverseProcessEffects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotReverseProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotReverseProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CannotWithdrawFromProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ChallengingProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ChallengingProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ChallengingProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CompletelyManualProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ConditionalAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ConsentControl { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CorrectingProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CorrectingProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context CorrectingProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataControllerDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataPublishedByDataSubject { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataSubject { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataSubjectDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataSubjectScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context DecisionMaking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EntityActiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EntityInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EntityNonInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EntityNonPermissiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EntityPassiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EntityPermissiveInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EvaluationOfIndividuals { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context EvaluationScoring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context FullAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context GeographicCoverage { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context GlobalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HighAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HugeDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HugeScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolved { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvementForControl { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvementForDecision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvementForInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvementForIntervention { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvementForOversight { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanInvolvementForVerification { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context HumanNotInvolved { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context InnovativeUseOfExistingTechnology { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context InnovativeUseOfNewTechnologies { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context InnovativeUseOfTechnology { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context LargeDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context LargeScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context LargeScaleProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context LocalEnvironmentScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context LocalityScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context MediumDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context MediumScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context MediumScaleProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context MultiNationalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context NationalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context NearlyGlobalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context NonPublicDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context NotAutomated { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ObjectingToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ObtainConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context OptingInToProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context OptingOutFromProcess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context PartialAutomation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ProcessingCondition { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ProcessingDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ProcessingLocation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ProcessingScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ProvideConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context PublicDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ReaffirmConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context RegionalScale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ReversingProcessEffects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ReversingProcessInput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ReversingProcessOutput { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context Scale { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ScoringOfIndividuals { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SingularDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SingularScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SmallDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SmallScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SmallScaleProcessing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SporadicDataVolume { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SporadicScaleOfDataSubjects { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context StorageCondition { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context StorageDeletion { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context StorageDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context StorageLocation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context StorageRestoration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context SystematicMonitoring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context ThirdPartyDataSource { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context WithdrawConsent { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Context WithdrawingFromProcess { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.Context other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.Context left, Azure.ResourceManager.ProgrammableConnectivity.Models.Context right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.Context (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.Context left, Azure.ResourceManager.ProgrammableConnectivity.Models.Context right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataProcessing : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>
    {
        public DataProcessing(Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation processingOperation, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.Context> contexts, Azure.ResourceManager.ProgrammableConnectivity.Models.Duration duration, Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency frequency, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions> transitRegions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions> storageRegions) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.Context> Contexts { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Duration Duration { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency Frequency { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation ProcessingOperation { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions> StorageRegions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions> TransitRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataRegions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>
    {
        public DataRegions(string countryCode, bool commercialActivity, System.Uri dataPrivacyFrameworkUri) { }
        public bool CommercialActivity { get { throw null; } set { } }
        public string CommercialOrganization { get { throw null; } set { } }
        public string CountryCode { get { throw null; } set { } }
        public System.Uri DataPrivacyFrameworkUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.DataRegions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Duration : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.Duration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Duration(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Duration EndlessDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Duration FixedOccurrencesDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Duration IndeterminateDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Duration TemporalDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Duration UntilEventDuration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Duration UntilTimeDuration { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.Duration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.Duration left, Azure.ResourceManager.ProgrammableConnectivity.Models.Duration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.Duration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.Duration left, Azure.ResourceManager.ProgrammableConnectivity.Models.Duration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency ContinuousFrequency { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency OftenFrequency { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency SingularFrequency { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency SporadicFrequency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency left, Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency left, Azure.ResourceManager.ProgrammableConnectivity.Models.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>
    {
        public GatewayPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>
    {
        public GatewayProperties(Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties configuredApplication, Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties configuredApplicationOwner) { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationProperties ConfiguredApplication { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ApplicationOwnerProperties ConfiguredApplicationOwner { get { throw null; } set { } }
        public string GatewayBaseUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> OperatorApiConnections { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GatewayProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeographicAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>
    {
        public GeographicAddress(string countryCode) { }
        public string City { get { throw null; } set { } }
        public string CountryCode { get { throw null; } set { } }
        public string Locality { get { throw null; } set { } }
        public string PostalCode { get { throw null; } set { } }
        public string StateOrProvince { get { throw null; } set { } }
        public string StreetName { get { throw null; } set { } }
        public string StreetNumber { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.GeographicAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalRepresentative : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>
    {
        public LocalRepresentative(string countryCode, Azure.ResourceManager.ProgrammableConnectivity.Models.Person representative) { }
        public string CountryCode { get { throw null; } set { } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Person Representative { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.LocalRepresentative>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>
    {
        internal MarketplaceProperties() { }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> PlanTermsAndConditionsLinks { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>
    {
        public OperatorApiConnectionPatch() { }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>
    {
        public OperatorApiConnectionProperties(Azure.Core.ResourceIdentifier operatorApiPlanId, Azure.Core.ResourceIdentifier gatewayId, bool planTermsAndConditionsAccepted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose> purposes, string purposeReason, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing> dataProcessingList) { }
        public string CamaraApiName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing> DataProcessingList { get { throw null; } }
        public Azure.Core.ResourceIdentifier GatewayId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OperatorApiPlanId { get { throw null; } set { } }
        public string OperatorName { get { throw null; } }
        public bool PlanTermsAndConditionsAccepted { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> PlanTermsAndConditionsLinks { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PurposeReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose> Purposes { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.Status Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiConnectionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>
    {
        public OperatorApiConnectionUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.DataProcessing> DataProcessingList { get { throw null; } }
        public Azure.Core.ResourceIdentifier OperatorApiPlanId { get { throw null; } set { } }
        public bool? PlanTermsAndConditionsAccepted { get { throw null; } set { } }
        public string PurposeReason { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose> Purposes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiConnectionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperatorApiPlanProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>
    {
        internal OperatorApiPlanProperties() { }
        public string CamaraApiName { get { throw null; } }
        public string Limits { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.MarketplaceProperties MarketplaceProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Markets { get { throw null; } }
        public string OperatorName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OperatorRegions { get { throw null; } }
        public Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedLocations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.OperatorApiPlanProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrganizationType : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrganizationType(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType AcademicScientificOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType ForProfitOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType GovernmentalOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType IndustryConsortium { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType InternationalOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType NonGovernmentalOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType NonProfitOrganization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType OrganizationalUnit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType left, Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType left, Azure.ResourceManager.ProgrammableConnectivity.Models.OrganizationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Person : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>
    {
        public Person(string familyName, string givenName, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string FamilyName { get { throw null; } set { } }
        public string GivenName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.Person System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.Person System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Person>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProcessingOperation : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProcessingOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Access { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Acquire { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Adapt { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Aggregate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Align { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Alter { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Analyze { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Anonymize { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Assess { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Collect { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Combine { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Consult { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Copy { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation CrossBorderTransfer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Derive { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Destruct { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Disclose { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation DiscloseByTransmission { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Display { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Disseminate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Download { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Erase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Export { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Filter { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Format { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Generate { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Infer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation MakeAvailable { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Match { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Modify { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Monitor { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Move { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Observe { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Obtain { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Organize { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Profiling { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Pseudonymize { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Query { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Record { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Reformat { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Remove { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Restrict { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Retrieve { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Screen { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Share { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Store { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Structure { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Transfer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Transform { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Transmit { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation Use { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation left, Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation left, Azure.ResourceManager.ProgrammableConnectivity.Models.ProcessingOperation right) { throw null; }
        public override string ToString() { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState left, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState left, Azure.ResourceManager.ProgrammableConnectivity.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Purpose : System.IEquatable<Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Purpose(string value) { throw null; }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose AcademicResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose AccountManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose Advertising { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose AgeVerification { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CombatClimateChange { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CommercialPurpose { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CommercialResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CommunicationForCustomerCare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CommunicationManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CounterMoneyLaundering { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose Counterterrorism { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CreditChecking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CustomerCare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CustomerClaimsManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CustomerManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CustomerOrderManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CustomerRelationshipManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose CustomerSolvencyMonitoring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose DataAltruism { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose DeliveryOfGoods { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose DirectMarketing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose DisputeManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose EnforceAccessControl { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose EnforceSecurity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose EstablishContractualAgreement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose FraudPreventionAndDetection { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose FulfillmentOfContractualObligation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose FulfillmentOfObligation { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose HumanResourceManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose IdentityAuthentication { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose IdentityVerification { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ImproveExistingProductsAndServices { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ImproveHealthcare { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ImproveInternalCRMProcesses { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ImprovePublicServices { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ImproveTransportMobility { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose IncreaseServiceRobustness { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose InternalResourceOptimization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose LegalCompliance { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose MaintainCreditCheckingDatabase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose MaintainCreditRatingDatabase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose MaintainFraudDatabase { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose Marketing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose MemberPartnerManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose MisusePreventionAndDetection { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose NonCommercialPurpose { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose NonCommercialResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose OptimizationForConsumer { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose OptimizationForController { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose OptimizeUserInterface { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose OrganizationComplianceManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose OrganizationGovernance { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose OrganizationRiskManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PaymentManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose Personalization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PersonalizedAdvertising { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PersonalizedBenefits { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PersonnelHiring { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PersonnelManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PersonnelPayment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProtectionOfIPR { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProtectionOfNationalSecurity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProtectionOfPublicSecurity { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProvideEventRecommendations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProvideOfficialStatistics { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProvidePersonalizedRecommendations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ProvideProductRecommendations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PublicBenefit { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PublicPolicyMaking { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose PublicRelations { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose RecordManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose RepairImpairments { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose RequestedServiceProvision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ResearchAndDevelopment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose RightsFulfillment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ScientificResearch { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose SearchFunctionalities { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose SellDataToThirdParties { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose SellInsightsFromData { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose SellProducts { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose SellProductsToDataSubject { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose Serviceoptimization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ServicePersonalization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ServiceProvision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ServiceRegistration { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose ServiceUsageAnalytics { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose SocialMediaMarketing { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose TargetedAdvertising { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose TechnicalServiceProvision { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose UserInterfacePersonalization { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose VendorManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose VendorPayment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose VendorRecordsManagement { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose VendorSelectionAssessment { get { throw null; } }
        public static Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose Verification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose left, Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose left, Azure.ResourceManager.ProgrammableConnectivity.Models.Purpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Status : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>
    {
        internal Status() { }
        public string Reason { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.Status System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProgrammableConnectivity.Models.Status System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProgrammableConnectivity.Models.Status>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
