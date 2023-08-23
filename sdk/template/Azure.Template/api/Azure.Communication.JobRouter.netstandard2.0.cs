namespace Azure.Communication.JobRouter
{
    public partial class AzureCommunicationServicesClientOptions : Azure.Core.ClientOptions
    {
        public AzureCommunicationServicesClientOptions(Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions.ServiceVersion version = Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions.ServiceVersion.V2022_07_18_Preview) { }
        public enum ServiceVersion
        {
            V2022_07_18_Preview = 1,
        }
    }
    public partial class JobRouterAdministrationClient
    {
        protected JobRouterAdministrationClient() { }
        public JobRouterAdministrationClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public JobRouterAdministrationClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteClassificationPolicy(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteClassificationPolicyAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDistributionPolicy(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDistributionPolicyAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteExceptionPolicy(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteExceptionPolicyAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteQueue(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteQueueAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetClassificationPolicies(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassificationPoliciesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetClassificationPolicy(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationPolicyAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDistributionPolicies(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDistributionPoliciesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetDistributionPolicy(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDistributionPolicyAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExceptionPolicies(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExceptionPoliciesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetExceptionPolicy(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExceptionPolicyAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetQueue(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueueAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetQueues(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetQueuesAsync(int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response UpsertClassificationPolicy(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertClassificationPolicyAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpsertDistributionPolicy(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertDistributionPolicyAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpsertExceptionPolicy(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertExceptionPolicyAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpsertQueue(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertQueueAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class JobRouterClient
    {
        protected JobRouterClient() { }
        public JobRouterClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public JobRouterClient(string endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AcceptJobAction(string workerId, string offerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcceptJobActionAsync(string workerId, string offerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response CancelJobAction(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobActionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseJobAction(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseJobActionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CompleteJobAction(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteJobActionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeclineJobAction(string workerId, string offerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeclineJobActionAsync(string workerId, string offerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteJob(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteWorker(string workerId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkerAsync(string workerId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetInQueuePosition(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetInQueuePositionAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetJob(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetJob(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobs(string status, string queueId, string channelId, string classificationPolicyId, System.DateTimeOffset? scheduledBefore, System.DateTimeOffset? scheduledAfter, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsAsync(string status, string queueId, string channelId, string classificationPolicyId, System.DateTimeOffset? scheduledBefore, System.DateTimeOffset? scheduledAfter, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetQueueStatistics(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueueStatisticsAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetWorker(string workerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkerAsync(string workerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkers(string state, string channelId, string queueId, bool? hasCapacity, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkersAsync(string state, string channelId, string queueId, bool? hasCapacity, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ReclassifyJobAction(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReclassifyJobActionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UnassignJobAction(string id, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnassignJobActionAsync(string id, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpsertJob(Azure.Communication.JobRouter.Models.RouterJob job, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpsertJob(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertJobAsync(Azure.Communication.JobRouter.Models.RouterJob job, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertJobAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpsertWorker(string workerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpsertWorkerAsync(string workerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Azure.Communication.JobRouter.Models
{
    public partial class JobMatchingMode
    {
        public JobMatchingMode() { }
        public Azure.Communication.JobRouter.Models.JobMatchModeType? ModeType { get { throw null; } set { } }
        public object QueueAndMatchMode { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Models.ScheduleAndSuspendMode ScheduleAndSuspendMode { get { throw null; } set { } }
        public object SuspendMode { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobMatchModeType : System.IEquatable<Azure.Communication.JobRouter.Models.JobMatchModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobMatchModeType(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.JobMatchModeType QueueAndMatchMode { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.JobMatchModeType ScheduleAndSuspendMode { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.JobMatchModeType SuspendMode { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.JobMatchModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.JobMatchModeType left, Azure.Communication.JobRouter.Models.JobMatchModeType right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.JobMatchModeType (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.JobMatchModeType left, Azure.Communication.JobRouter.Models.JobMatchModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabelOperator : System.IEquatable<Azure.Communication.JobRouter.Models.LabelOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabelOperator(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.LabelOperator Equal { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.LabelOperator GreaterThan { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.LabelOperator GreaterThanEqual { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.LabelOperator LessThan { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.LabelOperator LessThanEqual { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.LabelOperator NotEqual { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.LabelOperator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.LabelOperator left, Azure.Communication.JobRouter.Models.LabelOperator right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.LabelOperator (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.LabelOperator left, Azure.Communication.JobRouter.Models.LabelOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouterJob
    {
        public RouterJob() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.Communication.JobRouter.Models.RouterJobAssignment> Assignments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.Models.RouterWorkerSelector> AttachedWorkerSelectors { get { throw null; } }
        public string ChannelId { get { throw null; } set { } }
        public string ChannelReference { get { throw null; } set { } }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public System.DateTimeOffset? EnqueuedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Labels { get { throw null; } }
        public Azure.Communication.JobRouter.Models.JobMatchingMode MatchingMode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Notes { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.Models.RouterWorkerSelector> RequestedWorkerSelectors { get { throw null; } }
        public System.DateTimeOffset? ScheduledAt { get { throw null; } }
        public Azure.Communication.JobRouter.Models.RouterJobStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, object> Tags { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterJobStatusSelector : System.IEquatable<Azure.Communication.JobRouter.Models.RouterJobStatusSelector>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterJobStatusSelector(string value) { throw null; }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Active { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector All { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Assigned { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Cancelled { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector ClassificationFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Closed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Completed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Created { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector PendingClassification { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector PendingSchedule { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Queued { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector Scheduled { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector ScheduleFailed { get { throw null; } }
        public static Azure.Communication.JobRouter.Models.RouterJobStatusSelector WaitingForActivation { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.Models.RouterJobStatusSelector other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.Models.RouterJobStatusSelector left, Azure.Communication.JobRouter.Models.RouterJobStatusSelector right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.Models.RouterJobStatusSelector (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.Models.RouterJobStatusSelector left, Azure.Communication.JobRouter.Models.RouterJobStatusSelector right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RouterWorkerSelector
    {
        public RouterWorkerSelector(string key, Azure.Communication.JobRouter.Models.LabelOperator labelOperator) { }
        public bool? Expedite { get { throw null; } set { } }
        public double? ExpiresAfterSeconds { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public string Key { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Models.LabelOperator LabelOperator { get { throw null; } set { } }
        public Azure.Communication.JobRouter.Models.RouterWorkerSelectorStatus? Status { get { throw null; } }
        public object Value { get { throw null; } set { } }
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
    public partial class ScheduleAndSuspendMode
    {
        public ScheduleAndSuspendMode() { }
        public System.DateTimeOffset? ScheduleAt { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class CommunicationJobRouterClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterAdministrationClient, Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterAdministrationClient, Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions> AddJobRouterAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterClient, Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, string endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterClient, Azure.Communication.JobRouter.AzureCommunicationServicesClientOptions> AddJobRouterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
