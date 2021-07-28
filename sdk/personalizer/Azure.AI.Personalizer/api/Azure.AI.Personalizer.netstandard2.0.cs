namespace Azure.AI.Personalizer
{
    public partial class PersonalizerAdministrationClient
    {
        protected PersonalizerAdministrationClient() { }
        public PersonalizerAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerClientOptions options = null) { }
        public PersonalizerAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerClientOptions options = null) { }
        public virtual Azure.Response ApplyPersonalizerEvaluation(Azure.AI.Personalizer.Models.PersonalizerPolicyReferenceOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplyPersonalizerEvaluationAsync(Azure.AI.Personalizer.Models.PersonalizerPolicyReferenceOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Personalizer.Models.PersonalizerCreateEvaluationOperation CreatePersonalizerEvaluation(Azure.AI.Personalizer.Models.PersonalizerEvaluationOptions evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Personalizer.Models.PersonalizerCreateEvaluationOperation> CreatePersonalizerEvaluationAsync(Azure.AI.Personalizer.Models.PersonalizerEvaluationOptions evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeletePersonalizerEvaluation(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePersonalizerEvaluationAsync(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeletePersonalizerLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePersonalizerLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerServiceProperties> GetPersonalizerConfiguration(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerServiceProperties>> GetPersonalizerConfigurationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerEvaluation> GetPersonalizerEvaluation(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerEvaluation>> GetPersonalizerEvaluationAsync(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Personalizer.Models.PersonalizerEvaluation> GetPersonalizerEvaluations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Personalizer.Models.PersonalizerEvaluation> GetPersonalizerEvaluationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerLogProperties> GetPersonalizerLogProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerLogProperties>> GetPersonalizerLogPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> GetPersonalizerModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> GetPersonalizerModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerModelProperties> GetPersonalizerModelProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerModelProperties>> GetPersonalizerModelPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions> GetPersonalizerPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions>> GetPersonalizerPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetPersonalizerModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetPersonalizerModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions> ResetPersonalizerPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions>> ResetPersonalizerPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerServiceProperties> UpdatePersonalizerConfiguration(Azure.AI.Personalizer.Models.PersonalizerServiceProperties config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerServiceProperties>> UpdatePersonalizerConfigurationAsync(Azure.AI.Personalizer.Models.PersonalizerServiceProperties config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions> UpdatePersonalizerPolicy(Azure.AI.Personalizer.Models.PersonalizerPolicyOptions policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions>> UpdatePersonalizerPolicyAsync(Azure.AI.Personalizer.Models.PersonalizerPolicyOptions policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersonalizerClient
    {
        protected PersonalizerClient() { }
        public PersonalizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public PersonalizerClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerClientOptions options = null) { }
        public PersonalizerClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public PersonalizerClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerClientOptions options = null) { }
        public virtual Azure.Response Activate(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateAsync(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ActivateMultiSlot(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ActivateMultiSlotAsync(string eventId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerRankResult> Rank(Azure.AI.Personalizer.Models.PersonalizerRankOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerRankResult> Rank(System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IList<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerRankResult>> RankAsync(Azure.AI.Personalizer.Models.PersonalizerRankOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerRankResult>> RankAsync(System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IList<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerMultiSlotRankResult> RankMultiSlot(Azure.AI.Personalizer.Models.PersonalizerRankMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.Models.PersonalizerMultiSlotRankResult> RankMultiSlot(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerSlotOptions> slots, System.Collections.Generic.IList<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerMultiSlotRankResult>> RankMultiSlotAsync(Azure.AI.Personalizer.Models.PersonalizerRankMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerMultiSlotRankResult>> RankMultiSlotAsync(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerSlotOptions> slots, System.Collections.Generic.IList<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reward(string eventId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardAsync(string eventId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RewardMultiSlot(string eventId, Azure.AI.Personalizer.Models.PersonalizerRewardMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RewardMultiSlot(string eventId, string slotId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardMultiSlotAsync(string eventId, Azure.AI.Personalizer.Models.PersonalizerRewardMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardMultiSlotAsync(string eventId, string slotId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersonalizerClientOptions : Azure.Core.ClientOptions
    {
        public PersonalizerClientOptions(Azure.AI.Personalizer.PersonalizerClientOptions.ServiceVersion version = Azure.AI.Personalizer.PersonalizerClientOptions.ServiceVersion.V1_1_preview_1) { }
        public enum ServiceVersion
        {
            V1_1_preview_1 = 1,
        }
    }
}
namespace Azure.AI.Personalizer.Models
{
    public partial class PersonalizerCreateEvaluationOperation : Azure.Operation<Azure.AI.Personalizer.Models.PersonalizerEvaluation>
    {
        protected PersonalizerCreateEvaluationOperation() { }
        public PersonalizerCreateEvaluationOperation(string evaluationId, Azure.AI.Personalizer.PersonalizerAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.Personalizer.Models.PersonalizerEvaluation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerEvaluation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.Personalizer.Models.PersonalizerEvaluation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PersonalizerDateRange
    {
        internal PersonalizerDateRange() { }
        public System.DateTimeOffset? End { get { throw null; } }
        public System.DateTimeOffset? Start { get { throw null; } }
    }
    public partial class PersonalizerEvaluation
    {
        internal PersonalizerEvaluation() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.AI.Personalizer.Models.PersonalizerEvaluationType? EvaluationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<string>> FeatureImportance { get { throw null; } }
        public string Id { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Name { get { throw null; } }
        public string OptimalPolicy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.PersonalizerPolicyResult> PolicyResults { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerEvaluationJobStatus : System.IEquatable<Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerEvaluationJobStatus(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus Completed { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus Failed { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus NotSubmitted { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus OnlinePolicyRetained { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus OptimalPolicyApplied { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus Pending { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus Timeout { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus left, Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus left, Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersonalizerEvaluationOptions
    {
        public PersonalizerEvaluationOptions(string name, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions> policies) { }
        public bool? EnableOfflineExperimentation { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerPolicyOptions> Policies { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerEvaluationType : System.IEquatable<Azure.AI.Personalizer.Models.PersonalizerEvaluationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerEvaluationType(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationType Auto { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluationType Manual { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.PersonalizerEvaluationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.PersonalizerEvaluationType left, Azure.AI.Personalizer.Models.PersonalizerEvaluationType right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.PersonalizerEvaluationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.PersonalizerEvaluationType left, Azure.AI.Personalizer.Models.PersonalizerEvaluationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerLearningMode : System.IEquatable<Azure.AI.Personalizer.Models.PersonalizerLearningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerLearningMode(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerLearningMode Apprentice { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerLearningMode LoggingOnly { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerLearningMode Online { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.PersonalizerLearningMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.PersonalizerLearningMode left, Azure.AI.Personalizer.Models.PersonalizerLearningMode right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.PersonalizerLearningMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.PersonalizerLearningMode left, Azure.AI.Personalizer.Models.PersonalizerLearningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersonalizerLogProperties
    {
        internal PersonalizerLogProperties() { }
        public Azure.AI.Personalizer.Models.PersonalizerLogPropertiesDateRange DateRange { get { throw null; } }
    }
    public partial class PersonalizerLogPropertiesDateRange : Azure.AI.Personalizer.Models.PersonalizerDateRange
    {
        internal PersonalizerLogPropertiesDateRange() { }
    }
    public static partial class PersonalizerModelFactory
    {
        public static Azure.AI.Personalizer.Models.PersonalizerDateRange PersonalizerDateRange(System.DateTimeOffset? start = default(System.DateTimeOffset?), System.DateTimeOffset? end = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerEvaluation PersonalizerEvaluation(string id = null, string name = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string jobId = null, Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus? status = default(Azure.AI.Personalizer.Models.PersonalizerEvaluationJobStatus?), System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerPolicyResult> policyResults = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> featureImportance = null, Azure.AI.Personalizer.Models.PersonalizerEvaluationType? evaluationType = default(Azure.AI.Personalizer.Models.PersonalizerEvaluationType?), string optimalPolicy = null, System.DateTimeOffset? creationTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerLogProperties PersonalizerLogProperties(Azure.AI.Personalizer.Models.PersonalizerLogPropertiesDateRange dateRange = null) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerModelProperties PersonalizerModelProperties(System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerMultiSlotRankResult PersonalizerMultiSlotRankResult(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerSlotResult> slots = null, string eventId = null) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicyResult PersonalizerPolicyResult(string name = null, string arguments = null, Azure.AI.Personalizer.Models.PersonalizerPolicySource? policySource = default(Azure.AI.Personalizer.Models.PersonalizerPolicySource?), System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerPolicyResultSummary> summary = null, Azure.AI.Personalizer.Models.PersonalizerPolicyResultTotalSummary totalSummary = null) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicyResultSummary PersonalizerPolicyResultSummary(System.DateTimeOffset? timeStamp = default(System.DateTimeOffset?), float? ipsEstimatorNumerator = default(float?), float? ipsEstimatorDenominator = default(float?), float? snipsEstimatorDenominator = default(float?), System.TimeSpan? aggregateTimeWindow = default(System.TimeSpan?), float? nonZeroProbability = default(float?), float? sumOfSquares = default(float?), float? confidenceInterval = default(float?), float? averageReward = default(float?)) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerRankedAction PersonalizerRankedAction(string id = null, float? probability = default(float?)) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerRankResult PersonalizerRankResult(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerRankedAction> ranking = null, string eventId = null, string rewardActionId = null) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerSlotResult PersonalizerSlotResult(string slotId = null, string rewardActionId = null) { throw null; }
    }
    public partial class PersonalizerModelProperties
    {
        internal PersonalizerModelProperties() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
    }
    public partial class PersonalizerMultiSlotRankResult
    {
        internal PersonalizerMultiSlotRankResult() { }
        public string EventId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.PersonalizerSlotResult> Slots { get { throw null; } }
    }
    public partial class PersonalizerPolicyOptions
    {
        public PersonalizerPolicyOptions(string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class PersonalizerPolicyReferenceOptions
    {
        public PersonalizerPolicyReferenceOptions(string evaluationId, string policyName) { }
        public string EvaluationId { get { throw null; } }
        public string PolicyName { get { throw null; } }
    }
    public partial class PersonalizerPolicyResult
    {
        internal PersonalizerPolicyResult() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Personalizer.Models.PersonalizerPolicySource? PolicySource { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.PersonalizerPolicyResultSummary> Summary { get { throw null; } }
        public Azure.AI.Personalizer.Models.PersonalizerPolicyResultTotalSummary TotalSummary { get { throw null; } }
    }
    public partial class PersonalizerPolicyResultSummary
    {
        internal PersonalizerPolicyResultSummary() { }
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
    public partial class PersonalizerPolicyResultTotalSummary : Azure.AI.Personalizer.Models.PersonalizerPolicyResultSummary
    {
        internal PersonalizerPolicyResultTotalSummary() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerPolicySource : System.IEquatable<Azure.AI.Personalizer.Models.PersonalizerPolicySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerPolicySource(string value) { throw null; }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicySource Baseline { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicySource Custom { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicySource OfflineExperimentation { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicySource Online { get { throw null; } }
        public static Azure.AI.Personalizer.Models.PersonalizerPolicySource Random { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.Models.PersonalizerPolicySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.Models.PersonalizerPolicySource left, Azure.AI.Personalizer.Models.PersonalizerPolicySource right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.Models.PersonalizerPolicySource (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.Models.PersonalizerPolicySource left, Azure.AI.Personalizer.Models.PersonalizerPolicySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersonalizerRankableAction
    {
        public PersonalizerRankableAction(string id, System.Collections.Generic.IEnumerable<object> features) { }
        public System.Collections.Generic.IList<object> Features { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class PersonalizerRankedAction
    {
        internal PersonalizerRankedAction() { }
        public string Id { get { throw null; } }
        public float? Probability { get { throw null; } }
    }
    public partial class PersonalizerRankMultiSlotOptions
    {
        public PersonalizerRankMultiSlotOptions() { }
        public PersonalizerRankMultiSlotOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerSlotOptions> slots) { }
        public PersonalizerRankMultiSlotOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerSlotOptions> slots, System.Collections.Generic.IList<object> contextFeatures = null, string eventId = null, bool deferActivation = false) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerRankableAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<object> ContextFeatures { get { throw null; } }
        public bool? DeferActivation { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerSlotOptions> Slots { get { throw null; } }
    }
    public partial class PersonalizerRankOptions
    {
        public PersonalizerRankOptions() { }
        public PersonalizerRankOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions) { }
        public PersonalizerRankOptions(System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerRankableAction> actions, System.Collections.Generic.IList<object> contextFeatures = null, System.Collections.Generic.IList<string> excludedActions = null, string eventId = null, bool? deferActivation = default(bool?)) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerRankableAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<object> ContextFeatures { get { throw null; } }
        public bool? DeferActivation { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
    }
    public partial class PersonalizerRankResult
    {
        internal PersonalizerRankResult() { }
        public string EventId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.Models.PersonalizerRankedAction> Ranking { get { throw null; } }
        public string RewardActionId { get { throw null; } }
    }
    public partial class PersonalizerRewardMultiSlotOptions
    {
        public PersonalizerRewardMultiSlotOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.Models.PersonalizerSlotReward> reward) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.Models.PersonalizerSlotReward> Reward { get { throw null; } }
    }
    public partial class PersonalizerRewardOptions
    {
        public PersonalizerRewardOptions(float value) { }
        public float Value { get { throw null; } }
    }
    public partial class PersonalizerServiceProperties
    {
        public PersonalizerServiceProperties(System.TimeSpan rewardWaitTime, float defaultReward, string rewardAggregation, float explorationPercentage, System.TimeSpan modelExportFrequency, int logRetentionDays) { }
        public System.TimeSpan? AutoOptimizationFrequency { get { throw null; } set { } }
        public System.DateTimeOffset? AutoOptimizationStartDate { get { throw null; } set { } }
        public float DefaultReward { get { throw null; } set { } }
        public float ExplorationPercentage { get { throw null; } set { } }
        public bool? IsAutoOptimizationEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastConfigurationEditDate { get { throw null; } set { } }
        public Azure.AI.Personalizer.Models.PersonalizerLearningMode? LearningMode { get { throw null; } set { } }
        public bool? LogMirrorEnabled { get { throw null; } set { } }
        public System.Uri LogMirrorSasUri { get { throw null; } set { } }
        public int LogRetentionDays { get { throw null; } set { } }
        public System.TimeSpan ModelExportFrequency { get { throw null; } set { } }
        public string RewardAggregation { get { throw null; } set { } }
        public System.TimeSpan RewardWaitTime { get { throw null; } set { } }
    }
    public partial class PersonalizerSlotOptions
    {
        public PersonalizerSlotOptions() { }
        public PersonalizerSlotOptions(string id, string baselineAction) { }
        public PersonalizerSlotOptions(string id, string baselineAction, System.Collections.Generic.IList<object> features = null, System.Collections.Generic.IList<string> excludedActions = null) { }
        public string BaselineAction { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<object> Features { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class PersonalizerSlotResult
    {
        internal PersonalizerSlotResult() { }
        public string RewardActionId { get { throw null; } }
        public string SlotId { get { throw null; } }
    }
    public partial class PersonalizerSlotReward
    {
        public PersonalizerSlotReward(string slotId, float value) { }
        public string SlotId { get { throw null; } }
        public float Value { get { throw null; } }
    }
}
