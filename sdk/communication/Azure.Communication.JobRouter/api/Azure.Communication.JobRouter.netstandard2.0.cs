namespace Azure.Communication.JobRouter
{
    public partial class BestWorkerMode : Azure.Communication.JobRouter.DistributionMode
    {
        public BestWorkerMode(Azure.Communication.JobRouter.RouterRule scoringRule, System.Collections.Generic.IList<Azure.Communication.JobRouter.ScoringRuleParameterSelector> scoringParameterSelectors = null, bool bypassSelectors = false, bool allowScoringBatchOfWorkers = false, int? batchSize = default(int?), bool sortDescending = true, int minConcurrentOffers = 1, int maxConcurrentOffers = 1) : base (default(int), default(int)) { }
        public BestWorkerMode(int minConcurrentOffers = 1, int maxConcurrentOffers = 1, bool bypassSelectors = false, bool sortDescending = true) : base (default(int), default(int)) { }
        public Azure.Communication.JobRouter.RouterRule ScoringRule { get { throw null; } set { } }
        public Azure.Communication.JobRouter.ScoringRuleOptions ScoringRuleOptions { get { throw null; } set { } }
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
    }
    public partial class CloseJobOptions
    {
        public CloseJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public System.DateTimeOffset CloseTime { get { throw null; } set { } }
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
        public ConditionalQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueSelector> labelSelectors) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelector> LabelSelectors { get { throw null; } }
    }
    public partial class ConditionalWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public ConditionalWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerSelector> labelSelectors) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> LabelSelectors { get { throw null; } }
    }
    public partial class CreateClassificationPolicyOptions
    {
        public CreateClassificationPolicyOptions(string classificationPolicyId) { }
        public string ClassificationPolicyId { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectors { get { throw null; } set { } }
    }
    public partial class CreateDistributionPolicyOptions
    {
        public CreateDistributionPolicyOptions(string distributionPolicyId, System.TimeSpan offerTtl, Azure.Communication.JobRouter.DistributionMode mode) { }
        public string DistributionPolicyId { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan OfferTtl { get { throw null; } }
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
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<System.DateTimeOffset, string> Notes { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> RequestedWorkerSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
    }
    public partial class CreateJobWithClassificationPolicyOptions
    {
        public CreateJobWithClassificationPolicyOptions(string jobId, string channelId, string classificationPolicyId) { }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<System.DateTimeOffset, string> Notes { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> RequestedWorkerSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
    }
    public partial class CreateQueueOptions
    {
        public CreateQueueOptions(string queueId, string distributionPolicyId) { }
        public string DistributionPolicyId { get { throw null; } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
    }
    public partial class CreateWorkerOptions
    {
        public CreateWorkerOptions(string workerId, int totalCapacity) { }
        public bool AvailableForOffers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ChannelConfiguration> ChannelConfigurations { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.QueueAssignment> QueueIds { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
        public int TotalCapacity { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class DirectMapRule : Azure.Communication.JobRouter.RouterRule
    {
        public DirectMapRule() { }
    }
    public abstract partial class DistributionMode
    {
        protected DistributionMode(int minConcurrentOffers, int maxConcurrentOffers) { }
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
        public ExceptionRule(Azure.Communication.JobRouter.JobExceptionTrigger trigger, System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionAction?> actions) { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionAction?> Actions { get { throw null; } }
        public Azure.Communication.JobRouter.JobExceptionTrigger Trigger { get { throw null; } set { } }
    }
    public partial class ExpressionRule : Azure.Communication.JobRouter.RouterRule
    {
        public ExpressionRule(string expression) { }
        public string Expression { get { throw null; } set { } }
        public string Language { get { throw null; } }
    }
    public partial class FunctionRule : Azure.Communication.JobRouter.RouterRule
    {
        public FunctionRule(System.Uri functionAppUri) { }
        public FunctionRule(System.Uri functionAppUri, Azure.Communication.JobRouter.FunctionRuleCredential credential) { }
        public Azure.Communication.JobRouter.FunctionRuleCredential Credential { get { throw null; } set { } }
        public System.Uri FunctionUri { get { throw null; } set { } }
    }
    public partial class FunctionRuleCredential
    {
        public FunctionRuleCredential(string functionKey) { }
        public FunctionRuleCredential(string appKey, string clientId) { }
        public string AppKey { get { throw null; } set { } }
        public string ClientId { get { throw null; } set { } }
        public string FunctionKey { get { throw null; } set { } }
    }
    public partial class GetJobsOptions
    {
        public GetJobsOptions() { }
        public string ChannelId { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public Azure.Communication.JobRouter.JobStateSelector Status { get { throw null; } set { } }
    }
    public partial class GetWorkersOptions
    {
        public GetWorkersOptions() { }
        public string ChannelId { get { throw null; } set { } }
        public bool HasCapacity { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public Azure.Communication.JobRouter.WorkerStateSelector Status { get { throw null; } set { } }
    }
    public abstract partial class JobExceptionTrigger
    {
        internal JobExceptionTrigger() { }
        protected string Kind { get { throw null; } set { } }
    }
    public enum JobStateSelector
    {
        All = 0,
        PendingClassification = 1,
        Queued = 2,
        Assigned = 3,
        Completed = 4,
        Closed = 5,
        Cancelled = 6,
        ClassificationFailed = 7,
        Active = 8,
    }
    public enum LabelOperator
    {
        Equal = 0,
        NotEqual = 1,
        LessThan = 2,
        LessThanEqual = 3,
        GreaterThan = 4,
        GreaterThanEqual = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabelValue : System.IEquatable<Azure.Communication.JobRouter.LabelValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabelValue(bool value) { throw null; }
        public LabelValue(char value) { throw null; }
        public LabelValue(decimal value) { throw null; }
        public LabelValue(double value) { throw null; }
        public LabelValue(short value) { throw null; }
        public LabelValue(int value) { throw null; }
        public LabelValue(long value) { throw null; }
        public LabelValue(float value) { throw null; }
        public LabelValue(string value) { throw null; }
        public LabelValue(ushort value) { throw null; }
        public LabelValue(uint value) { throw null; }
        public LabelValue(ulong value) { throw null; }
        public object Value { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.LabelValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.LabelValue left, Azure.Communication.JobRouter.LabelValue right) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.LabelValue left, Azure.Communication.JobRouter.LabelValue right) { throw null; }
    }
    public partial class LongestIdleMode : Azure.Communication.JobRouter.DistributionMode
    {
        public LongestIdleMode(int minConcurrentOffers = 1, int maxConcurrentOffers = 1, bool? bypassSelectors = false) : base (default(int), default(int)) { }
    }
    public partial class ManualReclassifyExceptionAction : Azure.Communication.JobRouter.ExceptionAction
    {
        public ManualReclassifyExceptionAction(string queueId, int priority, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerSelector> workerSelectors = null) { }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> WorkerSelectors { get { throw null; } }
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
        public PassThroughWorkerSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, System.TimeSpan? ttl = default(System.TimeSpan?)) { }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
    }
    public partial class QueueAssignment
    {
        public QueueAssignment() { }
        public void Write(System.Text.Json.Utf8JsonWriter writer) { }
    }
    public partial class QueueLengthExceptionTrigger : Azure.Communication.JobRouter.JobExceptionTrigger
    {
        public QueueLengthExceptionTrigger(int threshold) { }
        public int Threshold { get { throw null; } set { } }
    }
    public partial class QueueSelector
    {
        public QueueSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.LabelValue value) { }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelValue Value { get { throw null; } set { } }
    }
    public abstract partial class QueueSelectorAttachment
    {
        internal QueueSelectorAttachment() { }
        protected string Kind { get { throw null; } set { } }
    }
    public partial class QueueWeightedAllocation
    {
        public QueueWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueSelector> labelSelectors) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelector> LabelSelectors { get { throw null; } }
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
        public RoundRobinMode(int minConcurrentOffers = 1, int maxConcurrentOffers = 1, bool? bypassSelectors = false) : base (default(int), default(int)) { }
    }
    public partial class RouterAdministrationClient
    {
        protected RouterAdministrationClient() { }
        public RouterAdministrationClient(string connectionString) { }
        public RouterAdministrationClient(string connectionString, Azure.Communication.JobRouter.RouterClientOptions options) { }
        public RouterAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.RouterClientOptions options = null) { }
        public RouterAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.RouterClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy> CreateClassificationPolicy(Azure.Communication.JobRouter.CreateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy>> CreateClassificationPolicyAsync(Azure.Communication.JobRouter.CreateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy> CreateDistributionPolicy(Azure.Communication.JobRouter.CreateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy>> CreateDistributionPolicyAsync(Azure.Communication.JobRouter.CreateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy> CreateExceptionPolicy(Azure.Communication.JobRouter.CreateExceptionPolicyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy>> CreateExceptionPolicyAsync(Azure.Communication.JobRouter.CreateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.JobQueue> CreateQueue(Azure.Communication.JobRouter.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.JobQueue>> CreateQueueAsync(Azure.Communication.JobRouter.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.JobQueue> GetQueue(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.JobQueue>> GetQueueAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.JobQueueItem> GetQueues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.JobQueueItem> GetQueuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy> UpdateClassificationPolicy(Azure.Communication.JobRouter.UpdateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ClassificationPolicy>> UpdateClassificationPolicyAsync(Azure.Communication.JobRouter.UpdateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy> UpdateDistributionPolicy(Azure.Communication.JobRouter.UpdateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.DistributionPolicy>> UpdateDistributionPolicyAsync(Azure.Communication.JobRouter.UpdateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy> UpdateExceptionPolicy(Azure.Communication.JobRouter.UpdateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ExceptionPolicy>> UpdateExceptionPolicyAsync(Azure.Communication.JobRouter.UpdateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.JobQueue> UpdateQueue(Azure.Communication.JobRouter.UpdateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.JobQueue>> UpdateQueueAsync(Azure.Communication.JobRouter.UpdateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RouterClient
    {
        protected RouterClient() { }
        public RouterClient(string connectionString) { }
        public RouterClient(string connectionString, Azure.Communication.JobRouter.RouterClientOptions options) { }
        public RouterClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.RouterClientOptions options = null) { }
        public RouterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.RouterClientOptions options = null) { }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.AcceptJobOfferResult> AcceptJobOffer(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.AcceptJobOfferResult>> AcceptJobOfferAsync(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.CancelJobResult> CancelJob(Azure.Communication.JobRouter.CancelJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.CancelJobResult>> CancelJobAsync(Azure.Communication.JobRouter.CancelJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.CloseJobResult> CloseJob(Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.CloseJobResult>> CloseJobAsync(Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.CompleteJobResult> CompleteJob(Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.CompleteJobResult>> CompleteJobAsync(Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> CreateJob(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> CreateJob(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> CreateJobAsync(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> CreateJobAsync(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> CreateWorker(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker>> CreateWorkerAsync(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.DeclineJobOfferResult> DeclineJobOffer(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.DeclineJobOfferResult>> DeclineJobOfferAsync(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> DeleteWorker(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkerAsync(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.RouterJobItem> GetJobs(Azure.Communication.JobRouter.GetJobsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.RouterJobItem> GetJobsAsync(Azure.Communication.JobRouter.GetJobsOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.JobPositionDetails> GetQueuePosition(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.JobPositionDetails>> GetQueuePositionAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.QueueStatistics> GetQueueStatistics(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.QueueStatistics>> GetQueueStatisticsAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> GetWorker(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker>> GetWorkerAsync(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.Models.RouterWorkerItem> GetWorkers(Azure.Communication.JobRouter.GetWorkersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.Models.RouterWorkerItem> GetWorkersAsync(Azure.Communication.JobRouter.GetWorkersOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.ReclassifyJobResult> ReclassifyJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.ReclassifyJobResult>> ReclassifyJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterJob> UpdateJob(Azure.Communication.JobRouter.UpdateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterJob>> UpdateJobAsync(Azure.Communication.JobRouter.UpdateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker> UpdateWorker(Azure.Communication.JobRouter.UpdateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.Models.RouterWorker>> UpdateWorkerAsync(Azure.Communication.JobRouter.UpdateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RouterClientOptions : Azure.Core.ClientOptions
    {
        public RouterClientOptions(Azure.Communication.JobRouter.RouterClientOptions.ServiceVersion version = Azure.Communication.JobRouter.RouterClientOptions.ServiceVersion.V2022_07_18_preview) { }
        public enum ServiceVersion
        {
            V2021_10_20_preview2 = 1,
            V2022_07_18_preview = 2,
        }
    }
    public abstract partial class RouterRule
    {
        internal RouterRule() { }
        public string Kind { get { throw null; } set { } }
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
    public partial class ScoringRuleOptions
    {
        public ScoringRuleOptions() { }
        public bool? AllowScoringBatchOfWorkers { get { throw null; } set { } }
        public int? BatchSize { get { throw null; } set { } }
        public bool? DescendingOrder { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ScoringRuleParameterSelector> ScoringParameters { get { throw null; } set { } }
    }
    public enum ScoringRuleParameterSelector
    {
        JobLabels = 0,
        WorkerSelectors = 1,
    }
    public partial class StaticQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public StaticQueueSelectorAttachment(Azure.Communication.JobRouter.QueueSelector labelSelector) { }
        public Azure.Communication.JobRouter.QueueSelector LabelSelector { get { throw null; } set { } }
    }
    public partial class StaticRule : Azure.Communication.JobRouter.RouterRule
    {
        public StaticRule(Azure.Communication.JobRouter.LabelValue value) { }
        public Azure.Communication.JobRouter.LabelValue Value { get { throw null; } set { } }
    }
    public partial class StaticWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public StaticWorkerSelectorAttachment(Azure.Communication.JobRouter.WorkerSelector labelSelector) { }
        public Azure.Communication.JobRouter.WorkerSelector LabelSelector { get { throw null; } set { } }
    }
    public partial class UpdateClassificationPolicyOptions
    {
        public UpdateClassificationPolicyOptions(string classificationPolicyId) { }
        public string ClassificationPolicyId { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectors { get { throw null; } set { } }
    }
    public partial class UpdateDistributionPolicyOptions
    {
        public UpdateDistributionPolicyOptions(string distributionPolicyId) { }
        public string DistributionPolicyId { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan OfferTtl { get { throw null; } set { } }
    }
    public partial class UpdateExceptionPolicyOptions
    {
        public UpdateExceptionPolicyOptions(string exceptionPolicyId) { }
        public string ExceptionPolicyId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule?> ExceptionRules { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class UpdateJobOptions
    {
        public UpdateJobOptions(string jobId) { }
        public string ChannelId { get { throw null; } set { } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<System.DateTimeOffset, string> Notes { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> RequestedWorkerSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
    }
    public partial class UpdateQueueOptions
    {
        public UpdateQueueOptions(string queueId) { }
        public string DistributionPolicyId { get { throw null; } set { } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
    }
    public partial class UpdateWorkerOptions
    {
        public UpdateWorkerOptions(string workerId) { }
        public bool? AvailableForOffers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ChannelConfiguration?> ChannelConfigurations { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.QueueAssignment?> QueueIds { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
        public int? TotalCapacity { get { throw null; } set { } }
        public string WorkerId { get { throw null; } }
    }
    public partial class WaitTimeExceptionTrigger : Azure.Communication.JobRouter.JobExceptionTrigger
    {
        public WaitTimeExceptionTrigger(System.TimeSpan threshold) { }
        public System.TimeSpan Threshold { get { throw null; } set { } }
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
    public partial class WorkerSelector
    {
        public WorkerSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.LabelValue value, System.TimeSpan? ttl = default(System.TimeSpan?), bool? expedite = default(bool?)) { }
        public bool? Expedite { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireTime { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Models.WorkerSelectorState? State { get { throw null; } }
        public System.TimeSpan? Ttl { get { throw null; } set { } }
        public Azure.Communication.JobRouter.LabelValue Value { get { throw null; } set { } }
    }
    public abstract partial class WorkerSelectorAttachment
    {
        internal WorkerSelectorAttachment() { }
        protected string Kind { get { throw null; } set { } }
    }
    public enum WorkerStateSelector
    {
        Active = 0,
        Draining = 1,
        Inactive = 2,
        All = 3,
    }
    public partial class WorkerWeightedAllocation
    {
        public WorkerWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerSelector> labelSelectors) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> LabelSelectors { get { throw null; } }
        public double Weight { get { throw null; } set { } }
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
    public partial class CancelJobResult
    {
        internal CancelJobResult() { }
    }
    public partial class ClassificationPolicy
    {
        internal ClassificationPolicy() { }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectors { get { throw null; } set { } }
    }
    public partial class ClassificationPolicyItem
    {
        internal ClassificationPolicyItem() { }
        public Azure.Communication.JobRouter.Models.ClassificationPolicy ClassificationPolicy { get { throw null; } }
        public string Etag { get { throw null; } }
    }
    public partial class CloseJobResult
    {
        internal CloseJobResult() { }
    }
    public partial class CompleteJobResult
    {
        internal CompleteJobResult() { }
    }
    public partial class DeclineJobOfferResult
    {
        internal DeclineJobOfferResult() { }
    }
    public partial class DistributionPolicy
    {
        internal DistributionPolicy() { }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan? OfferTtl { get { throw null; } set { } }
    }
    public partial class DistributionPolicyItem
    {
        internal DistributionPolicyItem() { }
        public Azure.Communication.JobRouter.Models.DistributionPolicy DistributionPolicy { get { throw null; } }
        public string Etag { get { throw null; } }
    }
    public partial class ExceptionPolicy
    {
        internal ExceptionPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule> ExceptionRules { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ExceptionPolicyItem
    {
        internal ExceptionPolicyItem() { }
        public string Etag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.ExceptionPolicy ExceptionPolicy { get { throw null; } }
    }
    public partial class JobAssignment
    {
        internal JobAssignment() { }
        public System.DateTimeOffset AssignTime { get { throw null; } }
        public System.DateTimeOffset? CloseTime { get { throw null; } }
        public System.DateTimeOffset? CompleteTime { get { throw null; } }
        public string Id { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class JobOffer
    {
        internal JobOffer() { }
        public int CapacityCost { get { throw null; } }
        public System.DateTimeOffset? ExpiryTimeUtc { get { throw null; } }
        public string Id { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? OfferTimeUtc { get { throw null; } }
    }
    public partial class JobPositionDetails
    {
        internal JobPositionDetails() { }
        public double EstimatedWaitTimeMinutes { get { throw null; } }
        public string JobId { get { throw null; } }
        public int Position { get { throw null; } }
        public string QueueId { get { throw null; } }
        public int QueueLength { get { throw null; } }
    }
    public partial class JobQueue
    {
        internal JobQueue() { }
        public string DistributionPolicyId { get { throw null; } set { } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class JobQueueItem
    {
        internal JobQueueItem() { }
        public string Etag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.JobQueue JobQueue { get { throw null; } }
    }
    public partial class JobRouterError
    {
        internal JobRouterError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.Models.JobRouterError> Details { get { throw null; } }
        public Azure.Communication.JobRouter.Models.JobRouterError InnerError { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public partial class QueueStatistics
    {
        internal QueueStatistics() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, double> EstimatedWaitTimeMinutes { get { throw null; } }
        public int Length { get { throw null; } }
        public double? LongestJobWaitTimeMinutes { get { throw null; } }
        public string QueueId { get { throw null; } }
    }
    public partial class ReclassifyJobResult
    {
        internal ReclassifyJobResult() { }
    }
    public partial class RouterJob
    {
        internal RouterJob() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.JobRouter.Models.JobAssignment> Assignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.WorkerSelector> AttachedWorkerSelectors { get { throw null; } }
        public string ChannelId { get { throw null; } set { } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public System.DateTimeOffset? EnqueueTimeUtc { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterJobStatus? JobStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public System.Collections.Generic.SortedDictionary<System.DateTimeOffset, string> Notes { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelector> RequestedWorkerSelectors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
    }
    public partial class RouterJobItem
    {
        internal RouterJobItem() { }
        public string Etag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterJob RouterJob { get { throw null; } }
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
        public static Azure.Communication.JobRouter.Models.RouterJobStatus Queued { get { throw null; } }
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
    public static partial class RouterModelFactory
    {
        public static Azure.Communication.JobRouter.Models.AcceptJobOfferResult AcceptJobOfferResult(string assignmentId = null, string jobId = null, string workerId = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.ClassificationPolicy ClassificationPolicy(string id = null, string name = null, string fallbackQueueId = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueSelectorAttachment> queueSelectors = null, Azure.Communication.JobRouter.RouterRule prioritizationRule = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerSelectorAttachment> workerSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.ClassificationPolicyItem ClassificationPolicyItem(Azure.Communication.JobRouter.Models.ClassificationPolicy classificationPolicy = null, string etag = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.DistributionPolicyItem DistributionPolicyItem(Azure.Communication.JobRouter.Models.DistributionPolicy distributionPolicy = null, string etag = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.ExceptionPolicy ExceptionPolicy(string id = null, string name = null, System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ExceptionRule> exceptionRules = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.ExceptionPolicyItem ExceptionPolicyItem(Azure.Communication.JobRouter.Models.ExceptionPolicy exceptionPolicy = null, string etag = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.JobAssignment JobAssignment(string id = null, string workerId = null, System.DateTimeOffset assignTime = default(System.DateTimeOffset), System.DateTimeOffset? completeTime = default(System.DateTimeOffset?), System.DateTimeOffset? closeTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.Models.JobOffer JobOffer(string id = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset? offerTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? expiryTimeUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.Models.JobPositionDetails JobPositionDetails(string jobId = null, int position = 0, string queueId = null, int queueLength = 0, double estimatedWaitTimeMinutes = 0) { throw null; }
        public static Azure.Communication.JobRouter.Models.JobQueueItem JobQueueItem(Azure.Communication.JobRouter.Models.JobQueue jobQueue = null, string etag = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.JobRouterError JobRouterError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.Models.JobRouterError> details = null, Azure.Communication.JobRouter.Models.JobRouterError innerError = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.QueueStatistics QueueStatistics(string queueId = null, int length = 0, System.Collections.Generic.IReadOnlyDictionary<string, double> estimatedWaitTimeMinutes = null, double? longestJobWaitTimeMinutes = default(double?)) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterJobItem RouterJobItem(Azure.Communication.JobRouter.Models.RouterJob routerJob = null, string etag = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterWorkerItem RouterWorkerItem(Azure.Communication.JobRouter.Models.RouterWorker routerWorker = null, string etag = null) { throw null; }
        public static Azure.Communication.JobRouter.Models.UnassignJobResult UnassignJobResult(string jobId = null, int unassignmentCount = 0) { throw null; }
        public static Azure.Communication.JobRouter.Models.WorkerAssignment WorkerAssignment(string id = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset assignTime = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class RouterWorker
    {
        public RouterWorker() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.Models.WorkerAssignment> AssignedJobs { get { throw null; } }
        public bool? AvailableForOffers { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.ChannelConfiguration> ChannelConfigurations { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Labels { get { throw null; } set { } }
        public double? LoadRatio { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.Models.JobOffer> Offers { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.QueueAssignment> QueueAssignments { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Models.RouterWorkerState? State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.LabelValue> Tags { get { throw null; } set { } }
        public int? TotalCapacity { get { throw null; } set { } }
    }
    public partial class RouterWorkerItem
    {
        internal RouterWorkerItem() { }
        public string Etag { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterWorker RouterWorker { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterWorkerState : System.IEquatable<Azure.Communication.JobRouter.Models.RouterWorkerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterWorkerState(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterWorkerState Active { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterWorkerState Draining { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterWorkerState Inactive { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.RouterWorkerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.RouterWorkerState left, Azure.Communication.JobRouter.Models.RouterWorkerState right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.RouterWorkerState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.RouterWorkerState left, Azure.Communication.JobRouter.Models.RouterWorkerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UnassignJobResult
    {
        internal UnassignJobResult() { }
        public string JobId { get { throw null; } }
        public int UnassignmentCount { get { throw null; } }
    }
    public partial class WorkerAssignment
    {
        internal WorkerAssignment() { }
        public System.DateTimeOffset AssignTime { get { throw null; } }
        public int CapacityCost { get { throw null; } }
        public string Id { get { throw null; } }
        public string JobId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkerSelectorState : System.IEquatable<Azure.Communication.JobRouter.Models.WorkerSelectorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkerSelectorState(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.WorkerSelectorState Active { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.WorkerSelectorState Expired { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.WorkerSelectorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.WorkerSelectorState left, Azure.Communication.JobRouter.Models.WorkerSelectorState right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.WorkerSelectorState (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.WorkerSelectorState left, Azure.Communication.JobRouter.Models.WorkerSelectorState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
