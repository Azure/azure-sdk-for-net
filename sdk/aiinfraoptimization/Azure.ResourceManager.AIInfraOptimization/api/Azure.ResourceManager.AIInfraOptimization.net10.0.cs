namespace Azure.ResourceManager.AIInfraOptimization
{
    public static partial class AIInfraOptimizationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult> RecommendVmSku(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>> RecommendVmSkuAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAIInfraOptimizationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAIInfraOptimizationContext() { }
        public static Azure.ResourceManager.AIInfraOptimization.AzureResourceManagerAIInfraOptimizationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AIInfraOptimization.Mocking
{
    public partial class MockableAIInfraOptimizationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAIInfraOptimizationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult> RecommendVmSku(Azure.Core.AzureLocation location, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>> RecommendVmSkuAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AIInfraOptimization.Models
{
    public partial class AIInfraOptimizationRecommendVmSkuOptionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>
    {
        internal AIInfraOptimizationRecommendVmSkuOptionConfig() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark Benchmark { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost Cost { get { throw null; } }
        public System.Uri DocumentationUri { get { throw null; } }
        public bool? IsAzureMlRecommended { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate PerformanceEstimate { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement Placement { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota Quota { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness Readiness { get { throw null; } }
        public int RecommendationRank { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology Topology { get { throw null; } }
        public string VmSize { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAIInfraOptimizationModelFactory
    {
        public static Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig AIInfraOptimizationRecommendVmSkuOptionConfig(string vmSize = null, int recommendationRank = 0, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness readiness = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology topology = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost cost = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota quota = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement placement = null, bool? isAzureMlRecommended = default(bool?), Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark benchmark = null, System.Uri documentationUri = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate performanceEstimate = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator RecommendVmSkuAccelerator(string model = null, int countPerVm = 0, int memoryGiBPerAccelerator = 0) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark RecommendVmSkuBenchmark(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel level = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel), string modelClass = null, string scenario = null, int submitterCount = 0, string submissionId = null, string benchmarkModel = null, string submitter = null, string system = null, double? throughput = default(double?), string throughputUnit = null, string software = null, string operatingSystem = null, string weightDataTypes = null, double? p99TtftMs = default(double?), double? p99TpotMs = default(double?)) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent RecommendVmSkuContent(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel model = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload workload = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment deployment = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization optimization = null, System.Collections.Generic.IEnumerable<string> targetVmSizes = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig subscriptionOptions = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost RecommendVmSkuCost(string currencyCode = null, double vmHourly = 0, double deploymentHourly = 0, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource source = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource), System.DateTimeOffset? priceObservedOn = default(System.DateTimeOffset?), Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError error = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment RecommendVmSkuDeployment(int? replicaCount = default(int?), Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption? procurementOption = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption?)) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost RecommendVmSkuHourlyCost(double? amount = default(double?), string currencyCode = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory RecommendVmSkuMemory(double modelWeightsGiB = 0, double kvCacheGiBPerRequest = 0, double kvCacheGiBTotal = 0, double modelAndKvCacheGiB = 0) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel RecommendVmSkuModel(string huggingFaceModelId = null, long? parameterCount = default(long?), Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision? weightPrecision = default(Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision?), int? numLayers = default(int?), int? numKeyValueHeads = default(int?), int? headDim = default(int?), int? maxContextLength = default(int?)) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization RecommendVmSkuOptimization(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference? rankingPreference = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference?), Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost maxDeploymentCostPerHour = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate RecommendVmSkuPerformanceEstimate(double deploymentOutputTokensPerSecond = 0, double ttftMs = 0) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement RecommendVmSkuPlacement(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus status = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus), string reason = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError error = null, System.Collections.Generic.IEnumerable<string> recommendedAvailabilityZones = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota RecommendVmSkuQuota(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus status = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus), string reason = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError error = null, int? maxAvailableReplicaCount = default(int?), Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease increase = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease RecommendVmSkuQuotaIncrease(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit> limits = null, System.Uri portalUri = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit RecommendVmSkuQuotaLimit(string name = null, long currentUsage = (long)0, long currentLimit = (long)0, long requiredLimit = (long)0) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness RecommendVmSkuReadiness(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus status = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus), string reason = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult RecommendVmSkuResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig> options = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing sizing = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing RecommendVmSkuSizing(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel model = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload workload = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory memory = null, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis basis = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis RecommendVmSkuSizingBasis(Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource parameterCountSource = default(Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource), Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation modelWeightsCalculation = default(Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation), Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource contextLengthSource = default(Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource)) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel RecommendVmSkuSizingModel(long parameterCount = (long)0, Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision weightPrecision = default(Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision), string huggingFaceModelId = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload RecommendVmSkuSizingWorkload(int maxConcurrentRequestsPerReplica = 0, int contextLength = 0) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError RecommendVmSkuStageError(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode code = default(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode), string message = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig RecommendVmSkuSubscriptionConfig(bool? shouldIncludeQuota = default(bool?), bool? shouldIncludePlacement = default(bool?), bool? shouldIncludePricing = default(bool?)) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget RecommendVmSkuTokenBudget(int? promptTokens = default(int?), int? maxOutputTokens = default(int?)) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology RecommendVmSkuTopology(int estimatedNodeCountPerReplica = 0, long estimatedTotalNodeCount = (long)0, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator accelerator = null) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload RecommendVmSkuWorkload(int? maxConcurrentRequestsPerReplica = default(int?), Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget tokenBudget = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContextLengthSource : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContextLengthSource(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource Default { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource Request { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource left, Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource left, Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelWeightsCalculation : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelWeightsCalculation(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation ArtifactSize { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation EstimatedFromParameterCount { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation left, Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation left, Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterCountSource : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterCountSource(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource HuggingFace { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource Request { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource left, Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource left, Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuAccelerator : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>
    {
        internal RecommendVmSkuAccelerator() { }
        public int CountPerVm { get { throw null; } }
        public int MemoryGiBPerAccelerator { get { throw null; } }
        public string Model { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuBenchmark : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>
    {
        internal RecommendVmSkuBenchmark() { }
        public string BenchmarkModel { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel Level { get { throw null; } }
        public string ModelClass { get { throw null; } }
        public string OperatingSystem { get { throw null; } }
        public double? P99TpotMs { get { throw null; } }
        public double? P99TtftMs { get { throw null; } }
        public string Scenario { get { throw null; } }
        public string Software { get { throw null; } }
        public string SubmissionId { get { throw null; } }
        public string Submitter { get { throw null; } }
        public int SubmitterCount { get { throw null; } }
        public string System { get { throw null; } }
        public double? Throughput { get { throw null; } }
        public string ThroughputUnit { get { throw null; } }
        public string WeightDataTypes { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmark>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuBenchmarkLevel : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuBenchmarkLevel(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel Benchmarked { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel TopologyMatched { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuBenchmarkLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>
    {
        public RecommendVmSkuContent() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment Deployment { get { throw null; } set { } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel Model { get { throw null; } set { } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization Optimization { get { throw null; } set { } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig SubscriptionOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetVmSizes { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload Workload { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>
    {
        internal RecommendVmSkuCost() { }
        public string CurrencyCode { get { throw null; } }
        public double DeploymentHourly { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError Error { get { throw null; } }
        public System.DateTimeOffset? PriceObservedOn { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource Source { get { throw null; } }
        public double VmHourly { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuCostSource : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuCostSource(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource AzureRetail { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource AzureSubscription { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource StaticPreview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuCostSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>
    {
        public RecommendVmSkuDeployment() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption? ProcurementOption { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuHourlyCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>
    {
        public RecommendVmSkuHourlyCost() { }
        public double? Amount { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuMemory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>
    {
        internal RecommendVmSkuMemory() { }
        public double KvCacheGiBPerRequest { get { throw null; } }
        public double KvCacheGiBTotal { get { throw null; } }
        public double ModelAndKvCacheGiB { get { throw null; } }
        public double ModelWeightsGiB { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>
    {
        public RecommendVmSkuModel() { }
        public int? HeadDim { get { throw null; } set { } }
        public string HuggingFaceModelId { get { throw null; } set { } }
        public int? MaxContextLength { get { throw null; } set { } }
        public int? NumKeyValueHeads { get { throw null; } set { } }
        public int? NumLayers { get { throw null; } set { } }
        public long? ParameterCount { get { throw null; } set { } }
        public Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision? WeightPrecision { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuOptimization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>
    {
        public RecommendVmSkuOptimization() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuHourlyCost MaxDeploymentCostPerHour { get { throw null; } set { } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference? RankingPreference { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuOptimization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuPerformanceEstimate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>
    {
        internal RecommendVmSkuPerformanceEstimate() { }
        public double DeploymentOutputTokensPerSecond { get { throw null; } }
        public double TtftMs { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPerformanceEstimate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuPlacement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>
    {
        internal RecommendVmSkuPlacement() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError Error { get { throw null; } }
        public string Reason { get { throw null; } }
        public System.Collections.Generic.IList<string> RecommendedAvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuPlacementStatus : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuPlacementStatus(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus Evaluated { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus NotEvaluated { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus Unsupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuPlacementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuProcurementOption : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuProcurementOption(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption OnDemand { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuProcurementOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>
    {
        internal RecommendVmSkuQuota() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError Error { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease Increase { get { throw null; } }
        public int? MaxAvailableReplicaCount { get { throw null; } }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuQuotaIncrease : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>
    {
        internal RecommendVmSkuQuotaIncrease() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit> Limits { get { throw null; } }
        public System.Uri PortalUri { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaIncrease>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuQuotaLimit : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>
    {
        internal RecommendVmSkuQuotaLimit() { }
        public long CurrentLimit { get { throw null; } }
        public long CurrentUsage { get { throw null; } }
        public string Name { get { throw null; } }
        public long RequiredLimit { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaLimit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuQuotaStatus : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuQuotaStatus(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus Available { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus Unavailable { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuQuotaStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuRankingPreference : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuRankingPreference(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference Cost { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference Latency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuRankingPreference right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuReadiness : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>
    {
        internal RecommendVmSkuReadiness() { }
        public string Reason { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadiness>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuReadinessStatus : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuReadinessStatus(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus QuotaIncreaseRequired { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus ReadyToAttempt { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus Unavailable { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus VerificationRequired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuReadinessStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>
    {
        internal RecommendVmSkuResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AIInfraOptimization.Models.AIInfraOptimizationRecommendVmSkuOptionConfig> Options { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing Sizing { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuSizing : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>
    {
        internal RecommendVmSkuSizing() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis Basis { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuMemory Memory { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel Model { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload Workload { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizing>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuSizingBasis : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>
    {
        internal RecommendVmSkuSizingBasis() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.ContextLengthSource ContextLengthSource { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.ModelWeightsCalculation ModelWeightsCalculation { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.ParameterCountSource ParameterCountSource { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingBasis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuSizingModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>
    {
        internal RecommendVmSkuSizingModel() { }
        public string HuggingFaceModelId { get { throw null; } }
        public long ParameterCount { get { throw null; } }
        public Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision WeightPrecision { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuSizingWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>
    {
        internal RecommendVmSkuSizingWorkload() { }
        public int ContextLength { get { throw null; } }
        public int MaxConcurrentRequestsPerReplica { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSizingWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuStageError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>
    {
        internal RecommendVmSkuStageError() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendVmSkuStageErrorCode : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendVmSkuStageErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode DataUnavailable { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode DependencyError { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode EvaluationBudgetExceeded { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode PartitionCapacityExceeded { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode Throttled { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode left, Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuStageErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecommendVmSkuSubscriptionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>
    {
        public RecommendVmSkuSubscriptionConfig() { }
        public bool? ShouldIncludePlacement { get { throw null; } set { } }
        public bool? ShouldIncludePricing { get { throw null; } set { } }
        public bool? ShouldIncludeQuota { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuSubscriptionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuTokenBudget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>
    {
        public RecommendVmSkuTokenBudget() { }
        public int? MaxOutputTokens { get { throw null; } set { } }
        public int? PromptTokens { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuTopology : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>
    {
        internal RecommendVmSkuTopology() { }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuAccelerator Accelerator { get { throw null; } }
        public int EstimatedNodeCountPerReplica { get { throw null; } }
        public long EstimatedTotalNodeCount { get { throw null; } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTopology>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecommendVmSkuWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>
    {
        public RecommendVmSkuWorkload() { }
        public int? MaxConcurrentRequestsPerReplica { get { throw null; } set { } }
        public Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuTokenBudget TokenBudget { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AIInfraOptimization.Models.RecommendVmSkuWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightPrecision : System.IEquatable<Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightPrecision(string value) { throw null; }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision BF16 { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision FP16 { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision FP32 { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision FP4 { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision FP8 { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision Int4 { get { throw null; } }
        public static Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision Int8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision left, Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision right) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision left, Azure.ResourceManager.AIInfraOptimization.Models.WeightPrecision right) { throw null; }
        public override string ToString() { throw null; }
    }
}
