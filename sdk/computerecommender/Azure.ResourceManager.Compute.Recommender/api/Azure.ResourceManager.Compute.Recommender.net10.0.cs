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
        public virtual Azure.Response<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult> Generate(Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult>> GenerateAsync(Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementResource GetComputeSkuMixPlacement(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementResource GetComputeSkuMixPlacementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ComputeSkuMixPlacementData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>
    {
        internal ComputeSkuMixPlacementData() { }
        public System.Collections.Generic.IList<string> SkuMixPlacementSupportedResourceTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuMixPlacementResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ComputeSkuMixPlacementResource() { }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult> Generate(Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>> GenerateAsync(Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Recommender.Mocking
{
    public partial class MockableComputeRecommenderArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeRecommenderArmClient() { }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource GetComputeRecommenderDiagnosticResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementResource GetComputeSkuMixPlacementResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableComputeRecommenderSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeRecommenderSubscriptionResource() { }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticResource GetComputeRecommenderDiagnostic() { throw null; }
        public virtual Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementResource GetComputeSkuMixPlacement() { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Recommender.Models
{
    public static partial class ArmComputeRecommenderModelFactory
    {
        public static Azure.ResourceManager.Compute.Recommender.ComputeRecommenderDiagnosticData ComputeRecommenderDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> computeRecommenderDiagnosticSupportedResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateContent ComputeRecommenderGenerateContent(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> desiredLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize> desiredSizes = null, int? desiredCount = default(int?), bool? availabilityZones = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderGenerateResult ComputeRecommenderGenerateResult(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> desiredLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize> desiredSizes = null, int? desiredCount = default(int?), bool? availabilityZones = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore> placementScores = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderPlacementScore ComputeRecommenderPlacementScore(string sku = null, Azure.Core.AzureLocation? region = default(Azure.Core.AzureLocation?), string availabilityZone = null, string score = null, bool? isQuotaAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeRecommenderResourceSize ComputeRecommenderResourceSize(string sku = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.ComputeSkuMixPlacementData ComputeSkuMixPlacementData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> skuMixPlacementSupportedResourceTypes = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice ComputeSkuMixPlacementDeploymentChoice(string id = null, int score = 0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem> skuSplit = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent ComputeSkuMixPlacementGenerateContent(System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile capacityProfile = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize> instanceDescriptionVmSizes = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult ComputeSkuMixPlacementGenerateResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice> placementChoices = null, System.DateTimeOffset? validUntilOn = default(System.DateTimeOffset?), Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason partialFulfillmentReason = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason)) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem ComputeSkuMixPlacementItem(string name = null, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority priority = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority), int capacity = 0, int? capacityMax = default(int?), string zone = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile SkuMixPlacementCapacityProfile(int capacity = 0, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType capacityType = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType), Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority priority = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority), double? spotPriorityMaxPricePerVm = default(double?), Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy? allocationStrategy = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy?), Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType? osType = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType?), Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy zoneAllocationPolicy = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize SkuMixPlacementVMSize(string name = null, int? rank = default(int?)) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy SkuMixPlacementZoneAllocationPolicy(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy? distributionStrategy = default(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference> zonePreferences = null) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference SkuMixPlacementZonePreference(string zone = null, int? rank = default(int?), int? targetMaxCapacity = default(int?)) { throw null; }
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
    public partial class ComputeSkuMixPlacementDeploymentChoice : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>
    {
        internal ComputeSkuMixPlacementDeploymentChoice() { }
        public string Id { get { throw null; } }
        public int Score { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem> SkuSplit { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuMixPlacementGenerateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>
    {
        public ComputeSkuMixPlacementGenerateContent(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile capacityProfile, System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize> instanceDescriptionVmSizes) { }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile CapacityProfile { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize> InstanceDescriptionVmSizes { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuMixPlacementGenerateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>
    {
        internal ComputeSkuMixPlacementGenerateResult() { }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason PartialFulfillmentReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementDeploymentChoice> PlacementChoices { get { throw null; } }
        public System.DateTimeOffset? ValidUntilOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementGenerateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeSkuMixPlacementItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>
    {
        internal ComputeSkuMixPlacementItem() { }
        public int Capacity { get { throw null; } }
        public int? CapacityMax { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority Priority { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.ComputeSkuMixPlacementItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuMixPlacementAllocationStrategy : System.IEquatable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuMixPlacementAllocationStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy EvictionOptimized { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy LowestPrice { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuMixPlacementCapacityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>
    {
        public SkuMixPlacementCapacityProfile(int capacity, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType capacityType, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority priority) { }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementAllocationStrategy? AllocationStrategy { get { throw null; } set { } }
        public int Capacity { get { throw null; } }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType CapacityType { get { throw null; } }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority Priority { get { throw null; } }
        public double? SpotPriorityMaxPricePerVm { get { throw null; } set { } }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy ZoneAllocationPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuMixPlacementCapacityType : System.IEquatable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuMixPlacementCapacityType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType VCpu { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType Vm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementCapacityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuMixPlacementOSType : System.IEquatable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuMixPlacementOSType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuMixPlacementPartialFulfillmentReason : System.IEquatable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuMixPlacementPartialFulfillmentReason(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason InsufficientCapacity { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason InsufficientQuota { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPartialFulfillmentReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuMixPlacementPriority : System.IEquatable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuMixPlacementPriority(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority Regular { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuMixPlacementVMSize : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>
    {
        public SkuMixPlacementVMSize(string name) { }
        public string Name { get { throw null; } }
        public int? Rank { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementVMSize>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuMixPlacementZonalDistributionStrategy : System.IEquatable<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuMixPlacementZonalDistributionStrategy(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy BestEffortBalanced { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy BestEffortSingleZone { get { throw null; } }
        public static Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy Prioritized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy left, Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuMixPlacementZoneAllocationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>
    {
        public SkuMixPlacementZoneAllocationPolicy() { }
        public Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonalDistributionStrategy? DistributionStrategy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference> ZonePreferences { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZoneAllocationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuMixPlacementZonePreference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>
    {
        public SkuMixPlacementZonePreference(string zone) { }
        public int? Rank { get { throw null; } set { } }
        public int? TargetMaxCapacity { get { throw null; } set { } }
        public string Zone { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Recommender.Models.SkuMixPlacementZonePreference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
