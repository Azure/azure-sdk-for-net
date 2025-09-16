namespace Azure.ResourceManager.ComputeRecommender
{
    public partial class AzureResourceManagerComputeRecommenderContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeRecommenderContext() { }
        public static Azure.ResourceManager.ComputeRecommender.AzureResourceManagerComputeRecommenderContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ComputeRecommenderExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase> GetSpotPlacementScore(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>> GetSpotPlacementScoreAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult> PostSpotPlacementScore(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>> PostSpotPlacementScoreAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeRecommender.Mocking
{
    public partial class MockableComputeRecommenderSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeRecommenderSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase> GetSpotPlacementScore(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>> GetSpotPlacementScoreAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult> PostSpotPlacementScore(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>> PostSpotPlacementScoreAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ComputeRecommender.Models
{
    public static partial class ArmComputeRecommenderModelFactory
    {
        public static Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase ComputeDiagnosticBase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> diagnosticSupportedResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore ComputeRecommenderPlacementScore(string sku = null, Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), string availabilityZone = null, string score = null, bool? isQuotaAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult SpotPlacementScoresResult(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> desiredLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize> desiredSizes = null, int? desiredCount = default(int?), bool? availabilityZones = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore> placementScores = null) { throw null; }
    }
    public partial class ComputeDiagnosticBase : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>
    {
        internal ComputeDiagnosticBase() { }
        public System.Collections.Generic.IReadOnlyList<string> DiagnosticSupportedResourceTypes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeDiagnosticBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeRecommenderPlacementScore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>
    {
        internal ComputeRecommenderPlacementScore() { }
        public string AvailabilityZone { get { throw null; } }
        public bool? IsQuotaAvailable { get { throw null; } }
        public Azure.Core.AzureLocation? Region { get { throw null; } }
        public string Score { get { throw null; } }
        public string Sku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeRecommenderResourceSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>
    {
        public ComputeRecommenderResourceSize() { }
        public string Sku { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpotPlacementScoresContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>
    {
        public SpotPlacementScoresContent() { }
        public bool? AvailabilityZones { get { throw null; } set { } }
        public int? DesiredCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> DesiredLocations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize> DesiredSizes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpotPlacementScoresResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>
    {
        internal SpotPlacementScoresResult() { }
        public bool? AvailabilityZones { get { throw null; } }
        public int? DesiredCount { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> DesiredLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderResourceSize> DesiredSizes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ComputeRecommender.Models.ComputeRecommenderPlacementScore> PlacementScores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ComputeRecommender.Models.SpotPlacementScoresResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
