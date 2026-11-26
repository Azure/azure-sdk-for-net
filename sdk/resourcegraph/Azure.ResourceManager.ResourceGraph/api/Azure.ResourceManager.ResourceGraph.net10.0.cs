namespace Azure.ResourceManager.ResourceGraph
{
    public partial class AzureResourceManagerResourceGraphContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourceGraphContext() { }
        public static Azure.ResourceManager.ResourceGraph.AzureResourceManagerResourceGraphContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataOnboardingActivationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>
    {
        internal DataOnboardingActivationData() { }
        public Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataOnboardingActivationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataOnboardingActivationResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string dataOnboardingName, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataOnboardingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>, System.Collections.IEnumerable
    {
        protected DataOnboardingCollection() { }
        public virtual Azure.Response<bool> Exists(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> Get(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>> GetAsync(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> GetIfExists(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>> GetIfExistsAsync(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataOnboardingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>
    {
        internal DataOnboardingData() { }
        public Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.DataOnboardingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.DataOnboardingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataOnboardingLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>, System.Collections.IEnumerable
    {
        protected DataOnboardingLocationCollection() { }
        public virtual Azure.Response<bool> Exists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> Get(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>> GetAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> GetIfExists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>> GetIfExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataOnboardingLocationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>
    {
        internal DataOnboardingLocationData() { }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? OnboardingLocationProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataOnboardingLocationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataOnboardingLocationResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string dataOnboardingName, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingActivationResource GetDataOnboardingActivation() { throw null; }
        Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataOnboardingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataOnboardingResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string dataOnboardingName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource> GetDataOnboardingLocation(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource>> GetDataOnboardingLocationAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingLocationCollection GetDataOnboardingLocations() { throw null; }
        Azure.ResourceManager.ResourceGraph.DataOnboardingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.DataOnboardingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.DataOnboardingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.OfferingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.OfferingResource>, System.Collections.IEnumerable
    {
        protected OfferingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OfferingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string offeringName, Azure.ResourceManager.ResourceGraph.OfferingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OfferingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string offeringName, Azure.ResourceManager.ResourceGraph.OfferingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource> Get(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.OfferingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.OfferingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource>> GetAsync(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.OfferingResource> GetIfExists(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.OfferingResource>> GetIfExistsAsync(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.OfferingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.OfferingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.OfferingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.OfferingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OfferingData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OfferingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>
    {
        public OfferingData() { }
        public Azure.ResourceManager.ResourceGraph.Models.OfferingProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.OfferingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OfferingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OfferingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OfferingResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.OfferingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingResource> GetDataOnboarding(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.DataOnboardingResource>> GetDataOnboardingAsync(string dataOnboardingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingCollection GetDataOnboardings() { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyCollection GetOntologies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyResource> GetOntology(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyResource>> GetOntologyAsync(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> GetQueryEndpoint(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>> GetQueryEndpointAsync(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointCollection GetQueryEndpoints() { throw null; }
        Azure.ResourceManager.ResourceGraph.OfferingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OfferingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OfferingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OfferingResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.OfferingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OfferingResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.OfferingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OntologyActivationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>
    {
        public OntologyActivationData() { }
        public Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.OntologyActivationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OntologyActivationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologyActivationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OntologyActivationResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyActivationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OntologyActivationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.OntologyActivationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OntologyActivationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.OntologyActivationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string ontologyName, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyActivationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyActivationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceGraph.OntologyActivationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OntologyActivationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyActivationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.OntologyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.OntologyResource>, System.Collections.IEnumerable
    {
        protected OntologyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OntologyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ontologyName, Azure.ResourceManager.ResourceGraph.OntologyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OntologyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ontologyName, Azure.ResourceManager.ResourceGraph.OntologyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyResource> Get(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.OntologyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.OntologyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyResource>> GetAsync(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.OntologyResource> GetIfExists(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.OntologyResource>> GetIfExistsAsync(string ontologyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.OntologyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.OntologyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.OntologyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.OntologyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OntologyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>
    {
        public OntologyData() { }
        public Azure.ResourceManager.ResourceGraph.Models.OntologyProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.OntologyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OntologyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologyLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>, System.Collections.IEnumerable
    {
        protected OntologyLocationCollection() { }
        public virtual Azure.Response<bool> Exists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> Get(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>> GetAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> GetIfExists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>> GetIfExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OntologyLocationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>
    {
        internal OntologyLocationData() { }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? OnboardingLocationProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.OntologyLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OntologyLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologyLocationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OntologyLocationResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string ontologyName, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyActivationResource GetOntologyActivation() { throw null; }
        Azure.ResourceManager.ResourceGraph.OntologyLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OntologyLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OntologyResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string ontologyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyLocationResource> GetOntologyLocation(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OntologyLocationResource>> GetOntologyLocationAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyLocationCollection GetOntologyLocations() { throw null; }
        Azure.ResourceManager.ResourceGraph.OntologyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.OntologyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.OntologyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OntologyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.OntologyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.OntologyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.OntologyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueryEndpointActivationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>
    {
        public QueryEndpointActivationData() { }
        public Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryEndpointActivationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QueryEndpointActivationResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string queryEndpointName, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>, System.Collections.IEnumerable
    {
        protected QueryEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string queryEndpointName, Azure.ResourceManager.ResourceGraph.QueryEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string queryEndpointName, Azure.ResourceManager.ResourceGraph.QueryEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> Get(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>> GetAsync(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> GetIfExists(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>> GetIfExistsAsync(string queryEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QueryEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>
    {
        public QueryEndpointData() { }
        public Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.QueryEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.QueryEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryEndpointLocationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>, System.Collections.IEnumerable
    {
        protected QueryEndpointLocationCollection() { }
        public virtual Azure.Response<bool> Exists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> Get(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>> GetAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> GetIfExists(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>> GetIfExistsAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QueryEndpointLocationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>
    {
        internal QueryEndpointLocationData() { }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? OnboardingLocationProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryEndpointLocationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QueryEndpointLocationResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string queryEndpointName, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource GetQueryEndpointActivation() { throw null; }
        Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QueryEndpointResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string offeringName, string queryEndpointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource> GetQueryEndpointLocation(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource>> GetQueryEndpointLocationAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointLocationCollection GetQueryEndpointLocations() { throw null; }
        Azure.ResourceManager.ResourceGraph.QueryEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.QueryEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.QueryEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.QueryEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.QueryEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.QueryEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ResourceGraph.QueryEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourceGraphExtensions
    {
        public static Azure.ResourceManager.ResourceGraph.DataOnboardingActivationResource GetDataOnboardingActivationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource GetDataOnboardingLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.DataOnboardingResource GetDataOnboardingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource> GetOffering(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource>> GetOfferingAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OfferingResource GetOfferingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OfferingCollection GetOfferings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OntologyActivationResource GetOntologyActivationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OntologyLocationResource GetOntologyLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OntologyResource GetOntologyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource GetQueryEndpointActivationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource GetQueryEndpointLocationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.QueryEndpointResource GetQueryEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetails(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetailsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList> GetResourceChanges(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>> GetResourceChangesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.ResourceGraphQueryCollection GetResourceGraphQueries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueries(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueriesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQuery(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetResourceGraphQueryAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource GetResourceGraphQueryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public static Azure.Response<System.BinaryData> GetResourceHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourceHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult> GetResources(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>> GetResourcesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.BinaryData> GetResourcesHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("Use GetResourcesHistory with ResourcesHistoryContent instead. The replacement returns the response body as BinaryData.")]
        public static Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>> GetResourcesHistory(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourcesHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("Use GetResourcesHistoryAsync with ResourcesHistoryContent instead. The replacement returns the response body as BinaryData.")]
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>>> GetResourcesHistoryAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGraphQueryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>, System.Collections.IEnumerable
    {
        protected ResourceGraphQueryCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetIfExists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetIfExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGraphQueryData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>
    {
        public ResourceGraphQueryData(Azure.Core.AzureLocation location) { }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string Query { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultKind? ResultKind { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGraphQueryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGraphQueryResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> Update(Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> UpdateAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Mocking
{
    public partial class MockableResourceGraphArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphArmClient() { }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingActivationResource GetDataOnboardingActivationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingLocationResource GetDataOnboardingLocationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.DataOnboardingResource GetDataOnboardingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OfferingResource GetOfferingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyActivationResource GetOntologyActivationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyLocationResource GetOntologyLocationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OntologyResource GetOntologyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointActivationResource GetQueryEndpointActivationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointLocationResource GetQueryEndpointLocationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.QueryEndpointResource GetQueryEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource GetResourceGraphQueryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourceGraphResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphResourceGroupResource() { }
        public virtual Azure.ResourceManager.ResourceGraph.ResourceGraphQueryCollection GetResourceGraphQueries() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQuery(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource>> GetResourceGraphQueryAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourceGraphSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource> GetOffering(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.OfferingResource>> GetOfferingAsync(string offeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ResourceGraph.OfferingCollection GetOfferings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueries(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.ResourceGraphQueryResource> GetResourceGraphQueriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableResourceGraphTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourceGraphTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetails(Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> GetResourceChangeDetailsAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList> GetResourceChanges(Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>> GetResourceChangesAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public virtual Azure.Response<System.BinaryData> GetResourceHistory(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method isn't available in the stable SDK version. To use it, please install https://www.nuget.org/packages/Azure.ResourceManager.ResourceGraph/1.1.0-beta.4.", true)]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourceHistoryAsync(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult> GetResources(Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>> GetResourcesAsync(Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetResourcesHistory(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("Use GetResourcesHistory with ResourcesHistoryContent instead. The replacement returns the response body as BinaryData.")]
        public virtual Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>> GetResourcesHistory(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetResourcesHistoryAsync(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("Use GetResourcesHistoryAsync with ResourcesHistoryContent instead. The replacement returns the response body as BinaryData.")]
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, System.BinaryData>>> GetResourcesHistoryAsync(Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ResourceGraph.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivationStatus : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.ActivationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivationStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ActivationStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ActivationStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ActivationStatus RollingOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.ActivationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.ActivationStatus left, Azure.ResourceManager.ResourceGraph.Models.ActivationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ActivationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ActivationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.ActivationStatus left, Azure.ResourceManager.ResourceGraph.Models.ActivationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmResourceGraphModelFactory
    {
        public static Azure.ResourceManager.ResourceGraph.DataOnboardingActivationData DataOnboardingActivationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.DataOnboardingData DataOnboardingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.DataOnboardingLocationData DataOnboardingLocationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? onboardingLocationProvisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties DataOnboardingProperties(string publisherNamespace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec> types = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> targetRegions = null, Azure.Core.ResourceIdentifier ontologyRef = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> activatedRegions = null, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?), Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? reviewStatus = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus?), Azure.ResourceManager.ResourceGraph.Models.ActivationStatus? activationStatus = default(Azure.ResourceManager.ResourceGraph.Models.ActivationStatus?), string rejectionReason = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval DateTimeInterval(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec EdgeOnboardingTypeSpec(float? payloadSizeKb = default(float?), Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates peakNotificationRates = null, Azure.ResourceManager.ResourceGraph.Models.Visibility visibility = default(Azure.ResourceManager.ResourceGraph.Models.Visibility), Azure.ResourceManager.ResourceGraph.Models.ReviewStatus status = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus), Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint ingestionEndpoint = null, string relationshipType = null, string sourceNodeType = null, string targetNodeType = null, long? expectedEdgeCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef EdgeTypeRef(string relationshipType = null, string sourceNodeType = null, string targetNodeType = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.Facet Facet(string expression = null, string resultType = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetError FacetError(string expression = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails> errors = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails FacetErrorDetails(string code = null, string message = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetRequest FacetRequest(string expression = null, Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions options = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions FacetRequestOptions(string sortBy = null, Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder? sortOrder = default(Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder?), string filter = null, int? top = default(int?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.FacetResult FacetResult(string expression = null, long totalRecords = (long)0, int count = 0, System.BinaryData data = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint IngestionEndpoint(System.Uri uri = null, System.Collections.Generic.IEnumerable<string> supportedFormats = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec NodeOnboardingTypeSpec(float? payloadSizeKb = default(float?), Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates peakNotificationRates = null, Azure.ResourceManager.ResourceGraph.Models.Visibility visibility = default(Azure.ResourceManager.ResourceGraph.Models.Visibility), Azure.ResourceManager.ResourceGraph.Models.ReviewStatus status = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus), Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint ingestionEndpoint = null, string resourceType = null, long? totalRowCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef NodeTypeRef(string resourceType = null, string alias = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OfferingData OfferingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.OfferingProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OfferingProperties OfferingProperties(string displayName = null, Azure.ResourceManager.ResourceGraph.Models.OfferingTier? tier = default(Azure.ResourceManager.ResourceGraph.Models.OfferingTier?), Azure.ResourceManager.ResourceGraph.Models.LifecycleState? lifecycleState = default(Azure.ResourceManager.ResourceGraph.Models.LifecycleState?), string organizationName = null, System.Collections.Generic.IEnumerable<string> contactEmails = null, string scenarioDescription = null, System.Uri documentationLink = null, string serviceTreeId = null, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec OnboardingTypeSpec(string kind = null, float? payloadSizeKb = default(float?), Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates peakNotificationRates = null, Azure.ResourceManager.ResourceGraph.Models.Visibility visibility = default(Azure.ResourceManager.ResourceGraph.Models.Visibility), Azure.ResourceManager.ResourceGraph.Models.ReviewStatus status = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus), Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint ingestionEndpoint = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OntologyActivationData OntologyActivationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OntologyData OntologyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.OntologyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.OntologyLocationData OntologyLocationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? onboardingLocationProvisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OntologyProperties OntologyProperties(string displayName = null, bool? autoOnboard = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef> nodeTypeRefs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef> edgeTypeRefs = null, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?), Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? reviewStatus = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus?), string rejectionReason = null, string approvedBy = null, System.DateTimeOffset? approvedOn = default(System.DateTimeOffset?), string rejectedBy = null, System.DateTimeOffset? rejectedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability? validationStatus = default(Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail> validationDetails = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot OntologySnapshot(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef> nodeTypeRefs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef> edgeTypeRefs = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment OntologyStorageAssignment(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind kind = default(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind), string resourceType = null, string relationshipType = null, string sourceNodeType = null, string targetNodeType = null, string scaleUnit = null, string dataset = null, string logicalTableName = null, string physicalTableName = null, int lookbackHours = 0) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates PeakNotificationRates(int write = 0, int delete = 0, int snapshot = 0, int @event = 0) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.QueryEndpointActivationData QueryEndpointActivationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties QueryEndpointActivationProperties(Azure.Core.ResourceIdentifier ontologyRef = null, Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference? enginePreference = default(Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference?), Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail> validationDetails = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.QueryEndpointData QueryEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.QueryEndpointLocationData QueryEndpointLocationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? onboardingLocationProvisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties QueryEndpointProperties(string displayName = null, Azure.Core.ResourceIdentifier ontologyRef = null, Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference? enginePreference = default(Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference?), int estimatedQueriesPerDay = 0, int? peakQueriesPerMinute = default(int?), Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties RegionalActivationProperties(Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot ontologySnapshot = null, Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? provisioningState = default(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState?), Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? reviewStatus = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail> validationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment> assignments = null, Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint ingestionEndpoint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> materializedDataOnboardingRefs = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData ResourceChangeData(string resourceId = null, string changeId = null, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot beforeSnapshot = null, Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot afterSnapshot = null, Azure.ResourceManager.ResourceGraph.Models.ChangeType? changeType = default(Azure.ResourceManager.ResourceGraph.Models.ChangeType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange> propertyChanges = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot ResourceChangeDataAfterSnapshot(string snapshotId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot ResourceChangeDataBeforeSnapshot(string snapshotId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters ResourceChangeDetailsRequestParameters(System.Collections.Generic.IEnumerable<string> resourceIds = null, System.Collections.Generic.IEnumerable<string> changeIds = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList ResourceChangeList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> changes = null, System.BinaryData skipToken = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters ResourceChangesRequestParameters(System.Collections.Generic.IEnumerable<string> resourceIds = null, string subscriptionId = null, Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval interval = null, string skipToken = null, int? top = default(int?), string table = null, bool? fetchPropertyChanges = default(bool?), bool? fetchSnapshots = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval ResourceChangesRequestParametersInterval(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.ResourceGraphQueryData ResourceGraphQueryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), string description = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResultKind? resultKind = default(Azure.ResourceManager.ResourceGraph.Models.ResultKind?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch ResourceGraphQueryPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ETag? eTag = default(Azure.ETag?), string description = null, string query = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange ResourcePropertyChange(string propertyName = null, string beforeValue = null, string afterValue = null, Azure.ResourceManager.ResourceGraph.Models.ChangeCategory changeCategory = Azure.ResourceManager.ResourceGraph.Models.ChangeCategory.User, Azure.ResourceManager.ResourceGraph.Models.PropertyChangeType propertyChangeType = Azure.ResourceManager.ResourceGraph.Models.PropertyChangeType.Insert) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent ResourceQueryContent(System.Collections.Generic.IEnumerable<string> subscriptions = null, System.Collections.Generic.IEnumerable<string> managementGroups = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions options = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> facets = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions ResourceQueryRequestOptions(string skipToken = null, int? top = default(int?), int? skip = default(int?), Azure.ResourceManager.ResourceGraph.Models.ResultFormat? resultFormat = default(Azure.ResourceManager.ResourceGraph.Models.ResultFormat?), bool? allowPartialScopes = default(bool?), Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter? authorizationScopeFilter = default(Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult ResourceQueryResult(long totalRecords = (long)0, long count = (long)0, Azure.ResourceManager.ResourceGraph.Models.ResultTruncated resultTruncated = Azure.ResourceManager.ResourceGraph.Models.ResultTruncated.True, string skipToken = null, System.BinaryData data = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ResourceGraph.Models.Facet> facets = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent ResourcesHistoryContent(System.Collections.Generic.IEnumerable<string> subscriptions = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions options = null, System.Collections.Generic.IEnumerable<string> managementGroups = null) { throw null; }
        [System.ObsoleteAttribute("Use ArmResourceGraphModelFactory.ResourcesHistoryContent instead.")]
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest ResourcesHistoryRequest(System.Collections.Generic.IEnumerable<string> subscriptions = null, string query = null, Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions options = null, System.Collections.Generic.IEnumerable<string> managementGroups = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions ResourcesHistoryRequestOptions(Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval interval = null, int? top = default(int?), int? skip = default(int?), string skipToken = null, Azure.ResourceManager.ResourceGraph.Models.ResultFormat? resultFormat = default(Azure.ResourceManager.ResourceGraph.Models.ResultFormat?)) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData ResourceSnapshotData(string snapshotId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), System.BinaryData content = null) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ValidationDetail ValidationDetail(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind kind = default(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind), string resourceType = null, string relationshipType = null, string sourceNodeType = null, string targetNodeType = null, Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability availability = default(Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability), Azure.Core.ResourceIdentifier dataOnboardingRef = null, Azure.ResourceManager.ResourceGraph.Models.ReviewStatus reviewStatus = default(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus), string message = null) { throw null; }
    }
    public enum AuthorizationScopeFilter
    {
        AtScopeAndBelow = 0,
        AtScopeAndAbove = 1,
        AtScopeExact = 2,
        AtScopeAboveAndBelow = 3,
    }
    public enum ChangeCategory
    {
        User = 0,
        System = 1,
    }
    public enum ChangeType
    {
        Create = 0,
        Update = 1,
        Delete = 2,
    }
    public partial class DataOnboardingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>
    {
        internal DataOnboardingProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> ActivatedRegions { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ActivationStatus? ActivationStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier OntologyRef { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? ProvisioningState { get { throw null; } }
        public string PublisherNamespace { get { throw null; } }
        public string RejectionReason { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? ReviewStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> TargetRegions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec> Types { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DataOnboardingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DateTimeInterval : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>
    {
        public DateTimeInterval(System.DateTimeOffset startOn, System.DateTimeOffset endOn) { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeOnboardingTypeSpec : Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>
    {
        internal EdgeOnboardingTypeSpec() { }
        public long? ExpectedEdgeCount { get { throw null; } }
        public string RelationshipType { get { throw null; } }
        public string SourceNodeType { get { throw null; } }
        public string TargetNodeType { get { throw null; } }
        protected override Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeOnboardingTypeSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTypeRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>
    {
        public EdgeTypeRef(string relationshipType, string sourceNodeType, string targetNodeType) { }
        public string RelationshipType { get { throw null; } set { } }
        public string SourceNodeType { get { throw null; } set { } }
        public string TargetNodeType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Facet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>
    {
        protected Facet(string expression) { }
        public string Expression { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.Facet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.Facet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.Facet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.Facet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.Facet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetError : Azure.ResourceManager.ResourceGraph.Models.Facet, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>
    {
        internal FacetError() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails> Errors { get { throw null; } }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetErrorDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>
    {
        internal FacetErrorDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>
    {
        public FacetRequest(string expression) { }
        public string Expression { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions Options { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetRequestOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>
    {
        public FacetRequestOptions() { }
        public string Filter { get { throw null; } set { } }
        public string SortBy { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.FacetSortOrder? SortOrder { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetRequestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FacetResult : Azure.ResourceManager.ResourceGraph.Models.Facet, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>
    {
        internal FacetResult() : base (default(string)) { }
        public int Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public long TotalRecords { get { throw null; } }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.Facet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.FacetResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.FacetResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.FacetResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FacetSortOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public partial class IngestionEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>
    {
        internal IngestionEndpoint() { }
        public System.Collections.Generic.IList<string> SupportedFormats { get { throw null; } }
        public System.Uri Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LifecycleState : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.LifecycleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LifecycleState(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.LifecycleState Deprecated { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.LifecycleState GA { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.LifecycleState Preview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.LifecycleState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.LifecycleState left, Azure.ResourceManager.ResourceGraph.Models.LifecycleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.LifecycleState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.LifecycleState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.LifecycleState left, Azure.ResourceManager.ResourceGraph.Models.LifecycleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeOnboardingTypeSpec : Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>
    {
        internal NodeOnboardingTypeSpec() { }
        public string ResourceType { get { throw null; } }
        public long? TotalRowCount { get { throw null; } }
        protected override Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeOnboardingTypeSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeTypeRef : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>
    {
        public NodeTypeRef(string resourceType) { }
        public string Alias { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OfferingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>
    {
        public OfferingProperties(string organizationName, System.Collections.Generic.IEnumerable<string> contactEmails, string scenarioDescription) { }
        public System.Collections.Generic.IList<string> ContactEmails { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri DocumentationLink { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.LifecycleState? LifecycleState { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? ProvisioningState { get { throw null; } }
        public string ScenarioDescription { get { throw null; } set { } }
        public string ServiceTreeId { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.OfferingTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OfferingProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OfferingProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.OfferingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.OfferingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OfferingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OfferingTier : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.OfferingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OfferingTier(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OfferingTier Dedicated { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.OfferingTier Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.OfferingTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.OfferingTier left, Azure.ResourceManager.ResourceGraph.Models.OfferingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.OfferingTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.OfferingTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.OfferingTier left, Azure.ResourceManager.ResourceGraph.Models.OfferingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnboardingProvisioningState : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnboardingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState left, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState left, Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class OnboardingTypeSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>
    {
        internal OnboardingTypeSpec() { }
        public Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint IngestionEndpoint { get { throw null; } }
        public float? PayloadSizeKb { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates PeakNotificationRates { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ReviewStatus Status { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.Visibility Visibility { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OnboardingTypeSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OntologyEntryKind : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OntologyEntryKind(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind Edge { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind Node { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind left, Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind left, Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OntologyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>
    {
        public OntologyProperties() { }
        public string ApprovedBy { get { throw null; } }
        public System.DateTimeOffset? ApprovedOn { get { throw null; } }
        public bool? AutoOnboard { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef> EdgeTypeRefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef> NodeTypeRefs { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? ProvisioningState { get { throw null; } }
        public string RejectedBy { get { throw null; } }
        public System.DateTimeOffset? RejectedOn { get { throw null; } }
        public string RejectionReason { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? ReviewStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail> ValidationDetails { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability? ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OntologyProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OntologyProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.OntologyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.OntologyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologySnapshot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>
    {
        public OntologySnapshot() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.EdgeTypeRef> EdgeTypeRefs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.NodeTypeRef> NodeTypeRefs { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OntologyStorageAssignment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>
    {
        internal OntologyStorageAssignment() { }
        public string Dataset { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind Kind { get { throw null; } }
        public string LogicalTableName { get { throw null; } }
        public int LookbackHours { get { throw null; } }
        public string PhysicalTableName { get { throw null; } }
        public string RelationshipType { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string ScaleUnit { get { throw null; } }
        public string SourceNodeType { get { throw null; } }
        public string TargetNodeType { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeakNotificationRates : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>
    {
        internal PeakNotificationRates() { }
        public int Delete { get { throw null; } }
        public int Event { get { throw null; } }
        public int Snapshot { get { throw null; } }
        public int Write { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.PeakNotificationRates>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum PropertyChangeType
    {
        Insert = 0,
        Update = 1,
        Remove = 2,
    }
    public partial class QueryEndpointActivationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>
    {
        public QueryEndpointActivationProperties() { }
        public Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference? EnginePreference { get { throw null; } }
        public Azure.Core.ResourceIdentifier OntologyRef { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.AzureLocation? Region { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail> ValidationDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointActivationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>
    {
        public QueryEndpointProperties(string displayName, Azure.Core.ResourceIdentifier ontologyRef, int estimatedQueriesPerDay) { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference? EnginePreference { get { throw null; } set { } }
        public int EstimatedQueriesPerDay { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier OntologyRef { get { throw null; } set { } }
        public int? PeakQueriesPerMinute { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.QueryEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueryEnginePreference : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueryEnginePreference(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference Galaxy { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference Kusto { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference NoPreference { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference Pacific { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference left, Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference left, Azure.ResourceManager.ResourceGraph.Models.QueryEnginePreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegionalActivationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>
    {
        public RegionalActivationProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.OntologyStorageAssignment> Assignments { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.IngestionEndpoint IngestionEndpoint { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> MaterializedDataOnboardingRefs { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.OntologySnapshot OntologySnapshot { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.OnboardingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.AzureLocation? Region { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? ReviewStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail> ValidationDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.RegionalActivationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>
    {
        internal ResourceChangeData() { }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot AfterSnapshot { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot BeforeSnapshot { get { throw null; } }
        public string ChangeId { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ChangeType? ChangeType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange> PropertyChanges { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeDataAfterSnapshot : Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>
    {
        internal ResourceChangeDataAfterSnapshot() { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataAfterSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeDataBeforeSnapshot : Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>
    {
        internal ResourceChangeDataBeforeSnapshot() { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDataBeforeSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeDetailsRequestParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>
    {
        public ResourceChangeDetailsRequestParameters(System.Collections.Generic.IEnumerable<string> resourceIds, System.Collections.Generic.IEnumerable<string> changeIds) { }
        public System.Collections.Generic.IList<string> ChangeIds { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeDetailsRequestParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangeList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>
    {
        internal ResourceChangeList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeData> Changes { get { throw null; } }
        public System.BinaryData SkipToken { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangeList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangesRequestParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>
    {
        public ResourceChangesRequestParameters(Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval interval) { }
        public bool? FetchPropertyChanges { get { throw null; } set { } }
        public bool? FetchSnapshots { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval Interval { get { throw null; } }
        public System.Collections.Generic.IList<string> ResourceIds { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public string Table { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceChangesRequestParametersInterval : Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>
    {
        public ResourceChangesRequestParametersInterval(System.DateTimeOffset startOn, System.DateTimeOffset endOn) : base (default(System.DateTimeOffset), default(System.DateTimeOffset)) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceChangesRequestParametersInterval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGraphQueryPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>
    {
        public ResourceGraphQueryPatch() { }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceGraphQueryPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcePropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>
    {
        internal ResourcePropertyChange() { }
        public string AfterValue { get { throw null; } }
        public string BeforeValue { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ChangeCategory ChangeCategory { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.PropertyChangeType PropertyChangeType { get { throw null; } }
        public string PropertyName { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcePropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>
    {
        public ResourceQueryContent(string query) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ResourceGraph.Models.FacetRequest> Facets { get { throw null; } }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryRequestOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>
    {
        public ResourceQueryRequestOptions() { }
        public bool? AllowPartialScopes { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.AuthorizationScopeFilter? AuthorizationScopeFilter { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryRequestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceQueryResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>
    {
        internal ResourceQueryResult() { }
        public long Count { get { throw null; } }
        public System.BinaryData Data { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ResourceGraph.Models.Facet> Facets { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultTruncated ResultTruncated { get { throw null; } }
        public string SkipToken { get { throw null; } }
        public long TotalRecords { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceQueryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>
    {
        public ResourcesHistoryContent() { }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("Use ResourcesHistoryContent instead.")]
    public partial class ResourcesHistoryRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>
    {
        public ResourcesHistoryRequest() { }
        public System.Collections.Generic.IList<string> ManagementGroups { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions Options { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Subscriptions { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourcesHistoryRequestOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>
    {
        public ResourcesHistoryRequestOptions() { }
        public Azure.ResourceManager.ResourceGraph.Models.DateTimeInterval Interval { get { throw null; } set { } }
        public Azure.ResourceManager.ResourceGraph.Models.ResultFormat? ResultFormat { get { throw null; } set { } }
        public int? Skip { get { throw null; } set { } }
        public string SkipToken { get { throw null; } set { } }
        public int? Top { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourcesHistoryRequestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSnapshotData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>
    {
        internal ResourceSnapshotData() { }
        public System.BinaryData Content { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ResourceSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResultFormat
    {
        Table = 0,
        ObjectArray = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResultKind : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.ResultKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResultKind(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ResultKind Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.ResultKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.ResultKind left, Azure.ResourceManager.ResourceGraph.Models.ResultKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ResultKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ResultKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.ResultKind left, Azure.ResourceManager.ResourceGraph.Models.ResultKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ResultTruncated
    {
        True = 0,
        False = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReviewStatus : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.ReviewStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReviewStatus(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ReviewStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ReviewStatus Executed { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ReviewStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ReviewStatus Submitted { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ReviewStatus UnderExecution { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ReviewStatus UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus left, Azure.ResourceManager.ResourceGraph.Models.ReviewStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ReviewStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ReviewStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.ReviewStatus left, Azure.ResourceManager.ResourceGraph.Models.ReviewStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationAvailability : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationAvailability(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability Available { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability NotOnboarded { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability OnboardingInProgress { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability left, Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability left, Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ValidationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>
    {
        internal ValidationDetail() { }
        public Azure.ResourceManager.ResourceGraph.Models.ValidationAvailability Availability { get { throw null; } }
        public Azure.Core.ResourceIdentifier DataOnboardingRef { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.OntologyEntryKind Kind { get { throw null; } }
        public string Message { get { throw null; } }
        public string RelationshipType { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public Azure.ResourceManager.ResourceGraph.Models.ReviewStatus ReviewStatus { get { throw null; } }
        public string SourceNodeType { get { throw null; } }
        public string TargetNodeType { get { throw null; } }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ValidationDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ResourceGraph.Models.ValidationDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ResourceGraph.Models.ValidationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ResourceGraph.Models.ValidationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ResourceGraph.Models.ValidationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Visibility : System.IEquatable<Azure.ResourceManager.ResourceGraph.Models.Visibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Visibility(string value) { throw null; }
        public static Azure.ResourceManager.ResourceGraph.Models.Visibility GA { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.Visibility InternalOnly { get { throw null; } }
        public static Azure.ResourceManager.ResourceGraph.Models.Visibility PublicPreview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ResourceGraph.Models.Visibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ResourceGraph.Models.Visibility left, Azure.ResourceManager.ResourceGraph.Models.Visibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.Visibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ResourceGraph.Models.Visibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ResourceGraph.Models.Visibility left, Azure.ResourceManager.ResourceGraph.Models.Visibility right) { throw null; }
        public override string ToString() { throw null; }
    }
}
