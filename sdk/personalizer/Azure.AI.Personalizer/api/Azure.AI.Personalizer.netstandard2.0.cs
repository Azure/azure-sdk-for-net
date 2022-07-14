namespace Azure.AI.Personalizer
{
    public partial class PersonalizerAdministrationClient
    {
        protected PersonalizerAdministrationClient() { }
        public PersonalizerAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Personalizer.PersonalizerClientOptions options = null) { }
        public PersonalizerAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Personalizer.PersonalizerClientOptions options = null) { }
        public virtual Azure.Response ApplyPersonalizerEvaluation(Azure.AI.Personalizer.PersonalizerPolicyReferenceOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ApplyPersonalizerEvaluationAsync(Azure.AI.Personalizer.PersonalizerPolicyReferenceOptions body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Personalizer.PersonalizerCreateEvaluationOperation CreatePersonalizerEvaluation(Azure.AI.Personalizer.PersonalizerEvaluationOptions evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Personalizer.PersonalizerCreateEvaluationOperation> CreatePersonalizerEvaluationAsync(Azure.AI.Personalizer.PersonalizerEvaluationOptions evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeletePersonalizerEvaluation(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePersonalizerEvaluationAsync(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeletePersonalizerLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeletePersonalizerLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.IO.Stream> ExportPersonalizerModel(bool isSigned, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.IO.Stream>> ExportPersonalizerModelAsync(bool isSigned, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerEvaluation> GetPersonalizerEvaluation(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerEvaluation>> GetPersonalizerEvaluationAsync(string evaluationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Personalizer.PersonalizerEvaluation> GetPersonalizerEvaluations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Personalizer.PersonalizerEvaluation> GetPersonalizerEvaluationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerLogProperties> GetPersonalizerLogProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerLogProperties>> GetPersonalizerLogPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerModelProperties> GetPersonalizerModelProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerModelProperties>> GetPersonalizerModelPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerPolicy> GetPersonalizerPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerPolicy>> GetPersonalizerPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerServiceProperties> GetPersonalizerProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerServiceProperties>> GetPersonalizerPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ImportPersonalizerSignedModel(System.IO.Stream modelBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ImportPersonalizerSignedModelAsync(System.IO.Stream modelBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ResetPersonalizerModel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetPersonalizerModelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerPolicy> ResetPersonalizerPolicy(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerPolicy>> ResetPersonalizerPolicyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerPolicy> UpdatePersonalizerPolicy(Azure.AI.Personalizer.PersonalizerPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerPolicy>> UpdatePersonalizerPolicyAsync(Azure.AI.Personalizer.PersonalizerPolicy policy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerServiceProperties> UpdatePersonalizerProperties(Azure.AI.Personalizer.PersonalizerServiceProperties config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerServiceProperties>> UpdatePersonalizerPropertiesAsync(Azure.AI.Personalizer.PersonalizerServiceProperties config, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerRankResult> Rank(Azure.AI.Personalizer.PersonalizerRankOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerRankResult> Rank(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerRankResult>> RankAsync(Azure.AI.Personalizer.PersonalizerRankOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerRankResult>> RankAsync(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerMultiSlotRankResult> RankMultiSlot(Azure.AI.Personalizer.PersonalizerRankMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Personalizer.PersonalizerMultiSlotRankResult> RankMultiSlot(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerSlotOptions> slots, System.Collections.Generic.IList<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerMultiSlotRankResult>> RankMultiSlotAsync(Azure.AI.Personalizer.PersonalizerRankMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Personalizer.PersonalizerMultiSlotRankResult>> RankMultiSlotAsync(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerSlotOptions> slots, System.Collections.Generic.IList<object> contextFeatures, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reward(string eventId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardAsync(string eventId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RewardMultiSlot(string eventId, Azure.AI.Personalizer.PersonalizerRewardMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RewardMultiSlot(string eventId, string slotId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardMultiSlotAsync(string eventId, Azure.AI.Personalizer.PersonalizerRewardMultiSlotOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RewardMultiSlotAsync(string eventId, string slotId, float reward, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersonalizerClientOptions : Azure.Core.ClientOptions
    {
        public PersonalizerClientOptions(Azure.AI.Personalizer.PersonalizerClientOptions.ServiceVersion version = Azure.AI.Personalizer.PersonalizerClientOptions.ServiceVersion.V1_1_Preview_3, bool useLocalInference = false, float subsampleRate = 1f) { }
        public enum ServiceVersion
        {
            V1_1_Preview_3 = 1,
        }
    }
    public partial class PersonalizerCreateEvaluationOperation : Azure.Operation<Azure.AI.Personalizer.PersonalizerEvaluation>
    {
        protected PersonalizerCreateEvaluationOperation() { }
        public PersonalizerCreateEvaluationOperation(string evaluationId, Azure.AI.Personalizer.PersonalizerAdministrationClient client) { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.AI.Personalizer.PersonalizerEvaluation Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.Personalizer.PersonalizerEvaluation>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.AI.Personalizer.PersonalizerEvaluation>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class PersonalizerEvaluation
    {
        internal PersonalizerEvaluation() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public Azure.AI.Personalizer.PersonalizerEvaluationType? EvaluationType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IList<string>> FeatureImportance { get { throw null; } }
        public string Id { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Name { get { throw null; } }
        public string OptimalPolicy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.PersonalizerPolicyResult> PolicyResults { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.AI.Personalizer.PersonalizerEvaluationJobStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerEvaluationJobStatus : System.IEquatable<Azure.AI.Personalizer.PersonalizerEvaluationJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerEvaluationJobStatus(string value) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus Completed { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus Failed { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus NotSubmitted { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus OnlinePolicyRetained { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus OptimalPolicyApplied { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus Pending { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationJobStatus Timeout { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.PersonalizerEvaluationJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.PersonalizerEvaluationJobStatus left, Azure.AI.Personalizer.PersonalizerEvaluationJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.PersonalizerEvaluationJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.PersonalizerEvaluationJobStatus left, Azure.AI.Personalizer.PersonalizerEvaluationJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersonalizerEvaluationOptions
    {
        public PersonalizerEvaluationOptions(string name, System.DateTimeOffset startTime, System.DateTimeOffset endTime, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerPolicy> policies) { }
        public bool? EnableOfflineExperimentation { get { throw null; } set { } }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.PersonalizerPolicy> Policies { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerEvaluationType : System.IEquatable<Azure.AI.Personalizer.PersonalizerEvaluationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerEvaluationType(string value) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerEvaluationType Auto { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerEvaluationType Manual { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.PersonalizerEvaluationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.PersonalizerEvaluationType left, Azure.AI.Personalizer.PersonalizerEvaluationType right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.PersonalizerEvaluationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.PersonalizerEvaluationType left, Azure.AI.Personalizer.PersonalizerEvaluationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerLearningMode : System.IEquatable<Azure.AI.Personalizer.PersonalizerLearningMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerLearningMode(string value) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerLearningMode Apprentice { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerLearningMode LoggingOnly { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerLearningMode Online { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.PersonalizerLearningMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.PersonalizerLearningMode left, Azure.AI.Personalizer.PersonalizerLearningMode right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.PersonalizerLearningMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.PersonalizerLearningMode left, Azure.AI.Personalizer.PersonalizerLearningMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersonalizerLogProperties
    {
        internal PersonalizerLogProperties() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public static partial class PersonalizerModelFactory
    {
        public static Azure.AI.Personalizer.PersonalizerEvaluation PersonalizerEvaluation(string id = null, string name = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string jobId = null, Azure.AI.Personalizer.PersonalizerEvaluationJobStatus? status = default(Azure.AI.Personalizer.PersonalizerEvaluationJobStatus?), System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerPolicyResult> policyResults = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<string>> featureImportance = null, Azure.AI.Personalizer.PersonalizerEvaluationType? evaluationType = default(Azure.AI.Personalizer.PersonalizerEvaluationType?), string optimalPolicy = null, System.DateTimeOffset? creationTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerModelProperties PersonalizerModelProperties(System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerMultiSlotRankResult PersonalizerMultiSlotRankResult(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerSlotResult> slots = null, string eventId = null) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerPolicyResult PersonalizerPolicyResult(string name = null, string arguments = null, Azure.AI.Personalizer.PersonalizerPolicySource? policySource = default(Azure.AI.Personalizer.PersonalizerPolicySource?), System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerPolicyResultSummary> summary = null, Azure.AI.Personalizer.PersonalizerPolicyResultSummary totalSummary = null) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerPolicyResultSummary PersonalizerPolicyResultSummary(System.DateTimeOffset? timeStamp = default(System.DateTimeOffset?), float? ipsEstimatorNumerator = default(float?), float? ipsEstimatorDenominator = default(float?), float? snipsEstimatorDenominator = default(float?), System.TimeSpan? aggregateTimeWindow = default(System.TimeSpan?), float? nonZeroProbability = default(float?), float? sumOfSquares = default(float?), float? confidenceInterval = default(float?), float? averageReward = default(float?)) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerRankedAction PersonalizerRankedAction(string id = null, float? probability = default(float?)) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerRankResult PersonalizerRankResult(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankedAction> ranking = null, string eventId = null, string rewardActionId = null) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerSlotResult PersonalizerSlotResult(string slotId = null, string rewardActionId = null) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.PersonalizerSlotResult> Slots { get { throw null; } }
    }
    public partial class PersonalizerPolicy
    {
        public PersonalizerPolicy(string name, string arguments) { }
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
        public Azure.AI.Personalizer.PersonalizerPolicySource? PolicySource { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.PersonalizerPolicyResultSummary> Summary { get { throw null; } }
        public Azure.AI.Personalizer.PersonalizerPolicyResultSummary TotalSummary { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalizerPolicySource : System.IEquatable<Azure.AI.Personalizer.PersonalizerPolicySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalizerPolicySource(string value) { throw null; }
        public static Azure.AI.Personalizer.PersonalizerPolicySource Baseline { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerPolicySource Custom { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerPolicySource OfflineExperimentation { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerPolicySource Online { get { throw null; } }
        public static Azure.AI.Personalizer.PersonalizerPolicySource Random { get { throw null; } }
        public bool Equals(Azure.AI.Personalizer.PersonalizerPolicySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Personalizer.PersonalizerPolicySource left, Azure.AI.Personalizer.PersonalizerPolicySource right) { throw null; }
        public static implicit operator Azure.AI.Personalizer.PersonalizerPolicySource (string value) { throw null; }
        public static bool operator !=(Azure.AI.Personalizer.PersonalizerPolicySource left, Azure.AI.Personalizer.PersonalizerPolicySource right) { throw null; }
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
        public PersonalizerRankMultiSlotOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerSlotOptions> slots) { }
        public PersonalizerRankMultiSlotOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerSlotOptions> slots, System.Collections.Generic.IList<object> contextFeatures = null, string eventId = null, bool deferActivation = false) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.PersonalizerRankableAction> Actions { get { throw null; } }
        public System.Collections.Generic.IList<object> ContextFeatures { get { throw null; } }
        public bool? DeferActivation { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.PersonalizerSlotOptions> Slots { get { throw null; } }
    }
    public partial class PersonalizerRankOptions
    {
        public PersonalizerRankOptions() { }
        public PersonalizerRankOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions) { }
        public PersonalizerRankOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> actions, System.Collections.Generic.IEnumerable<object> contextFeatures = null, System.Collections.Generic.IEnumerable<string> excludedActions = null, string eventId = null, bool? deferActivation = default(bool?)) { }
        public System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerRankableAction> Actions { get { throw null; } }
        public System.Collections.Generic.IEnumerable<object> ContextFeatures { get { throw null; } }
        public bool? DeferActivation { get { throw null; } set { } }
        public string EventId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<string> ExcludedActions { get { throw null; } }
    }
    public partial class PersonalizerRankResult
    {
        internal PersonalizerRankResult() { }
        public string EventId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Personalizer.PersonalizerRankedAction> Ranking { get { throw null; } }
        public string RewardActionId { get { throw null; } }
    }
    public partial class PersonalizerRewardMultiSlotOptions
    {
        public PersonalizerRewardMultiSlotOptions(System.Collections.Generic.IEnumerable<Azure.AI.Personalizer.PersonalizerSlotReward> reward) { }
        public System.Collections.Generic.IList<Azure.AI.Personalizer.PersonalizerSlotReward> Reward { get { throw null; } }
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
        public Azure.AI.Personalizer.PersonalizerLearningMode? LearningMode { get { throw null; } set { } }
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
