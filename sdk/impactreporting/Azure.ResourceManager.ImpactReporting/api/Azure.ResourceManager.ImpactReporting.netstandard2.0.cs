namespace Azure.ResourceManager.ImpactReporting
{
    public partial class ConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.ConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.ConnectorResource>, System.Collections.IEnumerable
    {
        protected ConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.ImpactReporting.ConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.ConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.ImpactReporting.ConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImpactReporting.ConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImpactReporting.ConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.ConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImpactReporting.ConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.ConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImpactReporting.ConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.ConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>
    {
        public ConnectorData() { }
        public Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.ConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImpactReporting.ConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.ConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.ConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource> Update(Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource>> UpdateAsync(Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ImpactReportingExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource> GetConnector(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource>> GetConnectorAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ConnectorResource GetConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ConnectorCollection GetConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactCategoryCollection GetImpactCategories(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetImpactCategory(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetImpactCategoryAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactCategoryResource GetImpactCategoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.InsightResource GetInsightResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetWorkloadImpact(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetWorkloadImpactAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.WorkloadImpactResource GetWorkloadImpactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.WorkloadImpactCollection GetWorkloadImpacts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class InsightCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.InsightResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.InsightResource>, System.Collections.IEnumerable
    {
        protected InsightCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.InsightResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string insightName, Azure.ResourceManager.ImpactReporting.InsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.InsightResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string insightName, Azure.ResourceManager.ImpactReporting.InsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.InsightResource> Get(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ImpactReporting.InsightResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ImpactReporting.InsightResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.InsightResource>> GetAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.InsightResource> GetIfExists(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ImpactReporting.InsightResource>> GetIfExistsAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ImpactReporting.InsightResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ImpactReporting.InsightResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ImpactReporting.InsightResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.InsightResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InsightData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.InsightData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>
    {
        public InsightData() { }
        public Azure.ResourceManager.ImpactReporting.Models.InsightProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.InsightData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.InsightData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.InsightData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.InsightData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.InsightData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InsightResource() { }
        public virtual Azure.ResourceManager.ImpactReporting.InsightData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string workloadImpactName, string insightName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.InsightResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.InsightResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ImpactReporting.InsightData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.InsightData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.InsightData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.InsightData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.InsightData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.InsightResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImpactReporting.InsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ImpactReporting.InsightResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ImpactReporting.InsightData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.InsightResource> GetInsight(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.InsightResource>> GetInsightAsync(string insightName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.InsightCollection GetInsights() { throw null; }
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
        public virtual Azure.ResourceManager.ImpactReporting.ConnectorResource GetConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactCategoryResource GetImpactCategoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.InsightResource GetInsightResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.WorkloadImpactResource GetWorkloadImpactResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableImpactReportingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableImpactReportingSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource> GetConnector(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ConnectorResource>> GetConnectorAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ConnectorCollection GetConnectors() { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.ImpactCategoryCollection GetImpactCategories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource> GetImpactCategory(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.ImpactCategoryResource>> GetImpactCategoryAsync(string impactCategoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource> GetWorkloadImpact(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ImpactReporting.WorkloadImpactResource>> GetWorkloadImpactAsync(string workloadImpactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ImpactReporting.WorkloadImpactCollection GetWorkloadImpacts() { throw null; }
    }
}
namespace Azure.ResourceManager.ImpactReporting.Models
{
    public static partial class ArmImpactReportingModelFactory
    {
        public static Azure.ResourceManager.ImpactReporting.ConnectorData ConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties ConnectorProperties(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState?), string connectorId = null, string tenantId = null, Azure.ResourceManager.ImpactReporting.Models.Platform connectorType = default(Azure.ResourceManager.ImpactReporting.Models.Platform), System.DateTimeOffset lastRunTimeStamp = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.ImpactCategoryData ImpactCategoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties ImpactCategoryProperties(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState?), string categoryId = null, string parentCategoryId = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties> requiredImpactProperties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.InsightData InsightData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.InsightProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.InsightProperties InsightProperties(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState?), string category = null, string status = null, string eventId = null, string groupId = null, Azure.ResourceManager.ImpactReporting.Models.Content content = null, System.DateTimeOffset? eventOn = default(System.DateTimeOffset?), string insightUniqueId = null, Azure.ResourceManager.ImpactReporting.Models.ImpactDetails impact = null, Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails additionalDetails = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties RequiredImpactProperties(string name = null, System.Collections.Generic.IEnumerable<string> allowedValues = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.WorkloadImpactData WorkloadImpactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties WorkloadImpactProperties(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState?), System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string impactedResourceId = null, string impactUniqueId = null, System.DateTimeOffset? reportedTimeUtc = default(System.DateTimeOffset?), string impactCategory = null, string impactDescription = null, System.Collections.Generic.IEnumerable<string> armCorrelationIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ImpactReporting.Models.Performance> performance = null, Azure.ResourceManager.ImpactReporting.Models.Connectivity connectivity = null, Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties additionalProperties = null, Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties errorDetails = null, Azure.ResourceManager.ImpactReporting.Models.Workload workload = null, string impactGroupId = null, Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel? confidenceLevel = default(Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel?), Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails clientIncidentDetails = null) { throw null; }
    }
    public partial class ClientIncidentDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>
    {
        public ClientIncidentDetails() { }
        public string ClientIncidentId { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.IncidentSource? ClientIncidentSource { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidenceLevel : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidenceLevel(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel High { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel Low { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel Medium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel left, Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel left, Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Connectivity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>
    {
        public Connectivity() { }
        public int? Port { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.Protocol? Protocol { get { throw null; } set { } }
        public string SourceAzureResourceId { get { throw null; } set { } }
        public string TargetAzureResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Connectivity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Connectivity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Connectivity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>
    {
        public ConnectorPatch() { }
        public Azure.ResourceManager.ImpactReporting.Models.Platform? ConnectorType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>
    {
        public ConnectorProperties(string connectorId, string tenantId, Azure.ResourceManager.ImpactReporting.Models.Platform connectorType, System.DateTimeOffset lastRunTimeStamp) { }
        public string ConnectorId { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.Platform ConnectorType { get { throw null; } set { } }
        public System.DateTimeOffset LastRunTimeStamp { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Content : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Content>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Content>
    {
        public Content(string title, string description) { }
        public string Description { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Content System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Content>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Content>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Content System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Content>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Content>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Content>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorDetailProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>
    {
        public ErrorDetailProperties() { }
        public string ErrorCode { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExpectedValueRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>
    {
        public ExpectedValueRange(double min, double max) { }
        public double Max { get { throw null; } set { } }
        public double Min { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactCategoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>
    {
        internal ImpactCategoryProperties() { }
        public string CategoryId { get { throw null; } }
        public string Description { get { throw null; } }
        public string ParentCategoryId { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ImpactReporting.Models.RequiredImpactProperties> RequiredImpactProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactCategoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImpactDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>
    {
        public ImpactDetails(string impactedResourceId, System.DateTimeOffset startOn, string impactId) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ImpactedResourceId { get { throw null; } set { } }
        public string ImpactId { get { throw null; } set { } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.ImpactDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.ImpactDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncidentSource : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.IncidentSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncidentSource(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.IncidentSource AzureDevops { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.IncidentSource ICM { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.IncidentSource Jira { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.IncidentSource Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.IncidentSource ServiceNow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.IncidentSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.IncidentSource left, Azure.ResourceManager.ImpactReporting.Models.IncidentSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.IncidentSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.IncidentSource left, Azure.ResourceManager.ImpactReporting.Models.IncidentSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InsightProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>
    {
        public InsightProperties(string category, Azure.ResourceManager.ImpactReporting.Models.Content content, string insightUniqueId, Azure.ResourceManager.ImpactReporting.Models.ImpactDetails impact) { }
        public Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails AdditionalDetails { get { throw null; } set { } }
        public string Category { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.Content Content { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.DateTimeOffset? EventOn { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ImpactDetails Impact { get { throw null; } set { } }
        public string InsightUniqueId { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.InsightProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.InsightProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightPropertiesAdditionalDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>
    {
        public InsightPropertiesAdditionalDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.InsightPropertiesAdditionalDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MetricUnit : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.MetricUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MetricUnit(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit ByteSeconds { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit Cores { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit Count { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit MilliCores { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit MilliSeconds { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit NanoCores { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.MetricUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.MetricUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.MetricUnit left, Azure.ResourceManager.ImpactReporting.Models.MetricUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.MetricUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.MetricUnit left, Azure.ResourceManager.ImpactReporting.Models.MetricUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Performance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Performance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Performance>
    {
        public Performance() { }
        public double? Actual { get { throw null; } set { } }
        public double? Expected { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ExpectedValueRange ExpectedValueRange { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.MetricUnit? Unit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Performance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Performance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Performance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Performance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Performance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Performance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Performance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Platform : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.Platform>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Platform(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.Platform AzureMonitor { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.Platform other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.Platform left, Azure.ResourceManager.ImpactReporting.Models.Platform right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.Platform (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.Platform left, Azure.ResourceManager.ImpactReporting.Models.Platform right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Protocol : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.Protocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Protocol(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol FTP { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol HTTP { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol HTTPS { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol RDP { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol SSH { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol TCP { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Protocol UDP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.Protocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.Protocol left, Azure.ResourceManager.ImpactReporting.Models.Protocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.Protocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.Protocol left, Azure.ResourceManager.ImpactReporting.Models.Protocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState left, Azure.ResourceManager.ImpactReporting.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.ProvisioningState left, Azure.ResourceManager.ImpactReporting.Models.ProvisioningState right) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Toolset : System.IEquatable<Azure.ResourceManager.ImpactReporting.Models.Toolset>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Toolset(string value) { throw null; }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Ansible { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset ARM { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Chef { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Other { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Portal { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Puppet { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset SDK { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Shell { get { throw null; } }
        public static Azure.ResourceManager.ImpactReporting.Models.Toolset Terraform { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ImpactReporting.Models.Toolset other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ImpactReporting.Models.Toolset left, Azure.ResourceManager.ImpactReporting.Models.Toolset right) { throw null; }
        public static implicit operator Azure.ResourceManager.ImpactReporting.Models.Toolset (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ImpactReporting.Models.Toolset left, Azure.ResourceManager.ImpactReporting.Models.Toolset right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Workload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Workload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Workload>
    {
        public Workload() { }
        public string Context { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.Toolset? Toolset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Workload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Workload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.Workload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.Workload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Workload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Workload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.Workload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadImpactProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>
    {
        public WorkloadImpactProperties(System.DateTimeOffset startOn, string impactedResourceId, string impactCategory) { }
        public Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties AdditionalProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ArmCorrelationIds { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ClientIncidentDetails ClientIncidentDetails { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ConfidenceLevel? ConfidenceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.Connectivity Connectivity { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.ErrorDetailProperties ErrorDetails { get { throw null; } set { } }
        public string ImpactCategory { get { throw null; } set { } }
        public string ImpactDescription { get { throw null; } set { } }
        public string ImpactedResourceId { get { throw null; } set { } }
        public string ImpactGroupId { get { throw null; } set { } }
        public string ImpactUniqueId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ImpactReporting.Models.Performance> Performance { get { throw null; } }
        public Azure.ResourceManager.ImpactReporting.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? ReportedTimeUtc { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.ImpactReporting.Models.Workload Workload { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadImpactPropertiesAdditionalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>
    {
        public WorkloadImpactPropertiesAdditionalProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ImpactReporting.Models.WorkloadImpactPropertiesAdditionalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
