namespace Azure.Communication.JobRouter
{
    public partial class AcceptJobOfferResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.AcceptJobOfferResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.AcceptJobOfferResult>
    {
        internal AcceptJobOfferResult() { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
        public string WorkerId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.AcceptJobOfferResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.AcceptJobOfferResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.AcceptJobOfferResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.AcceptJobOfferResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.AcceptJobOfferResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.AcceptJobOfferResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.AcceptJobOfferResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureCommunicationJobRouterContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureCommunicationJobRouterContext() { }
        public static Azure.Communication.JobRouter.AzureCommunicationJobRouterContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BestWorkerMode : Azure.Communication.JobRouter.DistributionMode, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.BestWorkerMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.BestWorkerMode>
    {
        public BestWorkerMode() { }
        public Azure.Communication.JobRouter.RouterRule ScoringRule { get { throw null; } set { } }
        public Azure.Communication.JobRouter.ScoringRuleOptions ScoringRuleOptions { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.BestWorkerMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.BestWorkerMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.BestWorkerMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.BestWorkerMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.BestWorkerMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.BestWorkerMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.BestWorkerMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CancelExceptionAction : Azure.Communication.JobRouter.ExceptionAction, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CancelExceptionAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelExceptionAction>
    {
        public CancelExceptionAction() { }
        public string DispositionCode { get { throw null; } set { } }
        public string Note { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CancelExceptionAction System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CancelExceptionAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CancelExceptionAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CancelExceptionAction System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelExceptionAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelExceptionAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelExceptionAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CancelJobOptions : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CancelJobOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelJobOptions>
    {
        public CancelJobOptions(string jobId) { }
        public string DispositionCode { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public string Note { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CancelJobOptions System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CancelJobOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CancelJobOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CancelJobOptions System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelJobOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelJobOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CancelJobOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClassificationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ClassificationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ClassificationPolicy>
    {
        public ClassificationPolicy(string classificationPolicyId) { }
        public Azure.ETag ETag { get { throw null; } }
        public string FallbackQueueId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Communication.JobRouter.RouterRule PrioritizationRule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.QueueSelectorAttachment> QueueSelectorAttachments { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.WorkerSelectorAttachment> WorkerSelectorAttachments { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ClassificationPolicy System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ClassificationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ClassificationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ClassificationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ClassificationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ClassificationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ClassificationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloseJobOptions : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CloseJobOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CloseJobOptions>
    {
        public CloseJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public System.DateTimeOffset CloseAt { get { throw null; } set { } }
        public string DispositionCode { get { throw null; } set { } }
        public string JobId { get { throw null; } }
        public string Note { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CloseJobOptions System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CloseJobOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CloseJobOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CloseJobOptions System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CloseJobOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CloseJobOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CloseJobOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompleteJobOptions : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CompleteJobOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CompleteJobOptions>
    {
        public CompleteJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Note { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CompleteJobOptions System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CompleteJobOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.CompleteJobOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.CompleteJobOptions System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CompleteJobOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CompleteJobOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.CompleteJobOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>
    {
        public ConditionalQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterQueueSelector> QueueSelectors { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConditionalWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>
    {
        public ConditionalWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition) { }
        public Azure.Communication.JobRouter.RouterRule Condition { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public CreateExceptionPolicyOptions(string exceptionPolicyId, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.ExceptionRule> exceptionRules) { }
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
        public int? MaxConcurrentOffers { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Queues { get { throw null; } }
        public Azure.RequestConditions RequestConditions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
        public string WorkerId { get { throw null; } }
    }
    public partial class DeclineJobOfferOptions : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>
    {
        public DeclineJobOfferOptions(string workerId, string offerId) { }
        public string OfferId { get { throw null; } }
        public System.DateTimeOffset? RetryOfferAt { get { throw null; } set { } }
        public string WorkerId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DeclineJobOfferOptions System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DeclineJobOfferOptions System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DeclineJobOfferOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirectMapRouterRule : Azure.Communication.JobRouter.RouterRule, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DirectMapRouterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DirectMapRouterRule>
    {
        public DirectMapRouterRule() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DirectMapRouterRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DirectMapRouterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DirectMapRouterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DirectMapRouterRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DirectMapRouterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DirectMapRouterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DirectMapRouterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DistributionMode : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DistributionMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionMode>
    {
        protected DistributionMode() { }
        public bool? BypassSelectors { get { throw null; } set { } }
        public Azure.Communication.JobRouter.DistributionModeKind Kind { get { throw null; } protected set { } }
        public int MaxConcurrentOffers { get { throw null; } set { } }
        public int MinConcurrentOffers { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DistributionMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DistributionMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DistributionMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DistributionMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DistributionModeKind : System.IEquatable<Azure.Communication.JobRouter.DistributionModeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DistributionModeKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.DistributionModeKind BestWorker { get { throw null; } }
        public static Azure.Communication.JobRouter.DistributionModeKind LongestIdle { get { throw null; } }
        public static Azure.Communication.JobRouter.DistributionModeKind RoundRobin { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.DistributionModeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.DistributionModeKind left, Azure.Communication.JobRouter.DistributionModeKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.DistributionModeKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.DistributionModeKind left, Azure.Communication.JobRouter.DistributionModeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DistributionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DistributionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionPolicy>
    {
        public DistributionPolicy(string distributionPolicyId) { }
        public Azure.ETag ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.DistributionMode Mode { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.TimeSpan? OfferExpiresAfter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DistributionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DistributionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.DistributionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.DistributionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.DistributionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExceptionAction : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionAction>
    {
        protected ExceptionAction() { }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.ExceptionActionKind Kind { get { throw null; } protected set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionAction System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionAction System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExceptionActionKind : System.IEquatable<Azure.Communication.JobRouter.ExceptionActionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExceptionActionKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionActionKind Cancel { get { throw null; } }
        public static Azure.Communication.JobRouter.ExceptionActionKind ManualReclassify { get { throw null; } }
        public static Azure.Communication.JobRouter.ExceptionActionKind Reclassify { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.ExceptionActionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.ExceptionActionKind left, Azure.Communication.JobRouter.ExceptionActionKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.ExceptionActionKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.ExceptionActionKind left, Azure.Communication.JobRouter.ExceptionActionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExceptionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionPolicy>
    {
        public ExceptionPolicy(string exceptionPolicyId) { }
        public Azure.ETag ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ExceptionRule> ExceptionRules { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionPolicy System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExceptionRule : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionRule>
    {
        public ExceptionRule(string id, Azure.Communication.JobRouter.ExceptionTrigger trigger) { }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ExceptionAction> Actions { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Communication.JobRouter.ExceptionTrigger Trigger { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExceptionTrigger : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionTrigger>
    {
        protected ExceptionTrigger() { }
        public Azure.Communication.JobRouter.ExceptionTriggerKind Kind { get { throw null; } protected set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionTrigger System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExceptionTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExceptionTrigger System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExceptionTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExceptionTriggerKind : System.IEquatable<Azure.Communication.JobRouter.ExceptionTriggerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExceptionTriggerKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionTriggerKind QueueLength { get { throw null; } }
        public static Azure.Communication.JobRouter.ExceptionTriggerKind WaitTime { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.ExceptionTriggerKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.ExceptionTriggerKind left, Azure.Communication.JobRouter.ExceptionTriggerKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.ExceptionTriggerKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.ExceptionTriggerKind left, Azure.Communication.JobRouter.ExceptionTriggerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExpressionRouterRule : Azure.Communication.JobRouter.RouterRule, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExpressionRouterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExpressionRouterRule>
    {
        public ExpressionRouterRule(string expression) { }
        public string Expression { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExpressionRouterRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExpressionRouterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ExpressionRouterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ExpressionRouterRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExpressionRouterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExpressionRouterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ExpressionRouterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionRouterRule : Azure.Communication.JobRouter.RouterRule, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.FunctionRouterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRule>
    {
        public FunctionRouterRule(System.Uri functionAppUri) { }
        public Azure.Communication.JobRouter.FunctionRouterRuleCredential Credential { get { throw null; } set { } }
        public System.Uri FunctionUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.FunctionRouterRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.FunctionRouterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.FunctionRouterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.FunctionRouterRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionRouterRuleCredential : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>
    {
        public FunctionRouterRuleCredential(string functionKey) { }
        public FunctionRouterRuleCredential(string appKey, string clientId) { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.FunctionRouterRuleCredential System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.FunctionRouterRuleCredential System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.FunctionRouterRuleCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class JobMatchingMode : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.JobMatchingMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.JobMatchingMode>
    {
        protected JobMatchingMode() { }
        public Azure.Communication.JobRouter.JobMatchingModeKind Kind { get { throw null; } protected set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.JobMatchingMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.JobMatchingMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.JobMatchingMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.JobMatchingMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.JobMatchingMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.JobMatchingMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.JobMatchingMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobMatchingModeKind : System.IEquatable<Azure.Communication.JobRouter.JobMatchingModeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobMatchingModeKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.JobMatchingModeKind QueueAndMatch { get { throw null; } }
        public static Azure.Communication.JobRouter.JobMatchingModeKind ScheduleAndSuspend { get { throw null; } }
        public static Azure.Communication.JobRouter.JobMatchingModeKind Suspend { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.JobMatchingModeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.JobMatchingModeKind left, Azure.Communication.JobRouter.JobMatchingModeKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.JobMatchingModeKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.JobMatchingModeKind left, Azure.Communication.JobRouter.JobMatchingModeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobRouterAdministrationClient
    {
        protected JobRouterAdministrationClient() { }
        public JobRouterAdministrationClient(string connectionString, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterAdministrationClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
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
        public virtual Azure.Pageable<System.BinaryData> GetClassificationPolicies(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.ClassificationPolicy> GetClassificationPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetClassificationPoliciesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.ClassificationPolicy> GetClassificationPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetClassificationPolicy(string classificationPolicyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy> GetClassificationPolicy(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetClassificationPolicyAsync(string classificationPolicyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy>> GetClassificationPolicyAsync(string classificationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDistributionPolicies(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.DistributionPolicy> GetDistributionPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDistributionPoliciesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.DistributionPolicy> GetDistributionPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDistributionPolicy(string distributionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.DistributionPolicy> GetDistributionPolicy(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDistributionPolicyAsync(string distributionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.DistributionPolicy>> GetDistributionPolicyAsync(string distributionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetExceptionPolicies(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.ExceptionPolicy> GetExceptionPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetExceptionPoliciesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.ExceptionPolicy> GetExceptionPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetExceptionPolicy(string exceptionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy> GetExceptionPolicy(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetExceptionPolicyAsync(string exceptionPolicyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy>> GetExceptionPolicyAsync(string exceptionPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetQueue(string queueId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterQueue> GetQueue(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetQueueAsync(string queueId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterQueue>> GetQueueAsync(string queueId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetQueues(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.RouterQueue> GetQueues(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetQueuesAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.RouterQueue> GetQueuesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy> UpdateClassificationPolicy(Azure.Communication.JobRouter.ClassificationPolicy classificationPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateClassificationPolicy(string classificationPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ClassificationPolicy>> UpdateClassificationPolicyAsync(Azure.Communication.JobRouter.ClassificationPolicy classificationPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateClassificationPolicyAsync(string classificationPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.DistributionPolicy> UpdateDistributionPolicy(Azure.Communication.JobRouter.DistributionPolicy distributionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateDistributionPolicy(string distributionPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.DistributionPolicy>> UpdateDistributionPolicyAsync(Azure.Communication.JobRouter.DistributionPolicy distributionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDistributionPolicyAsync(string distributionPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy> UpdateExceptionPolicy(Azure.Communication.JobRouter.ExceptionPolicy exceptionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateExceptionPolicy(string exceptionPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.ExceptionPolicy>> UpdateExceptionPolicyAsync(Azure.Communication.JobRouter.ExceptionPolicy exceptionPolicy, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateExceptionPolicyAsync(string exceptionPolicyId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterQueue> UpdateQueue(Azure.Communication.JobRouter.RouterQueue queue, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateQueue(string queueId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterQueue>> UpdateQueueAsync(Azure.Communication.JobRouter.RouterQueue queue, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateQueueAsync(string queueId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class JobRouterClient
    {
        protected JobRouterClient() { }
        public JobRouterClient(string connectionString, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public JobRouterClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public JobRouterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Communication.JobRouter.JobRouterClientOptions options = null) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AcceptJobOffer(string workerId, string offerId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.AcceptJobOfferResult> AcceptJobOffer(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AcceptJobOfferAsync(string workerId, string offerId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.AcceptJobOfferResult>> AcceptJobOfferAsync(string workerId, string offerId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelJob(Azure.Communication.JobRouter.CancelJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelJob(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(Azure.Communication.JobRouter.CancelJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CloseJob(Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CloseJob(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseJobAsync(Azure.Communication.JobRouter.CloseJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CloseJobAsync(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CompleteJob(Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CompleteJob(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteJobAsync(Azure.Communication.JobRouter.CompleteJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CompleteJobAsync(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> CreateJob(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> CreateJobAsync(Azure.Communication.JobRouter.CreateJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> CreateJobWithClassificationPolicy(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> CreateJobWithClassificationPolicyAsync(Azure.Communication.JobRouter.CreateJobWithClassificationPolicyOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterWorker> CreateWorker(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterWorker>> CreateWorkerAsync(Azure.Communication.JobRouter.CreateWorkerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeclineJobOffer(Azure.Communication.JobRouter.DeclineJobOfferOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeclineJobOffer(string workerId, string offerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeclineJobOfferAsync(Azure.Communication.JobRouter.DeclineJobOfferOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeclineJobOfferAsync(string workerId, string offerId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteJob(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteJobAsync(string jobId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteWorker(string workerId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteWorkerAsync(string workerId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetJob(string jobId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.RouterJob> GetJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetJobAsync(string jobId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.RouterJob>> GetJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Communication.JobRouter.RouterJob> GetJobs(Azure.Communication.JobRouter.RouterJobStatusSelector? status = default(Azure.Communication.JobRouter.RouterJobStatusSelector?), string queueId = null, string channelId = null, string classificationPolicyId = null, System.DateTimeOffset? scheduledBefore = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledAfter = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetJobs(string status, string queueId, string channelId, string classificationPolicyId, System.DateTimeOffset? scheduledBefore, System.DateTimeOffset? scheduledAfter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.RouterJob> GetJobsAsync(Azure.Communication.JobRouter.RouterJobStatusSelector? status = default(Azure.Communication.JobRouter.RouterJobStatusSelector?), string queueId = null, string channelId = null, string classificationPolicyId = null, System.DateTimeOffset? scheduledBefore = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledAfter = default(System.DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetJobsAsync(string status, string queueId, string channelId, string classificationPolicyId, System.DateTimeOffset? scheduledBefore, System.DateTimeOffset? scheduledAfter, Azure.RequestContext context) { throw null; }
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
        public virtual Azure.Pageable<Azure.Communication.JobRouter.RouterWorker> GetWorkers(Azure.Communication.JobRouter.RouterWorkerStateSelector? state = default(Azure.Communication.JobRouter.RouterWorkerStateSelector?), string channelId = null, string queueId = null, bool? hasCapacity = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetWorkers(string state, string channelId, string queueId, bool? hasCapacity, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Communication.JobRouter.RouterWorker> GetWorkersAsync(Azure.Communication.JobRouter.RouterWorkerStateSelector? state = default(Azure.Communication.JobRouter.RouterWorkerStateSelector?), string channelId = null, string queueId = null, bool? hasCapacity = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetWorkersAsync(string state, string channelId, string queueId, bool? hasCapacity, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ReclassifyJob(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response ReclassifyJob(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReclassifyJobAsync(string jobId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReclassifyJobAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Communication.JobRouter.UnassignJobResult> UnassignJob(Azure.Communication.JobRouter.UnassignJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UnassignJob(string jobId, string assignmentId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Communication.JobRouter.UnassignJobResult>> UnassignJobAsync(Azure.Communication.JobRouter.UnassignJobOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class JobRouterClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterAdministrationClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterAdministrationClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterAdministrationClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.Core.TokenCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterAdministrationClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, string connectionString) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.Core.TokenCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Communication.JobRouter.JobRouterClient, Azure.Communication.JobRouter.JobRouterClientOptions> AddJobRouterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
    public partial class JobRouterClientOptions : Azure.Core.ClientOptions
    {
        public JobRouterClientOptions(Azure.Communication.JobRouter.JobRouterClientOptions.ServiceVersion version = Azure.Communication.JobRouter.JobRouterClientOptions.ServiceVersion.V2024_01_18_Preview) { }
        public enum ServiceVersion
        {
            V2023_11_01 = 1,
            V2024_01_18_Preview = 2,
        }
    }
    public static partial class JobRouterModelFactory
    {
        public static Azure.Communication.JobRouter.AcceptJobOfferResult AcceptJobOfferResult(string assignmentId = null, string jobId = null, string workerId = null) { throw null; }
        public static Azure.Communication.JobRouter.CancelExceptionAction CancelExceptionAction(string id = null, string note = null, string dispositionCode = null) { throw null; }
        public static Azure.Communication.JobRouter.ClassificationPolicy ClassificationPolicy(Azure.ETag eTag = default(Azure.ETag), string id = null, string name = null, string fallbackQueueId = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueSelectorAttachment> queueSelectorAttachments = null, Azure.Communication.JobRouter.RouterRule prioritizationRule = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerSelectorAttachment> workerSelectorAttachments = null) { throw null; }
        public static Azure.Communication.JobRouter.ConditionalQueueSelectorAttachment ConditionalQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.ConditionalWorkerSelectorAttachment ConditionalWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule condition = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.DistributionPolicy DistributionPolicy(Azure.ETag eTag = default(Azure.ETag), string id = null, string name = null, System.TimeSpan? offerExpiresAfter = default(System.TimeSpan?), Azure.Communication.JobRouter.DistributionMode mode = null) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionAction ExceptionAction(string id = null, string kind = null) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionPolicy ExceptionPolicy(Azure.ETag eTag = default(Azure.ETag), string id = null, string name = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.ExceptionRule> exceptionRules = null) { throw null; }
        public static Azure.Communication.JobRouter.ExceptionRule ExceptionRule(string id = null, Azure.Communication.JobRouter.ExceptionTrigger trigger = null, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.ExceptionAction> actions = null) { throw null; }
        public static Azure.Communication.JobRouter.FunctionRouterRule FunctionRouterRule(System.Uri functionUri = null, Azure.Communication.JobRouter.FunctionRouterRuleCredential credential = null) { throw null; }
        public static Azure.Communication.JobRouter.ManualReclassifyExceptionAction ManualReclassifyExceptionAction(string id = null, string queueId = null, int? priority = default(int?), System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment PassThroughQueueSelectorAttachment(string key = null, Azure.Communication.JobRouter.LabelOperator labelOperator = default(Azure.Communication.JobRouter.LabelOperator)) { throw null; }
        public static Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment PassThroughWorkerSelectorAttachment(string key = null, Azure.Communication.JobRouter.LabelOperator labelOperator = default(Azure.Communication.JobRouter.LabelOperator), System.TimeSpan? expiresAfter = default(System.TimeSpan?)) { throw null; }
        public static Azure.Communication.JobRouter.QueueLengthExceptionTrigger QueueLengthExceptionTrigger(int threshold = 0) { throw null; }
        public static Azure.Communication.JobRouter.QueueWeightedAllocation QueueWeightedAllocation(double weight = 0, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors = null) { throw null; }
        public static Azure.Communication.JobRouter.RouterChannel RouterChannel(string channelId = null, int capacityCostPerJob = 0, int? maxNumberOfJobs = default(int?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobAssignment RouterJobAssignment(string assignmentId = null, string workerId = null, System.DateTimeOffset assignedAt = default(System.DateTimeOffset), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? closedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobNote RouterJobNote(string message = null, System.DateTimeOffset? addedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobOffer RouterJobOffer(string offerId = null, string jobId = null, int capacityCost = 0, System.DateTimeOffset? offeredAt = default(System.DateTimeOffset?), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Communication.JobRouter.RouterJobPositionDetails RouterJobPositionDetails(string jobId = null, int position = 0, string queueId = null, int queueLength = 0, System.TimeSpan estimatedWaitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Communication.JobRouter.RouterQueueStatistics RouterQueueStatistics(string queueId = null, int length = 0, System.Collections.Generic.IDictionary<int, System.TimeSpan> estimatedWaitTimes = null, double? longestJobWaitTimeMinutes = default(double?)) { throw null; }
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
    public partial class LongestIdleMode : Azure.Communication.JobRouter.DistributionMode, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.LongestIdleMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.LongestIdleMode>
    {
        public LongestIdleMode() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.LongestIdleMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.LongestIdleMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.LongestIdleMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.LongestIdleMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.LongestIdleMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.LongestIdleMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.LongestIdleMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManualReclassifyExceptionAction : Azure.Communication.JobRouter.ExceptionAction, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>
    {
        public ManualReclassifyExceptionAction() { }
        public int? Priority { get { throw null; } set { } }
        public string QueueId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ManualReclassifyExceptionAction System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ManualReclassifyExceptionAction System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ManualReclassifyExceptionAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OAuth2WebhookClientCredential : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>
    {
        public OAuth2WebhookClientCredential(string clientId, string clientSecret) { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.OAuth2WebhookClientCredential System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.OAuth2WebhookClientCredential System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.OAuth2WebhookClientCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PassThroughQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>
    {
        public PassThroughQueueSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator) { }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughQueueSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PassThroughWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>
    {
        public PassThroughWorkerSelectorAttachment(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, System.TimeSpan? expiresAfter = default(System.TimeSpan?)) { }
        public System.TimeSpan? ExpiresAfter { get { throw null; } }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.PassThroughWorkerSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueueAndMatchMode : Azure.Communication.JobRouter.JobMatchingMode, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueAndMatchMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueAndMatchMode>
    {
        public QueueAndMatchMode() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueAndMatchMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueAndMatchMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueAndMatchMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueAndMatchMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueAndMatchMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueAndMatchMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueAndMatchMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueueLengthExceptionTrigger : Azure.Communication.JobRouter.ExceptionTrigger, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>
    {
        public QueueLengthExceptionTrigger(int threshold) { }
        public int Threshold { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueLengthExceptionTrigger System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueLengthExceptionTrigger System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueLengthExceptionTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class QueueSelectorAttachment : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueSelectorAttachment>
    {
        protected QueueSelectorAttachment() { }
        public Azure.Communication.JobRouter.QueueSelectorAttachmentKind Kind { get { throw null; } protected set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QueueSelectorAttachmentKind : System.IEquatable<Azure.Communication.JobRouter.QueueSelectorAttachmentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QueueSelectorAttachmentKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.QueueSelectorAttachmentKind Conditional { get { throw null; } }
        public static Azure.Communication.JobRouter.QueueSelectorAttachmentKind PassThrough { get { throw null; } }
        public static Azure.Communication.JobRouter.QueueSelectorAttachmentKind RuleEngine { get { throw null; } }
        public static Azure.Communication.JobRouter.QueueSelectorAttachmentKind Static { get { throw null; } }
        public static Azure.Communication.JobRouter.QueueSelectorAttachmentKind WeightedAllocation { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.QueueSelectorAttachmentKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.QueueSelectorAttachmentKind left, Azure.Communication.JobRouter.QueueSelectorAttachmentKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.QueueSelectorAttachmentKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.QueueSelectorAttachmentKind left, Azure.Communication.JobRouter.QueueSelectorAttachmentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QueueWeightedAllocation : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueWeightedAllocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueWeightedAllocation>
    {
        public QueueWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterQueueSelector> queueSelectors) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterQueueSelector> QueueSelectors { get { throw null; } }
        public double Weight { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueWeightedAllocation System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueWeightedAllocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.QueueWeightedAllocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.QueueWeightedAllocation System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueWeightedAllocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueWeightedAllocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.QueueWeightedAllocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReclassifyExceptionAction : Azure.Communication.JobRouter.ExceptionAction, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>
    {
        public ReclassifyExceptionAction() { }
        public string ClassificationPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> LabelsToUpsert { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ReclassifyExceptionAction System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ReclassifyExceptionAction System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ReclassifyExceptionAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoundRobinMode : Azure.Communication.JobRouter.DistributionMode, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RoundRobinMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RoundRobinMode>
    {
        public RoundRobinMode() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RoundRobinMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RoundRobinMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RoundRobinMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RoundRobinMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RoundRobinMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RoundRobinMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RoundRobinMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterChannel : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterChannel>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterChannel>
    {
        public RouterChannel(string channelId, int capacityCostPerJob) { }
        public int CapacityCostPerJob { get { throw null; } }
        public string ChannelId { get { throw null; } }
        public int? MaxNumberOfJobs { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterChannel System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterChannel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterChannel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterChannel System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterChannel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterChannel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterChannel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterJob : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJob>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJob>
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJob System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJob System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterJobAssignment : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobAssignment>
    {
        internal RouterJobAssignment() { }
        public System.DateTimeOffset AssignedAt { get { throw null; } }
        public string AssignmentId { get { throw null; } }
        public System.DateTimeOffset? ClosedAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public string WorkerId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobAssignment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobAssignment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterJobNote : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobNote>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobNote>
    {
        public RouterJobNote(string message) { }
        public System.DateTimeOffset? AddedAt { get { throw null; } set { } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobNote System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobNote>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobNote>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobNote System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobNote>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobNote>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobNote>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterJobOffer : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobOffer>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobOffer>
    {
        internal RouterJobOffer() { }
        public int CapacityCost { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? OfferedAt { get { throw null; } }
        public string OfferId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobOffer System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobOffer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobOffer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobOffer System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobOffer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobOffer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobOffer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterJobPositionDetails : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobPositionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobPositionDetails>
    {
        internal RouterJobPositionDetails() { }
        public System.TimeSpan EstimatedWaitTime { get { throw null; } }
        public string JobId { get { throw null; } }
        public int Position { get { throw null; } }
        public string QueueId { get { throw null; } }
        public int QueueLength { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobPositionDetails System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobPositionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterJobPositionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterJobPositionDetails System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobPositionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobPositionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterJobPositionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RouterQueue : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueue>
    {
        public RouterQueue(string queueId) { }
        public string DistributionPolicyId { get { throw null; } set { } }
        public Azure.ETag ETag { get { throw null; } }
        public string ExceptionPolicyId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterQueue System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterQueue System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterQueueSelector : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueueSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueSelector>
    {
        public RouterQueueSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.RouterValue value) { }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
        public Azure.Communication.JobRouter.RouterValue Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterQueueSelector System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueueSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueueSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterQueueSelector System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterQueueStatistics : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueueStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueStatistics>
    {
        internal RouterQueueStatistics() { }
        public System.Collections.Generic.IDictionary<int, System.TimeSpan> EstimatedWaitTimes { get { throw null; } }
        public int Length { get { throw null; } }
        public double? LongestJobWaitTimeMinutes { get { throw null; } }
        public string QueueId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterQueueStatistics System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueueStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterQueueStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterQueueStatistics System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterQueueStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RouterRule : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterRule>
    {
        protected RouterRule() { }
        public Azure.Communication.JobRouter.RouterRuleKind Kind { get { throw null; } protected set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RouterRuleKind : System.IEquatable<Azure.Communication.JobRouter.RouterRuleKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RouterRuleKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.RouterRuleKind DirectMap { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterRuleKind Expression { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterRuleKind Function { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterRuleKind Static { get { throw null; } }
        public static Azure.Communication.JobRouter.RouterRuleKind Webhook { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.RouterRuleKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.RouterRuleKind left, Azure.Communication.JobRouter.RouterRuleKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.RouterRuleKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.RouterRuleKind left, Azure.Communication.JobRouter.RouterRuleKind right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RouterWorker : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorker>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorker>
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
        public int? MaxConcurrentOffers { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterJobOffer> Offers { get { throw null; } }
        public System.Collections.Generic.IList<string> Queues { get { throw null; } }
        public Azure.Communication.JobRouter.RouterWorkerState? State { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Communication.JobRouter.RouterValue> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterWorker System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorker>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorker>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterWorker System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorker>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorker>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorker>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterWorkerAssignment : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorkerAssignment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerAssignment>
    {
        internal RouterWorkerAssignment() { }
        public System.DateTimeOffset AssignedAt { get { throw null; } }
        public string AssignmentId { get { throw null; } }
        public int CapacityCost { get { throw null; } }
        public string JobId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterWorkerAssignment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorkerAssignment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorkerAssignment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterWorkerAssignment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerAssignment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerAssignment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerAssignment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RouterWorkerSelector : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorkerSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerSelector>
    {
        public RouterWorkerSelector(string key, Azure.Communication.JobRouter.LabelOperator labelOperator, Azure.Communication.JobRouter.RouterValue value) { }
        public bool? Expedite { get { throw null; } set { } }
        public System.TimeSpan? ExpiresAfter { get { throw null; } set { } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public string Key { get { throw null; } }
        public Azure.Communication.JobRouter.LabelOperator LabelOperator { get { throw null; } }
        public Azure.Communication.JobRouter.RouterWorkerSelectorStatus? Status { get { throw null; } }
        public Azure.Communication.JobRouter.RouterValue Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterWorkerSelector System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorkerSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RouterWorkerSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RouterWorkerSelector System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RouterWorkerSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RuleEngineQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>
    {
        public RuleEngineQueueSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule) { }
        public Azure.Communication.JobRouter.RouterRule Rule { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineQueueSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RuleEngineWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>
    {
        public RuleEngineWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterRule rule) { }
        public Azure.Communication.JobRouter.RouterRule Rule { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.RuleEngineWorkerSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScheduleAndSuspendMode : Azure.Communication.JobRouter.JobMatchingMode, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>
    {
        public ScheduleAndSuspendMode(System.DateTimeOffset scheduleAt) { }
        public System.DateTimeOffset ScheduleAt { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ScheduleAndSuspendMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ScheduleAndSuspendMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScheduleAndSuspendMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScoringRuleOptions : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ScoringRuleOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScoringRuleOptions>
    {
        public ScoringRuleOptions() { }
        public int? BatchSize { get { throw null; } set { } }
        public bool? DescendingOrder { get { throw null; } set { } }
        public bool? IsBatchScoringEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Communication.JobRouter.ScoringRuleParameterSelector> ScoringParameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ScoringRuleOptions System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ScoringRuleOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.ScoringRuleOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.ScoringRuleOptions System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScoringRuleOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScoringRuleOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.ScoringRuleOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StaticQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>
    {
        public StaticQueueSelectorAttachment(Azure.Communication.JobRouter.RouterQueueSelector queueSelector) { }
        public Azure.Communication.JobRouter.RouterQueueSelector QueueSelector { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.StaticQueueSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.StaticQueueSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticQueueSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StaticRouterRule : Azure.Communication.JobRouter.RouterRule, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticRouterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticRouterRule>
    {
        public StaticRouterRule(Azure.Communication.JobRouter.RouterValue value) { }
        public Azure.Communication.JobRouter.RouterValue Value { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.StaticRouterRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticRouterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticRouterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.StaticRouterRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticRouterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticRouterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticRouterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StaticWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>
    {
        public StaticWorkerSelectorAttachment(Azure.Communication.JobRouter.RouterWorkerSelector workerSelector) { }
        public Azure.Communication.JobRouter.RouterWorkerSelector WorkerSelector { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.StaticWorkerSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.StaticWorkerSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.StaticWorkerSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuspendMode : Azure.Communication.JobRouter.JobMatchingMode, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.SuspendMode>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.SuspendMode>
    {
        public SuspendMode() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.SuspendMode System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.SuspendMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.SuspendMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.SuspendMode System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.SuspendMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.SuspendMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.SuspendMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnassignJobOptions : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.UnassignJobOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobOptions>
    {
        public UnassignJobOptions(string jobId, string assignmentId) { }
        public string AssignmentId { get { throw null; } }
        public string JobId { get { throw null; } }
        public bool? SuspendMatching { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.UnassignJobOptions System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.UnassignJobOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.UnassignJobOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.UnassignJobOptions System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnassignJobResult : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.UnassignJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobResult>
    {
        internal UnassignJobResult() { }
        public string JobId { get { throw null; } }
        public int UnassignmentCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.UnassignJobResult System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.UnassignJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.UnassignJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.UnassignJobResult System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.UnassignJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WaitTimeExceptionTrigger : Azure.Communication.JobRouter.ExceptionTrigger, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>
    {
        public WaitTimeExceptionTrigger(System.TimeSpan threshold) { }
        public System.TimeSpan Threshold { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WaitTimeExceptionTrigger System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WaitTimeExceptionTrigger System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WaitTimeExceptionTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebhookRouterRule : Azure.Communication.JobRouter.RouterRule, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WebhookRouterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WebhookRouterRule>
    {
        public WebhookRouterRule(System.Uri authorizationServerUri, Azure.Communication.JobRouter.OAuth2WebhookClientCredential clientCredential, System.Uri webhookUri) { }
        public System.Uri AuthorizationServerUri { get { throw null; } }
        public Azure.Communication.JobRouter.OAuth2WebhookClientCredential ClientCredential { get { throw null; } }
        public System.Uri WebhookUri { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WebhookRouterRule System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WebhookRouterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WebhookRouterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WebhookRouterRule System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WebhookRouterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WebhookRouterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WebhookRouterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeightedAllocationQueueSelectorAttachment : Azure.Communication.JobRouter.QueueSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>
    {
        public WeightedAllocationQueueSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.QueueWeightedAllocation> allocations) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.QueueWeightedAllocation> Allocations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationQueueSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeightedAllocationWorkerSelectorAttachment : Azure.Communication.JobRouter.WorkerSelectorAttachment, System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>
    {
        public WeightedAllocationWorkerSelectorAttachment(System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.WorkerWeightedAllocation> allocations) { }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.WorkerWeightedAllocation> Allocations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WeightedAllocationWorkerSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class WorkerSelectorAttachment : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>
    {
        protected WorkerSelectorAttachment() { }
        public Azure.Communication.JobRouter.WorkerSelectorAttachmentKind Kind { get { throw null; } protected set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WorkerSelectorAttachment System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WorkerSelectorAttachment System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerSelectorAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkerSelectorAttachmentKind : System.IEquatable<Azure.Communication.JobRouter.WorkerSelectorAttachmentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkerSelectorAttachmentKind(string value) { throw null; }
        public static Azure.Communication.JobRouter.WorkerSelectorAttachmentKind Conditional { get { throw null; } }
        public static Azure.Communication.JobRouter.WorkerSelectorAttachmentKind PassThrough { get { throw null; } }
        public static Azure.Communication.JobRouter.WorkerSelectorAttachmentKind RuleEngine { get { throw null; } }
        public static Azure.Communication.JobRouter.WorkerSelectorAttachmentKind Static { get { throw null; } }
        public static Azure.Communication.JobRouter.WorkerSelectorAttachmentKind WeightedAllocation { get { throw null; } }
        public bool Equals(Azure.Communication.JobRouter.WorkerSelectorAttachmentKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Communication.JobRouter.WorkerSelectorAttachmentKind left, Azure.Communication.JobRouter.WorkerSelectorAttachmentKind right) { throw null; }
        public static implicit operator Azure.Communication.JobRouter.WorkerSelectorAttachmentKind (string value) { throw null; }
        public static bool operator !=(Azure.Communication.JobRouter.WorkerSelectorAttachmentKind left, Azure.Communication.JobRouter.WorkerSelectorAttachmentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkerWeightedAllocation : System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>, System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>
    {
        public WorkerWeightedAllocation(double weight, System.Collections.Generic.IEnumerable<Azure.Communication.JobRouter.RouterWorkerSelector> workerSelectors) { }
        public double Weight { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Communication.JobRouter.RouterWorkerSelector> WorkerSelectors { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WorkerWeightedAllocation System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Communication.JobRouter.WorkerWeightedAllocation System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Communication.JobRouter.WorkerWeightedAllocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
