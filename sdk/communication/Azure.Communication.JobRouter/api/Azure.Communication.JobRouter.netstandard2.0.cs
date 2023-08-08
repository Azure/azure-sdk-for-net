namespace Azure.Communication.JobRouter
{
    public partial class BestWorkerMode : Azure.Communication.JobRouter.DistributionMode
    {
        public BestWorkerMode() { }
        public BestWorkerMode(Azure.Communication.JobRouter.RouterRule scoringRule, System.Collections.Generic.IList<Azure.Communication.JobRouter.ScoringRuleParameterSelector> scoringParameterSelectors = null, bool allowScoringBatchOfWorkers = false, int? batchSize = default(int?), bool descendingOrder = true) { }
    }
    public partial class CancelExceptionAction : Azure.Communication.JobRouter.ExceptionAction
    {
        public CancelExceptionAction() { }
        public CancelExceptionAction(string note = null, string dispositionCode = null) { }
        public string DispositionCode { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
    }
    public partial class CancelJobOptions
    {
        public CancelJobOptions(string jobId) { }
        public string DispositionCode { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public string Note { get { throw null; } set { } }
    }
    public partial class ChannelConfiguration
    {
        public ChannelConfiguration(int capacityCostPerJob) { }
        public int CapacityCostPerJob { get { throw null; } set { } }
        public int? MaxNumberOfJobs { get { throw null; } set { } }
    }
    public partial class CloseJobOptions
    {
        public CloseJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public System.DateTimeOffset CloseAt { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public string Note { get { throw null; } set { } }
    }
    public partial class CompleteJobOptions
    {
        public CompleteJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Note { get { throw null; } set { } }
    }
    public partial class ConditionalQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public ConditionalQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterQueueSelector> QueueSelectors { get { throw null; } }
    }
    public partial class ConditionalWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public ConditionalWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
    }
    public partial class CreateClassificationPolicyOptions
    {
        public CreateClassificationPolicyOptions(string classificationPolicyId) { }
        public string ClassificationPolicyId { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectors { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectors { get { throw null; } }
    }
    public partial class CreateDistributionPolicyOptions
    {
        public CreateDistributionPolicyOptions(string distributionPolicyId, System.TimeSpan offerExpiresAfter, Azure.Communication.JobRouter.DistributionMode mode) { }
        public string DistributionPolicyId { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan OfferExpiresAfter { get { throw null; } }
    }
    public partial class CreateExceptionPolicyOptions
    {
        public CreateExceptionPolicyOptions(string exceptionPolicyId, System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule> exceptionRules) { }
        public string ExceptionPolicyId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule> ExceptionRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class CreateJobOptions
    {
        public CreateJobOptions(string jobId, string channelId, string queueId) { }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterJobNote> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } }
    }
    public partial class CreateJobWithClassificationPolicyOptions
    {
        public CreateJobWithClassificationPolicyOptions(string jobId, string channelId, string classificationPolicyId) { }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterJobNote> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } }
    }
    public partial class CreateQueueOptions
    {
        public CreateQueueOptions(string queueId, string distributionPolicyId) { }
        public string DistributionPolicyId { get { throw null; } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
    }
    public partial class CreateWorkerOptions
    {
        public CreateWorkerOptions(string workerId, int totalCapacity) { }
        public bool AvailableForOffers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ChannelConfiguration> ChannelConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterQueueAssignment> QueueAssignments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } }
        public int TotalCapacity { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class DeclineJobOfferOptions
    {
        public DeclineJobOfferOptions(string workerId, string offerId) { }
        public string OfferId { get { throw null; } }
        public System.DateTimeOffset? RetryOfferAt { get { throw null; } set { } }
        public string WorkerId { get { throw null; } }
    }
    public partial class DeclineJobOfferRequest
    {
        public DeclineJobOfferRequest() { }
        public System.DateTimeOffset? RetryOfferAt { get { throw null; } set { } }
    }
    public partial class DirectMapRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public DirectMapRouterRule() { }
    }
    public abstract partial class DistributionMode
    {
        protected DistributionMode() { }
        public bool? BypassSelectors { get { throw null; } set { } }
        public int MaxConcurrentOffers { get { throw null; } set { } }
        public int MinConcurrentOffers { get { throw null; } set { } }
    }
    public abstract partial class ExceptionAction
    {
        internal ExceptionAction() { }
        protected string Kind { get { throw null; } set { } }
    }
    public partial class ExceptionRule
    {
        public ExceptionRule(Azure.Communication.JobRouter.ExceptionTrigger trigger, System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionAction?> actions) { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionAction?> Actions { get { throw null; } }
        public Azure.Communication.JobRouter.ExceptionTrigger Trigger { get { throw null; } set { } }
    }
    public abstract partial class ExceptionTrigger
    {
        protected ExceptionTrigger() { }
        protected string Kind { get { throw null; } set { } }
    }
    public partial class ExpressionRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public ExpressionRouterRule(string expression) { }
        public string Expression { get { throw null; } set { } }
        public string Language { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpressionRouterRuleLanguage : System.IEquatable<Azure.Communication.JobRouter.ExpressionRouterRuleLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpressionRouterRuleLanguage(string value) { throw null; }
        public static Azure.Communication.JobRouter.ExpressionRouterRuleLanguage PowerFx { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.ExpressionRouterRuleLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.ExpressionRouterRuleLanguage left, Azure.Communication.JobRouter.ExpressionRouterRuleLanguage right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.ExpressionRouterRuleLanguage (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.ExpressionRouterRuleLanguage left, Azure.Communication.JobRouter.ExpressionRouterRuleLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public FunctionRouterRule(System.Uri functionAppUri) { }
        public Azure.Communication.JobRouter.FunctionRouterRuleCredential Credential { get { throw null; } set { } }
    }
    public partial class FunctionRouterRuleCredential
    {
        public FunctionRouterRuleCredential(string functionKey) { }
        public FunctionRouterRuleCredential(string appKey, string clientId) { }
    }
    public partial class GetJobsOptions
    {
        public GetJobsOptions() { }
        public string ChannelId { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledAfter { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledBefore { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterJobStatusSelector? Status { get { throw null; } set { } }
    }
    public partial class GetWorkersOptions
    {
        public GetWorkersOptions() { }
        public string ChannelId { get { throw null; } set { } }
        public bool HasCapacity { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterWorkerStateSelector? State { get { throw null; } set { } }
    }
    public partial class JobMatchingMode
    {
        public JobMatchingMode(Azure.Communication.JobRouter.QueueAndMatchMode queueAndMatchMode) { }
        public JobMatchingMode(Azure.Communication.JobRouter.ScheduleAndSuspendMode scheduleAndSuspendMode) { }
        public JobMatchingMode(Azure.Communication.JobRouter.SuspendMode suspendMode) { }
        public Azure.Communication.JobRouter.JobMatchModeType? ModeType { get { throw null; } }
        public Azure.Communication.JobRouter.QueueAndMatchMode QueueAndMatchMode { get { throw null; } }
        public Azure.Communication.JobRouter.ScheduleAndSuspendMode ScheduleAndSuspendMode { get { throw null; } }
        public Azure.Communication.JobRouter.SuspendMode SuspendMode { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobMatchModeType : System.IEquatable<Azure.Communication.JobRouter.JobMatchModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobMatchModeType(string value) { throw null; }
        public static Azure.Communication.JobRouter.JobMatchModeType QueueAndMatchMode { get { throw null; } }
        public static Azure.Communication.JobRouter.JobMatchModeType ScheduleAndSuspendMode { get { throw null; } }
        public static Azure.Communication.JobRouter.JobMatchModeType SuspendMode { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.JobMatchModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.JobMatchModeType left, Azure.Communication.JobRouter.JobMatchModeType right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.JobMatchModeType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.JobMatchModeType left, Azure.Communication.JobRouter.JobMatchModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobRouterAdministrationClient
    {
        protected JobRouterAdministrationClient() { }
        public JobRouterAdministrationClient(string connectionString) { }
        public JobRouterAdministrationClient(string connectionString, Azure.Communication.JobRouter.JobRouterClientOptions options) { }
        public JobRouterAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy> CreateClassificationPolicy(Azure.Communication.JobRouter.CreateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy>> CreateClassificationPolicyAsync(Azure.Communication.JobRouter.CreateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy> CreateDistributionPolicy(Azure.Communication.JobRouter.CreateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy>> CreateDistributionPolicyAsync(Azure.Communication.JobRouter.CreateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy> CreateExceptionPolicy(Azure.Communication.JobRouter.CreateExceptionPolicyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy>> CreateExceptionPolicyAsync(Azure.Communication.JobRouter.CreateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterQueue> CreateQueue(Azure.Communication.JobRouter.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterQueue>> CreateQueueAsync(Azure.Communication.JobRouter.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteClassificationPolicy(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationPolicyAsync(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteDistributionPolicy(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDistributionPolicyAsync(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteExceptionPolicy(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteExceptionPolicyAsync(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteQueue(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.ClassificationPolicyItem> GetClassificationPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.ClassificationPolicyItem> GetClassificationPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy> GetClassificationPolicy(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy>> GetClassificationPolicyAsync(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.DistributionPolicyItem> GetDistributionPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.DistributionPolicyItem> GetDistributionPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy> GetDistributionPolicy(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy>> GetDistributionPolicyAsync(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.ExceptionPolicyItem> GetExceptionPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.ExceptionPolicyItem> GetExceptionPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy> GetExceptionPolicy(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy>> GetExceptionPolicyAsync(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterQueue> GetQueue(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterQueue>> GetQueueAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.RouterQueueItem> GetQueues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.RouterQueueItem> GetQueuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy> UpdateClassificationPolicy(Azure.Communication.JobRouter.UpdateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateClassificationPolicy(string classificationPolicyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy>> UpdateClassificationPolicyAsync(Azure.Communication.JobRouter.UpdateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationPolicyAsync(string classificationPolicyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy> UpdateDistributionPolicy(Azure.Communication.JobRouter.UpdateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateDistributionPolicy(string distributionPolicyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy>> UpdateDistributionPolicyAsync(Azure.Communication.JobRouter.UpdateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDistributionPolicyAsync(string distributionPolicyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy> UpdateExceptionPolicy(Azure.Communication.JobRouter.UpdateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateExceptionPolicy(string exceptionPolicyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy>> UpdateExceptionPolicyAsync(Azure.Communication.JobRouter.UpdateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateExceptionPolicyAsync(string exceptionPolicyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterQueue> UpdateQueue(Azure.Communication.JobRouter.UpdateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateQueue(string queueId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterQueue>> UpdateQueueAsync(Azure.Communication.JobRouter.UpdateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateQueueAsync(string queueId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class JobRouterClient
    {
        protected JobRouterClient() { }
        public JobRouterClient(string connectionString) { }
        public JobRouterClient(string connectionString, Azure.Communication.JobRouter.JobRouterClientOptions options) { }
        public JobRouterClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.AcceptJobOfferResult> AcceptJobOffer(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.AcceptJobOfferResult>> AcceptJobOfferAsync(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelJob(Azure.Communication.JobRouter.CancelJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(Azure.Communication.JobRouter.CancelJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CloseJob(Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseJobAsync(Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CompleteJob(Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteJobAsync(Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> CreateJob(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> CreateJobAsync(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> CreateJobWithClassificationPolicy(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> CreateJobWithClassificationPolicyAsync(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> CreateWorker(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker>> CreateWorkerAsync(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeclineJobOffer(Azure.Communication.JobRouter.DeclineJobOfferOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeclineJobOfferAsync(Azure.Communication.JobRouter.DeclineJobOfferOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteWorker(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkerAsync(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.RouterJobItem> GetJobs(Azure.Communication.JobRouter.GetJobsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.RouterJobItem> GetJobsAsync(Azure.Communication.JobRouter.GetJobsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJobPositionDetails> GetQueuePosition(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJobPositionDetails>> GetQueuePositionAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterQueueStatistics> GetQueueStatistics(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterQueueStatistics>> GetQueueStatisticsAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> GetWorker(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker>> GetWorkerAsync(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.RouterWorkerItem> GetWorkers(Azure.Communication.JobRouter.GetWorkersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.RouterWorkerItem> GetWorkersAsync(Azure.Communication.JobRouter.GetWorkersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ReclassifyJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReclassifyJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.UnassignJobResult> UnassignJob(Azure.Communication.JobRouter.UnassignJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.UnassignJobResult>> UnassignJobAsync(Azure.Communication.JobRouter.UnassignJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> UpdateJob(Azure.Communication.JobRouter.UpdateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateJob(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> UpdateJobAsync(Azure.Communication.JobRouter.UpdateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> UpdateWorker(Azure.Communication.JobRouter.UpdateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateWorker(string workerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker>> UpdateWorkerAsync(Azure.Communication.JobRouter.UpdateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateWorkerAsync(string workerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class JobRouterClientOptions : Azure.Core.ClientOptions
    {
        public JobRouterClientOptions(Azure.Communication.JobRouter.JobRouterClientOptions.ServiceVersion version = Azure.Communication.JobRouter.JobRouterClientOptions.ServiceVersion.V2022_07_18_preview) { }
        public enum ServiceVersion
        {
            V2021_10_20_preview2 = 1,
            V2022_07_18_preview = 2,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabelOperator : System.IEquatable<Azure.Communication.JobRouter.LabelOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabelOperator(string value) { throw null; }
        public static Azure.Communication.JobRouter.LabelOperator Equal { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator GreaterThan { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator GreaterThanEqual { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator LessThan { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator LessThanEqual { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator NotEqual { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.LabelOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.LabelOperator left, Azure.Communication.JobRouter.LabelOperator right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.LabelOperator (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.LabelOperator left, Azure.Communication.JobRouter.LabelOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LabelValue : System.IEquatable<Azure.Communication.JobRouter.LabelValue>
    {
        public LabelValue(bool value) { }
        public LabelValue(decimal value) { }
        public LabelValue(double value) { }
        public LabelValue(int value) { }
        public LabelValue(long value) { }
        public LabelValue(float value) { }
        public LabelValue(string value) { }
        public object Value { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.LabelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.LabelValue left, Azure.Communication.JobRouter.LabelValue right) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.LabelValue left, Azure.Communication.JobRouter.LabelValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LongestIdleMode : Azure.Communication.JobRouter.DistributionMode
    {
        public LongestIdleMode() { }
    }
    public partial class ManualReclassifyExceptionAction : Azure.Communication.JobRouter.ExceptionAction
    {
        public ManualReclassifyExceptionAction() { }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
    }
    public partial class Oauth2ClientCredential
    {
        public Oauth2ClientCredential() { }
        public string ClientId { get { throw null; } set { } }
        public string ClientSecret { get { throw null; } set { } }
    }
    public partial class PassThroughQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public PassThroughQueueSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator) { }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
    }
    public partial class PassThroughWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public PassThroughWorkerSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator) { }
        public PassThroughWorkerSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, System.TimeSpan? expiresAfter = default(System.TimeSpan?)) { }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
    }
    public partial class QueueAndMatchMode
    {
        public QueueAndMatchMode() { }
    }
    public partial class QueueLengthExceptionTrigger : Azure.Communication.JobRouter.ExceptionTrigger
    {
        public QueueLengthExceptionTrigger(int threshold) { }
        public int Threshold { get { throw null; } set { } }
    }
    public abstract partial class QueueSelectorAttachment
    {
        internal QueueSelectorAttachment() { }
        protected string Kind { get { throw null; } set { } }
    }
    public partial class QueueWeightedAllocation
    {
        public QueueWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterQueueSelector> QueueSelectors { get { throw null; } }
        public double Weight { get { throw null; } set { } }
    }
    public partial class ReclassifyExceptionAction : Azure.Communication.JobRouter.ExceptionAction
    {
        public ReclassifyExceptionAction(string classificationPolicyId, System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> labelsToUpsert = null) { }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> LabelsToUpsert { get { throw null; } set { } }
    }
    public partial class RoundRobinMode : Azure.Communication.JobRouter.DistributionMode
    {
        public RoundRobinMode() { }
    }
    public partial class RouterJobNote
    {
        public RouterJobNote() { }
        public System.DateTimeOffset? AddedAt { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterJobStatusSelector : System.IEquatable<Azure.Communication.JobRouter.RouterJobStatusSelector>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterJobStatusSelector(string value) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Active { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector All { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Assigned { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Cancelled { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector ClassificationFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Closed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Completed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Created { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector PendingClassification { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector PendingSchedule { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Queued { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector Scheduled { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector ScheduleFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatusSelector WaitingForActivation { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterJobStatusSelector other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterJobStatusSelector left, Azure.Communication.JobRouter.RouterJobStatusSelector right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.RouterJobStatusSelector (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterJobStatusSelector left, Azure.Communication.JobRouter.RouterJobStatusSelector right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouterQueueAssignment
    {
        public RouterQueueAssignment() { }
    }
    public partial class RouterQueueSelector
    {
        public RouterQueueSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.LabelValue value) { }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelValue Value { get { throw null; } set { } }
    }
    public abstract partial class RouterRule
    {
        internal RouterRule() { }
        public string Kind { get { throw null; } set { } }
    }
    public partial class RouterWorkerSelector
    {
        public RouterWorkerSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.LabelValue value) { }
        public bool? Expedite { get { throw null; } set { } }
        public System.TimeSpan? ExpiresAfter { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus? Status { get { throw null; } }
        public Azure.Communication.JobRouter.LabelValue Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterWorkerState : System.IEquatable<Azure.Communication.JobRouter.RouterWorkerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterWorkerState(string value) { throw null; }
        public static Azure.Communication.JobRouter.RouterWorkerState Active { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterWorkerState Draining { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterWorkerState Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterWorkerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterWorkerState left, Azure.Communication.JobRouter.RouterWorkerState right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.RouterWorkerState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterWorkerState left, Azure.Communication.JobRouter.RouterWorkerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterWorkerStateSelector : System.IEquatable<Azure.Communication.JobRouter.RouterWorkerStateSelector>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterWorkerStateSelector(string value) { throw null; }
        public static Azure.Communication.JobRouter.RouterWorkerStateSelector Active { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterWorkerStateSelector All { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterWorkerStateSelector Draining { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterWorkerStateSelector Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterWorkerStateSelector other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterWorkerStateSelector left, Azure.Communication.JobRouter.RouterWorkerStateSelector right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.RouterWorkerStateSelector (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterWorkerStateSelector left, Azure.Communication.JobRouter.RouterWorkerStateSelector right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RuleEngineQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public RuleEngineQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule) { }
        public Azure.Communication.JobRouter.RouterRule Rule { get { throw null; } set { } }
    }
    public partial class RuleEngineWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public RuleEngineWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule) { }
        public Azure.Communication.JobRouter.RouterRule Rule { get { throw null; } set { } }
    }
    public partial class ScheduleAndSuspendMode
    {
        public ScheduleAndSuspendMode(System.DateTimeOffset scheduleAt) { }
        public System.DateTimeOffset ScheduleAt { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScoringRuleParameterSelector : System.IEquatable<Azure.Communication.JobRouter.ScoringRuleParameterSelector>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScoringRuleParameterSelector(string value) { throw null; }
        public static Azure.Communication.JobRouter.ScoringRuleParameterSelector JobLabels { get { throw null; } }
        public static Azure.Communication.JobRouter.ScoringRuleParameterSelector WorkerSelectors { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.ScoringRuleParameterSelector other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.ScoringRuleParameterSelector left, Azure.Communication.JobRouter.ScoringRuleParameterSelector right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.ScoringRuleParameterSelector (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.ScoringRuleParameterSelector left, Azure.Communication.JobRouter.ScoringRuleParameterSelector right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StaticQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public StaticQueueSelectorAttachment(Azure.Communication.JobRouter.RouterQueueSelector queueSelector) { }
        public Azure.Communication.JobRouter.RouterQueueSelector QueueSelector { get { throw null; } set { } }
    }
    public partial class StaticRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public StaticRouterRule(Azure.Communication.JobRouter.LabelValue value) { }
        public Azure.Communication.JobRouter.LabelValue Value { get { throw null; } set { } }
    }
    public partial class StaticWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public StaticWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterWorkerSelector workerSelector) { }
        public Azure.Communication.JobRouter.RouterWorkerSelector WorkerSelector { get { throw null; } set { } }
    }
    public partial class SuspendMode
    {
        public SuspendMode() { }
    }
    public partial class UnassignJobOptions
    {
        public UnassignJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
    }
    public partial class UpdateClassificationPolicyOptions
    {
        public UpdateClassificationPolicyOptions(string classificationPolicyId) { }
        public string ClassificationPolicyId { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectors { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectors { get { throw null; } }
    }
    public partial class UpdateDistributionPolicyOptions
    {
        public UpdateDistributionPolicyOptions(string distributionPolicyId) { }
        public string DistributionPolicyId { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan OfferExpiresAfter { get { throw null; } set { } }
    }
    public partial class UpdateExceptionPolicyOptions
    {
        public UpdateExceptionPolicyOptions(string exceptionPolicyId) { }
        public string ExceptionPolicyId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule?> ExceptionRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class UpdateJobOptions
    {
        public UpdateJobOptions(string jobId) { }
        public string? ChannelId { get { throw null; } set { } }
        public string? ChannelReference { get { throw null; } set { } }
        public string? ClassificationPolicyId { get { throw null; } set { } }
        public string? DispositionCode { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue?> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode? MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterJobNote?> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string? QueueId { get { throw null; } set { } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue?> Tags { get { throw null; } }
    }
    public partial class UpdateQueueOptions
    {
        public UpdateQueueOptions(string queueId) { }
        public string? DistributionPolicyId { get { throw null; } set { } }
        public string? ExceptionPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue?> Labels { get { throw null; } }
        public string? Name { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
    }
    public partial class UpdateWorkerOptions
    {
        public UpdateWorkerOptions(string workerId) { }
        public bool? AvailableForOffers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ChannelConfiguration?> ChannelConfigurations { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue?> Labels { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterQueueAssignment?> QueueAssignments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue?> Tags { get { throw null; } }
        public int? TotalCapacity { get { throw null; } set { } }
        public string WorkerId { get { throw null; } }
    }
    public partial class WaitTimeExceptionTrigger : Azure.Communication.JobRouter.ExceptionTrigger
    {
        public WaitTimeExceptionTrigger(System.TimeSpan threshold) { }
        public System.TimeSpan Threshold { get { throw null; } set { } }
    }
    public partial class WebhookRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public WebhookRouterRule() { }
        public System.Uri AuthorizationServerUri { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Oauth2ClientCredential ClientCredential { get { throw null; } set { } }
        public System.Uri WebhookUri { get { throw null; } set { } }
    }
    public partial class WeightedAllocationQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public WeightedAllocationQueueSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueWeightedAllocation> allocations) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueWeightedAllocation> Allocations { get { throw null; } }
    }
    public partial class WeightedAllocationWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public WeightedAllocationWorkerSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerWeightedAllocation> allocations) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerWeightedAllocation> Allocations { get { throw null; } }
    }
    public abstract partial class WorkerSelectorAttachment
    {
        internal WorkerSelectorAttachment() { }
        protected string Kind { get { throw null; } set { } }
    }
    public partial class WorkerWeightedAllocation
    {
        public WorkerWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors) { }
        public double Weight { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
    }
}
namespace Azure.Communication.JobRouter.Models
{
    public partial class AcceptJobOfferResult
    {
        internal AcceptJobOfferResult() { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class ClassificationPolicy
    {
        internal ClassificationPolicy() { }
        public string FallbackQueueId { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectors { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectors { get { throw null; } }
    }
    public partial class ClassificationPolicyItem
    {
        internal ClassificationPolicyItem() { }
        public Azure.Communication.JobRouter.Models.ClassificationPolicy ClassificationPolicy { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
    }
    public static partial class CommunicationJobRouterModelFactory
    {
        public static Azure.Communication.JobRouter.Models.AcceptJobOfferResult AcceptJobOfferResult(string assignmentId = null, string jobId = null, string workerId = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterJobAssignment RouterJobAssignment(string assignmentId = null, string workerId = null, System.DateTimeOffset assignedAt = default(System.DateTimeOffset), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? closedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterJobOffer RouterJobOffer(string offerId = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset? offeredAt = default(System.DateTimeOffset?), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterQueueStatistics RouterQueueStatistics(string queueId = null, int length = 0, System.Collections.Generic.IReadOnlyDictionary<string, double> estimatedWaitTimeMinutes = null, double? longestJobWaitTimeMinutes = default(double?)) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterWorkerAssignment RouterWorkerAssignment(string assignmentId = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset assignedAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Communication.JobRouter.Models.UnassignJobResult UnassignJobResult(string jobId = null, int unassignmentCount = 0) { throw null; }
    }
    public partial class DistributionPolicy
    {
        internal DistributionPolicy() { }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } }
        public string Name { get { throw null; } }
        public System.TimeSpan? OfferExpiresAfter { get { throw null; } set { } }
    }
    public partial class DistributionPolicyItem
    {
        internal DistributionPolicyItem() { }
        public Azure.Communication.JobRouter.Models.DistributionPolicy DistributionPolicy { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
    }
    public partial class ExceptionPolicy
    {
        internal ExceptionPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule> ExceptionRules { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ExceptionPolicyItem
    {
        internal ExceptionPolicyItem() { }
        public Azure.ETag ETag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.ExceptionPolicy ExceptionPolicy { get { throw null; } }
    }
    public partial class RouterJob
    {
        internal RouterJob() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.JobRouter.Models.RouterJobAssignment> Assignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterWorkerSelector> AttachedWorkerSelectors { get { throw null; } }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } }
        public string ClassificationPolicyId { get { throw null; } }
        public string DispositionCode { get { throw null; } }
        public System.DateTimeOffset? EnqueuedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode MatchingMode { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterJobNote> Notes { get { throw null; } }
        public int? Priority { get { throw null; } }
        public string QueueId { get { throw null; } }
        public System.Collections.Generic.List<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.DateTimeOffset? ScheduledAt { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterJobStatus? Status { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } }
    }
    public partial class RouterJobAssignment
    {
        internal RouterJobAssignment() { }
        public System.DateTimeOffset AssignedAt { get { throw null; } }
        public string AssignmentId { get { throw null; } }
        public System.DateTimeOffset? ClosedAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class RouterJobItem
    {
        internal RouterJobItem() { }
        public Azure.ETag ETag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterJob Job { get { throw null; } }
    }
    public partial class RouterJobOffer
    {
        internal RouterJobOffer() { }
        public int CapacityCost { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? OfferedAt { get { throw null; } }
        public string OfferId { get { throw null; } }
    }
    public partial class RouterJobPositionDetails
    {
        internal RouterJobPositionDetails() { }
        public System.TimeSpan EstimatedWaitTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public int Position { get { throw null; } }
        public string QueueId { get { throw null; } }
        public int QueueLength { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterJobStatus : System.IEquatable<Azure.Communication.JobRouter.Models.RouterJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterJobStatus(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Assigned { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Cancelled { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus ClassificationFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Closed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Completed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Created { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus PendingClassification { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus PendingSchedule { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Queued { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Scheduled { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus ScheduleFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatus WaitingForActivation { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.RouterJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.RouterJobStatus left, Azure.Communication.JobRouter.Models.RouterJobStatus right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.RouterJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.RouterJobStatus left, Azure.Communication.JobRouter.Models.RouterJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouterQueue
    {
        internal RouterQueue() { }
        public string DistributionPolicyId { get { throw null; } }
        public string ExceptionPolicyId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class RouterQueueItem
    {
        internal RouterQueueItem() { }
        public Azure.ETag ETag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterQueue Queue { get { throw null; } }
    }
    public partial class RouterQueueStatistics
    {
        internal RouterQueueStatistics() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, double> EstimatedWaitTimeMinutes { get { throw null; } }
        public int Length { get { throw null; } }
        public double? LongestJobWaitTimeMinutes { get { throw null; } }
        public string QueueId { get { throw null; } }
    }
    public partial class RouterWorker
    {
        internal RouterWorker() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.Models.RouterWorkerAssignment> AssignedJobs { get { throw null; } }
        public bool? AvailableForOffers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ChannelConfiguration> ChannelConfigurations { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } }
        public double? LoadRatio { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.Models.RouterJobOffer> Offers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterQueueAssignment> QueueAssignments { get { throw null; } }
        public Azure.Communication.JobRouter.RouterWorkerState? State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } }
        public int? TotalCapacity { get { throw null; } }
    }
    public partial class RouterWorkerAssignment
    {
        internal RouterWorkerAssignment() { }
        public System.DateTimeOffset AssignedAt { get { throw null; } }
        public string AssignmentId { get { throw null; } }
        public int CapacityCost { get { throw null; } }
        public string JobId { get { throw null; } }
    }
    public partial class RouterWorkerItem
    {
        internal RouterWorkerItem() { }
        public Azure.ETag ETag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterWorker Worker { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterWorkerSelectorStatus : System.IEquatable<Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterWorkerSelectorStatus(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus Active { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus Expired { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus left, Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus left, Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScoringRuleOptions
    {
        internal ScoringRuleOptions() { }
        public bool? AllowScoringBatchOfWorkers { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public bool? DescendingOrder { get { throw null; } set { } }
    }
    public partial class UnassignJobResult
    {
        internal UnassignJobResult() { }
        public string JobId { get { throw null; } }
        public int UnassignmentCount { get { throw null; } }
    }
}
