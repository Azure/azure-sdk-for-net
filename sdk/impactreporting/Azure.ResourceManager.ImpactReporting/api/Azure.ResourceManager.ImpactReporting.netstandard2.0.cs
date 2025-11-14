namespace Azure.ResourceManager.ImpactReporting
{
    public partial class AzureResourceManagerImpactReportingContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerImpactReportingContext() { }
        public static Azure.ResourceManager.ImpactReporting.AzureResourceManagerImpactReportingContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ImpactCategoryCollection : Azure.ResourceManager.ArmCollection
    {
        protected ImpactCategoryCollection() { }
        public virtual Azure.Response<bool> Exists(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> Get(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetAll(string resourceType, string categoryName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetAllAsync(string resourceType, string categoryName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetAsync(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetIfExists(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetIfExistsAsync(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImpactCategoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>
    {
        internal ImpactCategoryData() { }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactCategoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactCategoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactCategoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImpactCategoryResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactCategoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string impactCategoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImpactReporting.ImpactCategoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactCategoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactCategoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>, System.Collections.IEnumerable
    {
        protected ImpactConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.ImpactReporting.ImpactConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.ImpactReporting.ImpactConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImpactConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>
    {
        public ImpactConnectorData() { }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImpactConnectorResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImpactReporting.ImpactConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> Update(Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> UpdateAsync(Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImpactInsightCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>, System.Collections.IEnumerable
    {
        protected ImpactInsightCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string insightName, Azure.ResourceManager.ImpactReporting.ImpactInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string insightName, Azure.ResourceManager.ImpactReporting.ImpactInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> Get(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>> GetAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> GetIfExists(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>> GetIfExistsAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImpactInsightData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>
    {
        public ImpactInsightData() { }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactInsightData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactInsightData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactInsightResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImpactInsightResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactInsightData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string workloadImpactName, string insightName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImpactReporting.ImpactInsightData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ImpactInsightData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ImpactInsightData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImpactReporting.ImpactInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImpactReporting.ImpactInsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ImpactReportingExtensions
    {
        public static Azure.ResourceManager.ImpactReporting.ImpactCategoryCollection GetImpactCategories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetImpactCategory(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetImpactCategoryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactCategoryResource GetImpactCategoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> GetImpactConnector(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> GetImpactConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactConnectorResource GetImpactConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactConnectorCollection GetImpactConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactInsightResource GetImpactInsightResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetWorkloadImpact(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetWorkloadImpactAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.WorkloadImpactResource GetWorkloadImpactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.WorkloadImpactCollection GetWorkloadImpacts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class WorkloadImpactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>, System.Collections.IEnumerable
    {
        protected WorkloadImpactCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workloadImpactName, Azure.ResourceManager.ImpactReporting.WorkloadImpactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workloadImpactName, Azure.ResourceManager.ImpactReporting.WorkloadImpactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> Get(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetAsync(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetIfExists(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetIfExistsAsync(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkloadImpactData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>
    {
        public WorkloadImpactData() { }
        public Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.WorkloadImpactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.WorkloadImpactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadImpactResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkloadImpactResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.WorkloadImpactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string workloadImpactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactInsightResource> GetImpactInsight(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactInsightResource>> GetImpactInsightAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactInsightCollection GetImpactInsights() { throw null; }
        Azure.ResourceManager.ImpactReporting.WorkloadImpactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.WorkloadImpactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.WorkloadImpactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImpactReporting.WorkloadImpactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImpactReporting.WorkloadImpactData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ImpactReporting.Mocking
{
    public partial class MockableImpactReportingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableImpactReportingArmClient() { }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactCategoryResource GetImpactCategoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactConnectorResource GetImpactConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactInsightResource GetImpactInsightResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.WorkloadImpactResource GetWorkloadImpactResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableImpactReportingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableImpactReportingSubscriptionResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactCategoryCollection GetImpactCategories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetImpactCategory(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetImpactCategoryAsync(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource> GetImpactConnector(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactConnectorResource>> GetImpactConnectorAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactConnectorCollection GetImpactConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetWorkloadImpact(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetWorkloadImpactAsync(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.WorkloadImpactCollection GetWorkloadImpacts() { throw null; }
    }
}
namespace Azure.ResourceManager.ImpactReporting.Models
{
    public static partial class ArmImpactReportingModelFactory
    {
        public static Azure.ResourceManager.ImpactReporting.ImpactCategoryData ImpactCategoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties ImpactCategoryProperties(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState?), string categoryId = null, string parentCategoryId = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties> requiredImpactProperties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactConnectorData ImpactConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties ImpactConnectorProperties(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState?), string connectorId = null, string tenantId = null, Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType connectorType = default(Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType), System.DateTimeOffset lastRanOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactInsightData ImpactInsightData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties ImpactInsightProperties(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState?), string category = null, string status = null, string eventId = null, string groupId = null, Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent content = null, System.DateTimeOffset? eventOn = default(System.DateTimeOffset?), string insightUniqueId = null, Azure.ResourceManager.ImpactReporting.Models.ImpactDetails impact = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalDetails = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties RequiredImpactProperties(string name = null, System.Collections.Generic.IEnumerable<string> allowedValues = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.WorkloadImpactData WorkloadImpactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties WorkloadImpactProperties(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState?), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier impactedResourceId = null, string impactUniqueId = null, System.DateTimeOffset? reportedTimeUtc = default(System.DateTimeOffset?), string impactCategory = null, string impactDescription = null, System.Collections.Generic.IEnumerable<string> armCorrelationIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance> performance = null, Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails connectivity = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null, Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails errorDetails = null, Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload workload = null, string impactGroupId = null, Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel? confidenceLevel = default(Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel?), Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails clientIncidentDetails = null) { throw null; }
    }
    public partial class ImpactCategoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>
    {
        internal ImpactCategoryProperties() { }
        public string CategoryId { get { throw null; } }
        public string Description { get { throw null; } }
        public string ParentCategoryId { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties> RequiredImpactProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactClientIncidentDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>
    {
        public ImpactClientIncidentDetails() { }
        public string ClientIncidentId { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource? ClientIncidentSource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactConfidenceLevel : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactConfidenceLevel(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel High { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel Low { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel left, Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel left, Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactConnectivityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>
    {
        public ImpactConnectivityDetails() { }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol? Protocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceAzureResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetAzureResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactConnectorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>
    {
        public ImpactConnectorPatch() { }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType? ConnectorType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>
    {
        public ImpactConnectorProperties(string connectorId, string tenantId, Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType connectorType, System.DateTimeOffset lastRanOn) { }
        public string ConnectorId { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType ConnectorType { get { throw null; } set { } }
        public System.DateTimeOffset LastRanOn { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? ProvisioningState { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactConnectorType : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactConnectorType(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType AzureMonitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType left, Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType left, Azure.ResourceManager.ImpactReporting.Models.ImpactConnectorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>
    {
        public ImpactDetails(Azure.Core.ResourceIdentifier impactedResourceId, System.DateTimeOffset startOn, Azure.Core.ResourceIdentifier impactId) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImpactedResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImpactId { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactedWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>
    {
        public ImpactedWorkload() { }
        public string Context { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactToolset? Toolset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>
    {
        public ImpactErrorDetails() { }
        public string ErrorCode { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactIncidentSource : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactIncidentSource(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource AzureDevops { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource Icm { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource Jira { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource ServiceNow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource left, Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource left, Azure.ResourceManager.ImpactReporting.Models.ImpactIncidentSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactInsightContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>
    {
        public ImpactInsightContent(string title, string description) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactInsightProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>
    {
        public ImpactInsightProperties(string category, Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent content, string insightUniqueId, Azure.ResourceManager.ImpactReporting.Models.ImpactDetails impact) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalDetails { get { throw null; } }
        public string Category { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactInsightContent Content { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactDetails Impact { get { throw null; } set { } }
        public string InsightUniqueId { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactInsightProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactMetricExpectedValueRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>
    {
        public ImpactMetricExpectedValueRange(double min, double max) { }
        public double Max { get { throw null; } set { } }
        public double Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactMetricUnit : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactMetricUnit(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit ByteSeconds { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit Cores { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit Count { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit MilliCores { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit MilliSeconds { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit NanoCores { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit left, Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit left, Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactPerformance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>
    {
        public ImpactPerformance() { }
        public double? Actual { get { throw null; } set { } }
        public double? Expected { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactMetricExpectedValueRange ExpectedValueRange { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactMetricUnit? Unit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactProtocol : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactProtocol(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Ftp { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Http { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Https { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Rdp { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Ssh { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol left, Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol left, Azure.ResourceManager.ImpactReporting.Models.ImpactProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactReportingProvisioningState : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactReportingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState left, Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState left, Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImpactToolset : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ImpactToolset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImpactToolset(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Ansible { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Arm { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Chef { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Portal { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Puppet { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Sdk { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Shell { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactToolset Terraform { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ImpactToolset other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ImpactToolset left, Azure.ResourceManager.ImpactReporting.Models.ImpactToolset right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ImpactToolset (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ImpactToolset left, Azure.ResourceManager.ImpactReporting.Models.ImpactToolset right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RequiredImpactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>
    {
        internal RequiredImpactProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedValues { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadImpactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>
    {
        public WorkloadImpactProperties(System.DateTimeOffset startOn, Azure.Core.ResourceIdentifier impactedResourceId, string impactCategory) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IList<string> ArmCorrelationIds { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactClientIncidentDetails ClientIncidentDetails { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactConfidenceLevel? ConfidenceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactConnectivityDetails Connectivity { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactErrorDetails ErrorDetails { get { throw null; } set { } }
        public string ImpactCategory { get { throw null; } set { } }
        public string ImpactDescription { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImpactedResourceId { get { throw null; } set { } }
        public string ImpactGroupId { get { throw null; } set { } }
        public string ImpactUniqueId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImpactReporting.Models.ImpactPerformance> Performance { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactReportingProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ReportedTimeUtc { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactedWorkload Workload { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
