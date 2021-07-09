namespace Azure.AI.Personalizer
{
    public partial class EvaluationsClient
    {
        protected EvaluationsClient() { }
        public EvaluationsClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public EvaluationsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.Evaluation> Create(Azure.AI.Personalizer.Models.EvaluationContract evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.Evaluation>> CreateAsync(Azure.AI.Personalizer.Models.EvaluationContract evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.Evaluation> Get(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.Evaluation>> GetAsync(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.Evaluation>> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.Evaluation>>> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventsClient
    {
        protected EventsClient() { }
        public EventsClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public EventsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response Activate(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reward(string eventId, Azure.AI.Personalizer.Models.RewardRequest reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardAsync(string eventId, Azure.AI.Personalizer.Models.RewardRequest reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogClient
    {
        protected LogClient() { }
        public LogClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public LogClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.LogProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.LogProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ModelClient
    {
        protected ModelClient() { }
        public ModelClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public ModelClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response<System.IO.Stream> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.ModelProperties> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.ModelProperties>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reset(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MultiSlotClient
    {
        protected MultiSlotClient() { }
        public MultiSlotClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public MultiSlotClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.MultiSlotRankResponse> Rank(Azure.AI.Personalizer.Models.MultiSlotRankRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.MultiSlotRankResponse>> RankAsync(Azure.AI.Personalizer.Models.MultiSlotRankRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MultiSlotEventsClient
    {
        protected MultiSlotEventsClient() { }
        public MultiSlotEventsClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public MultiSlotEventsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response Activate(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reward(string eventId, Azure.AI.Personalizer.Models.MultiSlotRewardRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardAsync(string eventId, Azure.AI.Personalizer.Models.MultiSlotRewardRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersonalizerBaseClient
    {
        protected PersonalizerBaseClient() { }
        public PersonalizerBaseClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public PersonalizerBaseClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.RankResponse> Rank(Azure.AI.Personalizer.Models.RankRequest rankRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.RankResponse>> RankAsync(Azure.AI.Personalizer.Models.RankRequest rankRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersonalizerBaseClientOptions : Azure.Core.ClientOptions
    {
        public PersonalizerBaseClientOptions(Azure.AI.Personalizer.PersonalizerBaseClientOptions.ServiceVersion version = Azure.AI.Personalizer.PersonalizerBaseClientOptions.ServiceVersion.Vv1_1_preview_1) { }
        public enum ServiceVersion
        {
            Vv1_1_preview_1 = 1,
        }
    }
    public partial class PersonalizerClient
    {
        protected PersonalizerClient() { }
        public PersonalizerClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public PersonalizerClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public Azure.AI.Personalizer.EvaluationsClient Evaluations { get { throw null; } set { } }
        public Azure.AI.Personalizer.EventsClient Events { get { throw null; } set { } }
        public Azure.AI.Personalizer.LogClient Log { get { throw null; } set { } }
        public Azure.AI.Personalizer.ModelClient Model { get { throw null; } set { } }
        public Azure.AI.Personalizer.MultiSlotClient MultiSlot { get { throw null; } set { } }
        public Azure.AI.Personalizer.MultiSlotEventsClient MultiSlotEvents { get { throw null; } set { } }
        public Azure.AI.Personalizer.PersonalizerBaseClient PersonalizerBase { get { throw null; } set { } }
        public Azure.AI.Personalizer.PolicyClient Policy { get { throw null; } set { } }
        public Azure.AI.Personalizer.ServiceConfigurationClient ServiceConfiguration { get { throw null; } set { } }
    }
    public partial class PolicyClient
    {
        protected PolicyClient() { }
        public PolicyClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public PolicyClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PolicyContract> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PolicyContract>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PolicyContract> Reset(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PolicyContract>> ResetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PolicyContract> Update(Azure.AI.Personalizer.Models.PolicyContract policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PolicyContract>> UpdateAsync(Azure.AI.Personalizer.Models.PolicyContract policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceConfigurationClient
    {
        protected ServiceConfigurationClient() { }
        public ServiceConfigurationClient(string endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public ServiceConfigurationClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerBaseClientOptions options = null) { }
        public virtual Azure.Response ApplyFromEvaluation(Azure.AI.Personalizer.Models.PolicyReferenceContract body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplyFromEvaluationAsync(Azure.AI.Personalizer.Models.PolicyReferenceContract body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.ServiceConfiguration> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.ServiceConfiguration>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.ServiceConfiguration> Update(Azure.AI.Personalizer.Models.ServiceConfiguration config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.ServiceConfiguration>> UpdateAsync(Azure.AI.Personalizer.Models.ServiceConfiguration config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.Personalizer.Models
{
    public partial class DateRange
    {
        internal DateRange() { }
        public System.DateTimeOffset? From { get { throw null; } }
        public System.DateTimeOffset? To { get { throw null; } }
    }
    public partial class Evaluation
    {
        internal Evaluation() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.AI.Personalizer.Models.EvaluationType? EvaluationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<string>> FeatureImportance { get { throw null; } }
        public string Id { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Name { get { throw null; } }
        public string OptimalPolicy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.PolicyResult> PolicyResults { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.AI.Personalizer.Models.EvaluationJobStatus? Status { get { throw null; } }
    }
    public partial class EvaluationContract
    {
        public EvaluationContract(string name, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PolicyContract> policies) { }
        public bool? EnableOfflineExperimentation { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PolicyContract> Policies { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationJobStatus : System.IEquatable<Azure.AI.Personalizer.Models.EvaluationJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationJobStatus(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus Completed { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus Failed { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus NotSubmitted { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus OnlinePolicyRetained { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus OptimalPolicyApplied { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus Pending { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationJobStatus Timeout { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.EvaluationJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.EvaluationJobStatus left, Azure.AI.Personalizer.Models.EvaluationJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.EvaluationJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.EvaluationJobStatus left, Azure.AI.Personalizer.Models.EvaluationJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationType : System.IEquatable<Azure.AI.Personalizer.Models.EvaluationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationType(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.EvaluationType Auto { get { throw null; } }
        public static Azure.AI.Personalizer.Models.EvaluationType Manual { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.EvaluationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.EvaluationType left, Azure.AI.Personalizer.Models.EvaluationType right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.EvaluationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.EvaluationType left, Azure.AI.Personalizer.Models.EvaluationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LearningMode : System.IEquatable<Azure.AI.Personalizer.Models.LearningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LearningMode(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.LearningMode Apprentice { get { throw null; } }
        public static Azure.AI.Personalizer.Models.LearningMode LoggingOnly { get { throw null; } }
        public static Azure.AI.Personalizer.Models.LearningMode Online { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.LearningMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.LearningMode left, Azure.AI.Personalizer.Models.LearningMode right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.LearningMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.LearningMode left, Azure.AI.Personalizer.Models.LearningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogProperties
    {
        internal LogProperties() { }
        public Azure.AI.Personalizer.Models.LogsPropertiesDateRange DateRange { get { throw null; } }
    }
    public partial class LogsPropertiesDateRange : Azure.AI.Personalizer.Models.DateRange
    {
        internal LogsPropertiesDateRange() { }
    }
    public partial class ModelProperties
    {
        internal ModelProperties() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
    }
    public partial class MultiSlotRankRequest
    {
        public MultiSlotRankRequest() { }
        public MultiSlotRankRequest(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.RankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.SlotRequest> slots) { }
        public MultiSlotRankRequest(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.RankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.SlotRequest> slots, System.Collections.Generic.IList<object> contextFeatures = null, string eventId = null, bool deferActivation = false) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.RankableAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<object> ContextFeatures { get { throw null; } }
        public bool? DeferActivation { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.SlotRequest> Slots { get { throw null; } }
    }
    public partial class MultiSlotRankResponse
    {
        internal MultiSlotRankResponse() { }
        public string EventId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.SlotResponse> Slots { get { throw null; } }
    }
    public partial class MultiSlotRewardRequest
    {
        public MultiSlotRewardRequest(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.SlotReward> reward) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.SlotReward> Reward { get { throw null; } }
    }
    public static partial class PersonalizerBaseModelFactory
    {
        public static Azure.AI.Personalizer.Models.DateRange DateRange(System.DateTimeOffset? from = default(System.DateTimeOffset?), System.DateTimeOffset? to = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.Models.Evaluation Evaluation(string id = null, string name = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string jobId = null, Azure.AI.Personalizer.Models.EvaluationJobStatus? status = default(Azure.AI.Personalizer.Models.EvaluationJobStatus?), System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PolicyResult> policyResults = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> featureImportance = null, Azure.AI.Personalizer.Models.EvaluationType? evaluationType = default(Azure.AI.Personalizer.Models.EvaluationType?), string optimalPolicy = null, System.DateTimeOffset? creationTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.Models.LogProperties LogsProperties(Azure.AI.Personalizer.Models.LogsPropertiesDateRange dateRange = null) { throw null; }
        public static Azure.AI.Personalizer.Models.ModelProperties ModelProperties(System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.Models.MultiSlotRankResponse MultiSlotRankResponse(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.SlotResponse> slots = null, string eventId = null) { throw null; }
        public static Azure.AI.Personalizer.Models.PolicyResult PolicyResult(string name = null, string arguments = null, Azure.AI.Personalizer.Models.PolicySource? policySource = default(Azure.AI.Personalizer.Models.PolicySource?), System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PolicyResultSummary> summary = null, Azure.AI.Personalizer.Models.PolicyResultTotalSummary totalSummary = null) { throw null; }
        public static Azure.AI.Personalizer.Models.PolicyResultSummary PolicyResultSummary(System.DateTimeOffset? timeStamp = default(System.DateTimeOffset?), float? ipsEstimatorNumerator = default(float?), float? ipsEstimatorDenominator = default(float?), float? snipsEstimatorDenominator = default(float?), System.TimeSpan? aggregateTimeWindow = default(System.TimeSpan?), float? nonZeroProbability = default(float?), float? sumOfSquares = default(float?), float? confidenceInterval = default(float?), float? averageReward = default(float?)) { throw null; }
        public static Azure.AI.Personalizer.Models.RankedAction RankedAction(string id = null, float? probability = default(float?)) { throw null; }
        public static Azure.AI.Personalizer.Models.RankResponse RankResponse(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.RankedAction> ranking = null, string eventId = null, string rewardActionId = null) { throw null; }
        public static Azure.AI.Personalizer.Models.SlotResponse SlotResponse(string id = null, string rewardActionId = null) { throw null; }
    }
    public partial class PolicyContract
    {
        public PolicyContract(string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class PolicyReferenceContract
    {
        public PolicyReferenceContract(string evaluationId, string policyName) { }
        public string EvaluationId { get { throw null; } }
        public string PolicyName { get { throw null; } }
    }
    public partial class PolicyResult
    {
        internal PolicyResult() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Personalizer.Models.PolicySource? PolicySource { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.PolicyResultSummary> Summary { get { throw null; } }
        public Azure.AI.Personalizer.Models.PolicyResultTotalSummary TotalSummary { get { throw null; } }
    }
    public partial class PolicyResultSummary
    {
        internal PolicyResultSummary() { }
        public System.TimeSpan? AggregateTimeWindow { get { throw null; } }
        public float? AverageReward { get { throw null; } }
        public float? ConfidenceInterval { get { throw null; } }
        public float? IpsEstimatorDenominator { get { throw null; } }
        public float? IpsEstimatorNumerator { get { throw null; } }
        public float? NonZeroProbability { get { throw null; } }
        public float? SnipsEstimatorDenominator { get { throw null; } }
        public float? SumOfSquares { get { throw null; } }
        public System.DateTimeOffset? TimeStamp { get { throw null; } }
    }
    public partial class PolicyResultTotalSummary : Azure.AI.Personalizer.Models.PolicyResultSummary
    {
        internal PolicyResultTotalSummary() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicySource : System.IEquatable<Azure.AI.Personalizer.Models.PolicySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicySource(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.PolicySource Baseline { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PolicySource Custom { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PolicySource OfflineExperimentation { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PolicySource Online { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PolicySource Random { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.PolicySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.PolicySource left, Azure.AI.Personalizer.Models.PolicySource right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.PolicySource (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.PolicySource left, Azure.AI.Personalizer.Models.PolicySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RankableAction
    {
        public RankableAction(string id, System.Collections.Generic.IEnumerable<object> features) { }
        public System.Collections.Generic.IList<object> Features { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class RankedAction
    {
        internal RankedAction() { }
        public string Id { get { throw null; } }
        public float? Probability { get { throw null; } }
    }
    public partial class RankRequest
    {
        public RankRequest() { }
        public RankRequest(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.RankableAction> actions) { }
        public RankRequest(System.Collections.Generic.IList<Azure.AI.Personalizer.Models.RankableAction> actions, System.Collections.Generic.IList<object> contextFeatures = null, System.Collections.Generic.IList<string> excludedActions = null, string eventId = null, bool? deferActivation = default(bool?)) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.RankableAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<object> ContextFeatures { get { throw null; } }
        public bool? DeferActivation { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
    }
    public partial class RankResponse
    {
        internal RankResponse() { }
        public string EventId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.RankedAction> Ranking { get { throw null; } }
        public string RewardActionId { get { throw null; } }
    }
    public partial class RewardRequest
    {
        public RewardRequest(float value) { }
        public float Value { get { throw null; } }
    }
    public partial class ServiceConfiguration
    {
        public ServiceConfiguration(System.TimeSpan rewardWaitTime, float defaultReward, string rewardAggregation, float explorationPercentage, System.TimeSpan modelExportFrequency, int logRetentionDays) { }
        public System.TimeSpan? AutoOptimizationFrequency { get { throw null; } set { } }
        public System.DateTimeOffset? AutoOptimizationStartDate { get { throw null; } set { } }
        public float DefaultReward { get { throw null; } set { } }
        public float ExplorationPercentage { get { throw null; } set { } }
        public bool? IsAutoOptimizationEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastConfigurationEditDate { get { throw null; } set { } }
        public Azure.AI.Personalizer.Models.LearningMode? LearningMode { get { throw null; } set { } }
        public bool? LogMirrorEnabled { get { throw null; } set { } }
        public string LogMirrorSasUri { get { throw null; } set { } }
        public int LogRetentionDays { get { throw null; } set { } }
        public System.TimeSpan ModelExportFrequency { get { throw null; } set { } }
        public string RewardAggregation { get { throw null; } set { } }
        public System.TimeSpan RewardWaitTime { get { throw null; } set { } }
    }
    public partial class SlotRequest
    {
        public SlotRequest() { }
        public SlotRequest(string id, string baselineAction) { }
        public SlotRequest(string id, string baselineAction, System.Collections.Generic.IList<object> features = null, System.Collections.Generic.IList<string> excludedActions = null) { }
        public string BaselineAction { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<object> Features { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class SlotResponse
    {
        internal SlotResponse() { }
        public string Id { get { throw null; } }
        public string RewardActionId { get { throw null; } }
    }
    public partial class SlotReward
    {
        public SlotReward(string slotId, float value) { }
        public string SlotId { get { throw null; } }
        public float Value { get { throw null; } }
    }
}
