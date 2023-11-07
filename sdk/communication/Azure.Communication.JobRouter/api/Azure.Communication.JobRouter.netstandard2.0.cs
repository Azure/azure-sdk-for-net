namespace Azure.Communication.JobRouter
{
    public partial class AcceptJobOfferResult
    {
        internal AcceptJobOfferResult() { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class BestWorkerMode : Azure.Communication.JobRouter.DistributionMode
    {
        public BestWorkerMode() { }
        public Azure.Communication.JobRouter.RouterRule ScoringRule { get { throw null; } set { } }
        public Azure.Communication.JobRouter.ScoringRuleOptions ScoringRuleOptions { get { throw null; } set { } }
    }
    public partial class CancelExceptionAction : Azure.Communication.JobRouter.ExceptionAction
    {
        public CancelExceptionAction() { }
        public string DispositionCode { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
    }
    public partial class CancelJobOptions
    {
        public CancelJobOptions() { }
        public string DispositionCode { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
    }
    public partial class ClassificationPolicy
    {
        public ClassificationPolicy(string classificationPolicyId) { }
        public Azure.ETag ETag { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectorAttachments { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectorAttachments { get { throw null; } }
    }
    public partial class CloseJobOptions
    {
        public CloseJobOptions(string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public System.DateTimeOffset CloseAt { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
    }
    public partial class CompleteJobOptions
    {
        public CompleteJobOptions(string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public string Note { get { throw null; } set { } }
    }
    public partial class ConditionalQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public ConditionalQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterQueueSelector> QueueSelectors { get { throw null; } }
    }
    public partial class ConditionalWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public ConditionalWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
    }
    public partial class CreateClassificationPolicyOptions
    {
        public CreateClassificationPolicyOptions(string classificationPolicyId) { }
        public string ClassificationPolicyId { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectorAttachments { get { throw null; } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectorAttachments { get { throw null; } }
    }
    public partial class CreateDistributionPolicyOptions
    {
        public CreateDistributionPolicyOptions(string distributionPolicyId, System.TimeSpan offerExpiresAfter, Azure.Communication.JobRouter.DistributionMode mode) { }
        public string DistributionPolicyId { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan OfferExpiresAfter { get { throw null; } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
    }
    public partial class CreateExceptionPolicyOptions
    {
        public CreateExceptionPolicyOptions(string exceptionPolicyId, System.Collections.Generic.IList<Azure.Communication.JobRouter.ExceptionRule> exceptionRules) { }
        public string ExceptionPolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ExceptionRule> ExceptionRules { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
    }
    public partial class CreateJobOptions
    {
        public CreateJobOptions(string jobId, string channelId, string queueId) { }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterJobNote> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
    }
    public partial class CreateJobWithClassificationPolicyOptions
    {
        public CreateJobWithClassificationPolicyOptions(string jobId, string channelId, string classificationPolicyId) { }
        public string ChannelId { get { throw null; } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterJobNote> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
    }
    public partial class CreateQueueOptions
    {
        public CreateQueueOptions(string queueId, string distributionPolicyId) { }
        public string DistributionPolicyId { get { throw null; } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string QueueId { get { throw null; } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
    }
    public partial class CreateWorkerOptions
    {
        public CreateWorkerOptions(string workerId, int capacity) { }
        public bool AvailableForOffers { get { throw null; } set { } }
        public int Capacity { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterChannel> Channels { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public System.Collections.Generic.IList<string> Queues { get { throw null; } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class DeclineJobOfferOptions
    {
        public DeclineJobOfferOptions() { }
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
        public string Kind { get { throw null; } protected set { } }
        public int MaxConcurrentOffers { get { throw null; } set { } }
        public int MinConcurrentOffers { get { throw null; } set { } }
    }
    public partial class DistributionPolicy
    {
        public DistributionPolicy(string distributionPolicyId) { }
        public Azure.ETag ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan? OfferExpiresAfter { get { throw null; } set { } }
    }
    public abstract partial class ExceptionAction
    {
        protected ExceptionAction() { }
        public string Id { get { throw null; } }
        public string Kind { get { throw null; } protected set { } }
    }
    public partial class ExceptionPolicy
    {
        public ExceptionPolicy(string exceptionPolicyId) { }
        public Azure.ETag ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ExceptionRule> ExceptionRules { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ExceptionRule
    {
        public ExceptionRule(string id, Azure.Communication.JobRouter.ExceptionTrigger trigger) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ExceptionAction> Actions { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.ExceptionTrigger Trigger { get { throw null; } }
    }
    public abstract partial class ExceptionTrigger
    {
        protected ExceptionTrigger() { }
        public string Kind { get { throw null; } protected set { } }
    }
    public partial class ExpressionRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public ExpressionRouterRule(string expression) { }
        public string Expression { get { throw null; } }
        public string Language { get { throw null; } }
    }
    public partial class FunctionRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public FunctionRouterRule(System.Uri functionAppUri) { }
        public Azure.Communication.JobRouter.FunctionRouterRuleCredential Credential { get { throw null; } set { } }
        public System.Uri FunctionUri { get { throw null; } }
    }
    public partial class FunctionRouterRuleCredential
    {
        public FunctionRouterRuleCredential(string functionKey) { }
        public FunctionRouterRuleCredential(string appKey, string clientId) { }
    }
    public abstract partial class JobMatchingMode
    {
        protected JobMatchingMode() { }
        public string Kind { get { throw null; } protected set { } }
    }
    public partial class JobRouterAdministrationClient
    {
        protected JobRouterAdministrationClient() { }
        public JobRouterAdministrationClient(string connectionString) { }
        public JobRouterAdministrationClient(string connectionString, Azure.Communication.JobRouter.JobRouterClientOptions options) { }
        public JobRouterAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy> CreateClassificationPolicy(Azure.Communication.JobRouter.CreateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy>> CreateClassificationPolicyAsync(Azure.Communication.JobRouter.CreateClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.DistributionPolicy> CreateDistributionPolicy(Azure.Communication.JobRouter.CreateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.DistributionPolicy>> CreateDistributionPolicyAsync(Azure.Communication.JobRouter.CreateDistributionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy> CreateExceptionPolicy(Azure.Communication.JobRouter.CreateExceptionPolicyOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy>> CreateExceptionPolicyAsync(Azure.Communication.JobRouter.CreateExceptionPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterQueue> CreateQueue(Azure.Communication.JobRouter.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterQueue>> CreateQueueAsync(Azure.Communication.JobRouter.CreateQueueOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteClassificationPolicy(string classificationPolicyId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationPolicyAsync(string classificationPolicyId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDistributionPolicy(string distributionPolicyId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDistributionPolicyAsync(string distributionPolicyId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteExceptionPolicy(string exceptionPolicyId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteExceptionPolicyAsync(string exceptionPolicyId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteQueue(string queueId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string queueId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetClassificationPolicies(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.ClassificationPolicy> GetClassificationPolicies(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassificationPoliciesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.ClassificationPolicy> GetClassificationPoliciesAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassificationPolicy(string classificationPolicyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy> GetClassificationPolicy(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationPolicyAsync(string classificationPolicyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy>> GetClassificationPolicyAsync(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDistributionPolicies(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.DistributionPolicy> GetDistributionPolicies(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDistributionPoliciesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.DistributionPolicy> GetDistributionPoliciesAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDistributionPolicy(string distributionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.DistributionPolicy> GetDistributionPolicy(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDistributionPolicyAsync(string distributionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.DistributionPolicy>> GetDistributionPolicyAsync(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExceptionPolicies(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.ExceptionPolicy> GetExceptionPolicies(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExceptionPoliciesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.ExceptionPolicy> GetExceptionPoliciesAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExceptionPolicy(string exceptionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy> GetExceptionPolicy(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExceptionPolicyAsync(string exceptionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy>> GetExceptionPolicyAsync(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetQueue(string queueId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterQueue> GetQueue(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueueAsync(string queueId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterQueue>> GetQueueAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetQueues(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.RouterQueue> GetQueues(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetQueuesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.RouterQueue> GetQueuesAsync(int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy> UpdateClassificationPolicy(Azure.Communication.JobRouter.ClassificationPolicy classificationPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateClassificationPolicy(string classificationPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy>> UpdateClassificationPolicyAsync(Azure.Communication.JobRouter.ClassificationPolicy classificationPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationPolicyAsync(string classificationPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.DistributionPolicy> UpdateDistributionPolicy(Azure.Communication.JobRouter.DistributionPolicy distributionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateDistributionPolicy(string distributionPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.DistributionPolicy>> UpdateDistributionPolicyAsync(Azure.Communication.JobRouter.DistributionPolicy distributionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDistributionPolicyAsync(string distributionPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy> UpdateExceptionPolicy(Azure.Communication.JobRouter.ExceptionPolicy exceptionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy>> UpdateExceptionPolicyAsync(Azure.Communication.JobRouter.ExceptionPolicy exceptionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterQueue> UpdateQueue(Azure.Communication.JobRouter.RouterQueue queue, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterQueue>> UpdateQueueAsync(Azure.Communication.JobRouter.RouterQueue queue, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateQueueAsync(string queueId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class JobRouterClient
    {
        protected JobRouterClient() { }
        public JobRouterClient(string connectionString) { }
        public JobRouterClient(string connectionString, Azure.Communication.JobRouter.JobRouterClientOptions options) { }
        public JobRouterClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AcceptJobOffer(string workerId, string offerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.AcceptJobOfferResult> AcceptJobOffer(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcceptJobOfferAsync(string workerId, string offerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.AcceptJobOfferResult>> AcceptJobOfferAsync(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelJob(string jobId, Azure.Communication.JobRouter.CancelJobOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelJob(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string jobId, Azure.Communication.JobRouter.CancelJobOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseJob(string jobId, Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CloseJob(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseJobAsync(string jobId, Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CompleteJob(string jobId, Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CompleteJob(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteJobAsync(string jobId, Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> CreateJob(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> CreateJobAsync(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> CreateJobWithClassificationPolicy(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> CreateJobWithClassificationPolicyAsync(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterWorker> CreateWorker(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterWorker>> CreateWorkerAsync(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeclineJobOffer(string workerId, string offerId, Azure.Communication.JobRouter.DeclineJobOfferOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeclineJobOffer(string workerId, string offerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeclineJobOfferAsync(string workerId, string offerId, Azure.Communication.JobRouter.DeclineJobOfferOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeclineJobOfferAsync(string workerId, string offerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteJob(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteWorker(string workerId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkerAsync(string workerId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetJob(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.RouterJob> GetJobs(int? maxpagesize = default(int?), Azure.Communication.JobRouter.RouterJobStatusSelector? status = default(Azure.Communication.JobRouter.RouterJobStatusSelector?), string queueId = null, string channelId = null, string classificationPolicyId = null, System.DateTimeOffset? scheduledBefore = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledAfter = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobs(int? maxpagesize, string status, string queueId, string channelId, string classificationPolicyId, System.DateTimeOffset? scheduledBefore, System.DateTimeOffset? scheduledAfter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.RouterJob> GetJobsAsync(int? maxpagesize = default(int?), Azure.Communication.JobRouter.RouterJobStatusSelector? status = default(Azure.Communication.JobRouter.RouterJobStatusSelector?), string queueId = null, string channelId = null, string classificationPolicyId = null, System.DateTimeOffset? scheduledBefore = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledAfter = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsAsync(int? maxpagesize, string status, string queueId, string channelId, string classificationPolicyId, System.DateTimeOffset? scheduledBefore, System.DateTimeOffset? scheduledAfter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetQueuePosition(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJobPositionDetails> GetQueuePosition(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueuePositionAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJobPositionDetails>> GetQueuePositionAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetQueueStatistics(string queueId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterQueueStatistics> GetQueueStatistics(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueueStatisticsAsync(string queueId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterQueueStatistics>> GetQueueStatisticsAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWorker(string workerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterWorker> GetWorker(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkerAsync(string workerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterWorker>> GetWorkerAsync(string workerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.RouterWorker> GetWorkers(int? maxpagesize = default(int?), Azure.Communication.JobRouter.RouterWorkerStateSelector? state = default(Azure.Communication.JobRouter.RouterWorkerStateSelector?), string channelId = null, string queueId = null, bool? hasCapacity = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkers(int? maxpagesize, string state, string channelId, string queueId, bool? hasCapacity, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.RouterWorker> GetWorkersAsync(int? maxpagesize = default(int?), Azure.Communication.JobRouter.RouterWorkerStateSelector? state = default(Azure.Communication.JobRouter.RouterWorkerStateSelector?), string channelId = null, string queueId = null, bool? hasCapacity = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkersAsync(int? maxpagesize, string state, string channelId, string queueId, bool? hasCapacity, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ReclassifyJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReclassifyJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.UnassignJobResult> UnassignJob(string jobId, string assignmentId, Azure.Communication.JobRouter.UnassignJobOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UnassignJob(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.UnassignJobResult>> UnassignJobAsync(string jobId, string assignmentId, Azure.Communication.JobRouter.UnassignJobOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnassignJobAsync(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> UpdateJob(Azure.Communication.JobRouter.RouterJob job, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateJob(string jobId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> UpdateJobAsync(Azure.Communication.JobRouter.RouterJob job, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterWorker> UpdateWorker(Azure.Communication.JobRouter.RouterWorker worker, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateWorker(string workerId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterWorker>> UpdateWorkerAsync(Azure.Communication.JobRouter.RouterWorker worker, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateWorkerAsync(string workerId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class JobRouterClientOptions : Azure.Core.ClientOptions
    {
        public JobRouterClientOptions(Azure.Communication.JobRouter.JobRouterClientOptions.ServiceVersion version = Azure.Communication.JobRouter.JobRouterClientOptions.ServiceVersion.V2023_11_01) { }
        public enum ServiceVersion
        {
            V2023_11_01 = 1,
        }
    }
    public static partial class JobRouterModelFactory
    {
        public static Azure.Communication.JobRouter.AcceptJobOfferResult AcceptJobOfferResult(string assignmentId = null, string jobId = null, string workerId = null) { throw null; }
        public static Azure.Communication.JobRouter.CancelExceptionAction CancelExceptionAction(string id = null, string note = null, string dispositionCode = null) { throw null; }
        public static Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment ConditionalQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment ConditionalWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionAction ExceptionAction(string id = null, string kind = null) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionRule ExceptionRule(string id = null, Azure.Communication.JobRouter.ExceptionTrigger trigger = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.ExceptionAction> actions = null) { throw null; }
        public static Azure.Communication.JobRouter.ExpressionRouterRule ExpressionRouterRule(string language = null, string expression = null) { throw null; }
        public static Azure.Communication.JobRouter.FunctionRouterRule FunctionRouterRule(System.Uri functionUri = null, Azure.Communication.JobRouter.FunctionRouterRuleCredential credential = null) { throw null; }
        public static Azure.Communication.JobRouter.ManualReclassifyExceptionAction ManualReclassifyExceptionAction(string id = null, string queueId = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment PassThroughQueueSelectorAttachment(string key = null, Azure.Communication.JobRouter.LabelOperator labelOperator = default(Azure.Communication.JobRouter.LabelOperator)) { throw null; }
        public static Azure.Communication.JobRouter.QueueLengthExceptionTrigger QueueLengthExceptionTrigger(int threshold = 0) { throw null; }
        public static Azure.Communication.JobRouter.QueueWeightedAllocation QueueWeightedAllocation(double weight = 0, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.RouterChannel RouterChannel(string channelId = null, int capacityCostPerJob = 0, int? maxNumberOfJobs = default(int?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobAssignment RouterJobAssignment(string assignmentId = null, string workerId = null, System.DateTimeOffset assignedAt = default(System.DateTimeOffset), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? closedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobNote RouterJobNote(string message = null, System.DateTimeOffset? addedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobOffer RouterJobOffer(string offerId = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset? offeredAt = default(System.DateTimeOffset?), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterWorkerAssignment RouterWorkerAssignment(string assignmentId = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset assignedAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment RuleEngineQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule = null) { throw null; }
        public static Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment RuleEngineWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule = null) { throw null; }
        public static Azure.Communication.JobRouter.ScheduleAndSuspendMode ScheduleAndSuspendMode(System.DateTimeOffset scheduleAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Communication.JobRouter.StaticQueueSelectorAttachment StaticQueueSelectorAttachment(Azure.Communication.JobRouter.RouterQueueSelector queueSelector = null) { throw null; }
        public static Azure.Communication.JobRouter.StaticWorkerSelectorAttachment StaticWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterWorkerSelector workerSelector = null) { throw null; }
        public static Azure.Communication.JobRouter.UnassignJobResult UnassignJobResult(string jobId = null, int unassignmentCount = 0) { throw null; }
        public static Azure.Communication.JobRouter.WebhookRouterRule WebhookRouterRule(System.Uri authorizationServerUri = null, Azure.Communication.JobRouter.OAuth2WebhookClientCredential clientCredential = null, System.Uri webhookUri = null) { throw null; }
        public static Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment WeightedAllocationQueueSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueWeightedAllocation> allocations = null) { throw null; }
        public static Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment WeightedAllocationWorkerSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerWeightedAllocation> allocations = null) { throw null; }
        public static Azure.Communication.JobRouter.WorkerWeightedAllocation WorkerWeightedAllocation(double weight = 0, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabelOperator : System.IEquatable<Azure.Communication.JobRouter.LabelOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabelOperator(string value) { throw null; }
        public static Azure.Communication.JobRouter.LabelOperator Equal { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator GreaterThan { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator LessThan { get { throw null; } }
        public static Azure.Communication.JobRouter.LabelOperator LessThanOrEqual { get { throw null; } }
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
    public partial class OAuth2WebhookClientCredential
    {
        public OAuth2WebhookClientCredential(string clientId, string clientSecret) { }
    }
    public partial class PassThroughQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public PassThroughQueueSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator) { }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
    }
    public partial class PassThroughWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public PassThroughWorkerSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, System.TimeSpan? expiresAfter = default(System.TimeSpan?)) { }
        public System.TimeSpan? ExpiresAfter { get { throw null; } }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
    }
    public partial class QueueAndMatchMode : Azure.Communication.JobRouter.JobMatchingMode
    {
        public QueueAndMatchMode() { }
    }
    public partial class QueueLengthExceptionTrigger : Azure.Communication.JobRouter.ExceptionTrigger
    {
        public QueueLengthExceptionTrigger(int threshold) { }
        public int Threshold { get { throw null; } }
    }
    public abstract partial class QueueSelectorAttachment
    {
        protected QueueSelectorAttachment() { }
        public string Kind { get { throw null; } protected set { } }
    }
    public partial class QueueWeightedAllocation
    {
        public QueueWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterQueueSelector> QueueSelectors { get { throw null; } }
        public double Weight { get { throw null; } }
    }
    public partial class ReclassifyExceptionAction : Azure.Communication.JobRouter.ExceptionAction
    {
        public ReclassifyExceptionAction() { }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> LabelsToUpsert { get { throw null; } }
    }
    public partial class RoundRobinMode : Azure.Communication.JobRouter.DistributionMode
    {
        public RoundRobinMode() { }
    }
    public partial class RouterChannel
    {
        public RouterChannel(string channelId, int capacityCostPerJob) { }
        public int CapacityCostPerJob { get { throw null; } }
        public string ChannelId { get { throw null; } }
        public int? MaxNumberOfJobs { get { throw null; } set { } }
    }
    public partial class RouterJob
    {
        public RouterJob(string jobId) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.JobRouter.RouterJobAssignment> Assignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterWorkerSelector> AttachedWorkerSelectors { get { throw null; } }
        public string ChannelId { get { throw null; } set { } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public System.DateTimeOffset? EnqueuedAt { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.JobMatchingMode MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterJobNote> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.DateTimeOffset? ScheduledAt { get { throw null; } }
        public Azure.Communication.JobRouter.RouterJobStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
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
    public partial class RouterJobNote
    {
        public RouterJobNote(string message) { }
        public System.DateTimeOffset? AddedAt { get { throw null; } set { } }
        public string Message { get { throw null; } }
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
    public readonly partial struct RouterJobStatus : System.IEquatable<Azure.Communication.JobRouter.RouterJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterJobStatus(string value) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobStatus Assigned { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus Cancelled { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus ClassificationFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus Closed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus Completed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus Created { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus PendingClassification { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus PendingSchedule { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus Queued { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus Scheduled { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus ScheduleFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterJobStatus WaitingForActivation { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterJobStatus left, Azure.Communication.JobRouter.RouterJobStatus right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.RouterJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterJobStatus left, Azure.Communication.JobRouter.RouterJobStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RouterQueue
    {
        public RouterQueue(string queueId) { }
        public string DistributionPolicyId { get { throw null; } set { } }
        public Azure.ETag ETag { get { throw null; } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class RouterQueueSelector
    {
        public RouterQueueSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.RouterValue value) { }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
        public Azure.Communication.JobRouter.RouterValue Value { get { throw null; } }
    }
    public partial class RouterQueueStatistics
    {
        internal RouterQueueStatistics() { }
        public System.Collections.Generic.IDictionary<int, System.TimeSpan> EstimatedWaitTimes { get { throw null; } }
        public int Length { get { throw null; } }
        public double? LongestJobWaitTimeMinutes { get { throw null; } }
        public string QueueId { get { throw null; } }
    }
    public abstract partial class RouterRule
    {
        protected RouterRule() { }
        public string Kind { get { throw null; } protected set { } }
    }
    public partial class RouterValue : System.IEquatable<Azure.Communication.JobRouter.RouterValue>
    {
        public RouterValue(bool value) { }
        public RouterValue(decimal value) { }
        public RouterValue(double value) { }
        public RouterValue(int value) { }
        public RouterValue(long value) { }
        public RouterValue(float value) { }
        public RouterValue(string value) { }
        public object Value { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterValue other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterValue left, Azure.Communication.JobRouter.RouterValue right) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterValue left, Azure.Communication.JobRouter.RouterValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouterWorker
    {
        public RouterWorker(string workerId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterWorkerAssignment> AssignedJobs { get { throw null; } }
        public bool? AvailableForOffers { get { throw null; } set { } }
        public int? Capacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterChannel> Channels { get { throw null; } }
        public Azure.ETag ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public double? LoadRatio { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterJobOffer> Offers { get { throw null; } }
        public System.Collections.Generic.IList<string> Queues { get { throw null; } }
        public Azure.Communication.JobRouter.RouterWorkerState? State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
    }
    public partial class RouterWorkerAssignment
    {
        internal RouterWorkerAssignment() { }
        public System.DateTimeOffset AssignedAt { get { throw null; } }
        public string AssignmentId { get { throw null; } }
        public int CapacityCost { get { throw null; } }
        public string JobId { get { throw null; } }
    }
    public partial class RouterWorkerSelector
    {
        public RouterWorkerSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.RouterValue value) { }
        public bool? Expedite { get { throw null; } set { } }
        public System.TimeSpan? ExpiresAfter { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } set { } }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
        public Azure.Communication.JobRouter.RouterWorkerSelectorStatus? Status { get { throw null; } }
        public Azure.Communication.JobRouter.RouterValue Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterWorkerSelectorStatus : System.IEquatable<Azure.Communication.JobRouter.RouterWorkerSelectorStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterWorkerSelectorStatus(string value) { throw null; }
        public static Azure.Communication.JobRouter.RouterWorkerSelectorStatus Active { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterWorkerSelectorStatus Expired { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterWorkerSelectorStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterWorkerSelectorStatus left, Azure.Communication.JobRouter.RouterWorkerSelectorStatus right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.RouterWorkerSelectorStatus (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterWorkerSelectorStatus left, Azure.Communication.JobRouter.RouterWorkerSelectorStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.Communication.JobRouter.RouterRule Rule { get { throw null; } }
    }
    public partial class RuleEngineWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public RuleEngineWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule) { }
        public Azure.Communication.JobRouter.RouterRule Rule { get { throw null; } }
    }
    public partial class ScheduleAndSuspendMode : Azure.Communication.JobRouter.JobMatchingMode
    {
        public ScheduleAndSuspendMode(System.DateTimeOffset scheduleAt) { }
        public System.DateTimeOffset ScheduleAt { get { throw null; } }
    }
    public partial class ScoringRuleOptions
    {
        internal ScoringRuleOptions() { }
        public int? BatchSize { get { throw null; } set { } }
        public bool? DescendingOrder { get { throw null; } set { } }
        public bool? IsBatchScoringEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ScoringRuleParameterSelector> ScoringParameters { get { throw null; } }
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
        public Azure.Communication.JobRouter.RouterQueueSelector QueueSelector { get { throw null; } }
    }
    public partial class StaticRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public StaticRouterRule(Azure.Communication.JobRouter.RouterValue value) { }
        public Azure.Communication.JobRouter.RouterValue Value { get { throw null; } set { } }
    }
    public partial class StaticWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public StaticWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterWorkerSelector workerSelector) { }
        public Azure.Communication.JobRouter.RouterWorkerSelector WorkerSelector { get { throw null; } }
    }
    public partial class SuspendMode : Azure.Communication.JobRouter.JobMatchingMode
    {
        public SuspendMode() { }
    }
    public partial class UnassignJobOptions
    {
        public UnassignJobOptions() { }
        public bool? SuspendMatching { get { throw null; } set { } }
    }
    public partial class UnassignJobResult
    {
        internal UnassignJobResult() { }
        public string JobId { get { throw null; } }
        public int UnassignmentCount { get { throw null; } }
    }
    public partial class WaitTimeExceptionTrigger : Azure.Communication.JobRouter.ExceptionTrigger
    {
        public WaitTimeExceptionTrigger(System.TimeSpan threshold) { }
        public System.TimeSpan Threshold { get { throw null; } set { } }
    }
    public partial class WebhookRouterRule : Azure.Communication.JobRouter.RouterRule
    {
        public WebhookRouterRule(System.Uri authorizationServerUri, Azure.Communication.JobRouter.OAuth2WebhookClientCredential clientCredential, System.Uri webhookUri) { }
        public System.Uri AuthorizationServerUri { get { throw null; } }
        public Azure.Communication.JobRouter.OAuth2WebhookClientCredential ClientCredential { get { throw null; } }
        public System.Uri WebhookUri { get { throw null; } }
    }
    public partial class WeightedAllocationQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment
    {
        public WeightedAllocationQueueSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueWeightedAllocation> allocations) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.QueueWeightedAllocation> Allocations { get { throw null; } }
    }
    public partial class WeightedAllocationWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment
    {
        public WeightedAllocationWorkerSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerWeightedAllocation> allocations) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.WorkerWeightedAllocation> Allocations { get { throw null; } }
    }
    public abstract partial class WorkerSelectorAttachment
    {
        protected WorkerSelectorAttachment() { }
        public string Kind { get { throw null; } protected set { } }
    }
    public partial class WorkerWeightedAllocation
    {
        public WorkerWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors) { }
        public double Weight { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
    }
}
