namespace Azure.ResourceManager.Compute.Recommender
{
    public partial class AzureResourceManagerComputeRecommenderContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeRecommenderContext() { }
        public static Azure.ResourceManager.Compute.Recommender.AzureResourceManagerComputeRecommenderContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ComputeRecommenderDiagnosticData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>
    {
        internal ComputeRecommenderDiagnosticData() { }
        public System.Collections.Generic.IList<string> ComputeRecommenderDiagnosticSupportedResourceTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeRecommenderDiagnosticResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeRecommenderDiagnosticResource() { }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult> Generate(Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent spotPlacementScoresInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>> GenerateAsync(Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent spotPlacementScoresInput, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ComputeRecommenderExtensions
    {
        public static Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource GetComputeRecommenderDiagnostic(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource GetComputeRecommenderDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Recommender.Mocking
{
    public partial class MockableComputeRecommenderArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeRecommenderArmClient() { }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource GetComputeRecommenderDiagnosticResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeRecommenderSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeRecommenderSubscriptionResource() { }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource GetComputeRecommenderDiagnostic() { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Recommender.Models
{
    public static partial class ArmComputeRecommenderModelFactory
    {
        public static Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData ComputeRecommenderDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IList<string> computeRecommenderDiagnosticSupportedResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent ComputeRecommenderGenerateContent(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> desiredLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize> desiredSizes = null, int? desiredCount = default(int?), bool? availabilityZones = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult ComputeRecommenderGenerateResult(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> desiredLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize> desiredSizes = null, int? desiredCount = default(int?), bool? availabilityZones = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore> placementScores = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore ComputeRecommenderPlacementScore(string sku = null, Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), string availabilityZone = null, string score = null, bool? isQuotaAvailable = default(bool?)) { throw null; }
    }
    public partial class ComputeRecommenderGenerateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>
    {
        public ComputeRecommenderGenerateContent() { }
        public bool? AvailabilityZones { get { throw null; } set { } }
        public int? DesiredCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> DesiredLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize> DesiredSizes { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeRecommenderGenerateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>
    {
        internal ComputeRecommenderGenerateResult() { }
        public bool? AvailabilityZones { get { throw null; } }
        public int? DesiredCount { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> DesiredLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize> DesiredSizes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore> PlacementScores { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeRecommenderPlacementScore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>
    {
        internal ComputeRecommenderPlacementScore() { }
        public string AvailabilityZone { get { throw null; } }
        public bool? IsQuotaAvailable { get { throw null; } }
        public Azure.Core.AzureLocation? Region { get { throw null; } }
        public string Score { get { throw null; } }
        public string Sku { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeRecommenderResourceSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>
    {
        public ComputeRecommenderResourceSize() { }
        public string Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
